using AdminLteAspNetMVC1.Common;
using EMS.BL.Common;
using EMS.Model;
using EMS.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VM = EMS.Model;

namespace AdminLteAspNetMVC1.Controllers
{
    [NoCache]
    public class LoginController : BaseController  //BaseController<EMS.BL.ISampleBL, EMS.BL.SampleBL>
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(VM.LoginModel model, string returnUrl)
        {
            var request = Request;

            if (ModelState.IsValid)
            {
                //using (Permission permissionBL = new Permission())
                //{
                //    UserItem userItem = permissionBL.ValidUser(model);
                //    if (userItem == null)
                //    {
                //        ModelState.AddModelError("", "用户名或密码不存在.");
                //        return View(model);
                //    }
                //    else
                //    {
                //        UserHelper.WriteLoginCookie(userItem);
                //        returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
                //        return Redirect(returnUrl);
                //    }
                //}

                using (Permission permissionBL = new Permission())
                {
                    UserItem userItem = permissionBL.ValidUser(model);
                    if (userItem == null)
                    {
                        ModelState.AddModelError("", "用户名或密码不存在.");
                        return View(model);
                    }
                    else
                    {
                        UserHelper.WriteLoginCookie(userItem);
                        returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
                        return Redirect(returnUrl);
                    }
                }
            }
            else
            {
                return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult LoginOff()
        {
            FormsAuthentication.SignOut();
            //return PartialView("LoginPart", new VM.LoginModel());
            return Redirect("/");
        }
    }

}