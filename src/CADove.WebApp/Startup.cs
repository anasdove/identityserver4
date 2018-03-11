using CADove.Shared;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace CADove.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                    .AddInMemoryClients(IdentityServerConfig.GetClient())
                    .AddTestUsers(IdentityServerConfig.GetUserComplete().ToList());

            //services.AddIdentityServer();

            // Add Authentication Handler
            services.AddAuthentication()
                    //.AddGoogle(Constant.AuthenticationScheme.GOOGLE, options =>
                    //{
                    //    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    //    options.ClientId = Constant.ClientGoogle.CLIENT_ID;
                    //    options.ClientSecret = Constant.ClientGoogle.SECRET;
                    //})
                    .AddOpenIdConnect(Constant.AuthenticationScheme.OPEN_ID_CONNECT, Constant.IDENTITY_SERVER, options =>
                    {
                        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                        options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                        options.RequireHttpsMetadata = false;

                        options.Authority = Constant.AUTH_BASE_URI;
                        options.ClientId = Constant.Client.CLIENT_ID;
                        options.ResponseType = "id_token";
                        options.SaveTokens = true;
                        options.CallbackPath = new PathString("/signin-idsrv");
                        options.SignedOutCallbackPath = new PathString("/signout-callback-idsrv");
                        options.RemoteSignOutPath = new PathString("/signout-idsrv");

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            NameClaimType = "name",
                            RoleClaimType = "role"
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
