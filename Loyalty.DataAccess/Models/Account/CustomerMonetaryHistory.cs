using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.DataAccess.Models.Identity;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerMonetaryHistory : LoyaltyBaseModel
    {
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime TransactionDate { get; set; }
        public string TransactionPDate { get; set; }

        [StringLength(500)]
        public string TransactionDesc { get; set; }

        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Discount { get; set; }

        [StringLength(500)]
        public string PlaceDesc { get; set; }

        [StringLength(100)]
        public string TerminalDesc { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
