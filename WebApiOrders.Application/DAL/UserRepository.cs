using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.Application.DAL
{
    public class UserRepository : IGenericRepository<UserModel>
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            return await _dbContext.Set<UserModel>()
                .Include(p => p.Orders)
                .Include(r => r.Role)
                .ToListAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            return await _dbContext.Set<UserModel>()
                .Include(p => p.Orders)
                .Include(r => r.Role)
                .FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task CreateAsync(UserModel entity)
        {
            await _dbContext.Set<UserModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserModel entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<UserModel>().FindAsync(id);
            _dbContext.Set<UserModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            //Add Dispose method if needed
        }

    }
}
