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
    public class LoyaltyRuleActionDomain : BusinessDomainV3<LoyaltyRuleAction>, IBusinessDomainV3<LoyaltyRuleAction>
    {
        #region Ctors
        public LoyaltyRuleActionDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyRuleActionDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyRuleAction currentLoyaltyRuleAction, LoyaltyRuleAction item)
        {

            if (currentLoyaltyRuleAction != null)
            {
                currentLoyaltyRuleAction.LastUpdate = DateTime.Now;
                currentLoyaltyRuleAction.LoyaltyActionTypeId = item.LoyaltyActionTypeId;
                currentLoyaltyRuleAction.LoyaltyValueTypeAttributeId = item.LoyaltyValueTypeAttributeId;
                currentLoyaltyRuleAction.LoyaltyTierId = item.LoyaltyTierId;
                currentLoyaltyRuleAction.ActionValue = item.ActionValue;
                currentLoyaltyRuleAction.ActionPercent = item.ActionPercent;
                currentLoyaltyRuleAction.ActionNewValue = item.ActionNewValue;
                currentLoyaltyRuleAction.CreditDay = item.CreditDay;
                MainRepository.Add(item);
            }
            else
            {
                if (item.Id == Guid.Empty)
                    item.Id = Guid.NewGuid();
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);

            }
        }

        public async Task DeleteRuleActions(List<LoyaltyRuleAction> datas)
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
