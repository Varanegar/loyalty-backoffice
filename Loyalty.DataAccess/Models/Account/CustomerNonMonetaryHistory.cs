using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.DataAccess.Models.Identity;

namespace Loyalty.DataAccess.Models.Account
{
    public class CustomerNonMonetaryHistory : LoyaltyBaseModel
    {
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime ActivityDate { get; set; }
        public string ActivityPDate { get; set; }

        [StringLength(500)]
        public string ActivityDesc { get; set; }

        [StringLength(500)]
        public string PlaceDesc { get; set; }

        [StringLength(100)]
        public string TerminalDesc { get; set; }

        [StringLength(500)]
        public string Description { get; set; }


    }
}
