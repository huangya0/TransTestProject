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
    [Authorize]
    public class SampleController : BaseController<EMS.BL.ISampleBL, EMS.BL.SampleBL>
    {
        //private AdminLteAspNetMVC1Context db = new AdminLteAspNetMVC1Context();

        // GET: Sample
        public ActionResult Index()
        {
            var dataList = BusinessLogic.GetSampleList();
            return View(dataList);

            //return View();
        }

        // GET: Sample/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleItemModel sampleItemModel = BusinessLogic.GetSampleList().Where(i=>i.Id == id).First();
            if (sampleItemModel == null)
            {
                return HttpNotFound();
            }
            return View(sampleItemModel);
        }

        // GET: Sample/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sample/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,UpdatedDate,UpdatedBy,UpdatedByID,CreatedDate,CreatedBy,CreatedByID")] SampleItemModel sampleItemModel)
        {
            if (ModelState.IsValid)
            {
                //db.SampleItemModels.Add(sampleItemModel);
                //db.SaveChanges();
                //需在SampleBL中建一个Create方法,  Create方法里将view model转换成database model再用EF方法保存
                return RedirectToAction("Index");
            }

            return View(sampleItemModel);
        }

        // GET: Sample/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleItemModel sampleItemModel = BusinessLogic.GetSampleList().Where(i => i.Id == id).First();
            if (sampleItemModel == null)
            {
                return HttpNotFound();
            }
            return View(sampleItemModel);
        }

        // POST: Sample/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,UpdatedDate,UpdatedBy,UpdatedByID,CreatedDate,CreatedBy,CreatedByID")] SampleItemModel sampleItemModel)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(sampleItemModel).State = EntityState.Modified;
                //db.SaveChanges();
                //需在SampleBL中建一个Edit方法, Edit方法里将view model转换成database model再用EF方法保存
                return RedirectToAction("Index");
            }
            return View(sampleItemModel);
        }

        // GET: Sample/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SampleItemModel sampleItemModel = BusinessLogic.GetSampleList().Where(i => i.Id == id).First();
            if (sampleItemModel == null)
            {
                return HttpNotFound();
            }
            return View(sampleItemModel);
        }

        // POST: Sample/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SampleItemModel sampleItemModel = BusinessLogic.GetSampleList().Where(i => i.Id == id).First();
            //db.SampleItemModels.Remove(sampleItemModel);
            //db.SaveChanges();
            //需在SampleBL中建一个Delete方法, Delete方法再调用EF的删除
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
