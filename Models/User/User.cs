using System;
using System.Collections.Generic;
using DreamCash.Services;

namespace DreamCash.Models
{
    public class User
    {
        public User(string name, string document, string email, string password, string phone, DateTime birthday, string sex, string address, int accountId)
        {
            Name = name;
            Document = document;
            Email = email;
            Password = password;
            Phone = phone;
            Birthday = birthday;
            Sex = sex;
            Address = address;
            AccountId = accountId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Investiment> Investiments { get; set; }

        public void AddAccountId(int accountId)
        {
            AccountId = accountId;
        }
        public void HidePassword()
        {
            Password = "";
        }

        public void EncryptPassword()
        {
            Password = PasswordService.Encrypt(Password);
        }

        public bool Login(string password)
        {
            if (PasswordService.Compare(password, Password))
            {
                return true;
            }
            return false;
        }

        public void Update(string phone, string address)
        {
            Phone = phone;
            Address = address;
        }
    }
}
