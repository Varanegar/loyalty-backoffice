using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Anatoli.ViewModels;
using Anatoli.ViewModels.CustomerModels;
using Anatoli.ViewModels.RequestModel;

namespace Loyalty.Test
{
    public class CustomerManagement : BaseTestManagment
    {
        private static Guid _customerId = new Guid("BCA615FD-68A1-422E-B065-9ECA5C991F9F");
        public static void CreateCustomer(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();
            req.customerData = new CustomerViewModel()
            {
               UniqueId = _customerId,
                FirstName = "testtttt",
                LastName = "testian",
                Email = "oijsdfh jkasfh",
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
               CompanyId = Guid.Parse("c7fa54cc-75ec-4c02-b31c-1c81cbca4ca4"),
                
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
                UniqueIdString = null,
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
        public static void CustomerActive(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel(){customerData = new CustomerViewModel(){UniqueId = _customerId}};

            Call(client, servserURI + "api/loyalty/customer/active", req);
        }

        public static void CustomerInactive(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel() { customerData = new CustomerViewModel() { UniqueId = _customerId } };

            Call(client, servserURI + "api/loyalty/customer/inactive", req);
        }

        public static void GetCustomerById(HttpClient client, string servserURI)
        {
            var req = new CustomerRequestModel();
            req.customerId = Guid.Parse("3C16F408-1366-48ED-BE6C-9223A0776594");

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

        public static void GetCustomerMonetaryHistory(HttpClient client, string servserURI)
        {
            var req = new CustomerHistoryRequestModel();
            req.customerMonetaryHistoryData = new CustomerMonetaryHistoryViewModel() { CustomerId = new Guid("67637fc3-d57f-4a65-b46a-e3e33c410f7b") };

            Call(client, servserURI + "api/loyalty/customerhistory/loadmonetary", req);
        }

        public static void GetCustomerNonMonetaryHistory(HttpClient client, string servserURI)
        {
            var req = new CustomerHistoryRequestModel();
            req.customerNonMonetaryHistoryData = new CustomerNonMonetaryHistoryViewModel() { CustomerId = new Guid("67637fc3-d57f-4a65-b46a-e3e33c410f7b") };

            Call(client, servserURI + "api/loyalty/customerhistory/loadnonmonetary", req);
        }

        public static void GetCustomerTransactionHistory(HttpClient client, string servserURI)
        {
            var req = new CustomerHistoryRequestModel();
            req.customerTransactionHistoryData = new CustomerTransactionHistoryViewModel()
            {
                CustomerId = new Guid("67637fc3-d57f-4a65-b46a-e3e33c410f7b"),
                LoyaltyValueTypeId = new Guid("af424bda-8462-41fb-9119-d6ec7e158f7a")
            };

            Call(client, servserURI + "api/loyalty/customerhistory/loadtransaction", req);
        }
    }
}
