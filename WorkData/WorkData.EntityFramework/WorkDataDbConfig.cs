// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：WorkDataDbContextConfig.cs
// 创建标识：吴来伟 2018-06-22 14:40
// 创建描述：
//
// 修改标识：吴来伟2018-06-22 14:40
// 修改描述：
//  ------------------------------------------------------------------------------

namespace WorkData.EntityFramework
{
    public class WorkDataDbConfig
    {
        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// db类型
        /// </summary>
        public WorkDataDbType WorkDataDbType { get; set; }
    }

    /// <summary>
    /// WorkDataDbType
    /// </summary>
    public enum WorkDataDbType
    {
        SqlServer = 0,
        MySql = 1,
        PgSql = 2
    }
}