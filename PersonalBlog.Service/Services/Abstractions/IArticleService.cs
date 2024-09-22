using PersonalBlog.Entity.DTOs.Articles;

namespace PersonalBlog.Service.Services.Abstractions;

public interface IArticleService
{
    Task<ArticleDto> GetArticleByGuidAsync(Guid articleId);
    Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
    Task CreateArticleAsync(ArticleAddDto articleAddDto);
    Task<bool> UpdateArticleAsync(ArticleUpdateDto articleAddDto);
    Task<string> SoftDeleteArticleAsync(Guid articleId);
    
}
