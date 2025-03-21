using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Profiles;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using ViperHub.Infrastructure.Repository;

namespace ViperHub.IOC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {


            services.AddAutoMapper(typeof(CategoryProfile));
            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddDbContext<ViperHubContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoriaForo, CategoriaForoRepository>();
            services.AddScoped<IClanes, ClaneRepository>();
            services.AddScoped<IComentariosForo, ComentarioForoRepository>();
            services.AddScoped<IEquiposTorneos, EquiposTorneoRepository>();
            services.AddScoped<IMultimedium,   MultimediumRepository>();
            services.AddScoped<ITemasForo, TemasForoRepository>();
            services.AddScoped<ITorneos, TorneoRepository>();
            services.AddScoped<IUsuariosClan, UsuarioClaneRepository>();
            services.AddScoped<IUsuario, UsuarioRepository>();

            // services.

            return services;

        }
    }
}
