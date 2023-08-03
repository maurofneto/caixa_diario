using CashFlowTracker.Web.Configurations;
using CashFlowTracker.Web.Models;
using Microsoft.Extensions.Options;

namespace CashFlowTracker.Web.Services
{
    public class ConsolidacaoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUriConsolidacao;

        public ConsolidacaoService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _baseUriConsolidacao = appSettings.Value.BaseUriConsolidacao;
        }

        public async Task<IEnumerable<SaldoConsolidadoViewModel>> GetConsolidadoAsync(DateTime dataInicio, DateTime dataFim)
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<SaldoConsolidadoViewModel>>(
                $"{_baseUriConsolidacao}?dataInicio={dataInicio:yyyy-MM-dd}&dataFim={dataFim:yyyy-MM-dd}");
            return response;
        }
    }
}
