using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkData.Domain.EntityFramework.EntityFramework.Extensions;
using WorkData.Domain.Permissions.Roles;
using WorkData.Domain.WeiXin;

namespace WorkData.Domain.EntityFramework.Mappings.WeiXin
{
    public class WeiXinUserInfoMap : IEntityTypeConfiguration<WeiXinUserInfo>
    {
        public void Configure(EntityTypeBuilder<WeiXinUserInfo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasMaxLength(128)
                .HasColumnName("Id")
                .IsRequired()
                .HasValueGenerator<AuditValueGenerator>(); //默认实现的

            builder.Property(t => t.City)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("City")
                .IsRequired();

            builder.Property(t => t.Country)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("Country")
                .IsRequired();

            builder.Property(t => t.HeadImgUrl)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("HeadImgUrl")
                .IsRequired();

            builder.Property(t => t.NickName)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("NickName")
                .IsRequired();

            builder.Property(t => t.OpenId)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("OpenId")
                .IsRequired();

            builder.Property(t => t.Province)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("Province")
                .IsRequired();

            builder.Property(t => t.Sex)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("Sex")
                .IsRequired();

            builder.Property(t => t.UnionId)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("UnionId")
                .IsRequired();

            builder.Property(t => t.CreateUserId)
                .HasMaxLength(300)
                .IsRequired(false)
                .HasColumnName("CreateUserId")
                .IsRequired();

            builder.ToTable("WeiXinUserInfo");
        }
    }
}
