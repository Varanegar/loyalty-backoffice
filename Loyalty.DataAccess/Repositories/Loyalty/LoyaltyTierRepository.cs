﻿using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models.Loyalty;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyTierRepository : AnatoliRepository<LoyaltyTier>, ILoyaltyTierRepository
    {
        #region Ctors
        public LoyaltyTierRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyTierRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyTierRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
