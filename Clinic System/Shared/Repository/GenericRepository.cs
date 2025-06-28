using System.Linq.Expressions;
using clinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clinic_managment_System.Clinic_System.Shared.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ClinicDbContext _applicationDBContext;
    public GenericRepository(ClinicDbContext applicationDBContext)
    {
        _applicationDBContext = applicationDBContext;
    }
    public async Task AddAsync(TEntity entity)
    {
        await _applicationDBContext.Set<TEntity>().AddAsync(entity);
    }
    public async Task<bool> Delete(Expression<Func<TEntity, bool>> Predicate)
    {
        TEntity? result = await _applicationDBContext.Set<TEntity>().FirstOrDefaultAsync(Predicate);
        if (result is not null)
        {
            _applicationDBContext.Set<TEntity>().Remove(result);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Return a Tracked List OF Entity
    /// </summary>
    /// <param name="Selector">Name Of Navigation Property</param>
    /// <returns>Task<IEnumerable<TEntity>></returns>
    public async Task<IEnumerable<TEntity>> GetAllAsync(string? Selector = null)
    {
        if (Selector is not null)
        {
            return await _applicationDBContext.Set<TEntity>().Include(Selector).ToListAsync();
        }
        return await _applicationDBContext.Set<TEntity>().ToListAsync();
    }

    ///  <summary>
    ///  It's a Generic Method to Get All Items With Filter
    public IQueryable<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> expression)
    {
        return _applicationDBContext.Set<TEntity>().Where(expression);
    }
    /// <summary>
    /// Return a Nullable Item Of Entity
    /// </summary>
    /// <param name="expression">Lambda Expression</param>
    /// <param name="include">Name Of Navigation Property</param>
    /// <returns>Task<TEntity?></returns>
    public async Task<TEntity?> GetItemAsync(
     Expression<Func<TEntity, bool>> predicate,
     Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = _applicationDBContext.Set<TEntity>();

        if (include != null)
        {
            query = include(query);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    /// <summary>
    ///  Return a Read Only List of Entity
    ///  AsNoTracking List
    /// </summary>
    /// <param name="Selector">Name Of Navigation Property</param>
    /// <returns>Task<IEnumerable<TEntity>></returns>
    /// 
    public async Task<IEnumerable<TEntity>> ReadAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = _applicationDBContext.Set<TEntity>();

        if (include != null)
        {
            query = include(query);
        }

        return await query.AsNoTracking().ToListAsync();
    }
    
    public async Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> Predicate, TEntity entity)
    {
        TEntity? existedItem = await _applicationDBContext.Set<TEntity>().FirstOrDefaultAsync(Predicate);
        if (existedItem is not null)
        {
            _applicationDBContext.Entry(existedItem).CurrentValues.SetValues(entity);
            _applicationDBContext.Entry(existedItem).State = EntityState.Modified;
            return true;
        }
        return false;
    }
}