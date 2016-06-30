using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyalty.DataAccess.Models.Loyalty;
using Anatoli.Common.DataAccess.Interfaces;

namespace Loyalty.DataAccess.Interfaces.Loyalty
{
    public interface ILoyaltyValueTypeAttributeRepository : IRepository<LoyaltyValueTypeAttribute>
    {
    }
}
