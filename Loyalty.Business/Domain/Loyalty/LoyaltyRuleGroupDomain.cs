using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyRuleGroupDomain : BusinessDomainV3<LoyaltyRuleGroup>, IBusinessDomainV3<LoyaltyRuleGroup>
    {
        #region Ctors
        public LoyaltyRuleGroupDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleGroupDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRuleGroup current, LoyaltyRuleGroup item)
        {
            if (current != null)
            {
                current.LastUpdate = DateTime.Now;
                current.LoyaltyRuleGroupName = item.LoyaltyRuleGroupName;
                current.LoyaltyRuleGroupCode = item.LoyaltyRuleGroupCode;
                MainRepository.Update(current);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }
        public async Task Delete(List<LoyaltyRuleGroup> datas)
        {
            //Validate

            await DeleteAsync(datas);
        }


        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion
    }
}
