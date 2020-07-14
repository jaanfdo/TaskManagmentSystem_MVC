using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEACC_TMS_New;
using SEACC_TMS_New.Models;

namespace SEACC_TMS_New.Controllers
{
    public class tbl_pmsTxTimeSheet_DetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tbl_pmsTxTimeSheet_Detail
        //public ActionResult Index()
        //{
        //    var tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Include(t => t.tbl_pmsTxTask).Include(t => t.tbl_pmsTxTimeSheet);
        //    return View(tbl_pmsTxTimeSheet_Detail.ToList());
        //}

        //public ActionResult Details(string id)
        //{
        //    var tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == id).Include(t => t.tbl_pmsTxTask).Include(t => t.tbl_pmsTxTimeSheet);
        //    return View(tbl_pmsTxTimeSheet_Detail.ToList());
        //}

        // GET: tbl_pmsTxTimeSheet_Detail/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTimeSheet_Detail tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Find(id);
        //    if (tbl_pmsTxTimeSheet_Detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTimeSheet_Detail);
        //}

        // GET: tbl_pmsTxTimeSheet_Detail/Create
        //public ActionResult Create(int? i)
        //{
        //    ViewBag.task_ID = new SelectList(db.tbl_pmsTxTask, "task_ID", "taskReference");
        //    ViewBag.timeSheet_ID = new SelectList(db.tbl_pmsTxTimeSheet, "timeSheet_ID", "subTask_ID");
        //    ViewBag.i = i;

        //    return PartialView();
        //}

        // POST: tbl_pmsTxTimeSheet_Detail/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "line_No,timeSheet_ID,task_ID,utilizedHours,remarks")] tbl_pmsTxTimeSheet_Detail tbl_pmsTxTimeSheet_Detail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tbl_pmsTxTimeSheet_Detail.Add(tbl_pmsTxTimeSheet_Detail);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.task_ID = new SelectList(db.tbl_pmsTxTask, "task_ID", "taskReference", tbl_pmsTxTimeSheet_Detail.task_ID);
        //    ViewBag.timeSheet_ID = new SelectList(db.tbl_pmsTxTimeSheet, "timeSheet_ID", "subTask_ID", tbl_pmsTxTimeSheet_Detail.timeSheet_ID);
        //    return View(tbl_pmsTxTimeSheet_Detail);
        //}

        // GET: tbl_pmsTxTimeSheet_Detail/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //tbl_pmsTxTimeSheet_Detail tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Find(id);
        //    List<tbl_pmsTxTimeSheet_Detail> tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == id).Include(t => t.tbl_pmsTxTask).Include(t => t.tbl_pmsTxTimeSheet).ToList();      
        //    if (tbl_pmsTxTimeSheet_Detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.task_ID = new SelectList(db.tbl_pmsTxTask, "task_ID", "taskReference", tbl_pmsTxTimeSheet_Detail.FirstOrDefault().task_ID);
        //    ViewBag.timeSheet_ID = new SelectList(db.tbl_pmsTxTimeSheet, "timeSheet_ID", "subTask_ID", tbl_pmsTxTimeSheet_Detail.FirstOrDefault().timeSheet_ID);

        //    return View(tbl_pmsTxTimeSheet_Detail);
        //}

        // POST: tbl_pmsTxTimeSheet_Detail/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(tbl_pmsTxTimeSheet_Detail tbl_pmsTxTimeSheet_Detail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tbl_pmsTxTimeSheet_Detail).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.task_ID = new SelectList(db.tbl_pmsTxTask, "task_ID", "taskReference", tbl_pmsTxTimeSheet_Detail.task_ID);
        //    ViewBag.timeSheet_ID = new SelectList(db.tbl_pmsTxTimeSheet, "timeSheet_ID", "subTask_ID", tbl_pmsTxTimeSheet_Detail.timeSheet_ID);
        //    return View(tbl_pmsTxTimeSheet_Detail);
        //}

        // GET: tbl_pmsTxTimeSheet_Detail/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTimeSheet_Detail tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Find(id);
        //    if (tbl_pmsTxTimeSheet_Detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTimeSheet_Detail);
        //}

        //// POST: tbl_pmsTxTimeSheet_Detail/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbl_pmsTxTimeSheet_Detail tbl_pmsTxTimeSheet_Detail = db.tbl_pmsTxTimeSheet_Detail.Find(id);
        //    db.tbl_pmsTxTimeSheet_Detail.Remove(tbl_pmsTxTimeSheet_Detail);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
