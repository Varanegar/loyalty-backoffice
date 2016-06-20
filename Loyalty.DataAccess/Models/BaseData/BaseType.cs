namespace Loyalty.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;  
      
    public class BaseType : LoyaltyBaseModel
    {
        //public int BaseTypeId { get; set; }
        [StringLength(500)]
        public string BaseTypeDesc { get; set; }
        [StringLength(100)]
        public string BaseTypeName { get; set; }

        public virtual ICollection<BaseValue> BaseValues { get; set; }

    }
}
