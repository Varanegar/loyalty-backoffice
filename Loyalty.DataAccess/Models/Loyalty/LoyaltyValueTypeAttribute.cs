using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyValueTypeAttribute : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyValueTypeAttributeCode { get; set; }

        [StringLength(100)]
        public string LoyaltyValueTypeAttributeName { get; set; }

        public Guid LoyaltyValueTypeId { get; set; }
        public virtual LoyaltyValueType LoyaltyValueType { get; set; }
    }
}
