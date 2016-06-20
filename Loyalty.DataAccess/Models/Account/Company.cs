using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Account
{
    public class Company : LoyaltyBaseModel
    {
        public int CompanyCode { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        public virtual ICollection<CompanyCenter> CompanyCenters { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        [ForeignKey("AnatoliAccount")]
        public Nullable<Guid> AnatoliAccountId { get; set; }
        public virtual AnatoliAccount AnatoliAccount { get; set; }
    }
}
