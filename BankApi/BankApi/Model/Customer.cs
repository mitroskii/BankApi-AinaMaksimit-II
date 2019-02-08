using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BankApi.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public long BankId { get; set; }
        public string Password { get; set; }
        [IgnoreDataMember]
        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public virtual Bank Bank { get; set; }
        [IgnoreDataMember]
        [InverseProperty("BankNavigation")]
        public virtual ICollection<Account> Account { get; set; }
    }
}