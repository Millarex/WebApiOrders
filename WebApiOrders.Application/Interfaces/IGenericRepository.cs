using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiOrders.Application.Interfaces
{
    public interface IGenericRepository<TEntity> : IDisposable
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(int id, TEntity entity);
        Task<bool> DeleteAsync(int id);
    }
}
