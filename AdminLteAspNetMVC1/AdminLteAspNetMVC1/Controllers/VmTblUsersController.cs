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
using EMS.Model;


namespace AdminLteAspNetMVC1.Controllers
{
    public class VmTblUsersController : BaseController<EMS.BL.IUserBL, EMS.BL.UserBL>
    {

        // GET: VmTblUsers
        public ActionResult Index()
        {
            return View(BusinessLogic.GetUserList());
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
