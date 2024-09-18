using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.DTOs.Articles;
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
            IList<ArticleDto> articles = await articleService.GetAllArticlesAsync();
            
            return View(articles);
        }

    }
}
