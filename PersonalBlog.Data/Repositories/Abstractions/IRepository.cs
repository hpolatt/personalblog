using System.Linq.Expressions;
using System.Security.Claims;
using PersonalBlog.Core.Entities;

namespace PersonalBlog.Data.Repositories.Abstractions;

public interface IRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity, Guid userId, string userEmail);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetByGuidAsync(Guid id);
    Task<T> UpdateAsync(T entity, Guid userId, string userEmail);
    Task DeleteAsync(T entity);
    Task SoftDeleteAsync(T entity, Guid userId, string userEmail);

    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
}
