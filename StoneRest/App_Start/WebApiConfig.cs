using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Routing;
using System.Net.Http;

namespace StoneRest
{
    public static class WebApiConfig
    {
        
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Configuração para retornar valores em formato JSON
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(new RequestHeaderMapping("Accept",
                              "text/html",
                              StringComparison.InvariantCultureIgnoreCase,
                              true,
                              "application/json"));

            // Web API routes
            config.MapHttpAttributeRoutes();
                        
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{city}",
                defaults: new { city = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "ShowTemperatures",
                routeTemplate: "api/{controller}/{city}/temperatures",
                defaults: new
                {
                    city = RouteParameter.Optional,
                    action = "ShowTemperatures"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteTemperatures",
                routeTemplate: "api/{controller}/{city}/temperatures",
                defaults: new {
                    city = RouteParameter.Optional,
                    action = "Delete"
                }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteCity",
                routeTemplate: "api/{controller}/{city}",
                defaults: new
                {
                    city = RouteParameter.Optional,
                    action = "DeleteCity"
                }
            );


            config.Routes.MapHttpRoute(
                name: "AddCityByCEP",
                routeTemplate: "api/{controller}/by_cep/{cep}",
                defaults: new
                {
                    cep = RouteParameter.Optional,
                    action = "AddCityByCEP"
                }
            );
        }
    }
}
