using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSSL.ObjectModels
{
    public class AccountTypes
    {
        public Guid AccountTypesID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string AccountType { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}