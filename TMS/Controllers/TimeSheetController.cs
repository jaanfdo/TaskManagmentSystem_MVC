using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TMS;
using TMS.Models;
using TMS.Models.ViewModels;
using TMS.Common;
using static TMS.Common.clsEnums;

namespace TMS.Controllers
{
    //[RoutePrefix("TimeSheet")]
    //[Authorize(Roles = "Administrators")]
    [Authorize]
    public class TimeSheetController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        // GET: tbl_pmsTxTimeSheet
        //[Route]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Index()
        {
            cls_HelpMethods.UserDetail();
            cls_HelpMethods.CompanyDetail();

            var tbl_pmsTxTimeSheet = db.tbl_pmsTxTimeSheet.Where(p => !p.isCancelled).Include(t => t.tbl_genMasSubTask);//p.user_ID == sUser_ID && 
            return View(tbl_pmsTxTimeSheet.ToList());
        }

        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Index2()
        {
            cls_HelpMethods.UserDetail();
            cls_HelpMethods.CompanyDetail();

            var tbl_pmsTxTimeSheet = db.tbl_pmsTxTimeSheet.Where(p => !p.isCancelled).Include(t => t.tbl_genMasSubTask);//p.user_ID == sUser_ID && 
            return View(tbl_pmsTxTimeSheet.ToList());
        }

        public ActionResult List()
        {
            return View();
        }

        public JsonResult TimeSheets(bool ShowAll)
        {
            List<TimeSheetVM> List = db.tbl_pmsTxTimeSheet.Where(p => p.user_ID == sUser_ID)
                .Select(x => new TimeSheetVM
                {
                    user_ID = x.user_ID,
                    user = db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == x.user_ID).userName,
                    timeSheet_ID = x.timeSheet_ID,
                    timeSheetDate = x.timeSheetDate,
                    subTask_ID = x.subTask_ID,
                    subTask = x.tbl_genMasSubTask.subTaskName,
                    isCancelled = x.isCancelled,
                    totalUtilizedHours = x.totalUtilizedHours,
                    remarks = x.remarks
                }).OrderByDescending(p => p.timeSheetDate).ThenByDescending(p => p.timeSheet_ID).ToList();

            if (!ShowAll)
                List = List.Where(p => p.isCancelled == false).ToList();

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TimeSheetsDetail(string timeSheet_ID)
        {
            List<TimeSheet_DetailVM> List = db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == timeSheet_ID)
                .Select(x => new TimeSheet_DetailVM
                {
                    timeSheet_ID = x.timeSheet_ID,
                    task_ID = x.task_ID,
                    status_ID = x.status_ID,
                    status = x.status_ID != null ? db.tbl_genMasStatus.FirstOrDefault(p => p.status_ID == x.status_ID).status : "",
                    task = x.tbl_pmsTxTask.taskReference,
                    utilizedHours = x.utilizedHours,
                    remarks = x.remarks,
                    line_No = x.line_No
                }).ToList();

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TimeSheet(string timeSheet_ID)
        {
            List<TimeSheetVM> List = db.tbl_pmsTxTimeSheet.Where(p => p.timeSheet_ID == timeSheet_ID)
                .Select(x => new TimeSheetVM
                {
                    timeSheet_ID = x.timeSheet_ID,
                    timeSheetDate = x.timeSheetDate,
                    subTask_ID = x.tbl_genMasSubTask.subTaskName,
                    remarks = x.remarks,
                    totalUtilizedHours = x.totalUtilizedHours,
                    isCancelled = x.isCancelled
                }).ToList();

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        // GET: tbl_pmsTxTimeSheet/Edit/5
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Edit(string timeSheet_ID)
        {
            if (timeSheet_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = db.tbl_pmsTxTimeSheet.Where(p => p.timeSheet_ID == timeSheet_ID).FirstOrDefault();
            if (tbl_pmsTxTimeSheet == null)
            {
                return HttpNotFound();
            }

            ViewBag.isCancel = tbl_pmsTxTimeSheet.isCancelled;
            ViewBag.timeSheet_ID = tbl_pmsTxTimeSheet.timeSheet_ID;

            ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask, "subTask_ID", "subTaskName", tbl_pmsTxTimeSheet.subTask_ID);

            var vResult = db.tbl_pmsTxTask.Where(p => p.status_ID != "2" && p.assignedUser_ID == sUser_ID);
            ViewBag.task_ID = new SelectList(vResult, "task_ID", "taskReference");

            return View(tbl_pmsTxTimeSheet);
        }

        // GET: tbl_pmsTxTimeSheet/Details/5
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = db.tbl_pmsTxTimeSheet.Find(id);
            if (tbl_pmsTxTimeSheet == null)
            {
                return HttpNotFound();
            }
            return View(tbl_pmsTxTimeSheet);
        }

