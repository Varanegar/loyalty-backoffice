using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Loyalty;
using Anatoli.Common.DataAccess.Models;

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
        public LoyaltyCardSetRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
