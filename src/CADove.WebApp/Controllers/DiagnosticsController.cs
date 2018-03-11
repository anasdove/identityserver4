using CADove.WebApp.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CADove.WebApp.Controllers
{
    [SecurityHeaders]
    [Authorize]
    public class DiagnosticsController : Controller
    {
        public IActionResult Index()
        {
            var localAddresses = new string[] { "127.0.0.1", "::1", HttpContext.Connection.LocalIpAddress.ToString() };
            if (localAddresses.Contains(HttpContext.Connection.RemoteIpAddress.ToString()))
            {
                return View();
            }

            return NotFound();
        }
    }
}