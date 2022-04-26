using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.Application.Interfaces
{
    public interface IWebApiOrdersDbContext
    {
        DbSet<OrderModel> Orders { get; set; }
        DbSet<RoleModel> Roles { get; set; }
        DbSet<UserModel> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
