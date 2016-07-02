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
        private static readonly Guid _ruleId = new Guid("B81A0370-B424-A824-AE3B-07F13C0B612F");

        #region RuleType
        public static void GetRuleTypes(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/ruletype/load", req);
        }
        #endregion

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

        #region Rule
        public static void GetRules(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/rule/load", req);
        }

        public static void SaveRule(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRuleRequestModel();
            req.ruleData = new LoyaltyRuleViewModel()
            {
                UniqueId = _ruleId,
                LoyaltyRuleCode = "2",
                LoyaltyRuleName = "قانون 2",
                HasCondition = true,
                LoyaltyRuleGroupId = _ruleGroupId,
                LoyaltyRuleTypeId = new Guid("E91AC283-0C89-4C2A-B9B9-32A6CF2B78C5"),
                LoyaltyRuleTriggers = new List<LoyaltyRuleTriggerViewModel>() { new LoyaltyRuleTriggerViewModel() { LoyaltyTriggerId = new Guid("A0C7BFCA-527E-4D53-BCA4-37838B325187") } }
            };
            Call(client, servserURI + "api/loyalty/rule/save", req);
        }
        public static void DeleteRules(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRuleRequestModel();
            req.ruleData = new LoyaltyRuleViewModel() { UniqueId = _ruleId };
            Call(client, servserURI + "api/loyalty/rule/delete", req);
        }
        #endregion


    }
}
