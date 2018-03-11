using CADove.Shared;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CADove.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [Route("GetClientCredentialAsync")]
        [HttpGet]
        public async Task<IActionResult> GetClientCredentialAsync()
        {
            // Discover endpoints from metadata.
            DiscoveryResponse discoveryClient = await DiscoveryClient.GetAsync(Constant.BASE_URI);
            if (discoveryClient.IsError)
            {
                return new JsonResult(discoveryClient.Error);
            }

            // Request Token.
            TokenClient tokenClient = new TokenClient(discoveryClient.TokenEndpoint, Constant.Client.CLIENT_ID, Constant.Client.SECRET);
            TokenResponse tokenResponse = await tokenClient.RequestClientCredentialsAsync(Constant.ApiResource.SCOPE_NAME);
            if (tokenResponse.IsError) return new JsonResult(tokenResponse.Error);
            return new JsonResult(tokenResponse.Json);
        }

        [Route("GetResourceOwnerPasswordAsync")]
        [HttpGet]
        public async Task<IActionResult> GetResourceOwnerPasswordAsync()
        {
            // Discover endpoints from metadata.
            DiscoveryResponse discoveryClient = await DiscoveryClient.GetAsync(Constant.BASE_URI);
            if (discoveryClient.IsError)
            {
                return new JsonResult(discoveryClient.Error);
            }

            // Request Token.
            TokenClient tokenClient = new TokenClient(discoveryClient.TokenEndpoint, Constant.Client.CLIENT_ID, Constant.Client.SECRET);
            TokenResponse tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(Constant.CAUser.USERNAME, Constant.CAUser.PASSWORD, Constant.ApiResource.SCOPE_NAME);
            if (tokenResponse.IsError) return new JsonResult(tokenResponse.Error);
            return new JsonResult(tokenResponse.Json);
        }
    }
}
