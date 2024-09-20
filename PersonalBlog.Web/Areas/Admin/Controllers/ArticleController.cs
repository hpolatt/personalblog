using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.ResultMessages;
using PersonalBlog.Service.Extensions;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator validator;
        private readonly IToastNotification toastNotification;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
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
            var article = mapper.Map<Article>(articleAddDto);
            var validationResult = validator.Validate(new ValidationContext<Article>(article));
            if (validationResult.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title));
                return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            validationResult.AddToModelState(this.ModelState);
            articleAddDto.Categories = await categoryService.GetAllCategoriesNonDeletedAsync();
            return View(articleAddDto);
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
            var article = mapper.Map<Article>(articleUpdateDto);
            var validationResult = validator.Validate(new ValidationContext<Article>(article));
            if (validationResult.IsValid)
            {
                var result = await articleService.UpdateArticleAsync(articleUpdateDto);
                toastNotification.AddSuccessToastMessage(Messages.Article.Add(articleUpdateDto.Title));
                if (result == true) return RedirectToAction("Index", "Article", new { Area = "Admin" });
            }
            validationResult.AddToModelState(this.ModelState);
            articleUpdateDto.Categories = await categoryService.GetAllCategoriesNonDeletedAsync();
            return View(articleUpdateDto);

        }

        public async Task<ActionResult> Delete(Guid articleId)
        {
            var res = await articleService.SoftDeleteArticleAsync(articleId);
            if (res is not null) toastNotification.AddSuccessToastMessage(Messages.Article.Delete(res));
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
        }


    }
}
