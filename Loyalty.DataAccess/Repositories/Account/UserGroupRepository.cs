using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Account;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class UserGroupRepository : AnatoliRepository<UserGroup>, IUserGroupRepository
    {
        #region Ctors
        public UserGroupRepository() : this(new AnatoliDbContext()) { }
        public UserGroupRepository(AnatoliDbContext context)
            : base(context)
        {
        }

        public UserGroupRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
