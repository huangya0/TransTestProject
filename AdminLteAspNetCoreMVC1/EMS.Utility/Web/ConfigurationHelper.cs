using EMS.Utility.Log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
//using System.Net.Configuration;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EMS.Utility.Web
{
    /// <summary>
    /// Get seetings from ConfigurationManager
    /// </summary>
    public static class ConfigurationHelper
    {
        //public static SmtpSection GetMailSetting()
        //{
        //    SmtpSection netSmtpMailSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
        //    return netSmtpMailSection;
        //}

        public static string GetAppSetting(IConfiguration configuration, string name)
        {
            string strSetting = string.Empty;
            if ( !string.IsNullOrEmpty(configuration.GetValue<string>(name)))
            {
                //ConfigurationHelper.GetAppSetting.
                strSetting = configuration.GetValue<string>(name);
            }
            else
            {
                LogHelper.AddErrorLog("Missing element [" + name + "] in AppSetting section of WebConfig!", "WebConfig");
            }
            return strSetting;
        }

        public static string GetConnectionString(IConfiguration configuration, string name)
        {
            string strConnectionString = string.Empty;
            try
            {
                //strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
                strConnectionString = configuration.GetConnectionString(name);
                //strConnectionString = ConfigurationExtensions.GetConnectionString(this.configuration, "Sqlserver");

            }
            catch
            {

            }
            return strConnectionString;
        }
    }

}

