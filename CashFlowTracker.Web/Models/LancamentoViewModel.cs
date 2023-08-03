using CashFlowTracker.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CashFlowTracker.Web.Models
{
    public class LancamentoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo Data é obrigatório.")]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
        [Display(Name = "Tipo de Lançamento")]
        public TipoLancamento Tipo { get; set; }

        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        public string Categoria { get; set; }
    }
}
