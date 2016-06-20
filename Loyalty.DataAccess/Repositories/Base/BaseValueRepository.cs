using Loyalty.DataAccess.Interfaces.Base;
using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class BaseValueRepository : AnatoliRepository<BaseValue>, IBaseValueRepository
    {
        #region Ctors
        public BaseValueRepository() : this(new AnatoliDbContext()) { }
        public BaseValueRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
