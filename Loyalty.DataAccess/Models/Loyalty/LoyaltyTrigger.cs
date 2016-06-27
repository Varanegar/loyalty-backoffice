using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models
{
    public class LoyaltyTrigger : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyTriggerCode { get; set; }

        [StringLength(100)]
        public string LoyaltyTriggerName { get; set; }

        public virtual Guid LoyaltyTriggerTypeId { get; set; }
        public virtual LoyaltyTriggerType LoyaltyTriggerType { get; set; }
    }
}
