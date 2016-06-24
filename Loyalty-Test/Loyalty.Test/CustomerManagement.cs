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
                //CustomerType = 0,
                CompanyId = Guid.Parse("cf7c4810-9da0-433c-8639-21bdbd889c85"),
                
                //MarriageDate = DateTime.Now,
                //GraduateDate = DateTime.Now,
                //ReagentId = null,
                //GetNews = true,
                //GetMessage = true


            };

            Call(client, servserURI + "api/loyalty/customer/savesingle", req);

        }

        public static void CreateCustomerGroup(HttpClient client, string servserURI)
        {
            var sampleGroup = new CustomerGroupViewModel()
            {
                GroupName = "گروه اصلی"
            };
            var req = new CustomerRequestModel();
            req.customerGroupData = new List<CustomerGroupViewModel>();
            req.customerGroupData.Add(sampleGroup);

            Call(client, servserURI + "api/loyalty/customer/customergroups/save", req);

        }

        public static void GetCustomerList(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();

            Call(client, servserURI + "api/loyalty/customer/customers/compress", req);
        }

        public static void GetCustomerById(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();
            req.customerId = Guid.Parse("6F89DD6D-5271-4C7A-BC9F-5CE342219914");

            Call(client, servserURI + "api/loyalty/customer/customers/byid", req);
        }
        public static void GetCustomerGroupList(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();

            Call(client, servserURI + "api/loyalty/customer/customergroups/compress", req);
        }

        public static void GetCustomerToFindReagent(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();
            req.searchTerm = "9125793221";

            Call(client, servserURI + "api/loyalty/customer/customers/search/bycodeorcard", req);
        }

    }
}
