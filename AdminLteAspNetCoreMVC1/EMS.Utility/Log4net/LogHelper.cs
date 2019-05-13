using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Utility.Log4net
{
    public class LogHelper
    {
        //https://www.cnblogs.com/dlvguo/p/10609782.html

        private const string configFileName = "log4net.config"; //"Web.config";
        private const string repositoryName = "NETCoreRepository";
        public LogHelper()
        {

        }
        private static void SetXmlConfigurator()
        {
            ILoggerRepository repository = LogManager.CreateRepository(repositoryName);
            XmlConfigurator.Configure(repository, new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + configFileName));
            //repositoryName = repository.Name;
            //ILog logger = LogManager.GetLogger(repository.Name, "NETCorelog4net");
            //ConfigureLog4Net();
        }
        //private static void ConfigureLog4Net()
        //{
        //    Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
        //    if (hierarchy != null && hierarchy.Configured)
        //    {
        //        foreach (IAppender appender in hierarchy.GetAppenders())
        //        {
        //            if (appender is AdoNetAppender)
        //            {
        //                var adoNetAppender = (AdoNetAppender)appender;
        //                adoNetAppender.ConnectionString = ConfigurationManager.ConnectionStrings["EmsWebDB"].ConnectionString;
        //                adoNetAppender.ActivateOptions(); //Refresh AdoNetAppenders Settings
        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 记录调试（Debug）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        /// <param name="ex">记录的异常</param>
        public static void AddDebugLog(string message, Type type, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Debug(message, ex);
        }
        /// <summary>
        /// 记录调试（Debug）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        /// <param name="ex">记录的异常</param>
        public static void AddDebugLog(string message, string actionName, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Debug(message, ex);
        }
        /// <summary>
        /// 记录调试（Debug）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        public static void AddDebugLog(string message, string actionName)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Debug(message);
        }
        /// <summary>
        /// 记录调试（Debug）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        public static void AddDebugLog(string message, Type type)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Debug(message);
        }
        /// <summary>
        /// 记录错误（Error）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        /// <param name="ex">记录的异常</param>
        public static void AddErrorLog(string message, Type type, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Error(message, ex);
        }
        /// <summary>
        /// 记录错误（Error）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        /// <param name="ex">记录的异常</param>
        public static void AddErrorLog(string message, string actionName, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Error(message, ex);
        }
        /// <summary>
        /// 记录错误（Error）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        public static void AddErrorLog(string message, string actionName)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Error(message);
        }
        /// <summary>
        /// 记录错误（Error）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        public static void AddErrorLog(string message, Type type)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Error(message);
        }
        /// <summary>
        /// 记录致命错误（Fatal）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        /// <param name="ex">记录的异常</param>
        public static void AddFatalLog(string message, Type type, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Fatal(message, ex);
        }
        /// <summary>
        /// 记录致命错误（Fatal）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        /// <param name="ex">记录的异常</param>
        public static void AddFatalLog(string message, string actionName, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Fatal(message, ex);
        }
        /// <summary>
        /// 记录致命错误（Fatal）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        public static void AddFatalLog(string message, string actionName)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Fatal(message);
        }
        /// <summary>
        /// 记录致命错误（Fatal）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        public static void AddFatalLog(string message, Type type)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Fatal(message);
        }
        /// <summary>
        /// 记录警告（Warn）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        /// <param name="ex">记录的异常</param>
        public static void AddWarnLog(string message, Type type, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Warn(message, ex);
        }
        /// <summary>
        /// 记录警告（Warn）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        /// <param name="ex">记录的异常</param>
        public static void AddWarnLog(string message, string actionName, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Warn(message, ex);
        }
        /// <summary>
        /// 记录警告（Warn）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        public static void AddWarnLog(string message, string actionName)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Warn(message);
        }
        /// <summary>
        /// 记录警告（Warn）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        public static void AddWarnLog(string message, Type type)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Warn(message);
        }
        /// <summary>
        /// 记录普通信息（Info）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        /// <param name="ex">记录的异常</param>
        public static void AddInfoLog(string message, Type type, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Info(message, ex);
        }
        /// <summary>
        /// 记录普通信息（Info）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        /// <param name="ex">记录的异常</param>
        public static void AddInfoLog(string message, string actionName, Exception ex)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Info(message, ex);
        }
        /// <summary>
        /// 记录普通信息（Info）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="actionName">记录操作的名称</param>
        public static void AddInfoLog(string message, string actionName)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(repositoryName, actionName);
            logger.Info(message);
        }
        /// <summary>
        /// 记录普通信息（Info）日志
        /// </summary>
        /// <param name="message">记录的信息</param>
        /// <param name="type">记录操作的类</param>
        public static void AddInfoLog(string message, Type type)
        {
            SetXmlConfigurator();
            ILog logger = log4net.LogManager.GetLogger(type);
            logger.Info(message);
        }
    }
}
