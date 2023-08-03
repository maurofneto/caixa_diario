using CashFlowTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowTracker.Domain.Services.Interfaces
{
    public interface IConsolidacaoService
    {
        Task<IEnumerable<SaldoConsolidado>> ConsolidarLancamentosAsync(DateTime dataInicio, DateTime dataFim);
    }
}
