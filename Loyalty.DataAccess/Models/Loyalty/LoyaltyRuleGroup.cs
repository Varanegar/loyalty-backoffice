using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyRuleGroup : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyRuleGroupCode { get; set; }

        [StringLength(100)]
        public string LoyaltyRuleGroupName { get; set; }

        public virtual ICollection<LoyaltyRule> LoyaltyRules { get; set; }

    }
}
