using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleConditionValue : BaseModel
    {
        [ForeignKey("LoyaltyRuleCondition")]
        public Guid LoyaltyRuleConditionId { get; set; }
        public virtual LoyaltyRuleCondition LoyaltyRuleCondition { get; set; }


        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
        public decimal StepValue { get; set; }

    }
}
