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
                CreatedById = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Category
            {
                Id = Guid.Parse("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                Name = "Hardware",
                CreatedById = Guid.Parse("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
