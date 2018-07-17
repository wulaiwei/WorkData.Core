// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Domain.EntityFramework
// 文件名：UserRoleMap.cs
// 创建标识：吴来伟 2018-06-07 14:42
// 创建描述：
//
// 修改标识：吴来伟2018-06-07 14:42
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkData.Domain.Permissions.UserRoles;

namespace WorkData.Domain.EntityFramework.Mappings.Permissions
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(t => new
            {
                t.BaseRoleId,
                t.BaseUserId
            });

            builder.Property(t => t.BaseRoleId)
                .HasMaxLength(128)
                .HasColumnName("BaseRoleId")
                .IsRequired();

            builder.Property(t => t.BaseUserId)
                .HasMaxLength(128)
                .HasColumnName("BaseUserId")
                .IsRequired();

            builder.HasOne(t => t.BaseUser)
            .WithMany(t => t.UserRoles)
                .HasForeignKey(t => t.BaseUserId);

            builder.HasOne(t => t.BaseRole)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(t => t.BaseRoleId);
        }
    }
}