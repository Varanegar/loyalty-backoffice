using System;
using System.Linq;
using System.Data.Entity;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyValueTypeAttributeRepository : AnatoliRepository<LoyaltyValueTypeAttribute>, ILoyaltyValueTypeAttributeRepository
    {
        #region Ctors
        public LoyaltyValueTypeAttributeRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyValueTypeAttributeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyValueTypeAttributeRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }

        #endregion
    }
}
