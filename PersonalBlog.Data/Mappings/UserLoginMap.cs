using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class UserLoginMap : IEntityTypeConfiguration<AppUserLogin>
{
    public void Configure(EntityTypeBuilder<AppUserLogin> builder)
    {
        builder.ToTable("AspNetUserLogins");
        builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });
        builder.Property(x => x.LoginProvider).HasMaxLength(128);
        builder.Property(x => x.ProviderKey).HasMaxLength(128);
        builder.Property(x => x.ProviderDisplayName).HasMaxLength(128);
        builder.Property(x => x.UserId).IsRequired();
    }
}
