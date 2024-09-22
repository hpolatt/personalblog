using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalBlog.Data.Context;
using PersonalBlog.Data.Repositories.Abstractions;
using PersonalBlog.Data.Repositories.Concretes;
using PersonalBlog.Data.UnitOfWorks;

namespace PersonalBlog.Data;

public static class DataLayerRegistration
{

    public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration["ConnectionString:DefaultConnection"]));

        services.AddScoped<IUnitofWork, UnitofWork>();
        
        return services;
    }
}
