using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Infrastructure.Persistence.Context;
using SoFilmes.Infrastructure.Persistence.Repositories;

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

            // Repositórios
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMovieGenreRepository, MovieGenreRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
