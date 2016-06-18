﻿using System;
using Loyalty.DataAccess.Models;
using Anatoli.DataAccess.Interfaces;
using Loyalty.DataAccess.Repositories;
using Loyalty.DataAccess;
using Anatoli.ViewModels.ProductModels;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;

namespace Anatoli.Business.Domain
{
    public class ProductGroupDomain : BusinessDomainV3<ProductGroup>, IBusinessDomainV3<ProductGroup>
    {
        #region Properties
        #endregion

        #region Ctors
        public ProductGroupDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public ProductGroupDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }

        #endregion

        #region Methods
        public override void AddDataToRepository(ProductGroup currentGroup, ProductGroup item)
        {
            if (currentGroup != null)
            {
                if (currentGroup.GroupName != item.GroupName ||
                        currentGroup.NLeft != item.NLeft ||
                        currentGroup.NRight != item.NRight ||
                        currentGroup.NLevel != item.NLevel ||
                        currentGroup.ProductGroup2Id != item.ProductGroup2Id)
                {

                    currentGroup.LastUpdate = DateTime.Now;
                    currentGroup.GroupName = item.GroupName;
                    currentGroup.NLeft = item.NLeft;
                    currentGroup.NRight = item.NRight;
                    currentGroup.NLevel = item.NLevel;
                    currentGroup.ProductGroup2Id = item.ProductGroup2Id;
                    MainRepository.Update(currentGroup);
                }
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }

        #endregion
    }
}
