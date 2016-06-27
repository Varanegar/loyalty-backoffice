
using System.Linq;
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
    public class UserGroupUserDomain : BusinessDomainV3<UserGroupUser>, IBusinessDomainV3<UserGroupUser>
    {
        #region Ctors
        public UserGroupUserDomain(OwnerInfo ownerInfo)
            : this(ownerInfo, new AnatoliDbContext())
        {
        }
        public UserGroupUserDomain(OwnerInfo ownerInfo, AnatoliDbContext dbc)
            : base(ownerInfo, dbc)
        {
        }
        #endregion

        #region Methods
        public override void AddDataToRepository(UserGroupUser currentUserGroup, UserGroupUser item)
        {
            item.CreatedDate = item.LastUpdate = DateTime.Now;
            MainRepository.Add(item);
        }


        public async Task DeleteUserGroupUser(List<UserGroupUser> datas)
        {
            //Validate

            await DeleteAsync(datas);
        }
        public async Task RemoveFromGroup(Guid id, Guid userId)
        {
            var userGroupUser = await GetAllAsync<UserGroupUser>(x => x.UserGroupId == id && x.UserId == userId.ToString());
            await DeleteAsync(userGroupUser);
        }
 

        public override void SetConditionForFetchingData()
        {
            MainRepository.ExtraPredicate = p => true;
        }
        #endregion


    }
}
