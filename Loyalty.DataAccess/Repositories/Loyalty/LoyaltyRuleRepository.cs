using Loyalty.DataAccess.Interfaces.Loyalty;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Loyalty;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyRuleRepository : AnatoliRepository<LoyaltyRule>, ILoyaltyRuleRepository
    {
        #region Ctors
        public LoyaltyRuleRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyRuleRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyRuleRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
