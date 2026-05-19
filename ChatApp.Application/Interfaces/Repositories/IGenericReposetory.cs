using ChatApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces.Repositories
{    
    public interface IGenericRepository<T> where T : BaseEntity
    {
        // Reading
        IQueryable<T> GetAll(bool asTracking = false);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> criteria, bool asTracking = false);
        IQueryable<T> GetAllByCriteria(Expression<Func<T, bool>> criteria, bool asTracking = false);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);


        // Writing
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(int id);
        void DeleteRange(IEnumerable<T> entities);

        // Delete
        void HardDelete(T entity);
        Task SoftDeleteAsync(T entity);

        // Update control
        Task UpdateIncludeAsync(T entity, params string[] modifiedProperties);
        Task UpdateExcludeAsync(T entity, params string[] unmodifiedProperties);
        Task UpdateSmartAsync(T entity);

     
    }

}
