using AutoMapper;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class ArticleService : IArticleService
{
    public readonly IUnitofWork unitofWork;
    private readonly IMapper mapper;

    public ArticleService(IUnitofWork unitofWork, IMapper mapper)
    {
        this.unitofWork = unitofWork;
        this.mapper = mapper;
    }

    public async Task<List<ArticleDto>> GetAllArticlesAsync()
    {   
        var articles = await unitofWork.GetRepository<Article>().GetAllAsync();
        return mapper.Map<List<ArticleDto>>(articles);
    }
}
