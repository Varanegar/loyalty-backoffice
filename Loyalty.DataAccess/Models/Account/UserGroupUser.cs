using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.DataAccess.Models.Identity;

namespace Loyalty.DataAccess.Models.Account
{
    public class UserGroupUser : LoyaltyBaseModel
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("UserGroup")]
        public Guid UserGroupId { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}
