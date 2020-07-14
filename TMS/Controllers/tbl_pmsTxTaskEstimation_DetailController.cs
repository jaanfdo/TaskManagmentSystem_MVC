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
    public class tbl_pmsTxTaskEstimation_DetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tbl_pmsTxTaskEstimation_Detail
        public ActionResult Index()
        {
            var tbl_pmsTxTaskEstimation_Detail = db.tbl_pmsTxTaskEstimation_Detail.Include(t => t.tbl_genMasSubTask).Include(t => t.tbl_pmsTxTaskEstimation);
            return View(tbl_pmsTxTaskEstimation_Detail.ToList());
        }

        

        // GET: tbl_pmsTxTaskEstimation_Detail/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation_Detail tbl_pmsTxTaskEstimation_Detail = db.tbl_pmsTxTaskEstimation_Detail.Find(id);
        //    if (tbl_pmsTxTaskEstimation_Detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTaskEstimation_Detail);
        //}

        // GET: tbl_pmsTxTaskEstimation_Detail/Create
        //public ActionResult Create(int? i)
        //{
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask, "subTask_ID", "subTaskName");
        //    ViewBag.estimation_ID = new SelectList(db.tbl_pmsTxTaskEstimation, "estimation_ID", "task_ID");
        //    ViewBag.i = i;

        //    return PartialView();
        //}

        //public ActionResult StudentDetailsDemo(int? i)
        //{
        //    ViewBag.i = i;
        //    return PartialView();
        //}

        // POST: tbl_pmsTxTaskEstimation_Detail/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "line_No,estimation_ID,subTask_ID,estimatedHours")] tbl_pmsTxTaskEstimation_Detail tbl_pmsTxTaskEstimation_Detail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tbl_pmsTxTaskEstimation_Detail.Add(tbl_pmsTxTaskEstimation_Detail);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask, "subTask_ID", "subTaskName", tbl_pmsTxTaskEstimation_Detail.subTask_ID);
        //    ViewBag.estimation_ID = new SelectList(db.tbl_pmsTxTaskEstimation, "estimation_ID", "task_ID", tbl_pmsTxTaskEstimation_Detail.estimation_ID);
        //    return View(tbl_pmsTxTaskEstimation_Detail);
        //}

        // GET: tbl_pmsTxTaskEstimation_Detail/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //tbl_pmsTxTaskEstimation_Detail tbl_pmsTxTaskEstimation_Detail = db.tbl_pmsTxTaskEstimation_Detail.Find(id);
        //    List<tbl_pmsTxTaskEstimation_Detail> tbl_pmsTxTaskEstimation_Detail = db.tbl_pmsTxTaskEstimation_Detail.Where(p => p.estimation_ID == id).Include(t => t.tbl_genMasSubTask).Include(t => t.tbl_pmsTxTaskEstimation).ToList();
        //    if (tbl_pmsTxTaskEstimation_Detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask, "subTask_ID", "subTaskName", tbl_pmsTxTaskEstimation_Detail.FirstOrDefault().subTask_ID);
        //    ViewBag.estimation_ID = new SelectList(db.tbl_pmsTxTaskEstimation, "estimation_ID", "task_ID", tbl_pmsTxTaskEstimation_Detail.FirstOrDefault().estimation_ID);

        //    return View(tbl_pmsTxTaskEstimation_Detail);
        //}

        // POST: tbl_pmsTxTaskEstimation_Detail/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(tbl_pmsTxTaskEstimation_Detail tbl_pmsTxTaskEstimation_Detail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tbl_pmsTxTaskEstimation_Detail).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask, "subTask_ID", "subTaskName", tbl_pmsTxTaskEstimation_Detail.subTask_ID);
        //    ViewBag.estimation_ID = new SelectList(db.tbl_pmsTxTaskEstimation, "estimation_ID", "task_ID", tbl_pmsTxTaskEstimation_Detail.estimation_ID);
        //    return View(tbl_pmsTxTaskEstimation_Detail);
        //}

        // GET: tbl_pmsTxTaskEstimation_Detail/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation_Detail tbl_pmsTxTaskEstimation_Detail = db.tbl_pmsTxTaskEstimation_Detail.Find(id);
        //    if (tbl_pmsTxTaskEstimation_Detail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTaskEstimation_Detail);
        //}

        //// POST: tbl_pmsTxTaskEstimation_Detail/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    tbl_pmsTxTaskEstimation_Detail tbl_pmsTxTaskEstimation_Detail = db.tbl_pmsTxTaskEstimation_Detail.Find(id);
        //    db.tbl_pmsTxTaskEstimation_Detail.Remove(tbl_pmsTxTaskEstimation_Detail);
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
