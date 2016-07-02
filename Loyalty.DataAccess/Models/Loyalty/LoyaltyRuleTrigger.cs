using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;



namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleTrigger : LoyaltyBaseModel
    {
        [ForeignKey("LoyaltyRule")]
        public Guid LoyaltyRuleId { get; set; }
        public virtual LoyaltyRule LoyaltyRule { get; set; }

        [ForeignKey("LoyaltyTrigger")]
        public Guid LoyaltyTriggerId { get; set; }
        public virtual LoyaltyTrigger LoyaltyTrigger { get; set; }
    }
}
