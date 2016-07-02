using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anatoli.Common.DataAccess.Interfaces;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.DataAccess.Interfaces.Loyalty
{
    public interface ILoyaltyRuleGroupRepository : IRepository<LoyaltyRuleGroup>
    {
    }
}
