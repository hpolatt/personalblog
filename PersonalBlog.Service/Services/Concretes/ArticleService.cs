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

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {
        var CreatedById = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513");

        var article = new Article
        {
            Title = articleAddDto.Title,
            Content = articleAddDto.Content,
            CategoryId = articleAddDto.CategoryId,
            CreatedById = CreatedById,
            ModifiedById = CreatedById,
            ModifiedTime = articleAddDto.ModifiedTime
        };


        await unitofWork.GetRepository<Article>().AddAsync(article);
        await unitofWork.SaveChangesAsync();
        return ;
    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {   
        var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = mapper.Map<List<ArticleDto>>(articles);


        return map;
    }

    public async Task<ArticleDto> GetArticleByGuidAsync(Guid articleId)
    {
        var article =  await unitofWork.GetRepository<Article>().GetAsync(x=> !x.IsDeleted && x.Id == articleId, x => x.Category);
        return mapper.Map<ArticleDto>(article);
    }

    public async Task<bool> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var article =  await unitofWork.GetRepository<Article>().GetAsync(x=> !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);

        mapper.Map(articleUpdateDto, article);
        
        article.ModifiedTime = DateTime.Now;
        article.ModifiedById = Guid.Parse("8df24b15-63fd-4faf-9020-d8ce712a0513");
        
        await unitofWork.GetRepository<Article>().UpdateAsync(article);
        await unitofWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> SoftDeleteArticleAsync(Guid articleId) {
        var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);
        article.IsDeleted = true;
        article.DeletedTime = DateTime.Now;
        await unitofWork.GetRepository<Article>().UpdateAsync(article);
        await unitofWork.SaveChangesAsync();
        return true;
    }
}
