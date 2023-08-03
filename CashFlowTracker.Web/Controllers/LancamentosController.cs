using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Web.Models;
using CashFlowTracker.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTracker.Web.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly LancamentosService _lancamentosService;

        public LancamentosController(LancamentosService lancamentosService)
        {
            _lancamentosService = lancamentosService;
        }

        public async Task<IActionResult> Index()
        {
            var lancamentos = await _lancamentosService.GetLancamentosAsync();
            return View(lancamentos.OrderByDescending(l => l.Data));
        }

        [HttpGet]
        public IActionResult CriarLancamento()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarLancamento(LancamentoViewModel lancamento)
        {
            if (ModelState.IsValid)
            {
                await _lancamentosService.CreateLancamentoAsync(lancamento);
                return RedirectToAction(nameof(Index));
            }

            return View(lancamento);
        }

        [HttpPost]
        public async Task<IActionResult> CriarLancamento(LancamentosIndexViewModel lancamentoVM)
        {
            if (ModelState.IsValid)
            {
                // Crie um novo objeto Lancamento usando os dados da ViewModel
                var novoLancamento = new Lancamento
                {
                    Data = lancamentoVM.Data,
                    Valor = lancamentoVM.Valor,
                    Tipo = lancamentoVM.Tipo,
                    Categoria = lancamentoVM.Categoria
                };

                // Chame o método do serviço para criar o lançamento
                await _lancamentosService.CriarLancamentoAsync(novoLancamento);

                // Redirecionar de volta para a página Index com os filtros de data
                return RedirectToAction("Index", new { dataInicio = lancamentoVM.Data, dataFim = lancamentoVM.Data });
            }

            // Se o modelo não for válido, retorne para a página Index exibindo os erros
            // ou implemente a lógica de tratamento de erros conforme necessário
            return RedirectToAction("Index");
        }

        // Outros métodos do controller, como EditarLancamento, ExcluirLancamento, etc.
    }
}
