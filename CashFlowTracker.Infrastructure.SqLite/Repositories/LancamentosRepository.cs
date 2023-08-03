using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Enums;
using CashFlowTracker.Domain.Repositories;
using CashFlowTracker.Infrastructure.SqLite.Context;
using CashFlowTracker.Infrastructure.SqLite.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CashFlowTracker.Infrastructure.SqLite.Repositories
{
    public class LancamentosRepository : BaseRepository<Lancamento>, ILancamentosRepository
    {
        public LancamentosRepository(
            AppDbContext appDbContext)
            : base(appDbContext)
        {

        }

        public async Task<IEnumerable<Lancamento>> GetByTipoAsync(TipoLancamento tipo)
        {
            return await _dbSet.Where(l => l.Tipo == tipo).ToListAsync();
        }

        public async Task<IEnumerable<Lancamento>> GetByDateRangeAsync(DateTime dataInicio, DateTime dataFim)
        {
            return await _context.Lancamentos
                .Where(l => l.Data >= dataInicio && l.Data <= dataFim)
                .ToListAsync();
        }
    }
}
