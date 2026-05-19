using ChatApp.Application.Interfaces.IUnitOfWork;
using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Domain.Entites;
using ChatApp.Infrastrucure.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastrucure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatAppDbContext _dbContext;
        private readonly Hashtable _repositories;
        public UnitOfWork(ChatAppDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Hashtable();
        }
       

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var Repository = new GenericRepository<TEntity>(_dbContext);
                _repositories.Add(type, Repository);

            }
            return _repositories[type] as IGenericRepository<TEntity>;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
