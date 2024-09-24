using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDashboardService dashboardService;

        public HomeController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }
        // GET: HomeController
        public async Task<IActionResult> Index()
        {
            // var data = dashboardService.GetYearlyArticleCount();
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> YearlyArticleCount()
        {
            var data = await dashboardService.GetYearlyArticleCount();
            return Json(JsonConvert.SerializeObject(data));
        }

    }
}
