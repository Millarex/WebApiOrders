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
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
    }
}
