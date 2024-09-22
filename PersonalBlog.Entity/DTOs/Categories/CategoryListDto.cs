using System;

namespace PersonalBlog.Entity.DTOs.Categories;

public class CategoryListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ArticleCount { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime ModifiedTime { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedTime { get; set; }

    public bool IsDeleted { get; set; }


}
