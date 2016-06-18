﻿using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyCardBatchRepository : AnatoliRepository<LoyaltyCardBatch>, ILoyaltyCardBatchRepository
    {
        #region Ctors
        public LoyaltyCardBatchRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyCardBatchRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
