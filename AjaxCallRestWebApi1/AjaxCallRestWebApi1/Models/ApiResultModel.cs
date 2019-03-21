using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AjaxCallRestWebApi1.Models
{
    public class ApiResultModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 状态代码
        /// </summary>
        public HttpStatusCode return_code { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 返回的数据
        /// </summary>
        public object data { get; set; }

    }
}