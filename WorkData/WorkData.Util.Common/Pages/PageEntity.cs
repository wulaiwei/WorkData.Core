// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Util.Common
// 文件名：PageEntity.cs
// 创建标识：吴来伟 2018-05-02 10:12
// 创建描述：
//  
// 修改标识：吴来伟2018-05-02 10:12
// 修改描述：
//  ------------------------------------------------------------------------------


namespace WorkData.Util.Common.Pages
{
    /// <summary>
    /// 分页类型
    /// </summary>
    public class PageEntity
    {
        /// <summary>
        ///     每页行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     总记录数
        /// </summary>
        public int Records { get; set; }

        /// <summary>
        ///     总页数
        /// </summary>
        public int Total
        {
            get
            {
                if (Records > 0)
                    return Records % PageSize == 0 ? Records / PageSize : Records / PageSize + 1;

                return 0;
            }
        }


        /// <summary>
        ///     排序列
        /// </summary>
        public string Sidx { get; set; }

        /// <summary>
        ///     排序类型
        /// </summary>
        public string Sord { get; set; }
    }
}