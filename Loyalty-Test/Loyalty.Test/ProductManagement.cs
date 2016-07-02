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
    public class ProductManagement : BaseTestManagment
    {


        private static readonly Guid _programGroupId = new Guid("123CB38C-54D7-A824-AE3B-87F131DB612F");

        #region ProductGroup
        public static void GetProductGroup(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/gateway/product/productgroups", req);
        }
        #endregion

        #region Product
        public static void GetProduct(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/gateway/product/products", req);
        }
        #endregion

        

    }
}
