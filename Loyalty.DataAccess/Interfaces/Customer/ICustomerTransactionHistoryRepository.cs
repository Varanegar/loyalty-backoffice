using System;
using System.Linq;
using Loyalty.DataAccess.Models;
using System.Collections.Generic;
using Anatoli.Common.DataAccess.Interfaces;
using Loyalty.DataAccess.Models.Account;

namespace Anatoli.DataAccess.Interfaces
{
    public interface ICustomerTransactionHistoryRepository : IRepository<CustomerTransactionHistory>
    {
    }
}
