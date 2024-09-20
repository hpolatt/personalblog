using System.Globalization;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Service.Helpers.Images;
using PersonalBlog.Service.Services.Abstractions;
using PersonalBlog.Service.Services.Concretes;
using PersonalBlog.Service.Services.FluentValidation;

namespace PersonalBlog.Service.Extensions;

public static class ServiceLayerRegistration
{
    public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        // Service configurations
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IImageHelper, ImageHelper>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // AutoMapper configurations
        services.AddAutoMapper(assembly);

        // Fluent Validation configurations
        services.AddMvc();
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<ArticleValidator>();
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");

        return services;
    }
}
