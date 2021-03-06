using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Models
{
    //Historical, PerTransaction
    public class LoyaltyRuleType : BaseModel
    {
        [StringLength(100)]
        public string LoyaltyRuleTypeName { get; set; }
        public virtual ICollection<LoyaltyRule> LoyaltyRules { get; set; }
    }
}
