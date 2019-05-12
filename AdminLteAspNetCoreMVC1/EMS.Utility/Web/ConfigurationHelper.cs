using EMS.Utility.Log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
//using System.Net.Configuration;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

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

        public static string GetAppSetting(string name)
        {
            string strSetting = string.Empty;
            if ( !string.IsNullOrEmpty(ConfigurationHelper.GetAppSetting(name)))
            {
                //ConfigurationHelper.GetAppSetting.
                strSetting = ConfigurationHelper.GetAppSetting(name);
            }
            else
            {
                LogHelper.AddErrorLog("Missing element [" + name + "] in AppSetting section of WebConfig!", "WebConfig");
            }
            return strSetting;
        }

        public static string GetConnectionString(string name)
        {
            string strConnectionString = string.Empty;
            try
            {
                //strConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
                strConnectionString = ConfigurationHelper.GetConnectionString(name);
            }
            catch
            {

            }
            return strConnectionString;
        }
    }

}

