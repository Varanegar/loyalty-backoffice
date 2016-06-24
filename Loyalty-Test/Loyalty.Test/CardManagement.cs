using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anatoli.ViewModels;
using Anatoli.ViewModels.CustomerModels;
using Anatoli.ViewModels.LoyaltyModels;

namespace Loyalty.Test
{
    public class CardManagement : BaseTestManagment
    {
        #region Card Set
        public static void GetTiers(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/tiers", req);
        }

        public static void SaveTiers(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            List<LoyaltyTierViewModel> tierData = new List<LoyaltyTierViewModel>();
            tierData.Add(new LoyaltyTierViewModel() { TierName = "لطایی", TierCode = "1--1" });
            req.loyaltyTierListData = tierData;
            Call(client, servserURI + "api/loyalty/tiers/save", req);
        }
        #endregion


        #region Card Set
        public static void GetCardSets(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/cardsets", req);
        }

        public static void SaveCardSets(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            List<LoyaltyCardSetViewModel> loyaltyCardSetListData = new List<LoyaltyCardSetViewModel>();
            loyaltyCardSetListData.Add(new LoyaltyCardSetViewModel() { UniqueId = Guid.Parse("7FBA8876-E1D6-419B-AF4A-9308FD7E654D"), LoyaltyCardSetGenerateTypeId= Guid.Parse("AEBC1016-A309-440D-A9AE-DADA3D33D8D8"), LoyaltyCardSetCode = "1-1", LoyaltyCardSetName = "گروه مادران", Seed = 1, CurrentNo = 0, Initialtext = "mother-" });
            req.loyaltyCardSetListData = loyaltyCardSetListData;
            Call(client, servserURI + "api/loyalty/cardsets/save", req);
        }
        #endregion

        #region card
        public static void SaveCards(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            List<LoyaltyCardViewModel> loyaltyCardListData = new List<LoyaltyCardViewModel>();
            loyaltyCardListData.Add(new LoyaltyCardViewModel() { CardNo = "1000-1000-233", AssignDate = null, ExpireDate = null, CustomerId =Guid.Parse("6F89DD6D-5271-4C7A-BC9F-5CE342219914"), GenerateDate = DateTime.Now, IsActive = true, LoyaltyCardSetId= Guid.Parse("7FBA8876-E1D6-419B-AF4A-9308FD7E654D"), LoyaltyCardStatusId = Guid.Parse("6874BA5B-7DC5-4AD7-B946-3756AFBC4831") });
            req.loyaltyCardListData = loyaltyCardListData;
            Call(client, servserURI + "api/loyalty/cards/save", req);

            req = new LoyaltyRequestModel();
            loyaltyCardListData = new List<LoyaltyCardViewModel>();
            loyaltyCardListData.Add(new LoyaltyCardViewModel() { CardNo = "1000-9999-456", AssignDate = null, ExpireDate = null, GenerateDate = DateTime.Now, IsActive = true, LoyaltyCardSetId = Guid.Parse("7FBA8876-E1D6-419B-AF4A-9308FD7E654D"), LoyaltyCardStatusId = Guid.Parse("F63E00F3-F351-4EE7-8A58-83BE758F0C62") });
            req.loyaltyCardListData = loyaltyCardListData;
            Call(client, servserURI + "api/loyalty/cards/save", req);
        }

        public static void GetCardByCardsSets(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            req.loyaltyCardSetId = Guid.Parse("7FBA8876-E1D6-419B-AF4A-9308FD7E654D");
            Call(client, servserURI + "api/loyalty/cards/bycardsetid/compress", req);

        }

        public static void GetCardByCardsSetsByStatus(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            req.loyaltyCardSetId = Guid.Parse("7FBA8876-E1D6-419B-AF4A-9308FD7E654D");
            req.loyaltyCardStatusId = Guid.Parse("F63E00F3-F351-4EE7-8A58-83BE758F0C62");
            Call(client, servserURI + "api/loyalty/cards/bycardsetid/compress", req);
        }

        public static void GetCardByCustomers(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            req.customerId = Guid.Parse("6F89DD6D-5271-4C7A-BC9F-5CE342219914");
            Call(client, servserURI + "api/loyalty/cards/bycustomerid", req);

        }

        public static void GetCardByCardNo(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            req.searchTerm = "10";
            Call(client, servserURI + "api/loyalty/cards/searchcard", req);

        }

        #endregion
    }
}
