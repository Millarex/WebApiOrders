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

        public async Task<bool> CreateAsync(OrderModel entity)
        {
            //Manual validation TODO: Auto validation for Create method type of OrderModel
            if (entity == null || entity.Name == null || entity.Description == null)
                return false;
            var user = await _dbContext.Set<UserModel>().FindAsync(entity.UserId);
            if (user == null)
                return false;
            //
            await _dbContext.Set<OrderModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, OrderModel entity)
        {
            var order = await _dbContext.Set<OrderModel>()
                 .Include(r => r.User)
                 .FirstOrDefaultAsync(model => model.Id == id);
            if (order == null)
                return false;

            //Partial Update
            if (entity.Name != null)
                order.Name = entity.Name;
            if (entity.Description != null)
                order.Description = entity.Description;
            if (entity.Price != 0)
                order.Price = entity.Price;
            if (entity.UserId != 0)
            {
                var user = await _dbContext.Set<UserModel>().FindAsync(entity.UserId);
                if (user == null)
                    return false;
                else
                {
                    order.UserId = entity.UserId;
                    order.User = user;
                }
            }

            _dbContext.Set<OrderModel>().Update(order);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<OrderModel>().FindAsync(id);
            if (entity == null)
                return false;
            _dbContext.Set<OrderModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            //Add Dispose method if needed
        }

    }
}
