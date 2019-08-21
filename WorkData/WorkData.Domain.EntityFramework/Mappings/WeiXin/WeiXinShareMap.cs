using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkData.Domain.EntityFramework.EntityFramework.Extensions;
using WorkData.Domain.WeiXin;

namespace WorkData.Domain.EntityFramework.Mappings.WeiXin
{
    public class WeiXinShareMap : IEntityTypeConfiguration<WeiXinShare>
    {
        public void Configure(EntityTypeBuilder<WeiXinShare> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(128)
                .HasColumnName("Id")
                .IsRequired()
                .HasValueGenerator<AuditValueGenerator>(); //默认实现的

            builder.Property(t => t.LikeOpenId)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("LikeOpenId")
                .IsRequired();

            builder.Property(t => t.LikeOpenNick)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("LikeOpenNick")
                .IsRequired();

            builder.Property(t => t.ShareOpenId)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("ShareOpenId")
                .IsRequired();

            builder.Property(t => t.ShareOpenNick)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("ShareOpenNick")
                .IsRequired();

            builder.Property(t => t.CreateUserId)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("CreateUserId")
                .IsRequired();

            builder.ToTable("WeiXinShare");
        }
    }
}