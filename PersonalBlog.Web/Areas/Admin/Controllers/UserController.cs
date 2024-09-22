using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Experimental.ProjectCache;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NToastNotify;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Helpers.Images;
using PersonalBlog.Service.ResultMessages;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly IValidator<AppUser> validator;
        private readonly IToastNotification toastNotification;


        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IValidator<AppUser> validator, IToastNotification toastNotification)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
            mapper.Map<IEnumerable<UserDto>>(users);

            foreach (var item in userDtos)
            {
                var user = await userManager.FindByIdAsync(item.Id.ToString());
                item.Role = string.Join("", await userManager.GetRolesAsync(user));
            }

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
            var map = mapper.Map<AppUser>(userAddDto);
            var roles = await roleManager.Roles.ToListAsync();
            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await userManager.CreateAsync(map, userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    if (findRole != null)
                    {
                        await userManager.AddToRoleAsync(map, findRole.ToString());
                    }
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email));
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                foreach (var errors in result.Errors)
                    ModelState.AddModelError("", errors.Description);
            }
            userAddDto.Roles = roles;
            return View(userAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();

            var userDto = mapper.Map<UserUpdateDto>(user);
            userDto.Roles = roles;
            var userRoles = await userManager.GetRolesAsync(user);

            if (userRoles.Any())
            {
                var role = await roleManager.FindByNameAsync(userRoles.First());
                if (role != null)
                {
                    userDto.RoleId = role.Id;
                }
            }
            return View(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
                var mappedUser = mapper.Map(userUpdateDto, user);
                var result = await userManager.UpdateAsync(mappedUser);
                if (result.Succeeded)
                {
                    var role = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                    var userRoles = await userManager.GetRolesAsync(mappedUser);
                    await userManager.RemoveFromRolesAsync(mappedUser, userRoles);
                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(mappedUser, role.ToString());
                    }
                    toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email));
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                toastNotification.AddErrorToastMessage(result.Errors.First().Description);
            }
            else
            {
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        toastNotification.AddErrorToastMessage(error.ErrorMessage);
                    }
                }
            }
            // validationResult.AddToModelState(this.ModelState);
            userUpdateDto.Roles = await roleManager.Roles.ToListAsync(); ;
            return View(userUpdateDto);
        }

        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.User.Delete(user.Email));
                return RedirectToAction("Index", "User", new { area = "Admin" });
            }
            toastNotification.AddErrorToastMessage(result.Errors.First().Description);
            return RedirectToAction("Index", "User", new { area = "Admin" });
        }

    }
}
