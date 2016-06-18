using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;

namespace Loyalty.DataAccess.Repositories
{
    public class ProductTypeRepository : AnatoliRepository<ProductType>, IProductTypeRepository
    {
        #region Ctors
        public ProductTypeRepository() : this(new AnatoliDbContext()) { }
        public ProductTypeRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion
    }
}