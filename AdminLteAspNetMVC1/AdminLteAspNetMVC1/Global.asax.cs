using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AdminLteAspNetMVC1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public const string Default_ConnectionName = "EmsWebDB";

        public static bool IsApplicationStarted = false;

        protected void Application_Start()
        {
            IsApplicationStarted = false;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string CONNECTION_STRING = EMS.Utility.Web.ConfigurationHelper.GetConnectionString(Default_ConnectionName);
            //SqlDependency需打开SQL Server Service Broker，用以下脚本打开
            //ALTER DATABASE EmsWebDB SET NEW_BROKER WITH ROLLBACK IMMEDIATE;
            //ALTER DATABASE EmsWebDB SET ENABLE_BROKER;
            SqlDependency.Start(CONNECTION_STRING);
            IsApplicationStarted = true;

        }

        protected void Application_End()
        {
            string CONNECTION_STRING = EMS.Utility.Web.ConfigurationHelper.GetConnectionString(Default_ConnectionName);//System.Configuration.ConfigurationManager.ConnectionStrings["AirWaveDB"].ConnectionString;
            SqlDependency.Stop(CONNECTION_STRING);
        }
    }
}
