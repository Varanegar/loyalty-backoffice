using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerGroup : LoyaltyBaseModel
    {
        [StringLength(200)]
        public string GroupName { get; set; }
        public int NLeft { get; set; }
        public int NRight { get; set; }
        public int NLevel { get; set; }
        public Nullable<int> Priority { get; set; }
        public Guid? ParentId { get; set; }
        public virtual ICollection<Customer> CustomerInfos { get; set; }
        public virtual ICollection<CustomerGroup> CustomerGroup1 { get; set; }
        [ForeignKey("ParentId")]
        public virtual CustomerGroup Parent { get; set; }
    }
}
