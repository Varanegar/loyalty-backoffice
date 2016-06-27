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
    public class CustomerMonetaryHistoryRepository : AnatoliRepository<CustomerMonetaryHistory>, ICustomerMonetaryHistoryRepository
    {
        #region Ctors
        public CustomerMonetaryHistoryRepository() : this(new AnatoliDbContext()) { }
        public CustomerMonetaryHistoryRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerMonetaryHistoryRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
