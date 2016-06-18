namespace Loyalty.DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product : AnatoliBaseModel
    {
        [StringLength(20)]
        public string ProductCode { get; set; }
        [StringLength(20)]
        public string Barcode { get; set; }
        [StringLength(200)]
        public string ProductName { get; set; }
        [StringLength(200)]
        public string StoreProductName { get; set; }
        public Nullable<decimal> PackVolume { get; set; }
        public Nullable<decimal> PackWeight { get; set; }
        [DefaultValue(1)]
        public decimal QtyPerPack { get; set; }
        public Nullable<long> TaxCategoryValueId { get; set; }
        [StringLength(500)]
        public string Desctription { get; set; }
        [ForeignKey("ProductGroup")]
        public Nullable<Guid> ProductGroupId { get; set; }
        [ForeignKey("ProductType")]
        public Guid ProductTypeId { get; set; }
        public double ProductRate { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual bool IsActiveInOrder { get; set; }
    }
}
