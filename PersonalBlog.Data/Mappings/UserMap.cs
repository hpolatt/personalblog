using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        // Primary key
        builder.HasKey(u => u.Id);

        // Indexes for "normalized" username and email, to allow efficient lookups
        builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
        builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

        // Maps to the AspNetUsers table
        builder.ToTable("AspNetUsers");

        // A concurrency token for use with the optimistic concurrency checking
        builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

        // Limit the size of columns to use efficient database types
        builder.Property(u => u.UserName).HasMaxLength(256);
        builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
        builder.Property(u => u.Email).HasMaxLength(256);
        builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

        // The relationships between User and other entity types
        // Note that these relationships are configured with no navigation properties

        // Each User can have many UserClaims
        builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

        // Each User can have many UserLogins
        builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

        // Each User can have many UserTokens
        builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

        // Each User can have many entries in the UserRole join table
        builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

        builder.HasData(
            // Superadmin
            new AppUser
            {
                Id = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                FirstName = "Huseyin",
                LastName = "Polat",
                UserName = "superadmin@hpolat.com",
                NormalizedUserName = "SUPERADMIN@HPOLAT.COM",
                Email = "superadmin@hpolat.com",
                NormalizedEmail = "SUPERADMIN@HPOLAT.COM",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = CreatePasswordHash(new AppUser(), "Superadmin123."),
                ImageId = Guid.Parse("2452dfe7-24e8-4a40-b456-b2b3ed699b3b")
            },
            // Admin
            new AppUser
            {
                Id = Guid.Parse("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                FirstName = "Huseyin",
                LastName = "Polat",
                UserName = "admin@hpolat.com",
                NormalizedUserName = "ADMIN@HPOLAT.COM",
                Email = "admin@hpolat.com",
                NormalizedEmail = "ADMIN@HPOLAT.COM",
                EmailConfirmed = true,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = CreatePasswordHash(new AppUser(), "Admin123."),
                ImageId = Guid.Parse("b5aa4b7b-431c-46f3-bf7f-cec3b4569b37")
            }
            );

    }

    private string CreatePasswordHash(AppUser user, string password)
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        return passwordHasher.HashPassword(user, password);
    }
}
