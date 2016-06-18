using Anatoli.DataAccess.Models;
using Loyalty.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loyalty.DataAccess.Models
{
    public class Company : AnatoliBaseModel
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
