using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
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
                var roles = await userManager.GetRolesAsync(user);
                item.Role = roles.FirstOrDefault() ?? "User";
            }


            return View(userDtos);
        }

    }
}
