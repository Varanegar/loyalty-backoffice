
using Anatoli.Common.Business;
using Anatoli.Common.Business.Interfaces;
using Anatoli.Common.DataAccess.Models;
using Loyalty.DataAccess;
using Loyalty.DataAccess.Models.Account;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Anatoli.Business.Domain
{
    public class UserGroupDomain : BusinessDomainV3<UserGroup>, IBusinessDomainV3<UserGroup>
    {
        #region Ctors
        public UserGroupDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public UserGroupDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(UserGroup currentUserGroup, UserGroup item)
        {
            if (currentUserGroup != null)
            {
                if (currentUserGroup.UserGroupName != item.UserGroupName ||
                    currentUserGroup.UserGroupCode != item.UserGroupCode)
                {
                    currentUserGroup.LastUpdate = DateTime.Now;
                    MainRepository.Update(currentUserGroup);
                }
            }
            else
            {
                item.CreatedDate = item.LastUpdate = DateTime.Now;
                MainRepository.Add(item);
            }
        }


        public async Task DeleteUserGroup(List<UserGroup> datas)
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
