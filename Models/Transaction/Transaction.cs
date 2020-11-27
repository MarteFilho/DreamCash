using System;

namespace DreamCash.Models
{
    public class Transaction
    {
        public Transaction(string name, int userId, int accountId, int investimentId, decimal value, DateTime investimentDate)
        {
            Name = name;
            UserId = userId;
            AccountId = accountId;
            InvestimentId = investimentId;
            Value = value;
            InvestimentDate = investimentDate;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int InvestimentId { get; set; }
        public Investiment Investiment { get; set; }
        public decimal Value { get; set; }
        public DateTime InvestimentDate { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
