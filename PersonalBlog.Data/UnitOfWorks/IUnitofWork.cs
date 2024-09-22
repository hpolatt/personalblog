using System;
using PersonalBlog.Core.Entities;
using PersonalBlog.Data.Repositories.Abstractions;

namespace PersonalBlog.Data.UnitOfWorks;

public interface IUnitofWork: IAsyncDisposable
{
    IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    int SaveChanges();

}
