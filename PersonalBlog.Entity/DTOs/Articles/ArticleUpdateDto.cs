using System;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.DTOs.Images;
using PersonalBlog.Entity.Entities;

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
    public IEnumerable<CategoryDto> Categories { get; set; }
    
    public ImageDto? Image { get; set; }
    public IFormFile? ImageFile { get; set; }

}
