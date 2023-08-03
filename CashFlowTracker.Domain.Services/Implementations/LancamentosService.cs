using CashFlowTracker.Domain.Entities;
using CashFlowTracker.Domain.Enums;
using CashFlowTracker.Domain.Repositories;
using CashFlowTracker.Domain.Services.Implementations.Base;
using CashFlowTracker.Domain.Services.Interfaces;

namespace CashFlowTracker.Domain.Services.Implementations
{
    public class LancamentosService : BaseService<Lancamento>, ILancamentosService
    {
        private readonly ILancamentosRepository lancamentosRepository;

        public LancamentosService(
            ILancamentosRepository lancamentosRepository) 
            : base(lancamentosRepository)
        {
            this.lancamentosRepository = lancamentosRepository;
        }

        // Métodos específicos do serviço (se houver) podem ser adicionados aqui.

        public async Task<IEnumerable<Lancamento>> GetByTipoAsync(TipoLancamento tipo)
        {
            // Aqui você pode adicionar lógica adicional específica do serviço, se necessário.
            return await lancamentosRepository.GetByTipoAsync(tipo);
        }
    }
}
