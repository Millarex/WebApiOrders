using Microsoft.Extensions.DependencyInjection;
using WebApiOrders.Application.DAL;
using WebApiOrders.Application.Interfaces;
using WebApiOrders.Domain.Data;

namespace WebApiOrders.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
          this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<UserModel>, UserRepository>();
            services.AddScoped<IGenericRepository<OrderModel>, OrderRepository>();
            return services;
        }
    }
}
