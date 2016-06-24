using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Account;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class CustomerLoyaltyTierHistoryRepository : AnatoliRepository<CustomerLoyaltyTierHistory>, ICustomerLoyaltyTierHistoryRepository
    {
        #region Ctors
        public CustomerLoyaltyTierHistoryRepository() : this(new AnatoliDbContext()) { }
        public CustomerLoyaltyTierHistoryRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerLoyaltyTierHistoryRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
