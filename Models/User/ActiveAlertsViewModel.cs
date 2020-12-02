using System;
using System.ComponentModel.DataAnnotations;

namespace DreamCash.Models
{
    public class ActiveAlertsViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool AlertInvestments { get; set; }
        [Required]
        public bool AlertTransfers { get; set; }

    }
}