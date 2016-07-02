using System;
using System.Linq;
using System.Data.Entity;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Interfaces.Loyalty;

using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyRuleConditionTypeRepository : AnatoliRepository<LoyaltyRuleConditionType>, ILoyaltyRuleConditionTypeRepository
    {
        #region Ctors
        public LoyaltyRuleConditionTypeRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyRuleConditionTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyRuleConditionTypeRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
