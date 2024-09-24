using System;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Entity.DTOs.Images;

namespace PersonalBlog.Entity.DTOs.Users;

public class UserProfileDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public int AccessFailedCount { get; set; }
    public ImageDto? Image { get; set; }
    public IFormFile? ImageFile { get; set; }

}
