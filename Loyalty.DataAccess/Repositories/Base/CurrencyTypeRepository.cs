using System;
using System.Linq;
using System.Data.Entity;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class CurrencyTypeRepository : AnatoliRepository<CurrencyType>, ICurrencyTypeRepository
    {
        #region Ctors
        public CurrencyTypeRepository() : this(new AnatoliDbContext()) { }
        public CurrencyTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
