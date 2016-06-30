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
    public class LoyaltyProgramManagement : BaseTestManagment
    {


        private static readonly Guid _programGroupId = new Guid("123CB38C-54D7-A824-AE3B-87F131DB612F");

        #region ProgramGroup
        public static void GetProgramGroups(HttpClient client, string servserURI)
        {
            var req = new BaseRequestModel();
            Call(client, servserURI + "api/loyalty/programgroup/load", req);
        }

        public static void SaveProgramrGroups(HttpClient client, string servserURI)
        {
            var req = new LoyaltyProgramGroupRequestModel();
            req.programGroupData = new LoyaltyProgramGroupViewModel() { UniqueId = _programGroupId, LoyaltyProgramGroupCode = "12", LoyaltyProgramGroupName = "گروه برنامه" };
            Call(client, servserURI + "api/loyalty/programgroup/save", req);
        }
        public static void DeleteProgramGroups(HttpClient client, string servserURI)
        {
            var req = new LoyaltyProgramGroupRequestModel();
            req.programGroupData = new LoyaltyProgramGroupViewModel() { UniqueId = _programGroupId };
            Call(client, servserURI + "api/loyalty/programgroup/delete", req);
        }
        #endregion

        

    }
}
