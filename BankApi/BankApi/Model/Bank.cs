﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApi.Model
{
    public partial class Bank
    {
        public Bank()
        {
            Account = new HashSet<Account>();
            Customer = new HashSet<Customer>();
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(8)]
        public string BIC { get; set; }

        [InverseProperty("Bank")]
        public virtual ICollection<Account> Account { get; set; }
        [InverseProperty("Bank")]
        public virtual ICollection<Customer> Customer { get; set; }
    }
}