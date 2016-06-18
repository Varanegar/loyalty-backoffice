using System;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Anatoli.ViewModels.BaseModels;
using Loyalty.DataAccess.Repositories;
using System.Linq.Expressions;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;

namespace Loyalty.Business.Domain
{
    public class LoyaltyProgramDomain : BusinessDomainV3<LoyaltyProgram>, IBusinessDomainV3<LoyaltyProgram>
    {
        #region Ctors
        public LoyaltyProgramDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyProgramDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyProgram currentLoyaltyProgram, LoyaltyProgram item)
        {
            if (currentLoyaltyProgram != null)
            {
                if (currentLoyaltyProgram.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyProgram.LastUpdate = DateTime.Now;
                    currentLoyaltyProgram.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyProgram);
                }
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion
    }
}
