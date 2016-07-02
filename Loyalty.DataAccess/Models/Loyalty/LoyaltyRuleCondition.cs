using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleCondition : BaseModel
    {
        [ForeignKey("LoyaltyRule")]
        public Guid LoyaltyRuleId { get; set; }
        public virtual LoyaltyRule LoyaltyRule { get; set; }

        [ForeignKey("LoyaltyValueTypeAttribute")]
        public Guid LoyaltyValueTypeAttributeId { get; set; }
        public virtual LoyaltyValueTypeAttribute LoyaltyValueTypeAttribute { get; set; }

        public virtual ICollection<LoyaltyRuleConditionProductGroup> LoyaltyRuleConditionProductGroups { get; set; }
        public virtual ICollection<LoyaltyRuleConditionProduct> LoyaltyRuleConditionProducts { get; set; }
        public virtual ICollection<LoyaltyRuleConditionValue> LoyaltyRuleConditionValues { get; set; }

    }
}
