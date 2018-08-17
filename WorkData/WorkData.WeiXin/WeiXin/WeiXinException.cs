using System;
using LightWork.WeiXin;

namespace WorkData.WeiXin.WeiXin
{
    public class WeiXinException : System.Exception
    {
        public ReturnCode WeiXinReturnCode { get; }

        private static ReturnCode ParseCode(int returnCode)
        {
            var returnCodeEnum = (ReturnCode)Enum.ToObject(typeof(ReturnCode), returnCode);

            return returnCodeEnum;
        }

        public WeiXinException(string message) : base(message)
        {
        }

        public WeiXinException(int returnCode) : this(ParseCode(returnCode))
        {
        }

        public WeiXinException(ReturnCode returnCode) : base(returnCode.GetDescription())
        {
            this.WeiXinReturnCode = returnCode;
        }
    }
}