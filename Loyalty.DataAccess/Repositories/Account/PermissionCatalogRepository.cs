using Anatoli.Common.DataAccess.Repositories;
using Anatoli.DataAccess.Models.Identity;
using Loyalty.DataAccess.Interfaces.Account;

namespace Loyalty.DataAccess.Repositories.Account
{
    public class PermissionCatalogRepository : BaseAnatoliRepository<PermissionCatalog>, IPermissionCatalogRepository
    {
        #region Ctors
        public PermissionCatalogRepository() : this(new AnatoliDbContext()) { }
        public PermissionCatalogRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        #endregion

        //notice: new custom methods could be added in here
    }
}
