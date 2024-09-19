using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Service.Services.Abstractions;
using PersonalBlog.Service.Services.Concretes;

namespace PersonalBlog.Service;

public static class ServiceLayerRegistration
{
   public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddAutoMapper(assembly);
        return services;
    }
}
