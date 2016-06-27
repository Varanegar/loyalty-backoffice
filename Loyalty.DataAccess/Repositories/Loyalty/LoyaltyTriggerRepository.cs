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
    public class LoyaltyTriggerRepository : AnatoliRepository<LoyaltyTrigger>, ILoyaltyTriggerRepository
    {
        #region Ctors
        public LoyaltyTriggerRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyTriggerRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyTriggerRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }

        #endregion
    }
}
