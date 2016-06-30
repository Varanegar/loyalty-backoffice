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
    public class LoyaltyProgramGroupDomain : BusinessDomainV3<LoyaltyProgramGroup>, IBusinessDomainV3<LoyaltyProgramGroup>
    {
        #region Ctors
        public LoyaltyProgramGroupDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyProgramGroupDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyProgramGroup currentProgramGroup, LoyaltyProgramGroup item)
        {
            if (currentProgramGroup != null)
            {
                currentProgramGroup.LastUpdate = DateTime.Now;
                currentProgramGroup.IsRemoved = item.IsRemoved;
                currentProgramGroup.LoyaltyProgramGroupCode = item.LoyaltyProgramGroupCode;
                currentProgramGroup.LoyaltyProgramGroupName = item.LoyaltyProgramGroupName;
                MainRepository.Update(currentProgramGroup);
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }
        public async Task DeleteLoyaltyProgramGroups(List<LoyaltyProgramGroup> datas)
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
