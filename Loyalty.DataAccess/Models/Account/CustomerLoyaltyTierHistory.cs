using System;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerLoyaltyTierHistory : BaseModel
    {
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey("LoyaltyTier")]
        public Guid LoyaltyTierId { get; set; }
        public virtual LoyaltyTier LoyaltyTier { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}
