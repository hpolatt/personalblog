using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Helpers.Images;
using PersonalBlog.Service.ResultMessages;
using PersonalBlog.Service.Services.Abstractions;
using PersonalBlog.Web.Const;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = RoleConts.Superadmin)]
    public class UserController : Controller
    {
        private readonly RoleManager<AppRole> roleManager;
        private readonly IToastNotification toastNotification;
        private readonly IAppUserServie appUserServie;

        public UserController(RoleManager<AppRole> roleManager, IToastNotification toastNotification, IAppUserServie appUserServie)
        {

            this.roleManager = roleManager;
            this.toastNotification = toastNotification;
            this.appUserServie = appUserServie;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDto> userDtos = await appUserServie.GetAllUsersAsync();
            return View(userDtos);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto() { Roles = roles });
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
           if (ModelState.IsValid)
            {
                var result = await appUserServie.AddUserAsync(userAddDto);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email));
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                foreach (var errors in result.Errors)
                    ModelState.AddModelError("", errors.Description);
            }
            var roles = await roleManager.Roles.ToListAsync();
            userAddDto.Roles = roles;
            return View(userAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            UserUpdateDto userDto = await appUserServie.GetUserUpdateDtoByIdAsync(userId);
            return View(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await appUserServie.UpdateUserAsync(userUpdateDto);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email));
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
            }
            else
                foreach (var item in ModelState.Values)
                    foreach (var error in item.Errors)
                        toastNotification.AddErrorToastMessage(error.ErrorMessage);
            
            userUpdateDto.Roles = await roleManager.Roles.ToListAsync(); ;
            return View(userUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid userId)
        {
           var result = await appUserServie.DeleteUserAsync(userId);
            if (result.identityResult.Succeeded) {
                toastNotification.AddSuccessToastMessage(Messages.User.Delete(result.email)); 
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            foreach (var error in result.identityResult.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
            
            return NotFound();
            
                
        }

        [HttpGet]
        public async Task<IActionResult> Profile(Guid userId)
        {
            var userDto = await appUserServie.GetUserProfileDtoByIdAsync(userId);
            return View(userDto);
        }

        [HttpPost]
          public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            if (ModelState.IsValid)
            {
                var result = await appUserServie.UpdateProfileAsync(userProfileDto);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.User.Update(userProfileDto.Email));
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                toastNotification.AddErrorToastMessage(result.Errors.First().Description);
            }
            else
                foreach (var item in ModelState.Values)
                    foreach (var error in item.Errors)
                        toastNotification.AddErrorToastMessage(error.ErrorMessage);
                        
            return View(userProfileDto);
        }
    }
}
