using System;
using PersonalBlog.Entity.DTOs.Categories;

namespace PersonalBlog.Service.Services.Abstractions;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesNonDeletedAsync();
}
