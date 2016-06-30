using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Models
{
    public class LoyaltyValueType : BaseModel
    {
        [StringLength(100)]
        public string LoyaltyValueTypeName { get; set; }
        public virtual ICollection<LoyaltyValueTypeAttribute> LoyaltyValueTypeAttributes { get; set; }
    }
}
