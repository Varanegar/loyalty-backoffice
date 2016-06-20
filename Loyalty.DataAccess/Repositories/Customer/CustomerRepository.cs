using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Repositories;
using Loyalty.DataAccess.Models.Account;
using Anatoli.Common.DataAccess.Interfaces;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.DataAccess.Repositories
{
    public class CustomerRepository : AnatoliRepository<Customer>, ICustomerRepository, IRepository<Customer>
    {
        #region Ctors
        public CustomerRepository() : this(new AnatoliDbContext()) { }
        public CustomerRepository(AnatoliDbContext context)
            : base(context)
        {
        }
        public CustomerRepository(AnatoliDbContext context, OwnerInfo OwnerInfo )
            : base(context, OwnerInfo)
        {
        }
        #endregion
    }
}
