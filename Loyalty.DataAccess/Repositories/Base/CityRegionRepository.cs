using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class CityRegionRepository : AnatoliRepository<CityRegion>, ICityRegionRepository
    {
        #region Ctors
        public CityRegionRepository() : this(new AnatoliDbContext()) { }
        public CityRegionRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CityRegionRepository(AnatoliDbContext context, OwnerInfo ownerInfo)
            : base(context, ownerInfo)
        {
        }
        #endregion
    }
}
