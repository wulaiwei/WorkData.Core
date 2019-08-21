using System.Collections.Generic;

namespace WorkData.EntityFramework.Repositories.Filters.Configs
{
    /// <summary>
    /// 动态拦截器配置
    /// </summary>
    public class DynamicFilterConfig
    {
        public List<string> DynamicFilterList { get; set; }
    }
}