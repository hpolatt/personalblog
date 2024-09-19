using System;
using PersonalBlog.Entity.DTOs.Categories;

namespace PersonalBlog.Entity.DTOs.Articles;

public class ArticleDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public CategoryDto Category { get; set; }
    public string CreatedBy { get; set; }
    public virtual DateTime CreatedTime { get; set; }
    public bool IsDeleted { get; set; }
}

