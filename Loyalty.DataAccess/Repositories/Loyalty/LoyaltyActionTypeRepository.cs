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
    public class LoyaltyActionTypeRepository : AnatoliRepository<LoyaltyActionType>, ILoyaltyActionTypeRepository
    {
        #region Ctors
        public LoyaltyActionTypeRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyActionTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyActionTypeRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
