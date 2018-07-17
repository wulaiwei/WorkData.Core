// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：BaseRoleMap.cs
// 创建标识：吴来伟 2018-06-07 11:08
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 11:08
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkData.Domain.EntityFramework.EntityFramework.Extensions;
using WorkData.Domain.Permissions.Roles;

namespace WorkData.Domain.EntityFramework.Mappings.Permissions
{
    public class BaseRoleMap : IEntityTypeConfiguration<BaseRole>
    {
        public void Configure(EntityTypeBuilder<BaseRole> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(128)
                .HasColumnName("Id")
                .IsRequired()
                .HasValueGenerator<AuditValueGenerator>(); //默认实现的

            builder.ToTable("BaseRole");
        }
    }
}