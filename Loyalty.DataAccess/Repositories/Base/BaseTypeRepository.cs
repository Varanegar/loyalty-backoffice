using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class BaseTypeRepository : AnatoliRepository<BaseType>, IBaseTypeRepository
    {
        #region Ctors
        public BaseTypeRepository() : this(new AnatoliDbContext()) { }
        public BaseTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}
