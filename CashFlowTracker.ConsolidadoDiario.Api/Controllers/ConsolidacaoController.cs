using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTracker.ConsolidadoDiario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolidacaoController : ControllerBase
    {
        private readonly IConsolidacaoService _consolidacaoService;

        public ConsolidacaoController(IConsolidacaoService consolidacaoService)
        {
            _consolidacaoService = consolidacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetConsolidacao(DateTime dataInicio, DateTime dataFim)
        {
            if (dataInicio >= dataFim)
                return BadRequest("A data de início deve ser anterior à data de fim.");

            var consolidados = await _consolidacaoService.ConsolidarLancamentosAsync(dataInicio, dataFim);

            return Ok(consolidados);
        }
    }
}
