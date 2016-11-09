using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MiniAvatarClienteWeb
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MapHttpAttributeRoutes();
            //config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            //config.EnableCors();

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
                );
            //config.Routes.MapHttpRoute(
            //name: "DefaultApi2",
            // routeTemplate: "api/{controller}/{action}/{jsonRequets}",
            // defaults: new { controller = "SingleServiceApi", action = "Execute", jsonRequets = RouteParameter.Optional }
            // );

            //config.Routes.MapHttpRoute(
            // name: "DefaultApi3",
            //  routeTemplate: "api/{controller}/{action}/{provider}/{serviceName}/{jsonRequets}",
            //  defaults: new
            //  {
            //      controller = "SingleServiceApi",
            //      action = "Execute",
            //      provider = RouteParameter.Optional,
            //      serviceName = RouteParameter.Optional,
            //      jsonRequets = RouteParameter.Optional
            //  }
            //  );
        }
    }
}
