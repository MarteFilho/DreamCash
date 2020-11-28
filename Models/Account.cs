
namespace DreamCash.Models
{
    public class Account
    {
        public Account(int userId)
        {
            UserId = userId;
        }

        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
