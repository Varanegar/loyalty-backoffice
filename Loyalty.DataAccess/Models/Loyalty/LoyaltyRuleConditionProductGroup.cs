using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleConditionProductGroup : BaseModel
    {
        [ForeignKey("LoyaltyRuleCondition")]
        public Guid LoyaltyRuleConditionId { get; set; }
        public virtual LoyaltyRuleCondition LoyaltyRuleCondition { get; set; }

        [ForeignKey("ProductGroup")]
        public Guid ProductGroupId { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }

    }
}
