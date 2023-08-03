namespace CashFlowTracker.Web.Models
{
    public class ConsolidacaoIndexViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IEnumerable<SaldoConsolidadoViewModel> Saldos { get; set; }
    }
}
