using System;

namespace PersonalBlog.Entity.DTOs.Articles;

public class ArticleAddDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
    public string? ModifiedBy { get; set; }
    public virtual DateTime? ModifiedTime { get; set; }
    
}
