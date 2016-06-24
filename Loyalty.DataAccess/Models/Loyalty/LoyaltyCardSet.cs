using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Anatoli.Common.DataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty.DataAccess.Models.Loyalty
{
    public class LoyaltyCardSet : BaseModel
    {
        [StringLength(100)]
        public string LoyaltyCardSetName { get; set; }
        public int Seed { get; set; }
        public long CurrentNo { get; set; }
        public string Initialtext { get; set; }
        [ForeignKey("LoyaltyCardSetGenerateType")]
        public Guid LoyaltyCardSetGenerateTypeId { get; set; }
        public LoyaltyCardSetGenerateType LoyaltyCardSetGenerateType { get; set; }
        public virtual ICollection<LoyaltyCardBatch> LoyaltyCardBatchs { get; set; }
        public virtual ICollection<LoyaltyCard> LoyaltyCards { get; set; }
    }
}
