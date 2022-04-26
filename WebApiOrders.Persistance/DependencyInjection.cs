using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;
using WebApiOrders.Persistance.DAL;

namespace WebApiOrders.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<WebApiOrdersDBContext>(options =>
                    options.UseNpgsql(connectionString));

            services.AddScoped<IWebApiOrdersDbContext>(provider =>
               provider.GetService<WebApiOrdersDBContext>());

            services.AddScoped<IGenericRepository<UserModel>, UserRepository>();
            services.AddScoped<IGenericRepository<OrderModel>, OrderRepository>();
            return services;
        }
    }
}
