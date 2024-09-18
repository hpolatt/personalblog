using Microsoft.AspNetCore.Identity;

namespace PersonalBlog.Entity.Entities;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Guid? ImageId { get; set; }
    public Image Image { get; set; }

}
