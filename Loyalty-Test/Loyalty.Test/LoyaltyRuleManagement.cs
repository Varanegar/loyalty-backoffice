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
    public class LoyaltyRuleManagement : BaseTestManagment
    {


        private static readonly Guid _ruleGroupId = new Guid("191C038C-A4D7-A824-AE3B-07F131DB612F");

        #region RuleGroup
        public static void GetRuleGroups(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/rulegroup/load", req);
        }

        public static void SaveRuleGroups(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRuleGroupRequestModel();
            req.ruleGroupData = new LoyaltyRuleGroupViewModel() { UniqueId = _ruleGroupId, LoyaltyRuleGroupCode = "12", LoyaltyRuleGroupName = "گروه قانون های 1" };
            Call(client, servserURI + "api/loyalty/rulegroup/save", req);
        }
        public static void DeleteRuleGroups(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRuleGroupRequestModel();
            req.ruleGroupData = new LoyaltyRuleGroupViewModel() { UniqueId = _ruleGroupId };
            Call(client, servserURI + "api/loyalty/rulegroup/delete", req);
        }
        #endregion

        

    }
}
