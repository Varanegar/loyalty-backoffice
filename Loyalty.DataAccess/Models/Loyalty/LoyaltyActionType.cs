using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyActionType : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyActionTypeCode { get; set; }
        [StringLength(100)]
        public string LoyaltyActionTypeName { get; set; }
        public virtual ICollection<LoyaltyRuleAction> LoyaltyRuleActions { get; set; }
    }
}
