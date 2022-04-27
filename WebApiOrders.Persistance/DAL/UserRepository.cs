using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.Persistance.DAL
{
    public class UserRepository : IGenericRepository<UserModel>
    {
        private readonly WebApiOrdersDBContext _dbContext;
        public UserRepository(WebApiOrdersDBContext context)
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

        public async Task<bool> CreateAsync(UserModel entity)
        {
            //Manual validation TODO: Auto validation for Create method type of UserModel
            if (entity == null || entity.Name == null)
                return false;
            var role = await _dbContext.Set<RoleModel>().FindAsync(entity.RoleId);
            if (role == null)
                return false;
            //
            await _dbContext.Set<UserModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UserModel entity)
        {

            var user = await _dbContext.Set<UserModel>()
                .Include(r => r.Role)
                .FirstOrDefaultAsync(model => model.Id == id);
            if (user == null)
                return false;

            //Partial Update
            if (entity.Name != null)
                user.Name = entity.Name;
            if (entity.Age != 0)
                user.Age = entity.Age;
            if (entity.RoleId != 0)
            {
                var role = await _dbContext.Set<RoleModel>().FindAsync(entity.RoleId);
                if (role == null)
                    return false;
                else
                {
                    user.Role = role;
                    user.RoleId = entity.RoleId;
                }
            }

            _dbContext.Set<UserModel>().Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<UserModel>().FindAsync(id);
            if (entity == null)
                return false;
            _dbContext.Set<UserModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            //Add Dispose method if needed
        }

    }
}
