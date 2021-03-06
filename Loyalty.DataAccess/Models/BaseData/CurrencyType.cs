namespace Loyalty.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CurrencyType : LoyaltyBaseModel
    {
        //public int CurrencyType.Id { get; set; }
        [StringLength(100)]
        public string CurrencyTypeName { get; set; }
        public bool IsDefault { get; set; }
    }
}
