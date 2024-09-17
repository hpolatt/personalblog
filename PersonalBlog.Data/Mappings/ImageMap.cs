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
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Image
            {
                Id = Guid.Parse("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                FileName = "Hardware Image",
                FileType = "image/jpeg",
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
