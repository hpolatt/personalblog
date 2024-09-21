using System;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.DTOs.Images;

namespace PersonalBlog.Entity.DTOs.Articles;

public class ArticleDetailDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public CategoryDto Category { get; set; }
    public ImageDto? Image { get; set; }
}
