using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anatoli.ViewModels;
using Anatoli.ViewModels.CustomerModels;
using Anatoli.ViewModels.LoyaltyModels;
using Anatoli.ViewModels.RequestModel;
using Anatoli.ViewModels.User;

namespace Loyalty.Test
{
    public class LoyaltyUserManagement : BaseTestManagment
    {


        private static readonly Guid _userGroupId = new Guid("928CB38C-5AD7-4824-AE3B-87F131DB612F");


        #region User
        public static void GetUserProfile(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/identityAccounts/profile", req);
        }
        public static void SaveUser(HttpClient client, string servserURI)
        {
            var req = new CreateUserBindingModel();
            req.Username = "User1";
            req.Password = "12as9696@hg";
            req.Mobile = "09122387759";
            req.Email = "test@gmail.com";
            Call(client, servserURI + "api/identityAccounts/saveUser", req);
        }
        #endregion


        #region UserGroup
        public static void GetUserGroups(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/usergroup/load", req);
        }

        public static void SaveUserGroups(HttpClient client, string servserURI)
        {
            var req = new LoyaltyUserGroupRequestModel();
            req.userGroupData = new LoyaltyUserGroupViewModel() { UniqueId = _userGroupId, UserGroupCode = "12", UserGroupName = "صندوق دارها2" };
            Call(client, servserURI + "api/loyalty/usergroup/save", req);
        }
        public static void DeleteUserGroups(HttpClient client, string servserURI)
        {
            var req = new LoyaltyUserGroupRequestModel();
            req.userGroupData = new LoyaltyUserGroupViewModel() { UniqueId = _userGroupId };
            Call(client, servserURI + "api/loyalty/usergroup/delete", req);
        }
        #endregion

        #region UserGroupUser
        public static void AddUserGroupsUser(HttpClient client, string servserURI)
        {
            var req = new LoyaltyUserGroupRequestModel() { uniqueId = _userGroupId,
                                                           users = new List<UserViewModel>()
                                                           {
                                                               new UserViewModel() { Id = "E8724E69-0A81-4DC6-87FE-FDA91D1D2EC2" } ,
                                                               new UserViewModel() { Id = "D0BBD3F2-CF76-4C5B-9336-0D38F1B6DAAB" } ,
                                                               
                                                           } 
            };
            Call(client, servserURI + "api/loyalty/usergroup/adduser", req);
        }
        #endregion


    }
}
