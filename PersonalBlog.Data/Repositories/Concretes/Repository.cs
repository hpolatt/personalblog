using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalBlog.Core.Entities;
using PersonalBlog.Data.Context;
using PersonalBlog.Data.Repositories.Abstractions;

namespace PersonalBlog.Data.Repositories.Concretes;

public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext dbContext;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private DbSet<T> Table => dbContext.Set<T>();

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = Table;
        if (predicate is not null) query = query.Where(predicate);
        if (includeProperties.Length != 0) {
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
        }
        return await query.ToListAsync();
        
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>>[] includeProperties = null)
    {
        IQueryable<T> query = Table;
        query = query.Where(predicate);
        if (includeProperties.Any()) {
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
        }
        return await query.SingleAsync();
    }

    public async Task<T> GetByGuidAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        await Task.Run(() => Table.Update(entity));
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        await Task.Run(() => Table.Remove(entity));
    }

    public async Task SoftDeleteAsync(T entity)
    {
        entity.IsDeleted = true;
        await Task.Run(() => Table.Update(entity));
        
    }

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return Table.AnyAsync(predicate);
    }

    public Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        return Table.CountAsync(predicate);
    }
}
