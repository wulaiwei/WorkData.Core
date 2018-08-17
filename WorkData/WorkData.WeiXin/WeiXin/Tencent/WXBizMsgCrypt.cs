#region 导入名称空间

using LightWork.WeiXin;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using WorkData.WeiXin.WeiXin;

//using System.Web;

#endregion 导入名称空间

//-40001 ： 签名验证错误
//-40002 :  xml解析失败
//-40003 :  sha加密生成签名失败
//-40004 :  AESKey 非法
//-40005 :  corpid 校验错误
//-40006 :  AES 加密失败
//-40007 ： AES 解密失败
//-40008 ： 解密后得到的buffer非法
//-40009 :  base64加密异常
//-40010 :  base64解密异常

// ReSharper disable once CheckNamespace
namespace Tencent
{
    // ReSharper disable once InconsistentNaming
    internal class WXBizMsgCrypt
    {
        private readonly string _mSCorpId;
        private readonly string _mSEncodingAesKey;
        private readonly string _mSToken;

        //构造函数
        // @param sToken: 公众平台上，开发者设置的Token
        // @param sEncodingAesKey: 公众平台上，开发者设置的EncodingAESKey
        // @param sCorpId: 企业号的CorpID
        public WXBizMsgCrypt(string sToken, string sEncodingAesKey, string sCorpId)
        {
            _mSToken = sToken;
            _mSCorpId = sCorpId;
            _mSEncodingAesKey = sEncodingAesKey;
        }

        //验证URL
        // @param sMsgSignature: 签名串，对应URL参数的msg_signature
        // @param sTimeStamp: 时间戳，对应URL参数的timestamp
        // @param sNonce: 随机串，对应URL参数的nonce
        // @param sEchoStr: 随机串，对应URL参数的echostr
        // @param sReplyEchoStr: 解密之后的echostr，当return返回0时有效
        // @return：成功0，失败返回对应的错误码
        public ReturnCode VerifyUrl(string sMsgSignature, string sTimeStamp, string sNonce, string sEchoStr, ref string sReplyEchoStr)
        {
            sReplyEchoStr = "";
            if (_mSEncodingAesKey.Length != 43)
            {
                return ReturnCode.C40004Negative; //(int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_IllegalAesKey;
            }
            var returnCode = VerifySignature(_mSToken, sTimeStamp, sNonce, sEchoStr, sMsgSignature);
            if (returnCode != ReturnCode.C0)
            {
                return returnCode;
            }

            var cpid = "";
            try
            {
                sReplyEchoStr = Cryptography.AES_decrypt(sEchoStr, _mSEncodingAesKey, ref cpid); //_mSCorpId);
            }
            catch (System.Exception)
            {
                sReplyEchoStr = "";
                return ReturnCode.C40007Negative;// (int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_DecryptAES_Error;
            }
            if (cpid != _mSCorpId)
            {
                sReplyEchoStr = "";
                return ReturnCode.C40005Negative; //(int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_ValidateCorpid_Error;
            }
            return 0;
        }

        // 检验消息的真实性，并且获取解密后的明文
        // @param sMsgSignature: 签名串，对应URL参数的msg_signature
        // @param sTimeStamp: 时间戳，对应URL参数的timestamp
        // @param sNonce: 随机串，对应URL参数的nonce
        // @param sPostData: 密文，对应POST请求的数据
        // @param sMsg: 解密后的原文，当return返回0时有效
        // @return: 成功0，失败返回对应的错误码
        public ReturnCode DecryptMsg(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, ref string sMsg)
        {
            if (_mSEncodingAesKey.Length != 43)
            {
                return ReturnCode.C40004Negative;  // (int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_IllegalAesKey;
            }
            var doc = new XmlDocument();
            XmlNode root;
            string sEncryptMsg;
            try
            {
                doc.LoadXml(sPostData);
                root = doc.FirstChild;
                sEncryptMsg = root["Encrypt"].InnerText;
            }
            catch (System.Exception)
            {
                return ReturnCode.C40002Negative;// (int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_ParseXml_Error;
            }
            //verify signature
            var returnCode = VerifySignature(_mSToken, sTimeStamp, sNonce, sEncryptMsg, sMsgSignature);
            if (returnCode != ReturnCode.C0)
            {
                return returnCode;
            }

            //decrypt
            var cpid = "";
            try
            {
                sMsg = Cryptography.AES_decrypt(sEncryptMsg, _mSEncodingAesKey, ref cpid);
            }
            catch (FormatException)
            {
                sMsg = "";
                return ReturnCode.C40010Negative;
            }
            catch (System.Exception)
            {
                sMsg = "";
                return ReturnCode.C40007Negative;
            }
            return cpid != _mSCorpId ? ReturnCode.C40005Negative : ReturnCode.C0;
        }

