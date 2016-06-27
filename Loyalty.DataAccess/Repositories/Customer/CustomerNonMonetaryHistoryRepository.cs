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
    public class CustomerNonMonetaryHistoryRepository : AnatoliRepository<CustomerNonMonetaryHistory>, ICustomerNonMonetaryHistoryRepository
    {
        #region Ctors
        public CustomerNonMonetaryHistoryRepository() : this(new AnatoliDbContext()) { }
        public CustomerNonMonetaryHistoryRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerNonMonetaryHistoryRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
