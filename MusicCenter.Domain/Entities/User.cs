﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCenter.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public ICollection<UserCartProduct> CartProducts { get; set; } = new HashSet<UserCartProduct>();

        public ICollection<UseCaseLog> UseCaseLogs { get; set; } = new HashSet<UseCaseLog>();
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
