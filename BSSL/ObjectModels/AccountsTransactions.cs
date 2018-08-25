using System;
using System.ComponentModel.DataAnnotations;

namespace BSSL.ObjectModels
{
    public class AccountsTransactions
    {
        public Guid AccountsTransactionsID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public Guid AccountsID { get; set; }

        public DateTime TransactionDate { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual Accounts Accounts { get; set; }
    }
}
