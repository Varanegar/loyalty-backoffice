using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyProgramGroup : BaseModel
    {
        [StringLength(20)]
        public string LoyaltyProgramGroupCode { get; set; }

        [StringLength(100)]
        public string LoyaltyProgramGroupName { get; set; }

        public virtual ICollection<LoyaltyProgram> LoyaltyPrograms { get; set; }

    }
}
