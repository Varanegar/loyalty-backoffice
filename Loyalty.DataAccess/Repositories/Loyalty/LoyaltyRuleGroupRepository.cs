using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models.Loyalty;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories.Loyalty
{
    public class LoyaltyRuleGroupRepository : AnatoliRepository<LoyaltyRuleGroup>, ILoyaltyRuleGroupRepository
    {
        #region Ctors
        public LoyaltyRuleGroupRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyRuleGroupRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyRuleGroupRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
