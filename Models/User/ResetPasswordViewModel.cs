
using System.ComponentModel.DataAnnotations;

namespace DreamCash.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}