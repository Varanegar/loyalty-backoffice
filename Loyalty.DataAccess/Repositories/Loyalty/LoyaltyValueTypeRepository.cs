﻿using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyValueTypeRepository : AnatoliRepository<LoyaltyValueType>, ILoyaltyValueTypeRepository
    {
        #region Ctors
        public LoyaltyValueTypeRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyValueTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
