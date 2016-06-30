using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Loyalty;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyValueTypeAttributeDomain : BusinessDomainV3<LoyaltyValueTypeAttribute>, IBusinessDomainV3<LoyaltyValueTypeAttribute>
    {
        #region Ctors
        public LoyaltyValueTypeAttributeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyValueTypeAttributeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyValueTypeAttribute currentValueTypeAttribute, LoyaltyValueTypeAttribute item)
        {
            if (currentValueTypeAttribute != null)
            {
                currentValueTypeAttribute.LastUpdate = DateTime.Now;
                currentValueTypeAttribute.LoyaltyValueTypeAttributeCode = item.LoyaltyValueTypeAttributeCode;
                currentValueTypeAttribute.LoyaltyValueTypeAttributeName = item.LoyaltyValueTypeAttributeName;
                MainRepository.Update(currentValueTypeAttribute);
            }
            else{
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public async Task DeleteLoyaltyValueTypeAttribute(List<LoyaltyValueTypeAttribute> datas)
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
