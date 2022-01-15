using Microsoft.EntityFrameworkCore.Query;
using ShareMyPaper.Application.Dtos;
using System.Linq.Expressions;

namespace ShareMyPaper.Application.Interfaces.Repositories;
public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<IEnumerable<T>> ListAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    );
    Task<int> CountAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
     );
    Task<T> FirstOrDefaultAsync(
         Expression<Func<T, bool>> filter = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
     );
    Task<T> FirstAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    );
    Task<PagedResult<T>> PageAsync(
        int currentPage,
        int pageSize,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );
}