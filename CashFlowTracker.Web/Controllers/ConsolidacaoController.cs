using CashFlowTracker.Web.Models;
using CashFlowTracker.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTracker.Web.Controllers
{
    public class ConsolidacaoController : Controller
    {
        private readonly ConsolidacaoService _consolidacaoService;
        
        public ConsolidacaoController(ConsolidacaoService consolidacaoService)
        {
            _consolidacaoService = consolidacaoService;
        }

        public async Task<IActionResult> Index(DateTime? dataInicio, DateTime? dataFim)
        {
            // Se as datas de início e fim não forem informadas, utilize as datas padrão do mês atual
            if (!dataInicio.HasValue)
                dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            if (!dataFim.HasValue)
                dataFim = dataInicio.Value.AddMonths(1).AddSeconds(-1);

            // Obter os saldos consolidados com base nas datas informadas
            var saldosConsolidados = await _consolidacaoService.GetConsolidadoAsync(dataInicio.Value, dataFim.Value);

            // Criar a ViewModel para a página com os saldos e as datas de filtro
            var viewModel = new ConsolidacaoIndexViewModel
            {
                DataInicio = dataInicio.Value,
                DataFim = dataFim.Value,
                Saldos = saldosConsolidados
            };

            return View(viewModel);
        }
    }
}
