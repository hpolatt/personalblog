using PersonalBlog.Core.Entities;

namespace PersonalBlog.Entity.Entities;

public class Category : EntityBase, IEntityBase
{
    public Category()
    {
    }

    public Category(string name, string? description) 
    {
        Name = name;
        Description = description;
    }

    public Category(string name, string? description, Guid createdById, string createdBy) 
    {
        Name = name;
        Description = description;
        CreatedById = createdById;
        CreatedBy = createdBy;
    }

    public Category(string name, string? description, Guid createdById, string createdBy, Guid categoryId) 
    {
        Name = name;
        Description = description;
        CreatedById = createdById;
        CreatedBy = createdBy;
        Id = categoryId;
    }
    
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Article> Articles { get; set; }

}
