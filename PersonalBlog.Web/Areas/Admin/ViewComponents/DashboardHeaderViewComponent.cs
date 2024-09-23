using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Web.Areas.Admin.ViewComponents;

public class DashboardHeaderViewComponent : ViewComponent
{
    private readonly UserManager<AppUser> userManager;
    private readonly IMapper mapper;

    public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        AppUser loggedInUser = await userManager.GetUserAsync(HttpContext.User);
        var userInfo = mapper.Map<UserDto>(loggedInUser);
        return View(userInfo);
    }
}
