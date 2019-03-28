using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AdminLteAspNetMVC1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务 //跨域访问问题参考 https://www.cnblogs.com/qubernet/p/6396295.html
            config.EnableCors();
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new System.Net.Http.Formatting.QueryStringMapping("format", "json", "application/json"));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
