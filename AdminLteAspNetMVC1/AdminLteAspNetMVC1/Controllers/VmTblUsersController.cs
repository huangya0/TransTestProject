using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminLteAspNetMVC1.Common;
using AdminLteAspNetMVC1.Models;
using EMS.Model.User;


namespace AdminLteAspNetMVC1.Controllers
{
    public class VmTblUsersController : BaseController<EMS.BL.IUserBL, EMS.BL.UserBL>
    {

        // GET: VmTblUsers
        //public ActionResult Index()
        //{
        //    return View(BusinessLogic.GetUserList());
        //}

        public ActionResult Index(UserSearchModel search)
        {
            ViewBag.IsSortable = true;
            var model = new UserModel();
            //search.LogonName = this.GetCurrentCompanyId();
            model.ItemList = BusinessLogic.GetUserList(search);
            ViewBag.Message = BusinessLogic.Message;
            model.Search = search;
            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListContainer", model);
            }
            return View(model);
        }

        public ActionResult AddComment()
        {
            //return PartialView((object)("test by zack"));
            return Json("test test tes");
        }

        public ActionResult AjaxForm(SubmitViewModel item)
        {
            if (Request.IsAjaxRequest())
            {
                //此处保存到db
                //if(ModelState.IsValid)

                string itemPro = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                //string scriptStr = "<script>alert('服务器端返回脚本提示');</script>";
                return JavaScript($"alert('服务器端返回脚本提示，你提交的数据json是{itemPro}')");
            }

            return View(item);
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


        [HttpPost]
        public ActionResult AjaxTest(string message)
        {
            return PartialView((object)message);
        }

        // GET: VmTblUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VmTblUser vmTblUser = BusinessLogic.GetUserByID(id.GetValueOrDefault());
            if (vmTblUser == null)
            {
                return HttpNotFound();
            }
            return View(vmTblUser);
        }

        // GET: VmTblUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VmTblUsers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,LogonName,Password,UserName,Gender,PhoneNumber,EmailAddress,IDNumber,DateOFBirth,Status,CanDelete,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] VmTblUser vmTblUser)
        {
            if (BusinessLogic.IsExistUser(vmTblUser))
            {
                ModelState.AddModelError("UserLogonName", "已经存在些用户名！");
            }

            if (ModelState.IsValid)
            {
                //db.VmTblUsers.Add(vmTblUser);
                //db.SaveChanges();

                BusinessLogic.CreateUser(vmTblUser);
                return RedirectToAction("Index");
            }

            return View(vmTblUser);
        }

        // GET: VmTblUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VmTblUser vmTblUser = BusinessLogic.GetUserByID(id.GetValueOrDefault());

            if (vmTblUser == null)
            {
                return HttpNotFound();
            }
            return View(vmTblUser);
        }

        // POST: VmTblUsers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,LogonName,Password,UserName,Gender,PhoneNumber,EmailAddress,IDNumber,DateOFBirth,Status,CanDelete,CreatedDate,CreatedBy,UpdatedDate,UpdatedBy")] VmTblUser vmTblUser)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(vmTblUser).State = EntityState.Modified;
                //db.SaveChanges();
                BusinessLogic.UpdateUser(vmTblUser);

                return RedirectToAction("Index");
            }

            return View(vmTblUser);
        }

        // GET: VmTblUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //VmTblUser vmTblUser = db.VmTblUsers.Find(id);
            VmTblUser vmTblUser = BusinessLogic.GetUserByID(id.GetValueOrDefault());

            if (vmTblUser == null)
            {
                return HttpNotFound();
            }
            return View(vmTblUser);
        }

        // POST: VmTblUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //VmTblUser vmTblUser = db.VmTblUsers.Find(id);
            //db.VmTblUsers.Remove(vmTblUser);
            //db.SaveChanges();
            BusinessLogic.DeleteUser(id);

            return RedirectToAction("Index");
        }

    }
}
