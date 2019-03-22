using AdminLteAspNetMVC1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminLteAspNetMVC1.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact()
        {
            ViewBag.Message = await this.AsyncMethod1();

            return View();
        }

        private Task<string> AsyncMethod1()
        {
            Thread.Sleep(3000);
            return Task.FromResult("MEssage return by a AsyncMethod!");
        }

        public ActionResult MenuLevel2_1()
        {
            ViewBag.Message = "MenuLevel2_1 selected";

            return View();
        }

        public ActionResult MenuLevel2_2()
        {
            ViewBag.Message = "MenuLevel2_2 selected";

            return View();
        }

        public ActionResult MenuLevel2_3()
        {
            ViewBag.Message = "MenuLevel2_3 selected";

            return View();
        }

        public ActionResult MenuLevel3_1()
        {
            ViewBag.Message = "MenuLevel3_1 selected";

            return View();
        }

        public ActionResult MenuLevel3_2()
        {
            ViewBag.Message = "MenuLevel3_2 selected";

            return View();
        }

        public ActionResult MenuLevel3_3()
        {
            ViewBag.Message = "MenuLevel3_3 selected";

            return View();
        }
    }
}