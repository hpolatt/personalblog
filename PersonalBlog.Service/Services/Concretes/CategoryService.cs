using System;
using AutoMapper;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class CategoryService : ICategoryService
{
    public readonly IUnitofWork unitofWork;
    private readonly IMapper mapper;

    public CategoryService(IUnitofWork unitofWork, IMapper mapper)
    {
        this.unitofWork = unitofWork;
        this.mapper = mapper;
    }
    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await unitofWork.GetRepository<Category>().GetAllAsync();
        return mapper.Map<List<CategoryDto>>(categories);
    }
}
