using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyProgramRepository : AnatoliRepository<LoyaltyProgram>, ILoyaltyProgramRepository
    {
        #region Ctors
        public LoyaltyProgramRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyProgramRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public LoyaltyProgramRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
