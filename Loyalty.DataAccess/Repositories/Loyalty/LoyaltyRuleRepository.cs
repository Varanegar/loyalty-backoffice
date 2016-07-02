using Loyalty.DataAccess.Interfaces.Loyalty;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Loyalty;

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
        #endregion
    }
}
