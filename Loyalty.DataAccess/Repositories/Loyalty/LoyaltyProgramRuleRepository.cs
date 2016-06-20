using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Interfaces.Loyalty;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class LoyaltyProgramRuleRepository : AnatoliRepository<LoyaltyProgramRule>, ILoyaltyProgramRuleRepository
    {
        #region Ctors
        public LoyaltyProgramRuleRepository() : this(new AnatoliDbContext()) { }
        public LoyaltyProgramRuleRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
