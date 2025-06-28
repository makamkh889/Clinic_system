using System.Linq.Expressions;

namespace Clinic_managment_System.Clinic_System.Shared.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<bool> Delete(Expression<Func<TEntity, bool>> Predicate);
    Task<bool> UpdateAsync(Expression<Func<TEntity, bool>> Predicate, TEntity entity);
    Task<TEntity?> GetItemAsync(
    Expression<Func<TEntity, bool>> predicate,
    Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
    Task<IEnumerable<TEntity>> GetAllAsync(string? Selector = null);
    IQueryable<TEntity> GetAllWithFilter(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> ReadAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);
}