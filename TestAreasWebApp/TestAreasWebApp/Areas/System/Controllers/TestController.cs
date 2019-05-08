using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.System.Controllers
{
    public class TestController : Controller
    {
        // GET: System/Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return  View();
        }
    }
}