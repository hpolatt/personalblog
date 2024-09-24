using System;
using AutoMapper;
using PersonalBlog.Entity.DTOs.Users;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.AutoMapper.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AppUser, UserDto>();
        CreateMap<UserAddDto, AppUser>();
        CreateMap<AppUser, UserUpdateDto>();
        CreateMap<UserUpdateDto, AppUser>();
        CreateMap<UserProfileDto, AppUser>();
        CreateMap<AppUser, UserProfileDto>();
    }

}
