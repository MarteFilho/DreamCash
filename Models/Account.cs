﻿
using System;

namespace DreamCash.Models
{
    public class Account : Entity
    {
        public Account(Guid userId)
        {
            UserId = userId;
        }
        public long Amount { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
