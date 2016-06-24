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
        public static void GetCardSets(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/cardsets", req);
        }

        public static void SaveCardSets(HttpClient client, string servserURI)
        {
            var req = new LoyaltyRequestModel();
            List<LoyaltyCardSetViewModel> loyaltyCardSetListData = new List<LoyaltyCardSetViewModel>();
            loyaltyCardSetListData.Add(new LoyaltyCardSetViewModel() { LoyaltyCardSetCode = "1-1", LoyaltyCardSetName = "گروه مادران", Seed = 1, CurrentNo = 0, Initialtext = "mother-" });

            Call(client, servserURI + "api/loyalty/cardsets", req);
        }

    }
}
