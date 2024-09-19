using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
        public async Task<ActionResult> Index()
        {
            IList<ArticleDto> articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();

            return View(articles);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeletedAsync();
            return View(new ArticleAddDto { Categories = categories });
        }

        [HttpPost]
        public async Task<ActionResult> Add(ArticleAddDto articleAddDto)
        {
            await articleService.CreateArticleAsync(articleAddDto);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<ActionResult> Update(Guid articleId)
        {
            var article = await articleService.GetArticleByGuidAsync(articleId);
            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = await categoryService.GetAllCategoriesNonDeletedAsync();

            return View(articleUpdateDto);
        }

        [HttpPost]
        public async Task<ActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var result = await articleService.UpdateArticleAsync(articleUpdateDto);
            if (result == true) return RedirectToAction("Index", "Article", new { Area = "Admin" });

            articleUpdateDto.Categories = await categoryService.GetAllCategoriesNonDeletedAsync();
            return View(articleUpdateDto);

        }

        public async Task<ActionResult> Delete(Guid articleId)
        {
            await articleService.SoftDeleteArticleAsync(articleId);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }


    }
}
