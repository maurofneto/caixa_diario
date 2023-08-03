using CashFlowTracker.Domain.Enums;

namespace CashFlowTracker.Web.Models
{
    public class LancamentosIndexViewModel
    {
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public TipoLancamento Tipo { get; set; }
        public string Categoria { get; set; }
        public IEnumerable<LancamentoViewModel> Lancamentos { get; set; }
    }
}
