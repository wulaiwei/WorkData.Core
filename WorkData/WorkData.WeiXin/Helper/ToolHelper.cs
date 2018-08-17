// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：Jwell.Wechat.Common 
// 文件名：ToolHelper.cs
// 创建标识：吴来伟 2017-04-14
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Text.RegularExpressions;
using Senparc.Weixin.MP.Containers;

namespace WorkData.WeiXin.Helper
{
    /// <summary>
    /// 工具帮助类
    /// </summary>
    public class ToolHelper
    {
        #region 获取枚举描述
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            var str = enumValue.ToString();
            var field = enumValue.GetType().GetField(str);
            var objs = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (objs.Length == 0) return str;
            var da = (System.ComponentModel.DescriptionAttribute)objs[0];
            return da.Description;
        }
        #endregion

        #region AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken(string appId, string corpSecret)
        {
           if (CacheHelper.IsExist("AccessToken"))
               return CacheHelper.GetCache("AccessToken") as string;
           var info = AccessTokenContainer.TryGetAccessToken
               (
                   appId,
                   corpSecret
               );
           CacheHelper.Insert("AccessToken", info, 120);
           return info;
        }

        #endregion

        #region 属性赋值
        /// <summary>
        /// 属性赋值
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
        {
            var child = new TChild();
            var parentType = typeof(TParent);
            var childType = typeof(TParent);
            var properties = parentType.GetProperties();
            foreach (var propertie in properties)
            {
                //循环遍历属性 
                if (propertie.CanRead && propertie.CanWrite)
                {
                    //进行属性拷贝
                    propertie.SetValue(child, propertie.GetValue(parent, null), null);
                }

            }
            return child;
        } 
        #endregion
    }
}