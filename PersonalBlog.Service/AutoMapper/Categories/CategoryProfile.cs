using AutoMapper;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.AutoMapper.Categories;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryAddDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        CreateMap<CategoryDto, Category>().ReverseMap();
    }
}
