using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PTOPlanner.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "RouteWithAction",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RouteEmployeePTOBalance_GetBySPROC",
                routeTemplate: "api/EmployeePTOBalance/GetBySPROC/{employeeId}/{year}",
                defaults: new { employeeId = RouteParameter.Optional, year = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
