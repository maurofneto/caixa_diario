using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowTracker.ControleLancamentos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentosService _lancamentosService;

        public LancamentosController(ILancamentosService lancamentosService)
        {
            _lancamentosService = lancamentosService;
        }

        /// <summary>
        /// Obtém todos os lançamentos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Lancamento>), 200)]
        public async Task<IActionResult> GetAllLancamentos()
        {
            var lancamentos = await _lancamentosService.GetAllAsync();
            return Ok(lancamentos);
        }

        /// <summary>
        /// Obtém um lançamento pelo ID.
        /// </summary>
        /// <param name="id">O ID do lançamento.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Lancamento), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetLancamentoById(int id)
        {
            var lancamento = await _lancamentosService.GetByIdAsync(id);
            if (lancamento == null)
                return NotFound();

            return Ok(lancamento);
        }

        /// <summary>
        /// Cria um novo lançamento.
        /// </summary>
        /// <param name="lancamento">O lançamento a ser criado.</param>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> CreateLancamento(Lancamento lancamento)
        {
            await _lancamentosService.AddAsync(lancamento);
            return CreatedAtAction(nameof(GetLancamentoById), new { id = lancamento.Id }, lancamento);
        }

        /// <summary>
        /// Atualiza um lançamento existente.
        /// </summary>
        /// <param name="id">O ID do lançamento a ser atualizado.</param>
        /// <param name="lancamento">Os dados atualizados do lançamento.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateLancamento(int id, Lancamento lancamento)
        {
            try
            {
                await _lancamentosService.UpdateAsync(lancamento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                // Lidar com exceções específicas, se necessário
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um lançamento pelo ID.
        /// </summary>
        /// <param name="id">O ID do lançamento a ser excluído.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteLancamento(int id)
        {
            await _lancamentosService.DeleteAsync(id);
            return NoContent();
        }

        // Outras ações do controlador, se necessário
    }
}
