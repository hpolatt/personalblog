using System.Collections;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            // IList<Article> articles = await articleService.GetAllArticlesAsync();
            // articles
            return View();
        }

    }
}
