using System;
using PersonalBlog.Entity.DTOs.Articles;

namespace PersonalBlog.Entity.DTOs.Categories;

public class CategoryDetailDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedTime { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedTime { get; set; }
    public bool IsActive { get; set; }
    public ICollection<ArticleDto> Articles { get; set; }
    public int ArticleCount => Articles.Count;
}
