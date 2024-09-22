using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Data;
using PersonalBlog.Data.Context;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Extensions;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Register all services for each layer
builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtensions();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions(){
        // ProgressBar = true,
        PositionClass = ToastPositions.TopRight,
        ShowDuration = 3000,
        //  PreventDuplicates = true,
        // CloseButton = true,
        // HideDuration = 500,
        // TimeOut = 5000,
        // ExtendedTimeOut = 500,
        // ShowEasing = "swing",
        // HideEasing = "linear",
        // ShowMethod = "fadeIn",
        // HideMethod = "fadeOut"
    })
    .AddRazorRuntimeCompilation();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddRoleManager<RoleManager<AppRole>>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Admin/Auth/Login");
    options.LogoutPath = new PathString("/Admin/Auth/Logout");
    options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "PersonalBlog.Security.Cookie",
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/error");
    app.UseHsts();
}

app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();

app.Run();