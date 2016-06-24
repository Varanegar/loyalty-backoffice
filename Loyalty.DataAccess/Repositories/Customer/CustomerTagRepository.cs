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
    public class CustomerTagRepository : AnatoliRepository<CustomerTag>, ICustomerTagRepository
    {
        #region Ctors
        public CustomerTagRepository() : this(new AnatoliDbContext()) { }
        public CustomerTagRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerTagRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
