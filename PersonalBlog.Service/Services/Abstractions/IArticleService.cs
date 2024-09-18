using PersonalBlog.Entity.DTOs.Articles;

namespace PersonalBlog.Service.Services.Abstractions;

public interface IArticleService
{
    Task<List<ArticleDto>> GetAllArticlesAsync();
}
