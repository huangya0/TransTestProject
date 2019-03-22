using AdminLteAspNetMVC1.Common;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VM = EMS.Model;

namespace AdminLteAspNetMVC1.Controllers
{
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

                //UserItem userItem = permissionBL.ValidUser(model);
                if (model.LoginName == "zack" || model.LoginName == "zack2")
                {
                    UserModel um = new UserModel();
                    um.ID = 1;
                    um.LogonName = model.LoginName;

                    UserHelper.WriteLoginCookie(um);
                    returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
                    return Redirect(returnUrl);
                    
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不存在.");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult LoginOff()
        {
            FormsAuthentication.SignOut();
            //return PartialView("LoginPart", new VM.LoginModel());
            return Redirect("/");
        }
    }

}