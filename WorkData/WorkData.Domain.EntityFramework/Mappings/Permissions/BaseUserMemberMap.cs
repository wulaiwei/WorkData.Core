using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkData.Domain.EntityFramework.EntityFramework.Extensions;
using WorkData.Domain.Permissions.Users;

namespace WorkData.Domain.EntityFramework.Mappings.Permissions
{
    public class BaseUserMemberMap : IEntityTypeConfiguration<BaseUserMember>
    {
        public void Configure(EntityTypeBuilder<BaseUserMember> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(128)
                .HasColumnName("Id")
                .IsRequired()
                .HasValueGenerator<AuditValueGenerator>(); //默认实现的

            builder.Property(t => t.BaseUserId)
                .HasMaxLength(128)
                .HasColumnName("BaseUserId")
                .IsRequired();

            builder.HasOne(u => u.BaseUser)
                .WithOne(g => g.BaseUserMember)
                .HasForeignKey<BaseUserMember>(x => x.BaseUserId);

            builder.ToTable("BaseUserMember");
        }
    }
}