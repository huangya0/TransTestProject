using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace EMS.Utility.Data.DatabaseCacheDependency
{
    public class CacheHelper // : ICacheHelper
    {
        
        public string CacheId { get; private set; }
        public string DbConnectionName { get; private set; }

        public CacheHelper(string CacheId, string dbConnectionName)
        {
            this.CacheId = CacheId;
            this.DbConnectionName = dbConnectionName;
        }

        /// <summary>
        /// If exists Cache, get data in Cache.Else read data in DB and create SqlDependency and save data in Cache.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="q">can not use *,top,sql function in query string</param>
        /// <returns></returns>
        //public List<T> GetLinqCahce<T>(IQueryable<T> q)
        //{
        //    string CONNECTION_STRING = Utility.Web.ConfigurationHelper.GetConnectionString(DbConnectionName); //System.Configuration.ConfigurationManager.ConnectionStrings["AirWaveDB"].ConnectionString;

        //    List<T> objCache = (List<T>)System.Web.HttpRuntime.Cache.Get(CacheId);
        //    if (null == objCache)
        //    {
        //        var query = q as DbQuery<T>;

        //        var parameters = this.GetSqlParameterInLinq<T>(query);

        //        using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
        //        {
        //            conn.Open();

        //            using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
        //            {
        //                cmd.Parameters.AddRange(parameters);

        //                SqlDependency dep = new SqlDependency(cmd);
        //                //add onchange event,excute when linq's data update
        //                dep.OnChange += new OnChangeEventHandler(dep_OnChange);

        //                cmd.ExecuteNonQuery();
        //                objCache = query.ToList();
        //                //System.Web.HttpRuntime.Cache.Insert(this.CacheId, objCache);
                        
        //            }
        //        }
        //        return objCache;
        //    }
        //    else
        //    {
        //        return objCache;
        //    }
        //}
        //private void dep_OnChange(object sender, SqlNotificationEventArgs e)
        //{
        //    //System.Web.HttpRuntime.Cache.Remove(this.CacheId);
            
        //}

        ///// <summary>
        ///// get Parameter in linq and convert to SqlParameter.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="query"></param>
        ///// <returns></returns>
        //private SqlParameter[] GetSqlParameterInLinq<T>(DbQuery<T> query)
        //{
        //    var internalQuery = query.GetType()
        //.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //.Where(field => field.Name == "_internalQuery")
        //.Select(field => field.GetValue(query))
        //.First();

        //    var objectQuery = internalQuery.GetType()
        //        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //        .Where(field => field.Name == "_objectQuery")
        //        .Select(field => field.GetValue(internalQuery))
        //        .Cast<ObjectQuery<T>>()
        //        .First();

        //    //get SqlParamenters in linq
        //    var parameters = new SqlParameter[0];
        //    parameters = objectQuery.Parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray();
        //    return parameters;
        //}

    }

    public class SqlDependencyOperator<T>
    {
        private string CacheId;
        //private System.Web.Caching.Cache Cache;
        private MemoryCache Cache;

        //public List<T> GetCacheObj(string connStr, DbQuery<T> query, SqlParameter[] parameters, string cacheId,  MemoryCache cache)
        //{
        //    this.CacheId = cacheId;
        //    this.Cache = cache;
        //    List<T> objCache;
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
        //        {
        //            cmd.Parameters.AddRange(parameters);

        //            SqlDependency dep = new SqlDependency(cmd);
        //            SqlDependency.Start(connStr);
        //            //add onchange event,excute when linq's data update
        //            dep.OnChange += new OnChangeEventHandler(dep_OnChange);

        //            cmd.ExecuteNonQuery();
        //            objCache = query.ToList();
        //            // System.Web.HttpRuntime.Cache.Insert(this.CacheId, objCache);
        //            //this.Cache.Insert(this.CacheId, objCache);
        //            StaticCacheHelper.SetCacheValue(this.CacheId, objCache);
        //            //SqlDependency.Stop(connStr);
        //        }
        //    }
        //    return objCache;
        //}

        //private void dep_OnChange(object sender, SqlNotificationEventArgs e)
        //{
        //    //System.Web.HttpRuntime.Cache.Remove(this.CacheId);
        //    //this.Cache.Remove(this.CacheId);
        //    StaticCacheHelper.RemoveCacheValue(this.CacheId);
        //}
    }

    public static class StaticCacheHelper
    {
        private static MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <returns>返回缓存的值</returns>
        public static object GetCacheValue(string key)
        {
            object val = null;
            if (key != null && cache.TryGetValue(key, out val))
            {
                return val;
            }
            else
            {
                return default(object);
            }
        }

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <param name="value">缓存值</param>
        public static void SetCacheValue(string key, object value)
        {
            if (key != null)
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                });
            }
        }

        public static void RemoveCacheValue(string key)
        {
            cache.Remove(key);
        }

        //public static List<T> GetLinqCahce<T>(IQueryable<T> q, string cacheId, string dbConnectionName)
        //{

        //    //List<T> objCache = (List<T>)System.Web.HttpRuntime.Cache.Get(cacheId);
        //    List<T> objCache = (List<T>)GetCacheValue(cacheId);
        //    if (null == objCache)
        //    {
        //        string CONNECTION_STRING = Utility.Web.ConfigurationHelper.GetConnectionString(dbConnectionName);

        //        var query = q as DbQuery<T>;

        //        var parameters = StaticCacheHelper.GetSqlParameterInLinq<T>(query);

        //        SqlDependencyOperator<T> container = new SqlDependencyOperator<T>();
        //        objCache = container.GetCacheObj(CONNECTION_STRING, query, parameters, cacheId, System.Web.HttpRuntime.Cache);
        //        return objCache;
        //    }
        //    else
        //    {
        //        return objCache;
        //    }
        //}

        /// <summary>
        /// get Parameter in linq and convert to SqlParameter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        //private static SqlParameter[] GetSqlParameterInLinq<T>(DbQuery<T> query)
        //{
        //    var internalQuery = query.GetType()
        //.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //.Where(field => field.Name == "_internalQuery")
        //.Select(field => field.GetValue(query))
        //.First();

        //    var objectQuery = internalQuery.GetType()
        //        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //        .Where(field => field.Name == "_objectQuery")
        //        .Select(field => field.GetValue(internalQuery))
        //        .Cast<ObjectQuery<T>>()
        //        .First();

        //    //get SqlParamenters in linq
        //    var parameters = new SqlParameter[0];
        //    parameters = objectQuery.Parameters.Select(x => new SqlParameter(x.Name, x.Value)).ToArray();
        //    return parameters;
        //}
    }

}
