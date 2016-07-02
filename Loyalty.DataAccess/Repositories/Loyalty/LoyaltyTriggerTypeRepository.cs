using System;
using System.Linq;
using System.Data.Entity;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyTriggerTypeRepository : AnatoliRepository<LoyaltyTriggerType>, ILoyaltyTriggerTypeRepository
    {
        #region Ctors
        public LoyaltyTriggerTypeRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyTriggerTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyTriggerTypeRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
