using System;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Entity.DTOs.Images;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Entity.DTOs.Users;

public class UserAddDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }    
    public string Password { get; set; }
    public Guid RoleId { get; set; }
    public IList<AppRole>? Roles { get; set; }
    
}
