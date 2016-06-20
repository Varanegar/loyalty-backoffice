using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerGroupCustomer : LoyaltyBaseModel
    {
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("CustomerGroup")]
        public Guid CustomerGroupId { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
    }
}
