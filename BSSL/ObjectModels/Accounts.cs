using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSSL.ObjectModels
{
    public class Accounts
    {
        public Guid AccountsID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 10)]
        public string AccountNumber { get; set; }

        [Required]
        public Guid CustomerID { get; set; }

        public DateTime DateCreated { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public Guid AccountTypesID { get; set; }

        public virtual Customers Customers { get; set; }

        public virtual AccountTypes AccountTypes { get; set; }

        public virtual ICollection<AccountsTransactions> AccountsTransactions { get; set; }
    }
}