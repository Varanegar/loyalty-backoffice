﻿using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyCardSetRepository : AnatoliRepository<LoyaltyCardSet>, ILoyaltyCardSetRepository
    {
        #region Ctors
        public LoyaltyCardSetRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyCardSetRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
