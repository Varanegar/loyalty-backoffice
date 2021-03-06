﻿using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Base
{
    public class CityRegionDomain : BusinessDomainV3<CityRegion>, IBusinessDomainV3<CityRegion>
    {
        #region Ctors
        public CityRegionDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CityRegionDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CityRegion currentCityRegion, CityRegion item)
        {
            if (currentCityRegion != null)
            {
                if (currentCityRegion.GroupName != item.GroupName ||
                    currentCityRegion.NLeft != item.NLeft ||
                    currentCityRegion.NRight != item.NRight ||
                    currentCityRegion.NLevel != item.NLevel ||
                    currentCityRegion.CityRegion2Id != item.CityRegion2Id)
                {
                    currentCityRegion.LastUpdate = DateTime.Now;
                    currentCityRegion.GroupName = item.GroupName;
                    currentCityRegion.NLeft = item.NLeft;
                    currentCityRegion.NRight = item.NRight;
                    currentCityRegion.NLevel = item.NLevel;
                    currentCityRegion.CityRegion2Id = item.CityRegion2Id;
                    MainRepository.Update(currentCityRegion);
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
