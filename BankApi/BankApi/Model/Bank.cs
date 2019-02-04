﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

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
        [Required]
        [StringLength(10)]
        public string BIC { get; set; }

        [IgnoreDataMember]
        [InverseProperty("Bank")]
        public virtual ICollection<Account> Account { get; set; }
        [IgnoreDataMember]
        [InverseProperty("Bank")]
        public virtual ICollection<Customer> Customer { get; set; }
    }
}