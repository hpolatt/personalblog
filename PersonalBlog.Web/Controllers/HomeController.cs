using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.DTOs.Articles;
using PersonalBlog.Entity.DTOs.GitHub;
using PersonalBlog.Service.Services.Abstractions;
using PersonalBlog.Web.Models;

namespace PersonalBlog.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGitHubService gitHubService;

    public HomeController(ILogger<HomeController> logger, IGitHubService gitHubService)
    {
        _logger = logger;
        this.gitHubService = gitHubService;
    }

    public async Task<IActionResult> Index()
    {
       IEnumerable<GitHubProjectDto> projects = await gitHubService.GetGithubProjects();
        return View(projects);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

