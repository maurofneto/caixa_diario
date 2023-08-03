using CashFlowTracker.Domain.Entities.Base;
using CashFlowTracker.Domain.Enums;

namespace CashFlowTracker.Domain.Entities
{
    public class Lancamento : IBaseEntity
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public TipoLancamento Tipo { get; set; }
    }
}
