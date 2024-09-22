using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class ImageMap : IEntityTypeConfiguration<Image>
{

    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder
        .Property(x => x.FileName)
        .HasMaxLength(100)
        .IsRequired();

        builder
        .Property(x => x.FileType)
        .HasMaxLength(20)
        .IsRequired();

        builder.HasData(
            new Image
            {
                Id = Guid.Parse("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                FileName = "Software Image",
                FileType = "image/jpeg",
                CreatedById = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                CreatedBy = "superadmin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                FileName = "Hardware Image",
                FileType = "image/jpeg",
                CreatedById = Guid.Parse("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("2452dfe7-24e8-4a40-b456-b2b3ed699b3b"),
                FileName = "SuperAdmin_Profile",
                FileType = "image/jpeg",
                CreatedById = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                CreatedBy = "superadmin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("b5aa4b7b-431c-46f3-bf7f-cec3b4569b37"),
                FileName = "Admin_Profile",
                FileType = "image/jpeg",
                CreatedById = Guid.Parse("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
