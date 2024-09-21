using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Extensions;
using PersonalBlog.Service.Helpers.Images;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class ArticleService : IArticleService
{
    public readonly IUnitofWork unitofWork;
    private readonly IMapper mapper;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IImageHelper imageHelper;
    private readonly ClaimsPrincipal user;

    public ArticleService(IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
    {
        this.unitofWork = unitofWork;
        this.mapper = mapper;
        this.httpContextAccessor = httpContextAccessor;
        this.imageHelper = imageHelper;
        user = httpContextAccessor.HttpContext.User;
    }

    public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
    {

        var imageUploaded = await imageHelper.UploadImageAsync(articleAddDto.Title, articleAddDto.ImageFile, nameof(Article));
        Image image = new Image(imageUploaded.FileName, articleAddDto.ImageFile.ContentType, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.GetRepository<Image>().AddAsync(image, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());

        var article = new Article(articleAddDto.Title, articleAddDto.Content, articleAddDto.CategoryId, image.Id, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());

        await unitofWork.GetRepository<Article>().AddAsync(article, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.SaveChangesAsync();
        return;
    }

    public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
    {
        var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
        var map = mapper.Map<List<ArticleDto>>(articles);


        return map;
    }

    public async Task<ArticleDto> GetArticleByGuidAsync(Guid articleId)
    {
        var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleId, x => x.Category, x => x.Image);
        return mapper.Map<ArticleDto>(article);
    }

    public async Task<bool> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
    {
        var article = await unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.Id == articleUpdateDto.Id, x => x.Category);
        mapper.Map(articleUpdateDto, article);

        if (articleUpdateDto.ImageFile is not null)
        {
            imageHelper.Delete(article.Image.FileName);
            await unitofWork.GetRepository<Image>().SoftDeleteAsync(article.Image, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());

            var imageUploaded = await imageHelper.UploadImageAsync(articleUpdateDto.Title, articleUpdateDto.ImageFile, nameof(Article));
            Image image = new Image(imageUploaded.FileName, articleUpdateDto.ImageFile.ContentType, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
            await unitofWork.GetRepository<Image>().AddAsync(image, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
            article.ImageId = image.Id;

        }

        await unitofWork.GetRepository<Article>().UpdateAsync(article, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.SaveChangesAsync();

        return true;
    }

    public async Task<string> SoftDeleteArticleAsync(Guid articleId)
    {
        var article = await unitofWork.GetRepository<Article>().GetByGuidAsync(articleId);

        if (article.Image is not null)
        {
            imageHelper.Delete(article.Image.FileName);
            await unitofWork.GetRepository<Image>().SoftDeleteAsync(article.Image, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        }
        await unitofWork.GetRepository<Article>().UpdateAsync(article, user.GetLoggedInUserId(), user.GetLoggedInUserEmail());
        await unitofWork.SaveChangesAsync();
        return article.Title;
    }
}
