using CashFlowTracker.Web.Services;
using Microsoft.Extensions.Configuration;

namespace CashFlowTracker.Web.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("ApiConfig"));
            services.AddHttpClient();

            // Registro dos serviços no contêiner de injeção de dependências
            services.AddScoped<LancamentosService>();
            services.AddScoped<ConsolidacaoService>();

            // outros serviços e configurações...
        }
    }
}
