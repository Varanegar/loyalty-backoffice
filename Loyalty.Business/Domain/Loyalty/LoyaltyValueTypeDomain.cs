﻿using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Loyalty
{
    public class LoyaltyValueTypeDomain : BusinessDomainV3<LoyaltyValueType>, IBusinessDomainV3<LoyaltyValueType>
    {
        #region Ctors
        public LoyaltyValueTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public LoyaltyValueTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(LoyaltyValueType currentLoyaltyValueType, LoyaltyValueType item)
        {
            if (currentLoyaltyValueType != null)
            {
                if (currentLoyaltyValueType.IsRemoved != item.IsRemoved)
                {
                    currentLoyaltyValueType.LastUpdate = DateTime.Now;
                    currentLoyaltyValueType.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentLoyaltyValueType);
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
