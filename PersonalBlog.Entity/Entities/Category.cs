using PersonalBlog.Core.Entities;

namespace PersonalBlog.Entity.Entities;

public class Category : EntityBase, IEntityBase
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Article> Articles { get; set; }

}
