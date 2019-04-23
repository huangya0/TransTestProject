using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AspNetMvcAjaxWebApp1.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization.Json;

namespace AspNetMvcAjaxWebApp1.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        //主页面
        public ActionResult MainPage()
        {

            return View();
        }

        public ActionResult GetTableContent()
        {
            if (Request.IsAjaxRequest())
            {
                string tableStr = "<table><tr><td>这是Ajax返回的内容</td></tr></table>";
                return Content(tableStr);
            }
            else
            {
                return View("这不是Ajax返回的内容");
            }
        }

        public ActionResult AjaxForm(SubmitViewModel item)
        {
            if (Request.IsAjaxRequest())
            {
                string itemPro = JsonConvert.SerializeObject(item);
                //string scriptStr = "<script>alert('服务器端返回脚本提示');</script>";
                return JavaScript($"alert('服务器端返回脚本提示，你提交的数据json是{itemPro}')");
            }

            return View(item);
        }

        //分部页面
        public ActionResult ListPage()
        {
            IList<PersonViewModel> persons = new List<PersonViewModel>();
            for (int i = 0; i < 10; i++)
            {
                persons.Add(new PersonViewModel() { Email = "email" + i, Name = "name", IsMarried = false, PhoneNum = "1234" + i, Home = CityEnum.BJ, Height = i });
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(persons);
            }

            return View(persons);
        }
    }
}