using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminLteAspNetMVC1.Controllers
{
    public class HomeController : Controller
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
    }
}