using System;

namespace DreamCash.Models
{
    public class UserUpdateViewModel
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}