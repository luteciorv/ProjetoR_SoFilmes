using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SoFilmes.Application.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
