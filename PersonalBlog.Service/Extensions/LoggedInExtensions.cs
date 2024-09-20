using System;
using System.Security.Claims;

namespace PersonalBlog.Service.Extensions;

public static class LoggedInExtensions
{

    public static Guid GetLoggedInUserId(this ClaimsPrincipal principal)
    {
        return Guid.Parse(principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty);
    }
    public static string GetLoggedInUserEmail(this ClaimsPrincipal principal)
    {
        return principal.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
    }
}
