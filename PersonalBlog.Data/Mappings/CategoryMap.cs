using Microsoft.EntityFrameworkCore;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        builder
        .Property(x => x.Name)
        .HasMaxLength(50)
        .IsRequired();


        builder.HasData(
            new Category
            {
                Id = Guid.Parse("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                Name = "Software",
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                Name = "Hardware",
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
