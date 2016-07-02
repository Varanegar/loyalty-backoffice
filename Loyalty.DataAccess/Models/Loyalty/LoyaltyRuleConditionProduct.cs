using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleConditionProduct : BaseModel
    {
        [ForeignKey("LoyaltyRuleCondition")]
        public Guid LoyaltyRuleConditionId { get; set; }
        public virtual LoyaltyRuleCondition LoyaltyRuleCondition { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
