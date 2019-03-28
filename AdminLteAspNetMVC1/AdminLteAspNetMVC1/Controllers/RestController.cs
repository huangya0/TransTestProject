using AdminLteAspNetMVC1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AdminLteAspNetMVC1.Controllers
{
    public class Site
    {
        public int SiteId { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
    }

    public class HttpClientPostParam
    {
        public int StartId { get; set; }
        public int ItemCount { get; set; }
    }

    //[Authorize] //TestCallPage.html页面如果开了验证， 就会无权访问
    public class RestController : ApiController
    {
        /// <summary>
        /// User Data List
        /// </summary>
        private readonly List<Users> _userList = new List<Users>
       {
           new Users {UserID = 1, UserName = "zzl", UserEmail = "bfyxzls@sina.com"
            , Birthday= Convert.ToDateTime("1991-05-31")},
           new Users {UserID = 2, UserName = "Spiderman", UserEmail = "Spiderman@cnblogs.com"
            , Birthday= Convert.ToDateTime("1991-05-31")},
           new Users {UserID = 3, UserName = "Batman", UserEmail = "Batman@cnblogs.com"
            , Birthday= Convert.ToDateTime("1991-05-31")}
       };

        /// <summary>
        /// 得到列表对象
        /// </summary>
        /// <returns></returns>
        //[Route("rest")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userList);
        }

        /// <summary>
        /// 得到一个实体，根据主键
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Route("rest/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var user = _userList.FirstOrDefault(i => i.UserID == id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[Authorize] //验证
        [HttpGet]
        //[Route("rest/exists/{name}")]
        public HttpResponseMessage Exists(string name)
        {
            ApiResultModel result = new ApiResultModel();
            result.return_code = HttpStatusCode.OK;
            result.return_msg = "请求成功";
            result.success = true;
            result.data = (_userList.FirstOrDefault(i => i.UserName == name) != null);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="form">表单对象，它是唯一的</param>
        /// <returns></returns>
        //[Route("rest")] //已不用
        public HttpResponseMessage Post([FromBody] Users entity)
        {
            _userList.Add(entity);
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="form">表单对象，它是唯一的</param>
        /// <returns></returns>
        //[Route("rest")] //已不用
        public HttpResponseMessage Put(int id, [FromBody]Users entity)
        {
            ApiResultModel result = new ApiResultModel();
            var user = _userList.FirstOrDefault(i => i.UserID == id);
            if (user != null)
            {
                user.UserName = entity.UserName;
                user.UserEmail = entity.UserEmail;

                result.success = true;
                result.return_code = HttpStatusCode.OK;
                result.return_msg = "请求成功";
                result.data = user;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                result.success = false;
                result.return_code = HttpStatusCode.BadRequest;
                result.return_msg = "无效参数";
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
        }

        //Post方法，同时接收URL参数与Post过来的实体参数
        public HttpResponseMessage UpdateByID(int id, [FromBody]Users entity)
        {
            ApiResultModel result = new ApiResultModel();
            var user = _userList.FirstOrDefault(i => i.UserID == id);
            if (user != null)
            {
                user.UserName = entity.UserName;
                user.UserEmail = entity.UserEmail;

                result.success = true;
                result.return_code = HttpStatusCode.OK;
                result.return_msg = "请求成功";
                result.data = user;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                result.success = false;
                result.return_code = HttpStatusCode.BadRequest;
                result.return_msg = "无效参数";
                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
        }

        //public HttpResponseMessage AddNewItem(int id, [FromBody]Users entity)
        [HttpPost]
        public HttpResponseMessage AddNewItem([FromBody] Users entity)
        {
            _userList.Add(entity);
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        //[Route("rest/{id}")] //已不用
        [AllowAnonymous]
        public HttpResponseMessage Delete(int id)
        {
            _userList.Remove(_userList.FirstOrDefault(i => i.UserID == id));
            return Request.CreateResponse(HttpStatusCode.OK, _userList);
        }

        //验证需按 https://www.cnblogs.com/landeanfen/p/5287064.html#_label3_2 处理
        [Authorize]
        [HttpPost]
        public HttpResponseMessage DeleteByID(int id)
        {
            _userList.Remove(_userList.FirstOrDefault(i => i.UserID == id));
            return Request.CreateResponse(HttpStatusCode.OK, _userList);
        }

        //供同步/异步调用
        //async
        [HttpPost]
        public HttpResponseMessage SyncDeleteByID(int id)
        {
            Thread.Sleep(3000);
            _userList.Remove(_userList.FirstOrDefault(i => i.UserID == id));
            return Request.CreateResponse(HttpStatusCode.OK, _userList);
        }

        //测试QueryString有两个参考
        [HttpGet]
        public IList<Site> SiteList(int startId, int itemcount)
        {
            var sites = new List<Site>();
            sites.Add(new Site { SiteId = 1, Title = "test", Uri = "www.cnblogs.cc" });
            sites.Add(new Site { SiteId = 2, Title = "博客园首页", Uri = "www.cnblogs.com" });
            sites.Add(new Site { SiteId = 3, Title = "博问", Uri = "q.cnblogs.com" });
            sites.Add(new Site { SiteId = 4, Title = "新闻", Uri = "news.cnblogs.com" });
            sites.Add(new Site { SiteId = 5, Title = "招聘", Uri = "job.cnblogs.com" });

            var result = (from Site site in sites
                          where site.SiteId > startId
                          select site)
                            .Take(itemcount)
                            .ToList();
            return result;
        }

        //Get可以有多个URL参数
        [HttpGet]
        public string SiteList2(int startId, int itemcount)
        {
            return startId.ToString() + "--" + itemcount.ToString();
        }

        //测试HttpClient调用POST

        //public IList<Site> SiteList3(int startId, int itemcount)
        [HttpPost]
        public IList<Site> SiteList3(HttpClientPostParam obj)
        {
            //JavaScriptConvert.DeserializeObject(jsonString, obj.GetType());
            var sites = new List<Site>();
            sites.Add(new Site { SiteId = 1, Title = "test", Uri = "www.cnblogs.cc" });
            sites.Add(new Site { SiteId = 2, Title = "博客园首页", Uri = "www.cnblogs.com" });
            sites.Add(new Site { SiteId = 3, Title = "博问", Uri = "q.cnblogs.com" });
            sites.Add(new Site { SiteId = 4, Title = "新闻", Uri = "news.cnblogs.com" });
            sites.Add(new Site { SiteId = 5, Title = "招聘", Uri = "job.cnblogs.com" });

            var result = (from Site site in sites
                          where site.SiteId > obj.StartId
                          select site)
                            .Take(obj.ItemCount)
                            .ToList();
            return result;

            //return "Success";
            //return obj.StartId.ToString() + obj.ItemCount.ToString();
        }
    }
}
