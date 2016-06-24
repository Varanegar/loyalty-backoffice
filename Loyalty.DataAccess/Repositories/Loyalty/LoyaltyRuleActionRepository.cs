using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyRuleActionRepository : AnatoliRepository<LoyaltyRuleAction>, ILoyaltyRuleActionRepository
    {
        #region Ctors
        public LoyaltyRuleActionRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyRuleActionRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyRuleActionRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
