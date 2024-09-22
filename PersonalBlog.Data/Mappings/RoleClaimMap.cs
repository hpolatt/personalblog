using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class RoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
{
    public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
    {
        builder.ToTable("AspNetRoleClaims");
        builder.HasKey(rc => rc.Id);
        builder.Property(rc => rc.Id).ValueGeneratedOnAdd();
        builder.Property(rc => rc.ClaimType).HasMaxLength(50);
        builder.Property(rc => rc.ClaimValue).HasMaxLength(50);
    }
}