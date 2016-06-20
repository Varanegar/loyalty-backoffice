using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace Loyalty.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //JiraLogin();


                string servserURI = "http://localhost:59824/";

                var oauthClient = new OAuth2Client(new Uri(servserURI + "/oauth/token"));
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromHours(1);
                var oauthresult = oauthClient.RequestResourceOwnerPasswordAsync("AnatoliMobileApp", "Anatoli@App@Vn", "79A0D598-0BD2-45B1-BAAA-0A9CF9EFF240,3EEE33CE-E2FD-4A5D-A71C-103CC5046D0C").Result; //, "foo bar"
                if (oauthresult.AccessToken != null)
                {
                    client.SetBearerToken(oauthresult.AccessToken);

                    CustomerManagement.CreateCustomer(client, servserURI);
                }

            }
            catch (Exception ex)
            {
                //log.Error("error", ex);
                Console.WriteLine("Error, {0}", ex.Message);
            }
        }

    }
}
