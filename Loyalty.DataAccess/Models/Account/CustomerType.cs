using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerType : BaseModel
    {
        [StringLength(100)]
        public string CustomerTypeName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
