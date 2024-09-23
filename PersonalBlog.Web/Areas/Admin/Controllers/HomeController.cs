using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        // GET: HomeController
        public async Task<ActionResult> Index()
        {
            IList<ArticleDto> articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            
            return View(articles);
        }

    }
}
