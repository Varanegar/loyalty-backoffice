using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyTier : BaseModel
    {
        [StringLength(20)]
        public string TierCode { get; set; }
        [StringLength(100)]
        public string TierName { get; set; }
        public virtual ICollection<CustomerLoyaltyTierHistory> CustomerLoyaltyTierHistories { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
