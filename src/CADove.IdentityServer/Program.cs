using CADove.Shared;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CADove.IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(Constant.AUTH_BASE_URI) // The URLS the web host will listen on
                .UseStartup<Startup>()
                .Build();
    }
}
