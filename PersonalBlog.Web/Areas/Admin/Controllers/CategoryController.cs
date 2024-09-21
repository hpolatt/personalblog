using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PersonalBlog.Entity.DTOs.Categories;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Extensions;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService categoryService;
        private IMapper mapper;
        private IValidator<Category> validator;
        private IToastNotification toastNotification;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IValidator<Category> validator, IToastNotification toastNotification)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }
        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            IEnumerable<CategoryDetailDto> categories = await categoryService.GetAllCategoryListNonDeletedAsync();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new CategoryAddDto());
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryAddDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            var validationResult = validator.Validate(new ValidationContext<Category>(category));
            if (validationResult.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryDto);
                toastNotification.AddSuccessToastMessage($"{category.Name} Category added successfully.");
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            validationResult.AddToModelState(this.ModelState);
            return View(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> AddWithAjax([FromBody] CategoryAddDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            var validationResult = validator.Validate(new ValidationContext<Category>(category));
            if (validationResult.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryDto);
                toastNotification.AddSuccessToastMessage($"{category.Name} Category added successfully.");
                return Json(new { success = true, message = $"{category.Name} Category added successfully." });
            }
            validationResult.AddToModelState(this.ModelState);
            toastNotification.AddErrorToastMessage(validationResult.Errors.First().ErrorMessage);
            return Json(new { success = false, errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList() });
        }

        [HttpGet]
        public async Task<ActionResult> Update(Guid categoryId)
        {
            var category = await categoryService.GetCategoryByGuidAsync(categoryId);
            return View(category);
        }

        [HttpPost]
        public async Task<ActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var category = mapper.Map<Category>(categoryUpdateDto);
            var validationResult = validator.Validate(new ValidationContext<Category>(category));
            if (validationResult.IsValid)
            {
                await categoryService.UpdateCategoryAsync(categoryUpdateDto);
                toastNotification.AddSuccessToastMessage($"{category.Name} Category updated successfully.");
                return RedirectToAction("Index", "Category", new { Area = "Admin" });
            }
            validationResult.AddToModelState(this.ModelState);
            return View(categoryUpdateDto);
        }

        public async Task<ActionResult> Delete(Guid categoryId)
        {
            string categoryName = await categoryService.SoftDeleteCategoryAsync(categoryId);
            toastNotification.AddSuccessToastMessage($"{categoryName} deleted successfully.");
            return RedirectToAction("Index", "Category", new { Area = "Admin" });
        }

        [HttpGet]
        public async Task<ActionResult> Info(Guid categoryId)
        {
            var category = await categoryService.GetCategoryDetailByGuidAsync(categoryId);
            return View(category);
        }

    }
}
