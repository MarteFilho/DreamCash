using System.ComponentModel.DataAnnotations;

namespace DreamCash.Models
{
    public class CreateInvestmentViewModel
    {
        [Required(ErrorMessage = "Favor inserir um tipo de investimento!")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Favor inserir uma descrição do investimento!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Favor inserir o valor mínimo para o investimento!")]
        public long MinimumValue { get; set; }
    }
}