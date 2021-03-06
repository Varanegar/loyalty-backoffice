using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Models
{
    public class LoyaltyCard : BaseModel
    {
        public string CardNo { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime GenerateDate { get; set; }
        public DateTime? AssignDate { get; set; }
        public bool IsActive { get; set; }
        public Nullable<Guid> CancelReason { get; set; }
        [ForeignKey("LoyaltyCardSet")]
        public Guid LoyaltyCardSetId { get; set; }
        [ForeignKey("LoyaltyCardBatch")]
        public Nullable<Guid> LoyaltyCardBatchId { get; set; }
        [ForeignKey("Customer")]
        public Nullable<Guid> CustomerId { get; set; }
        [ForeignKey("LoyaltyCardStatus")]
        public Guid LoyaltyCardStatusId { get; set; }
        public virtual LoyaltyCardSet LoyaltyCardSet { get; set; }
        public virtual LoyaltyCardBatch LoyaltyCardBatch { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual LoyaltyCardStatus LoyaltyCardStatus { get; set; }

    }
}
