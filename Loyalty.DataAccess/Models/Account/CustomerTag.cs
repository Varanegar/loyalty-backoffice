using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerTag : LoyaltyBaseModel
    {
        [StringLength(200)]
        public string TagName { get; set; }
        public int NLeft { get; set; }
        public int NRight { get; set; }
        public int NLevel { get; set; }
        public Nullable<int> Priority { get; set; }
        public Guid? ParentId { get; set; }
        public virtual ICollection<Customer> CustomerInfos { get; set; }
        public virtual ICollection<CustomerTag> CustomerTag1 { get; set; }
        [ForeignKey("ParentId")]
        public virtual CustomerTag Parent { get; set; }

    }
}
