using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;
using PersonalBlog.Service.Services.Concretes;

namespace PersonalBlog.Web.Areas.Admin.ViewComponents;

public class DashboardHeaderViewComponent : ViewComponent
{
    private readonly IAppUserServie userService;

    public DashboardHeaderViewComponent(IAppUserServie userService)
    {
        this.userService = userService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userInfo = await userService.GetLoggedInUserDtoByIdAsync();
        return View(userInfo);
    }
}
