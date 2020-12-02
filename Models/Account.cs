
using System;

namespace DreamCash.Models
{
    public class Account : Entity
    {
        public Account(Guid userId)
        {
            UserId = userId;
            Amount = new Random().Next(0, 3000);
        }
        public long Amount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
