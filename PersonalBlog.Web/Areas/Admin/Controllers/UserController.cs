using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Experimental.ProjectCache;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager,  IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        // GET: UserController
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
            var roles =  await roleManager.Roles.ToListAsync();
            return View(new UserAddDto(){ Roles = roles });
        }

    }
}
