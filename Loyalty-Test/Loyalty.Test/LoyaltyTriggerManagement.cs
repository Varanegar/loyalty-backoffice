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

namespace Loyalty.Test
{
    public class LoyaltyTriggerManagement : BaseTestManagment
    {


        private static readonly Guid _triggerTypeId = new Guid("02E91DA5-1029-4E13-8F30-4748E12003F3");
        private static readonly Guid _triggerId = new Guid("5147BFCA-527E-4D53-BCA4-37838B325191"); 

        #region triigerType
        public static void GetTriggerType(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/triggers/loadtypes", req);
        }

        public static void SaveTriggerType(HttpClient client, string servserURI)
        {
            var req = new LoyaltyTriggerRequestModel();
            req.loyaltyTriggerTypeData = new LoyaltyTriggerTypeViewModel() { UniqueId = _triggerTypeId, LoyaltyTriggerTypeCode = "100", LoyaltyTriggerTypeName = "TriggerType" };
            Call(client, servserURI + "api/loyalty/triggers/savetype", req);
        }
        public static void DeleteTriggerType(HttpClient client, string servserURI)
        {
            var req = new LoyaltyTriggerRequestModel();
            req.loyaltyTriggerTypeData = new LoyaltyTriggerTypeViewModel() { UniqueId = _triggerTypeId };
            Call(client, servserURI + "api/loyalty/triggers/deletetype", req);
        }
        #endregion

        #region trigger
        public static void GetTrigger(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/triggers/load", req);
        }

        public static void GetTriggerByType(HttpClient client, string servserURI)
        {
            var req = new LoyaltyTriggerRequestModel();
            req.loyaltyTriggerTypeData = new LoyaltyTriggerTypeViewModel() { UniqueId = new Guid("02E91DA5-1029-4E13-8F30-4748E12003F3") };
            Call(client, servserURI + "api/loyalty/triggers/loadbytypeid", req);
        }
        public static void SaveTrigger(HttpClient client, string servserURI)
        {
            var req = new LoyaltyTriggerRequestModel();
            req.loyaltyTriggerData = new LoyaltyTriggerViewModel() { UniqueId = _triggerId, LoyaltyTriggerCode = "1001", LoyaltyTriggerName = "Trigger1", LoyaltyTriggerTypeId = _triggerTypeId };
            //req.loyaltyTriggerData = new LoyaltyTriggerViewModel() { UniqueId = new Guid("A0C7BFCA-527E-4D53-BCA4-37838B325187"), LoyaltyTriggerCode = "1002", LoyaltyTriggerName = "Trigger2", LoyaltyTriggerTypeId = _triggerTypeId };
            Call(client, servserURI + "api/loyalty/triggers/save", req);
        }
        public static void DeleteTrigger(HttpClient client, string servserURI)
        {
            var req = new LoyaltyTriggerRequestModel();
            req.loyaltyTriggerData = new LoyaltyTriggerViewModel() { UniqueId = _triggerId };
            Call(client, servserURI + "api/loyalty/triggers/delete", req);
        }
        #endregion


    }
}
