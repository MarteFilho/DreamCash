using System;

namespace DreamCash.Models
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
    }
}