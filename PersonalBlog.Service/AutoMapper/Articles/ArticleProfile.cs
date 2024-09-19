using AutoMapper;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.AutoMapper.Articles;

public class ArticleProfile : Profile
{    
    public ArticleProfile()
    {
        CreateMap<ArticleAddDto, Article>().ReverseMap();
        CreateMap<ArticleUpdateDto, Article>().ReverseMap();
         CreateMap<ArticleUpdateDto, ArticleDto>().ReverseMap();
        CreateMap<ArticleDto, Article>().ReverseMap();
    }
}
