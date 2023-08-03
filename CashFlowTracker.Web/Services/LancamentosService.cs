using CashFlowTracker.Web.Configurations;
using CashFlowTracker.Web.Models;
using Microsoft.Extensions.Options;

namespace CashFlowTracker.Web.Services
{
    public class LancamentosService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUriLancamentos;

        public LancamentosService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _baseUriLancamentos = appSettings.Value.BaseUriLancamentos;
        }

        public async Task<IEnumerable<LancamentoViewModel>> GetLancamentosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<LancamentoViewModel>>(_baseUriLancamentos);
            return response;
        }

        public async Task CreateLancamentoAsync(LancamentoViewModel lancamento)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUriLancamentos, lancamento);
            response.EnsureSuccessStatusCode();
        }
    }
}
