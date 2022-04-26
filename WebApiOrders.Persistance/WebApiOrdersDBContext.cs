using Microsoft.EntityFrameworkCore;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.Persistance
{
    public class WebApiOrdersDBContext : DbContext, IWebApiOrdersDbContext
    {
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public WebApiOrdersDBContext(DbContextOptions<WebApiOrdersDBContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Add default user Roles
            builder.Entity<RoleModel>().HasData(
              new RoleModel[]
              {
                    new RoleModel { Id=1, Name="Admin"},
                    new RoleModel { Id=2, Name="User"}
              });
            base.OnModelCreating(builder);
        }
    }
}
