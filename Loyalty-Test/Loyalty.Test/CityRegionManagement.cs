using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anatoli.ViewModels;
using Anatoli.ViewModels.CustomerModels;

namespace Loyalty.Test
{
    public class CityRegionManagement : BaseTestManagment
    {
        public static void GetCityregionByParentId(HttpClient client, string servserURI, Guid? ParentId)
        {
            var req = new BaseRequestModel();
            req.parentUniqueId = null;
            Call(client, servserURI + "api/base/region/cityregions/byparentid", req);
        }
        public static void GetCityregion(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/base/region/cityregions", req);
        }

    }
}
