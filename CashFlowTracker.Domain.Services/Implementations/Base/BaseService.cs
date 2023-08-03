using CashFlowTracker.Domain.Repositories.Base;
using CashFlowTracker.Domain.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowTracker.Domain.Services.Implementations.Base
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository;

        protected BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        // Métodos comuns de CRUD

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
