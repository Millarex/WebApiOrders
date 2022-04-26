using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiOrders.Application.Interfaces;

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
            return services;
        }
    }
}
