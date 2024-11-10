using ApiTic.Business.Interfaces;
using ApiTic.Business.Notificações;
using ApiTic.Business.Services;
using ApiTic.Data.Context;
using ApiTic.Data.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ApiTic.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Data
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ITipoDeProdutoRepository, TipoDeProdutoRepository>();


            //Business
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<ITipoDeProdutoService, TipoDeProdutoService>();



            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
