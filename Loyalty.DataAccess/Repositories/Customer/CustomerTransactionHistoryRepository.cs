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
    public class CustomerTransactionHistoryRepository : AnatoliRepository<CustomerTransactionHistory>, ICustomerTransactionHistoryRepository
    {
        #region Ctors
        public CustomerTransactionHistoryRepository() : this(new AnatoliDbContext()) { }
        public CustomerTransactionHistoryRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerTransactionHistoryRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
