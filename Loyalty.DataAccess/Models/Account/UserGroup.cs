using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.DataAccess.Models.Account
{
    public class UserGroup : LoyaltyBaseModel
    {
        [StringLength(20)]
        public string UserGroupCode { get; set; }

        [StringLength(100)]
        public string UserGroupName { get; set; }
    }
}
