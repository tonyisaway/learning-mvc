﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AngularJsDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //name: "Products",
            //routeTemplate: "api/Products/{action}",
            //defaults: new { controller = "Products" }
            //);
        }
    }
}
