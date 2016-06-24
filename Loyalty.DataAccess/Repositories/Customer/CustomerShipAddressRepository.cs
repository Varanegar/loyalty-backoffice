using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Account;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class CustomerShipAddressRepository : AnatoliRepository<CustomerShipAddress>, ICustomerShipAddressRepository
    {
        #region Ctors
        public CustomerShipAddressRepository() : this(new AnatoliDbContext()) { }
        public CustomerShipAddressRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerShipAddressRepository(AnatoliDbContext context, OwnerInfo OwnerInfo)
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
