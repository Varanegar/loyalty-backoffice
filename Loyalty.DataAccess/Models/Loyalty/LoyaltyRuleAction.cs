using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleAction : BaseModel
    {
        [ForeignKey("LoyaltyRule")]
        public Guid LoyaltyRuleId { get; set; }
        public virtual LoyaltyRule LoyaltyRule { get; set; }

        [ForeignKey("LoyaltyActionType")]
        public Guid LoyaltyActionTypeId { get; set; }
        public virtual LoyaltyActionType LoyaltyActionType { get; set; }

        [ForeignKey("LoyaltyValueTypeAttribute")]
        public Guid LoyaltyValueTypeAttributeId { get; set; }
        public virtual LoyaltyValueTypeAttribute LoyaltyValueTypeAttribute { get; set; }

        [ForeignKey("LoyaltyTier")]
        public Guid LoyaltyTierId { get; set; }
        public virtual LoyaltyTier LoyaltyTier { get; set; }

        public decimal ActionValue { get; set; }
        public float ActionPercent { get; set; }
        public decimal ActionNewValue { get; set; }
        public int CreditDay { get; set; }


    }
}
