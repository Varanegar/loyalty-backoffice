using System;
using System.Linq;
using System.Data.Entity;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyRuleTypeRepository : AnatoliRepository<LoyaltyRuleType>, ILoyaltyRuleTypeRepository
    {
        #region Ctors
        public LoyaltyRuleTypeRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyRuleTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyRuleTypeRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
