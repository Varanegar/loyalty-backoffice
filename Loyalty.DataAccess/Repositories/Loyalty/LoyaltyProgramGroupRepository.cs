using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyProgramGroupRepository : AnatoliRepository<LoyaltyProgramGroup>, ILoyaltyProgramGroupRepository
    {
        #region Ctors
        public LoyaltyProgramGroupRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyProgramGroupRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyProgramGroupRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
