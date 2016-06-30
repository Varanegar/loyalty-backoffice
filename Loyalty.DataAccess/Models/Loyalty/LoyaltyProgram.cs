using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Models
{
    public class LoyaltyProgram : BaseModel
    {
        [StringLength(100)]
        public string LoyaltyProgramName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("LoyaltyProgramGroup")]
        public Guid LoyaltyProgramGroupId { get; set; }
        public virtual LoyaltyProgramGroup LoyaltyProgramGroup { get; set; }

        public virtual ICollection<LoyaltyProgramRule> LoyaltyProgramRules { get; set; }
    }
}
