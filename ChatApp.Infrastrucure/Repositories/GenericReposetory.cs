using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Domain.Entites;
using ChatApp.Infrastrucure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastrucure.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
       
        protected readonly DbSet<T> _dbSet;
        private readonly ChatAppDbContext _context;

        public GenericRepository(ChatAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
           
        }

        #region Reading

        public IQueryable<T> GetAll(bool asTracking = false)
        {
            var query = asTracking ? _dbSet.AsTracking() : _dbSet.AsNoTracking();
            return query.Where(x => !x.IsDeleted);
        }


        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.ID == id && !x.IsDeleted);

        public async Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> criteria,bool asTracking = false)
        {
            var query = asTracking
                ? _dbSet.AsTracking()
                : _dbSet.AsNoTracking();

            return await query
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(criteria);
        }

        public IQueryable<T> GetAllByCriteria(Expression<Func<T, bool>> criteria,bool asTracking = false)
        {
            var query = asTracking
                ? _dbSet.AsTracking()
                : _dbSet.AsNoTracking();

            return query
                .Where(x => !x.IsDeleted)
                .Where(criteria);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(predicate, cancellationToken);

        #endregion

        #region Writing

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbSet.AddRangeAsync(entities);

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is not null)
                _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);

        #endregion

        #region Delete

        public void HardDelete(T entity)
            => _dbSet.Remove(entity);

        public async Task SoftDeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            await UpdateIncludeAsync(entity, nameof(BaseEntity.IsDeleted));
        }

        #endregion

        #region Update Control

        public async Task UpdateIncludeAsync(T entity, params string[] modifiedProperties)
        {
            var localEntity = _dbSet.Local.FirstOrDefault(e => e.ID == entity.ID);
            var entry = localEntity is null
                ? _context.Entry(entity)
                : _context.ChangeTracker.Entries<T>().First(x => x.Entity.ID == entity.ID);

            foreach (var prop in modifiedProperties)
            {
                var propertyInfo = entity.GetType().GetProperty(prop);
                if (propertyInfo is not null)
                {
                    var value = propertyInfo.GetValue(entity);

                    if (value != null)
                    {
                        entry.Property(prop).CurrentValue = value;
                        entry.Property(prop).IsModified = true;
                    }
                }
            }

        }

        public async Task UpdateExcludeAsync(T entity, params string[] unmodifiedProperties)
        {
            var localEntity = _dbSet.Local.FirstOrDefault(e => e.ID == entity.ID);
            var entry = localEntity is null
                ? _context.Entry(entity)
                : _context.ChangeTracker.Entries<T>().First(x => x.Entity.ID == entity.ID);

            foreach (var prop in entry.Properties)
            {
                if (!unmodifiedProperties.Contains(prop.Metadata.Name))
                {
                    var value = entity.GetType().GetProperty(prop.Metadata.Name)?.GetValue(entity);

                    if (value != null)
                    {
                        prop.CurrentValue = value;
                        prop.IsModified = true;
                    }
                }
            }

           
        }

        public async Task UpdateSmartAsync(T entity)
        {
            // ✅ 1. الحصول على الـ Key Property (المفتاح الأساسي)
            var keyName = _context.Model.FindEntityType(typeof(T))
                                        ?.FindPrimaryKey()
                                        ?.Properties
                                        ?.Select(x => x.Name)
                                        ?.FirstOrDefault();

            if (keyName == null)
                throw new InvalidOperationException($"No primary key defined for {typeof(T).Name}");

            // ✅ 2. الحصول على قيمة المفتاح
            var keyProperty = typeof(T).GetProperty(keyName);
            var keyValue = keyProperty?.GetValue(entity);
            if (keyValue == null)
                throw new ArgumentException($"Entity key value cannot be null for {typeof(T).Name}");

            // ✅ 3. جلب الكيان الأصلي من قاعدة البيانات
            var existingEntity = await _dbSet.FindAsync(keyValue);
            if (existingEntity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with key '{keyValue}' not found.");

            // ✅ 4. المقارنة والتحديث فقط لما يكون فيه فرق أو قيمة جديدة
            var entry = _context.Entry(existingEntity);
            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanWrite) continue; // تخطي الخصائص اللي ملهاش setter

                var newValue = prop.GetValue(entity);
                var oldValue = prop.GetValue(existingEntity);

                // 🔹 لو القيمة الجديدة مش null ومختلفة عن القديمة، حدثها
                if (newValue != null && !Equals(newValue, oldValue))
                {
                    prop.SetValue(existingEntity, newValue);
                    entry.Property(prop.Name).IsModified = true;
                }
            }

            
            
        }



        #endregion

    
    }


}
