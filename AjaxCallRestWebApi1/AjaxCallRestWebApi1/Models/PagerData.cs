using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxCallRestWebApi1.Models
{
    public class PagerData
    {
        /// <summary>
        /// 返回记录的总数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 返回分页的总数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 列表集合
        /// </summary>
        public object PageData { get; set; }


    }
}