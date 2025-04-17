using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ViperHub.Application.Interfaces;
using ViperHub.Application.Interfaces.Service;
using ViperHub.Application.Profiles;
using ViperHub.Application.Services;
using ViperHub.Domain.Models;
using ViperHub.Infrastructure.Persistence;
using ViperHub.Infrastructure.RepoInterfaces;
using ViperHub.Infrastructure.Repository;

namespace ViperHub.IOC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ViperHubContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryForoContract, CategoryForoService>();
            
            services.AddScoped<IClanesContract, ClaneService>();
            services.AddScoped<IComentariosForoContract, ComentarioForoService>();
            services.AddScoped<IEquiposTorneosContract, EquiposTorneoService>();
            services.AddScoped<IMultimediumContract, MultimediumService>();
            services.AddScoped<ITemasForoContract, TemasForoService>();
            services.AddScoped<ITorneosContract, TournamentService>();
            services.AddScoped<IUsuariosClanContract, TeamsService>();
            services.AddScoped<IUsuarioContract, UserService>();
            
            // services.



            //services.AddAutoMapper(typeof(CategoryProfile));
            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection infraestructure, IConfiguration configuration)
        {

            infraestructure.AddDbContext<ViperHubContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            infraestructure.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

            infraestructure.AddScoped<ICategoriaForo, CategoriaForoRepository>();
            infraestructure.AddScoped<IClanes, ClaneRepository>();
            infraestructure.AddScoped<IComentariosForo, ComentarioForoRepository>();
            infraestructure.AddScoped<IEquiposTorneos, EquiposTorneoRepository>();
            infraestructure.AddScoped<IMultimedium, MultimediumRepository>();
            infraestructure.AddScoped<ITemasForo, TemasForoRepository>();
            infraestructure.AddScoped<ITorneos, TorneoRepository>();
            infraestructure.AddScoped<IUsuariosClan, UsuarioClaneRepository>();
            infraestructure.AddScoped<IUsuario, UsuarioRepository>();

            // services.

            return infraestructure;

        }

    }
}
