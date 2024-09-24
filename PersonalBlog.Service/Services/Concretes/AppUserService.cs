using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Context;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Images;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Helpers.Images;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class AppUserService : IAppUserServie
{
    private readonly UserManager<AppUser> userManager;
    private readonly RoleManager<AppRole> roleManager;
    private readonly IUnitofWork unitofWork;
    private readonly IMapper mapper;
    private readonly ClaimsPrincipal user;
    private readonly IImageHelper imageHelper;
    private readonly AppDbContext dbContext;

    public AppUserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IUnitofWork unitofWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper, AppDbContext dbContext)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.unitofWork = unitofWork;
        this.mapper = mapper;
        user = httpContextAccessor.HttpContext.User;
        this.imageHelper = imageHelper;
        this.dbContext = dbContext;
    }

    public async Task<IdentityResult> AddUserAsync(UserAddDto userAddDto)
    {
        var map = mapper.Map<AppUser>(userAddDto);

        map.PasswordHash = CreatePasswordHash(map, userAddDto.Password);
        map.UserName = userAddDto.Email;
        var result = await userManager.CreateAsync(map);
        if (result.Succeeded)
        {
            var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
            if (findRole != null)
                await userManager.AddToRoleAsync(map, findRole.ToString());
        }
        return result;
    }

    public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        var result = await userManager.DeleteAsync(user);
        if (result.Succeeded) return (result, user.Email);
        return (result, null);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await userManager.Users.ToListAsync();
        var userDtos = mapper.Map<IEnumerable<UserDto>>(users);
        mapper.Map<IEnumerable<UserDto>>(users);

        foreach (var item in userDtos)
        {
            var user = await userManager.FindByIdAsync(item.Id.ToString());
            item.Role = string.Join("", await userManager.GetRolesAsync(user));
        }
        return userDtos;
    }

    public async Task<UserDto> GetLoggedInUserDtoByIdAsync()
    {
        AppUser loggedInUser = await userManager.GetUserAsync(user);
        var userInfo = mapper.Map<UserDto>(loggedInUser);
        userInfo.Role = string.Join("", await userManager.GetRolesAsync(loggedInUser));
         if (loggedInUser.ImageId is not null)
        {
            var image = await unitofWork.GetRepository<Image>().GetByGuidAsync(loggedInUser.ImageId.Value);
            userInfo.Image = mapper.Map<ImageUploadedDto>(image);
        }

        return userInfo;
    }

    public async Task<UserProfileDto> GetUserProfileDtoByIdAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
        var userDto = mapper.Map<UserProfileDto>(user);

        if (user.ImageId is not null)
        {
            var image = await unitofWork.GetRepository<Image>().GetByGuidAsync(user.ImageId.Value);
            userDto.Image = mapper.Map<ImageDto>(image);
        }

        return userDto;

    }

    public async Task<UserUpdateDto> GetUserUpdateDtoByIdAsync(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());
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
        return userDto;
    }

    public async Task<IdentityResult> UpdateProfileAsync(UserProfileDto userProfileDto)
    {
        var user = await userManager.FindByIdAsync(userProfileDto.Id.ToString());
        var mappedUser = mapper.Map(userProfileDto, user);
        if (userProfileDto.ImageFile is not null)
        {
            var imageUploaded = await imageHelper.UploadImageAsync(mappedUser.Id.ToString(), userProfileDto.ImageFile, nameof(AppUser));
            Image image = new Image(imageUploaded.FileName, userProfileDto.ImageFile.ContentType, userProfileDto.Id, userProfileDto.Email);
            await unitofWork.GetRepository<Image>().AddAsync(image, mappedUser.Id, mappedUser.Email);
            mappedUser.ImageId = image.Id;
            await unitofWork.SaveChangesAsync();
        }
        return await userManager.UpdateAsync(mappedUser);
    }

    public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
    {
        AppUser user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
        AppUser mappedUser = mapper.Map(userUpdateDto, user);
        mappedUser.PasswordHash = CreatePasswordHash(user, userUpdateDto.Password);
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
        }
        return result;

    }

    private string CreatePasswordHash(AppUser user, string password)
    {
        var passwordHasher = new PasswordHasher<AppUser>();
        return passwordHasher.HashPassword(user, password);
    }
}
