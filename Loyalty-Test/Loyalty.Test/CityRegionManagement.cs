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
            req.parentUniqueId = ParentId ?? new Guid();
            Call(client, servserURI + "api/base/region/cityregions/byparentid", req);
        }

    }
}
