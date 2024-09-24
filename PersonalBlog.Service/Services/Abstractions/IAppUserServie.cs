using System;
using Microsoft.AspNetCore.Identity;
using PersonalBlog.Entity.DTOs.Users;

namespace PersonalBlog.Service.Services.Abstractions;

public interface IAppUserServie
{
    Task<IdentityResult> AddUserAsync(UserAddDto userAddDto);
    Task<UserProfileDto> GetUserProfileDtoByIdAsync(Guid id);
    Task<UserUpdateDto> GetUserUpdateDtoByIdAsync(Guid id);
    Task<UserDto> GetLoggedInUserDtoByIdAsync();
    Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
    Task<IdentityResult> UpdateProfileAsync(UserProfileDto userProfileDto);
    Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();

}
