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
    public class CustomerManagement : BaseTestManagment
    {
        public static void CreateCustomer(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();
            req.customerData = new CustomerViewModel()
            {
               
                FirstName = "test",
                LastName = "testian",
                Email = "jsdfh jkasfh",
                MainStreet = "sdkh jhdsf",
                OtherStreet = "jsdv sdj",
                BirthDay = DateTime.Now,
                Mobile = "091223345",
                RegionInfoId = null,
                RegionLevel1Id = null,
                RegionLevel2Id = null,
                RegionLevel3Id = null,
                RegionLevel4Id = null,
                PostalCode = "987464",
                NationalCode = "" ,
                CustomerType = 0,
                CompanyId = Guid.Parse("c7fa54cc-75ec-4c02-b31c-1c81cbca4ca4"),
                
                MarriageDate = DateTime.Now,
                GraduateDate = DateTime.Now,
                ReagentId = null,
                GetNews = true,
                GetMessage = true


            };

            Call(client, servserURI + "api/loyalty/customer/savesingle", req);

        }



    }
}
