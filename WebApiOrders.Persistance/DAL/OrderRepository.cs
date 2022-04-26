using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.Persistance.DAL
{
    public class OrderRepository : IGenericRepository<OrderModel>
    {
        private readonly WebApiOrdersDBContext _dbContext;

        public OrderRepository(WebApiOrdersDBContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return await _dbContext.Set<OrderModel>().ToListAsync();
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            return await _dbContext.Set<OrderModel>().FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task CreateAsync(OrderModel entity)
        {
            await _dbContext.Set<OrderModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderModel entity)
        {
            _dbContext.Set<OrderModel>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<OrderModel>().FindAsync(id);
            _dbContext.Set<OrderModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            //Add Dispose method if needed
        }

    }
}
