using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerTransactionHistory : LoyaltyBaseModel
    {
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("LoyaltyValueType")]
        public Guid LoyaltyValueTypeId { get; set; }
        public virtual LoyaltyValueType LoyaltyValueType { get; set; }
       
        public DateTime TransactionDate { get; set; }
        [StringLength(10)]
        public string TransactionPDate { get; set; }
  
        [StringLength(500)]
        public string Description { get; set; }
        public decimal IncreaseValue { get; set; }
        public decimal DecreaseValue { get; set; }

    }
}
