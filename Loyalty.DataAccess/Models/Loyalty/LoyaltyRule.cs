using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRule : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyRuleCode { get; set; }

        [StringLength(100)]
        public string LoyaltyRuleName { get; set; }
        [StringLength(2000)]
        public string Description{ get; set; }
        public bool HasCondition { get; set; }

        [ForeignKey("LoyaltyRuleGroup")]
        public Guid LoyaltyRuleGroupId { get; set; }
        public virtual LoyaltyRuleGroup LoyaltyRuleGroup { get; set; }

        [ForeignKey("LoyaltyRuleType")]
        public Guid LoyaltyRuleTypeId { get; set; }
        public virtual LoyaltyRuleType LoyaltyRuleType { get; set; }


        public virtual ICollection<LoyaltyRuleTrigger> LoyaltyRuleTriggers { get; set; }

        public virtual ICollection<LoyaltyRuleAction> LoyaltyRuleActions { get; set; }

    }
}
