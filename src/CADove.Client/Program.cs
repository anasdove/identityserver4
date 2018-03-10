using CADove.Shared;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CADove.Client
{
    public class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            // Discover endpoints from metadata.
            DiscoveryResponse discoveryClient = await DiscoveryClient.GetAsync(Constant.BASE_URI);
            if (discoveryClient.IsError)
            {
                Console.WriteLine(discoveryClient.Error);
                return;
            }

            // Request Token.
            TokenClient tokenClient = new TokenClient(discoveryClient.TokenEndpoint, Constant.Client.CLIENT_ID, Constant.Client.SECRET);
            TokenResponse tokenResponse = await tokenClient.RequestClientCredentialsAsync(Constant.ApiResource.NAME);
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            // Call API
            HttpClient client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            HttpResponseMessage response = await client.GetAsync(Constant.API_BASE_URI + "Identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
