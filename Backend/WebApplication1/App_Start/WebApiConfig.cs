using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using DailyReports.Contracts.Interfaces;
using DailyReports.Service;
using DailyReports.DependencyResolver;
using DailyReports.Providers;

namespace DailyReports
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");//origins,headers,methods   
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();
           
            var container = SetupUnityContainerHelper.SetupUnityContainer();
            config.DependencyResolver = new UnityResolver(container);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Filters.Add(new AuthorizeAttribute());
           
        }
    }
}
