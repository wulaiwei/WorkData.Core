// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：GuidValueGenerator.cs
// 创建标识：吴来伟 2018-06-07 10:58
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 10:58
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace WorkData.Domain.EntityFramework.EntityFramework.Extensions
{
    public class AuditValueGenerator : ValueGenerator<string>
    {
        public AuditValueGenerator()
        {
            GeneratesTemporaryValues = false;
        }

        /// <summary>
        /// 下一个值
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public override string Next(EntityEntry entry)
        {
            return Guid.NewGuid().ToString();
        }

        public override bool GeneratesTemporaryValues { get; }
    }
}