        // GET: tbl_pmsTxTimeSheet/Delete/5
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = db.tbl_pmsTxTimeSheet.Find(id);
            if (tbl_pmsTxTimeSheet == null)
            {
                return HttpNotFound();
            }
            return View(tbl_pmsTxTimeSheet);
        }

        // GET: tbl_pmsTxTimeSheet/Create
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Create()
        {
            ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask, "subTask_ID", "subTaskName");
            ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status");

            var vResult = db.tbl_pmsTxTask.Where(p => p.status_ID != "2" && p.assignedUser_ID == sUser_ID);
            ViewBag.task_ID = new SelectList(vResult, "task_ID", "taskReference");
            return View();
        }



        #region Transactions
        // POST: tbl_pmsTxTimeSheet/Create
        [HttpPost]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public JsonResult SaveTimeSheet(TimeSheet oTimeSheet)
        {
            bool status = false;
            string TimeSheetID = "";
            string Message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        oTimeSheet.timeSheet_ID = tbl_AutoCode.AutoCode((int)enumFormNames.TimeSheet);
                        if (oTimeSheet.timeSheet_ID != null)
                        {
                            tbl_pmsTxTimeSheet oTimeSheets = new tbl_pmsTxTimeSheet(oTimeSheet.timeSheet_ID, oTimeSheet.timeSheetDate, oTimeSheet.subTask_ID, oTimeSheet.totalUtilizedHours, oTimeSheet.remarks != null ? oTimeSheet.remarks : "",
                               false, sUser_ID, sUser_ID, sUser_ID, sUser_ID, DateTime.Now, DateTime.Now, DateTime.Now, sCompany_ID, sCompanyBranch_ID);

                            db.tbl_pmsTxTimeSheet.Add(oTimeSheets);
                            TimeSheetID = oTimeSheet.timeSheet_ID;
                            db.SaveChanges();


                            foreach (var oDetail in oTimeSheet.TimeSheetDetails)
                            {
                                var Task = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oDetail.task_ID);
                                Task.status_ID = oDetail.status_ID;

                                tbl_pmsTxTimeSheet_Detail oTimeSheets_Detail = new tbl_pmsTxTimeSheet_Detail();
                                oTimeSheets_Detail.task_ID = oDetail.task_ID;
                                oTimeSheets_Detail.line_No = oDetail.line_No;
                                oTimeSheets_Detail.timeSheet_ID = oTimeSheet.timeSheet_ID;
                                oTimeSheets_Detail.remarks = oDetail.remarks != null ? oDetail.remarks : "";
                                oTimeSheets_Detail.utilizedHours = oDetail.utilizedHours;
                                oTimeSheets_Detail.status_ID = oDetail.status_ID;

                                db.tbl_pmsTxTimeSheet_Detail.Add(oTimeSheets_Detail);
                            }

                            //db.tbl_pmsTxTimeSheet_Detail.AddRange(oTimeSheet.TimeSheetDetails);
                            db.SaveChanges();

                            Message = "Time Sheet Saved Successfully...!";
                            status = true;
                        }
                        else
                        {
                            Message = "Time Sheet ID is Empty...!";
                            status = false;
                        }

                    }
                    else
                    {
                        string sHeader = "Your Session is Expired";
                        Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
                        status = false;
                    }
                }
                else
                {
                    Message = "Model State Invalid...!";
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }

            return new JsonResult { Data = new { status = status, TimeSheetID = TimeSheetID, Message = Message } };
        }

        // POST: tbl_pmsTxTimeSheet/Edit/5
        [HttpPost]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public JsonResult EditTimeSheet(TimeSheet oTimeSheet)
        {
            bool status = false;
            string Message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        var oldRecord = db.tbl_pmsTxTimeSheet.FirstOrDefault(p => p.timeSheet_ID == oTimeSheet.timeSheet_ID);
                        if (oldRecord != null)
                        {
                            foreach (var oldRecordDetail in db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == oTimeSheet.timeSheet_ID))
                            {
                                db.Entry(oldRecordDetail).State = EntityState.Deleted;
                            }
                            db.SaveChanges();

                            oldRecord.timeSheet_ID = oTimeSheet.timeSheet_ID;
                            oldRecord.timeSheetDate = oTimeSheet.timeSheetDate;
                            oldRecord.subTask_ID = oTimeSheet.subTask_ID;
                            oldRecord.totalUtilizedHours = oTimeSheet.totalUtilizedHours;
                            oldRecord.remarks = oTimeSheet.remarks != null ? oTimeSheet.remarks : "";
                            oldRecord.modifiedUser_ID = sUser_ID;
                            oldRecord.dateModified = DateTime.Now;

                            foreach (var oDetail in oTimeSheet.TimeSheetDetails)
                            {
                                var Task = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oDetail.task_ID);
                                Task.status_ID = oDetail.status_ID;

                                tbl_pmsTxTimeSheet_Detail oTimeSheets_Detail = new tbl_pmsTxTimeSheet_Detail();
                                oTimeSheets_Detail.task_ID = oDetail.task_ID;
                                oTimeSheets_Detail.line_No = oDetail.line_No;
                                oTimeSheets_Detail.timeSheet_ID = oTimeSheet.timeSheet_ID;
                                oTimeSheets_Detail.remarks = oDetail.remarks != null ? oDetail.remarks : "";
                                oTimeSheets_Detail.utilizedHours = oDetail.utilizedHours;
                                oTimeSheets_Detail.status_ID = oDetail.status_ID;

                                db.tbl_pmsTxTimeSheet_Detail.Add(oTimeSheets_Detail);
                            }

                            db.SaveChanges();

                            Message = "Time Sheet Updated Successfully...!";
                            status = true;
                        }
                        else
                        {
                            Message = "Time Sheet Details are Empty...!";
                            status = false;
                        }
                    }
                    else
                    {
                        string sHeader = "Your Session is Expired";
                        Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
                        status = false;
                    }
                }
                else
                {
                    Message = "Model State Invalid...!";
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }
            return new JsonResult { Data = new { status = status, Message = Message } };
        }

        // POST: tbl_pmsTxTimeSheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public JsonResult DeleteConfirmed(string timeSheet_ID)
        {
            bool status = false;
            string Message = "";
            try
            {
                if (timeSheet_ID != null)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        var oTimeSheet = db.tbl_pmsTxTimeSheet.Find(timeSheet_ID);
                        if (oTimeSheet != null)
                        {
                            oTimeSheet.isCancelled = true;
                            oTimeSheet.deletedUser_ID = sUser_ID;
                            oTimeSheet.dateDeleted = DateTime.Now;

                            //db.Entry(oTimeSheet).State = EntityState.Modified;
                            db.SaveChanges();

                            ViewBag.isCancel = oTimeSheet.isCancelled;

                            Message = "Time Sheet Cancelled Successfully...!";
                            status = true;
                        }
                        else
                        {
                            Message = "Time Sheet Details are Empty...!";
                            status = false;
                        }
                    }
                    else
                    {
                        string sHeader = "Your Session is Expired";
                        Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
                        status = false;
                    }
                }
                else
                {
                    Message = "Time Sheet ID is Empty...!";
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }
            return new JsonResult { Data = new { status = status, Message = Message } };
        } 
        #endregion


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
