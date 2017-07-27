using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPIDispatcher
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            //config.Routes.MapHttpRoute(
            // name: "DefaultApi2",
            //  routeTemplate: "api/{controller}/{action}/{param}",
            //  defaults: new { action = "Execute", param = RouteParameter.Optional }
            //  );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
               );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //config.Routes.MapHttpRoute(
            //name: "DefaultApi3",
            // routeTemplate: "api/{controller}/{action}/{provider}/{serviceName}/{jsonRequets}",
            // defaults: new
            // {
            //     controller = "SingleServiceApi",
            //     action = "Execute",
            //     provider = RouteParameter.Optional,
            //     serviceName = RouteParameter.Optional,
            //     jsonRequets = RouteParameter.Optional
            // }
            // );
        }
    }
}
