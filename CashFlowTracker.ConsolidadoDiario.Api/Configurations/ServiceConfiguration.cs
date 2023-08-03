using CashFlowTracker.Domain.Repositories;
using CashFlowTracker.Domain.Services.Implementations;
using CashFlowTracker.Domain.Services.Interfaces;
using CashFlowTracker.Infrastructure.SqLite.Repositories;

namespace CashFlowTracker.ConsolidadoDiario.Api.Configurations
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILancamentosService, LancamentosService>();
            services.AddScoped<IConsolidacaoService, ConsolidacaoService>();
        }

        public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILancamentosRepository, LancamentosRepository>();
        }
    }
}
