using System;

namespace DreamCash.Models
{
    public class Transaction : Entity
    {
        public Transaction(string name, Guid userId, Guid accountId, Guid investimentId, decimal value, DateTime investimentDate)
        {
            Name = name;
            UserId = userId;
            AccountId = accountId;
            InvestimentId = investimentId;
            Value = value;
            InvestimentDate = investimentDate;
        }

        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid AccountId { get; set; }
        public Account Account { get; set; }
        public Guid InvestimentId { get; set; }
        public Investiment Investiment { get; set; }
        public decimal Value { get; set; }
        public DateTime InvestimentDate { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