        //将企业号回复用户的消息加密打包
        // @param sReplyMsg: 企业号待回复用户的消息，xml格式的字符串
        // @param sTimeStamp: 时间戳，可以自己生成，也可以用URL参数的timestamp
        // @param sNonce: 随机串，可以自己生成，也可以用URL参数的nonce
        // @param sEncryptMsg: 加密后的可以直接回复用户的密文，包括msg_signature, timestamp, nonce, encrypt的xml格式的字符串,
        //						当return返回0时有效
        // return：成功0，失败返回对应的错误码
        public ReturnCode EncryptMsg(string sReplyMsg, string sTimeStamp, string sNonce, ref string sEncryptMsg)
        {
            if (_mSEncodingAesKey.Length != 43)
            {
                return ReturnCode.C40004Negative;// (int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_IllegalAesKey;
            }
            var raw = "";
            try
            {
                raw = Cryptography.AES_encrypt(sReplyMsg, _mSEncodingAesKey, _mSCorpId);
            }
            catch (System.Exception)
            {
                return ReturnCode.C40006Negative;// (int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_EncryptAES_Error;
            }
            var MsgSigature = "";
            var returnCode = GenarateSinature(_mSToken, sTimeStamp, sNonce, raw, ref MsgSigature);
            if (returnCode != ReturnCode.C0)
            {
                return returnCode;
            }
            sEncryptMsg = "";

            var EncryptLabelHead = "<Encrypt><![CDATA[";
            var EncryptLabelTail = "]]></Encrypt>";
            var MsgSigLabelHead = "<MsgSignature><![CDATA[";
            var MsgSigLabelTail = "]]></MsgSignature>";
            var TimeStampLabelHead = "<TimeStamp><![CDATA[";
            var TimeStampLabelTail = "]]></TimeStamp>";
            var NonceLabelHead = "<Nonce><![CDATA[";
            var NonceLabelTail = "]]></Nonce>";
            sEncryptMsg = sEncryptMsg + "<xml>" + EncryptLabelHead + raw + EncryptLabelTail;
            sEncryptMsg = sEncryptMsg + MsgSigLabelHead + MsgSigature + MsgSigLabelTail;
            sEncryptMsg = sEncryptMsg + TimeStampLabelHead + sTimeStamp + TimeStampLabelTail;
            sEncryptMsg = sEncryptMsg + NonceLabelHead + sNonce + NonceLabelTail;
            sEncryptMsg += "</xml>";

            return ReturnCode.C0;
        }

        //Verify Signature
        private static ReturnCode VerifySignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt,
            string sSigture)
        {
            var hash = "";
            var returnCode = GenarateSinature(sToken, sTimeStamp, sNonce, sMsgEncrypt, ref hash);
            if (returnCode != ReturnCode.C0)
            {
                return returnCode;
            }

            return hash == sSigture ? ReturnCode.C0 : ReturnCode.C40001Negative;
        }

        public static ReturnCode GenarateSinature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt,
            ref string sMsgSignature)
        {
            var al = new ArrayList();
            al.Add(sToken);
            al.Add(sTimeStamp);
            al.Add(sNonce);
            al.Add(sMsgEncrypt);
            al.Sort(new DictionarySort());
            var raw = "";
            for (var i = 0; i < al.Count; ++i)
            {
                raw += al[i];
            }

            SHA1 sha;
            ASCIIEncoding enc;
            var hash = "";
            try
            {
                sha = new SHA1CryptoServiceProvider();
                enc = new ASCIIEncoding();
                var dataToHash = enc.GetBytes(raw);
                var dataHashed = sha.ComputeHash(dataToHash);
                hash = BitConverter.ToString(dataHashed).Replace("-", "");
                hash = hash.ToLower();
            }
            catch (System.Exception)
            {
                return ReturnCode.C40003Negative;
                // return (int) WXBizMsgCryptErrorCode.WXBizMsgCrypt_ComputeSignature_Error;
            }
            sMsgSignature = hash;
            return ReturnCode.C0;
        }

        public class DictionarySort : IComparer
        {
            public int Compare(object oLeft, object oRight)
            {
                var sLeft = oLeft as string;
                var sRight = oRight as string;
                var iLeftLength = sLeft.Length;
                var iRightLength = sRight.Length;
                var index = 0;
                while (index < iLeftLength && index < iRightLength)
                {
                    if (sLeft[index] < sRight[index])
                        return -1;
                    if (sLeft[index] > sRight[index])
                        return 1;
                    index++;
                }
                return iLeftLength - iRightLength;
            }
        }
    }
}