using System.Globalization;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Service.Services.Abstractions;
using PersonalBlog.Service.Services.Concretes;
using PersonalBlog.Service.Services.FluentValidation;

namespace PersonalBlog.Service;

public static class ServiceLayerRegistration
{
    [Obsolete]
    public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        // Service configurations
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ICategoryService, CategoryService>();

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
