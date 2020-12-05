using System;

namespace DreamCash.Models
{
    public class CreateTransactionViewModel
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public Guid InvestimentId { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}