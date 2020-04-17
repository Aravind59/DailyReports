using System;
using System.Web.Http;
using DailyReports.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(DailyReports.Startup))]

namespace DailyReports
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        }

        private void ConfigureOAuth(IAppBuilder app)
        {  
          
           var authOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(24),
                AllowInsecureHttp = true,

            };
            app.UseOAuthBearerTokens(authOptions);
            app.UseOAuthAuthorizationServer(authOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
          
        }
    }
}
