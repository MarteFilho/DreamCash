
namespace DreamCash.Models
{
    public class Account
    {
        public Account(decimal amount, int userId)
        {
            Amount = amount;
            UserId = userId;
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
