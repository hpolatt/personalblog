using System;
using PersonalBlog.Entity.DTOs.Categories;

namespace PersonalBlog.Entity.DTOs.Articles;

public class ArticleUpdateDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
    public string? ModifiedBy { get; set; }
    public virtual DateTime? ModifiedTime { get; set; }
    public virtual bool IsActive { get; set; } = true;
    public IList<CategoryDto> Categories { get; set; }

}
