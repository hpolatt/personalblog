using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Data.Mappings;

public class ArticleMap : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
        .Property(x=> x.Title)
        .HasMaxLength(150)
        .IsRequired();

        builder
        .Property(x => x.Content)
        .IsRequired();
        builder.HasData(
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "First Article",
                Content = "This is the first article content of the blog site.",
                ViewCount = 5,
                CategoryId = Guid.Parse("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f") ,
                ImageId = Guid.Parse("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Second Article",
                Content = "This is the second article content of the blog site.",
                ViewCount = 10,
                CategoryId = Guid.Parse("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                ImageId = Guid.Parse("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
