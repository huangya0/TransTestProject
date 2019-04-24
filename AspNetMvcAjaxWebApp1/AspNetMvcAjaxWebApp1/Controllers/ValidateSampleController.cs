using AspNetMvcAjaxWebApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcAjaxWebApp1.Controllers
{
    public class ValidateSampleController : Controller
    {
        //http://jingpin.jikexueyuan.com/article/56983.html

        // GET: ValidateSample
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Person()
        {
            return PartialView("_Person");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Person(Person model)
        {
            if (!ModelState.IsValid)
            {
                var errors = "验证不通过!"; // GetErrorsFromModelState();
                return Json(new { success = false, errors = errors });
                //return PartialView("_Person", model);
            }

            ////save to persistent store;
            ////return data back to post OR do a normal MVC Redirect....
            //return Json(new { success = true });  //perhaps you want to do more on return.... otherwise this if block is not necessary....
            ////return RedirectToAction("Index");

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = true });
                //return JavaScript("addContentToDiv();");
            }

            return RedirectToAction("Index");
        }
    }
}