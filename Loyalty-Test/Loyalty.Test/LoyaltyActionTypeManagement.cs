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
    public class LoyaltyActionTypeManagement : BaseTestManagment
    {


        private static readonly Guid _actionTypeId = new Guid("BC0CA32C-A4D7-A824-AE3B-07F131DB612F");

        #region ActionType
        public static void GetActionTypes(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/actionType/load", req);
        }

        public static void SaveActionTypes(HttpClient client, string servserURI)
        {
            var req = new LoyaltyActionTypeRequestModel();
            req.actionTypeData = new LoyaltyActionTypeViewModel() { UniqueId = _actionTypeId, LoyaltyActionTypeCode = "128", LoyaltyActionTypeName = "نوع نتیجه" };
            Call(client, servserURI + "api/loyalty/actionType/save", req);
        }
        public static void DeleteActionTypes(HttpClient client, string servserURI)
        {
            var req = new LoyaltyActionTypeRequestModel();
            req.actionTypeData = new LoyaltyActionTypeViewModel() { UniqueId = _actionTypeId };
            Call(client, servserURI + "api/loyalty/actionType/delete", req);
        }
        #endregion

        

    }
}
