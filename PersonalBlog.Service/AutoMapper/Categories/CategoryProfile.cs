using AutoMapper;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.AutoMapper.Categories;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryAddDto, Category>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<Category, CategoryDetailDto>();
        CreateMap<Category, CategoryDto>();

    }
}
