/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc
    
    文件名：CustomMessageContext.cs
    文件功能描述：微信消息上下文
    
    
    创建标识：Senparc - 20150312
----------------------------------------------------------------*/

using Senparc.Weixin.Context;
using Senparc.Weixin.MP.Entities;

namespace WorkData.WeiXin.CustomMessageHandlers
{
    public class CustomMessageContext : MessageContext<IRequestMessageBase, IResponseMessageBase>
    {
        public CustomMessageContext()
        {
            base.MessageContextRemoved += CustomMessageContext_MessageContextRemoved;
        }

        /// <summary>
        /// 当上下文过期，被移除时触发的时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CustomMessageContext_MessageContextRemoved(object sender, Senparc.Weixin.Context.WeixinContextRemovedEventArgs<IRequestMessageBase,IResponseMessageBase> e)
        {
            var messageContext = e.MessageContext as CustomMessageContext;
            if (messageContext == null)
            {
                return;//如果是正常的调用，messageContext不会为null
            }

        }
    }
}
