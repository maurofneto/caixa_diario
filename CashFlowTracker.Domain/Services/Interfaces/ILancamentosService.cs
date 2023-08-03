using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Enums;
using CashFlowTracker.Domain.Services.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowTracker.Domain.Services.Interfaces
{
    public interface ILancamentosService : IBaseService<Lancamento>
    {
        Task<IEnumerable<Lancamento>> GetByTipoAsync(TipoLancamento tipo);
    }
}
