using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace Loyalty.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //JiraLogin();


                string servserURI = "http://localhost:59824/";
                //string servserURI = "http://217.218.53.71:4444/";

                var oauthClient = new OAuth2Client(new Uri(servserURI + "/oauth/token"));
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(1);
                var oauthresult = oauthClient.RequestResourceOwnerPasswordAsync("AnatoliMobileApp", "Anatoli@App@Vn", "79A0D598-0BD2-45B1-BAAA-0A9CF9EFF240,3EEE33CE-E2FD-4A5D-A71C-103CC5046D0C").Result; //, "foo bar"
                //var oauthresult = oauthClient.RequestResourceOwnerPasswordAsync("AnatoliMobileApp", "1", "79A0D598-0BD2-45B1-BAAA-0A9CF9EFF240,3EEE33CE-E2FD-4A5D-A71C-103CC5046D0C").Result; //, "foo bar"

                if (oauthresult.AccessToken != null)
                {
                    client.SetBearerToken(oauthresult.AccessToken);
                    #region City Region
                    //CityRegionManagement.GetCityregionByParentId(client, servserURI, null);
                    //CityRegionManagement.GetCityregionByParentId(client, servserURI, Guid.Parse("f9cab010-1978-4144-a83d-bc4c057f45c5"));
                    #endregion

                    #region Card Set
                    //CardManagement.SaveCardSets(client, servserURI);
                    //CardManagement.GetCardSets(client, servserURI);
                    #endregion

                    #region Tier
                   // CardManagement.SaveTiers(client, servserURI);
                    //CardManagement.GetTiers(client, servserURI);
                    //CardManagement.GetTierById(client, servserURI);
                    #endregion

                    #region Card
                    //CardManagement.SaveCards(client, servserURI);
                    //CardManagement.GetCardByCardNo(client, servserURI);
                    //CardManagement.GetCardByCardsSets(client, servserURI);
                    //CardManagement.GetCardByCardsSetsByStatus(client, servserURI);
                    //CardManagement.GetCardByCustomers(client, servserURI);
                    #endregion

                    #region Customer Group
                    //CustomerManagement.CreateCustomerGroup(client, servserURI);
                    //CustomerManagement.GetCustomerGroupList(client, servserURI);
                    #endregion

                    #region Customer
                    //CustomerManagement.CreateCustomer(client, servserURI);
                    //CustomerManagement.GetCustomerById(client, servserURI);
                    //CustomerManagement.GetCustomerList(client, servserURI);
                    //CustomerManagement.GetCustomerToFindReagent(client, servserURI);
                    //CustomerManagement.GetCustomerMonetaryHistory(client, servserURI);
                    //CustomerManagement.GetCustomerNonMonetaryHistory(client, servserURI);
                    //CustomerManagement.GetCustomerTransactionHistory(client, servserURI);
                    #endregion

                    #region userGroup
                    //LoyaltyUserManagement.SaveUser(client, servserURI);
                    //LoyaltyUserManagement.GetUserProfile(client, servserURI);
                    //LoyaltyUserManagement.SaveUserGroups(client, servserURI);
                    //LoyaltyUserManagement.DeleteUserGroups(client, servserURI);
                    //LoyaltyUserManagement.GetUserGroups(client, servserURI);
                    //LoyaltyUserManagement.AddUserGroupsUser(client, servserURI);
                    #endregion

                    #region trigger
                    //LoyaltyTriggerManagement.SaveTriggerType(client, servserURI);
                    //LoyaltyTriggerManagement.GetTriggerType(client, servserURI);
                    //LoyaltyTriggerManagement.DeleteTriggerType(client, servserURI);
                    //LoyaltyTriggerManagement.SaveTrigger(client, servserURI);
                    //LoyaltyTriggerManagement.GetTrigger(client, servserURI);
                    LoyaltyTriggerManagement.GetTriggerByType(client, servserURI);
                    //LoyaltyTriggerManagement.DeleteTrigger(client, servserURI);
                    #endregion

                    #region ProgramrGroups
                    //LoyaltyProgramManagement.GetProgramGroups(client, servserURI);
                    //LoyaltyProgramManagement.SaveProgramrGroups(client, servserURI);
                    //LoyaltyProgramManagement.DeleteProgramGroups(client, servserURI);
                    #endregion

                    #region RuleGroups
                    //LoyaltyRuleManagement.GetRuleGroups(client, servserURI);
                    //LoyaltyRuleManagement.SaveRuleGroups(client, servserURI);
                    //LoyaltyRuleManagement.DeleteRuleGroups(client, servserURI);
                    #endregion

                    #region Rule
                    //LoyaltyRuleManagement.GetRuleTypes(client, servserURI);

                    //LoyaltyRuleManagement.GetRules(client, servserURI);
                    //LoyaltyRuleManagement.SaveRule(client, servserURI);
                    //LoyaltyRuleManagement.DeleteRules(client, servserURI);
                    #endregion

                    #region LoyaltyActionType
                    //LoyaltyActionTypeManagement.GetActionTypes(client, servserURI);
                    //LoyaltyActionTypeManagement.SaveActionTypes(client, servserURI);
                    //LoyaltyActionTypeManagement.DeleteActionTypes(client, servserURI);
                    #endregion

                    #region LoyaltyValueType
                    //LoyaltyValueTypeManagement.GetValueTypeAttributs(client, servserURI);
                    //LoyaltyValueTypeManagement.SaveValueTypeAttributs(client, servserURI);
                    //LoyaltyValueTypeManagement.DeleteValueTypeAttributs(client, servserURI);
                    #endregion
                }

            }//
            catch (Exception ex)
            {
                //log.Error("error", ex);
                Console.WriteLine("Error, {0}", ex.Message);
            }
        }

    }
}
