using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Loyalty.DataAccess.Models
{
    public class ProductType : AnatoliBaseModel
    {
        [StringLength(100)]
        public string ProductTypeName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
