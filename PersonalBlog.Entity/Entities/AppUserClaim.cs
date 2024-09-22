using System;
using Microsoft.AspNetCore.Identity;

namespace PersonalBlog.Entity.Entities;

public class AppUserClaim : IdentityUserClaim<Guid>
{
    public virtual AppUser User { get; set; }
}