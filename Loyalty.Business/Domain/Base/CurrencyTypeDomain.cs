using System;
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models;

namespace Loyalty.Business.Domain.Base
{
    public class CurrencyTypeDomain : BusinessDomainV3<CurrencyType>, IBusinessDomainV3<CurrencyType>
    {
        #region Ctors
        public CurrencyTypeDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public CurrencyTypeDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(CurrencyType currentCurrencyType, CurrencyType item)
        {
            if (currentCurrencyType != null)
            {
                if (currentCurrencyType.IsRemoved != item.IsRemoved)
                {
                    currentCurrencyType.LastUpdate = DateTime.Now;
                    currentCurrencyType.IsRemoved = item.IsRemoved;
                    MainRepository.Update(currentCurrencyType);
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
