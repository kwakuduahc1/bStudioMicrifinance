using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSSL.ObjectModels
{
    public class Customers
    {
        public Guid CustomersID { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(50, MinimumLength =2)]
        public string Surname { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2)]
        public string OtherNames { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2)]
        public string Residence { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 15)]
        public string MobileNumber { get; set; }

        public DateTime DateAdded { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
