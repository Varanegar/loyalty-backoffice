using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models
{
    //Historical, PerTransaction
    public class LoyaltyTriggerType : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyTriggerTypeCode { get; set; }

        [StringLength(100)]
        public string LoyaltyTriggerTypeName { get; set; }
        public virtual ICollection<LoyaltyTrigger> LoyaltyTriggers { get; set; }
        public virtual ICollection<LoyaltyRule> LoyaltyRules { get; set; }
    }
}
