using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerTagCustomer : LoyaltyBaseModel
    {
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("CustomerTag")]
        public Guid CustomerTagId { get; set; }
        public virtual CustomerTag CustomerTag { get; set; }
    }
}
