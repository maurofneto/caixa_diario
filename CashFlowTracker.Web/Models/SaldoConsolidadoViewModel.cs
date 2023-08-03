namespace CashFlowTracker.Web.Models
{
    public class SaldoConsolidadoViewModel
    {
        public DateTime Data { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoInicial { get; set; }
        public IEnumerable<LancamentoViewModel> LancamentosRealizados { get; set; }
    }
}
