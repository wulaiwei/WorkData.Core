using System;

namespace WorkData.EntityFramework.Repositories.Filters.Configs
{
    public class DynamicFilterAttribute: Attribute
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

    }
}