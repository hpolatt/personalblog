using System;
using PersonalBlog.Entity.DTOs.Categories;

namespace PersonalBlog.Service.Services.Abstractions;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesNonDeletedAsync();
    Task<IEnumerable<CategoryDetailDto>> GetAllCategoryListNonDeletedAsync();
    Task<CategoryUpdateDto> GetCategoryByGuidAsync(Guid categoryId);
    Task<CategoryDetailDto> GetCategoryDetailByGuidAsync(Guid categoryId);
    Task CreateCategoryAsync(CategoryAddDto categoryDto);
    Task<bool> UpdateCategoryAsync(CategoryUpdateDto categoryDto);
    Task<string> SoftDeleteCategoryAsync(Guid categoryId);
}
