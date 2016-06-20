using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Account;

namespace Loyalty.DataAccess.Repositories
{
    public class CustomerGroupRepository : AnatoliRepository<CustomerGroup>, ICustomerGroupRepository
    {
        #region Ctors
        public CustomerGroupRepository() : this(new AnatoliDbContext()) { }
        public CustomerGroupRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
