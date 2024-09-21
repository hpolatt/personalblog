using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Extensions;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class CategoryService : ICategoryService
{
    public readonly IUnitofWork unitofWork;
    private readonly IMapper mapper;
    private ClaimsPrincipal user;

    public CategoryService(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        this.unitofWork = unitofWork;
        this.mapper = mapper;
        user = httpContextAccessor.HttpContext.User;
    }

    public async Task CreateCategoryAsync(CategoryAddDto categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await unitofWork.GetRepository<Category>().AddAsync(category, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesNonDeletedAsync()
    {
        var categories = await unitofWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<IEnumerable<CategoryDetailDto>> GetAllCategoryListNonDeletedAsync()
    {
        var categories = await unitofWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted, x => x.Articles);
        return mapper.Map<IEnumerable<CategoryDetailDto>>(categories);
    }

    public async Task<CategoryUpdateDto> GetCategoryByGuidAsync(Guid categoryId)
    {
        var category = await unitofWork.GetRepository<Category>().GetByGuidAsync(categoryId);
        return mapper.Map<CategoryUpdateDto>(category);
    }

    public async Task<CategoryDetailDto> GetCategoryDetailByGuidAsync(Guid categoryId)
    {
        var category = await unitofWork.GetRepository<Category>().GetAsync(x => x.Id == categoryId, x => x.Articles);
        return mapper.Map<CategoryDetailDto>(category);
    }

    public async Task<bool> UpdateCategoryAsync(CategoryUpdateDto categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await unitofWork.GetRepository<Category>().UpdateAsync(category, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.SaveChangesAsync();
        return true;
    }

    public async Task<string> SoftDeleteCategoryAsync(Guid categoryId)
    {
        var category = await unitofWork.GetRepository<Category>().GetByGuidAsync(categoryId);
        await unitofWork.GetRepository<Category>().SoftDeleteAsync(category, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.SaveChangesAsync();
        return category.Name;
    }
}
