using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.ToTable("AspNetUserRoles");
        builder.HasKey(ur => new { ur.UserId, ur.RoleId });

        builder.HasData(
            // Superadmin
            new AppUserRole
            {
                UserId = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                RoleId = Guid.Parse("904c4ca3-6a70-461b-9739-fb4900e36fcf")
            },
            // Admin
            new AppUserRole
            {
                UserId = Guid.Parse("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                RoleId = Guid.Parse("5d10d5f3-9e0b-47c5-b1ea-3551d4f93f9d")
            }
        );
    }
}
