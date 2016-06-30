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
    public class LoyaltyValueTypeManagement : BaseTestManagment
    {


        private static readonly Guid _valueTypeAttributeId = new Guid("A23CB32C-54D7-A824-AE3B-07F031DB112F");

        #region ProgramGroup
        public static void GetValueTypeAttributs(HttpClient client, string servserURI)
        {
            var req = new LoyaltyValueTypeAttributeRequestModel();
            Call(client, servserURI + "api/loyalty/valuetypeattribute/load", req);
        }

        public static void SaveValueTypeAttributs(HttpClient client, string servserURI)
        {
            var req = new LoyaltyValueTypeAttributeRequestModel();
            req.valueTypeAttributeData = new LoyaltyValueTypeAttributeViewModel() { UniqueId = _valueTypeAttributeId, 
                LoyaltyValueTypeAttributeCode = "312", 
                LoyaltyValueTypeAttributeName = "مبلغ خالص فاکتور" ,
                LoyaltyValueTypeId = new Guid("F84E6BCC-10D0-49FC-A9D8-F6DC9E8F15A0")
            };
            Call(client, servserURI + "api/loyalty/valuetypeattribute/save", req);
        }
        public static void DeleteValueTypeAttributs(HttpClient client, string servserURI)
        {
            var req = new LoyaltyValueTypeAttributeRequestModel();
            req.valueTypeAttributeData = new LoyaltyValueTypeAttributeViewModel() { UniqueId = _valueTypeAttributeId };
            Call(client, servserURI + "api/loyalty/valuetypeattribute/delete", req);
        }
        #endregion

        

    }
}
