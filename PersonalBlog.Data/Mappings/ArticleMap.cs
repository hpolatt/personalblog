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
                Content = "Pellentesque augue dolor, dapibus at ante at, venenatis pharetra diam. Ut in ipsum at sapien laoreet venenatis ac in ipsum. Vivamus id ligula dapibus, mattis ex eu, egestas ex. Etiam vel metus a felis ornare feugiat. Pellentesque nulla purus, volutpat at velit eget, aliquet vulputate odio. Mauris facilisis ligula massa, ac ullamcorper diam fermentum et. Sed pulvinar nulla sapien, ac finibus sem aliquet eu. Vivamus fermentum at risus eu mattis. Cras vitae rhoncus arcu, eu rhoncus elit. Nulla sem augue, lobortis id luctus ac, placerat quis libero. Sed laoreet lorem quis nulla scelerisque, in rhoncus ligula lobortis. Aliquam auctor lectus enim, et mattis elit iaculis quis. Morbi quam sem, sodales at vestibulum ac, interdum et lectus. Aliquam efficitur est accumsan euismod aliquet. Duis quam enim, pellentesque in pellentesque non, eleifend egestas lacus. Vivamus scelerisque lectus quis magna fermentum pharetra.",
                ViewCount = 5,
                CategoryId = Guid.Parse("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f") ,
                ImageId = Guid.Parse("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                CreatedById = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Second Article",
                // Lorem ipsum paragraph content of the second article.
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi volutpat consequat dui quis volutpat. Nullam nec pretium neque. Donec eleifend nec leo in blandit. Cras tristique sapien vitae aliquet semper. Aenean sed leo vitae quam ultrices pellentesque sed nec nulla. Nam in nisi ultrices, porta urna nec, facilisis mi. Cras quis felis vitae neque tristique semper vel venenatis libero. Suspendisse lobortis orci ac ullamcorper fringilla. Cras congue mi non semper ultrices. Nunc gravida dui et justo tempus, eu venenatis erat viverra. Nullam sagittis molestie mauris vel rhoncus." ,
                ViewCount = 10,
                CategoryId = Guid.Parse("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                ImageId = Guid.Parse("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                CreatedById = Guid.Parse("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                CreatedBy = "admin",
                CreatedTime = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            }
        );
    }
}
