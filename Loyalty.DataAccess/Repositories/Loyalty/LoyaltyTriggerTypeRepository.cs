﻿using System;
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
