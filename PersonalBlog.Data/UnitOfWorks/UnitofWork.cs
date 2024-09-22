using System;
using PersonalBlog.Data.Context;
using PersonalBlog.Data.Repositories.Abstractions;
using PersonalBlog.Data.Repositories.Concretes;

namespace PersonalBlog.Data.UnitOfWorks;

public class UnitofWork : IUnitofWork
{
    private readonly AppDbContext dbContext;

    public UnitofWork(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async ValueTask DisposeAsync()
    {
        await dbContext.DisposeAsync();
    }

    public int SaveChanges()
    {
        return dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }

    IRepository<T> IUnitofWork.GetRepository<T>()
    {
        return new Repository<T>(dbContext);
    }
}
