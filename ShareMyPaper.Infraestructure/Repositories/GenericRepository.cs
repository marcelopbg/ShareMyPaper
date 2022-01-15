using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ShareMyPaper.Application.Dtos;
using ShareMyPaper.Application.Interfaces.Repositories;
using ShareMyPaper.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShareMyPaper.Infraestructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public virtual async Task<IEnumerable<T>> ListAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (include != null)
        {
            query = include(query);
        }


        if (orderBy != null)
        {
            return await orderBy(query).AsNoTracking().ToListAsync();
        }
        else
        {
            return await query.AsNoTracking().ToListAsync();
        }
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        var keyValues = new object[] { id };
        return await _dbContext.Set<T>().FindAsync(keyValues);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);

        return entity;
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);

    }
    public virtual async Task<int> CountAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
     )
    {
        IQueryable<T> query = _dbContext.Set<T>(); ;

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (include != null)
        {
            query = include(query);
        }

        if (orderBy != null)
        {
            return await orderBy(query).AsNoTracking().CountAsync();
        }
        else
        {
            return await query.AsNoTracking().CountAsync();
        }
    }
    public virtual async Task<T> FirstOrDefaultAsync(
      Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        IQueryable<T> query = _dbContext.Set<T>();

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (include != null)
        {
            query = include(query);
        }

        if (orderBy != null)
        {
            return await orderBy(query).AsNoTracking().FirstOrDefaultAsync();
        }
        else
        {
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
    public virtual async Task<T> FirstAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
    )
    {
        IQueryable<T> query = _dbContext.Set<T>(); ;

        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (include != null)
        {
            query = include(query);
        }

        if (orderBy != null)
        {
            return await orderBy(query).AsNoTracking().FirstAsync();
        }
        else
        {
            return await query.AsNoTracking().FirstAsync();
        }
    }

    public virtual async Task<PagedResult<T>> PageAsync(
        int currentPage,
        int pageSize,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
    {

        IQueryable<T> query = _dbContext.Set<T>();
        PagedResult<T> result = new();


        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (include != null)
        {
            query = include(query);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        result.CurrentPage = currentPage;
        result.PageSize = pageSize;
        result.RowCount = await query.CountAsync();

        var pageCount = (double)result.RowCount / pageSize;
        result.PageCount = (int)Math.Ceiling(pageCount);
 
        var skip = (currentPage - 1) * pageSize;
        result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

        return result;
    }
}
