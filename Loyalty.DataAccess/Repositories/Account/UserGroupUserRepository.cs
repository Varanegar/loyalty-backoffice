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
    public class UserGroupUserRepository : AnatoliRepository<UserGroupUser>, IUserGroupUserRepository
    {
        #region Ctors
        public UserGroupUserRepository() : this(new AnatoliDbContext()) { }
        public UserGroupUserRepository(AnatoliDbContext context)
            : base(context)
        {
        }

        public UserGroupUserRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
