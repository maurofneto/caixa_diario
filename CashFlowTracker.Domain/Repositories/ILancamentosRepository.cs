using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Enums;
using CashFlowTracker.Domain.Repositories.Base;

namespace CashFlowTracker.Domain.Repositories
{
    public interface ILancamentosRepository : IBaseRepository<Lancamento>
    {
        Task<IEnumerable<Lancamento>> GetByTipoAsync(TipoLancamento tipo);
        Task<IEnumerable<Lancamento>> GetByDateRangeAsync(DateTime dataInicio, DateTime dataFim);
    }
}
