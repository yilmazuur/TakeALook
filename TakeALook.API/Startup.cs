using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Net.Http.Formatting;

[assembly: OwinStartup(typeof(TakeALook.API.Startup))]

namespace TakeALook.API
{
    /// <summary>
    /// Application ayağa kalkarken çalışır. 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Swagger ve webapi initialize edildi.
        /// </summary>
        /// <param name="appBuilder"></param>
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            SwaggerConfig.Register(config);

            //Controller üzeri AttributeRouting işlemi için açıldı
            config.MapHttpAttributeRoutes();

            //Dfault routing
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/v1/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
            );

            //sadece json ile çalışsın
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());


            appBuilder.UseWebApi(config);
        }
    }
}
