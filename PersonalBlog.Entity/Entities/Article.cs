using PersonalBlog.Core.Entities;

namespace PersonalBlog.Entity.Entities;

public class Article : EntityBase, IEntityBase
{
  
    public Article()
    {
    }

    public Article(string title, string content, Guid categoryId, Guid? imageId) {
        Title = title;
        Content = content;
        CategoryId = categoryId;
        ImageId = imageId;
    }
    public Article(string title, string content, Guid categoryId, Guid? imageId, Guid createdById, string createdBy) {
        Title = title;
        Content = content;
        CategoryId = categoryId;
        ImageId = imageId;
        CreatedById = createdById;
        CreatedBy = createdBy;
    }
    
    public string Title { get; set; }
    public string Content { get; set; }
    public int ViewCount { get; set; } = 0;
    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

    public Guid? ImageId { get; set; }
    public Image Image { get; set; }
}
