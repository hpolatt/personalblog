using AutoMapper;
using PersonalBlog.Entity.DTOs.Images;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.AutoMapper.Images;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<ImageDto, Image>().ReverseMap();
        CreateMap<ImageAddDto, Image>().ReverseMap();
        CreateMap<ImageUpdateDto, Image>().ReverseMap();
    }
}
