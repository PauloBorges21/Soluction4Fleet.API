using RT.Comb;
using Soluction4Fleet.API.Application.Auth.Services;
using Soluction4Fleet.API.Application.Interfaces.Repository;
using Soluction4Fleet.API.Application.Interfaces.Services;
using Soluction4Fleet.API.Application.Services;
using Soluction4Fleet.API.Domain;
using Soluction4Fleet.API.Infrastructure.Repositories;

namespace Soluction4Fleet.API.Presentation.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMontadoraService, MontadoraService>();
            services.AddScoped<IMontadoraRepository, MontadoraRepository>();
            services.AddScoped<ILocadoraService, LocadoraService>();
            services.AddScoped<ILocadoraRepository, LocadoraRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IFrotaLocadoraService, FrotaLocadoraService>();
            services.AddScoped<IFrotaLocadoraRepository, FrotaLocadoraRepository>();
            services.AddScoped<IRelatorioService, RelatorioService>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddSingleton<ICombProvider>(Provider.Sql);
            // Configura AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
