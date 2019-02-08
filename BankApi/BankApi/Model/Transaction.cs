using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BankApi.Model
{
    public partial class Transaction
    {
        public long Id { get; set; }
        [StringLength(20)]
        public string IBAN { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }
        [IgnoreDataMember]
        [ForeignKey("IBAN")]
        [InverseProperty("Transaction")]
        public virtual Account IBANNavigation { get; set; }
    }
}