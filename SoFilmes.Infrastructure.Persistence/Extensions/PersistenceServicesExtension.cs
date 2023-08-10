using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoFilmes.Infrastructure.Persistence.Context;

namespace SoFilmes.Infrastructure.Persistence.Extensions
{
    public static class PersistenceServicesExtension
    {
        public static void ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(config =>
            {
                var connectionString = configuration.GetConnectionString("MySql");
                config.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }
    }
}
