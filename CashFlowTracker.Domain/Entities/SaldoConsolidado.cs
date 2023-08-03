using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowTracker.Domain.Entities
{
    public class SaldoConsolidado
    {
        public DateTime Data { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal Saldo { get; set; }
        public decimal SaldoInicial { get; set; }
        public List<Lancamento> LancamentosRealizados { get; set; }
    }
}
