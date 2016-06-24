using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models
{
    public class LoyaltyCardSetGenerateType : BaseModel
    {
        [StringLength(100)]
        public string LoyaltyCardSetGenerateTypeName { get; set; }
    }
}
