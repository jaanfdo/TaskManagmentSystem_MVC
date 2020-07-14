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
using TMS.Common;
using TMS.Models.ViewModels;
using static TMS.Common.clsEnums;
using System.IO;
using System.Security;
using System.Security.Permissions;

namespace TMS.Controllers
{
    //[Route("Task")]
    //[Authorize(Roles = "Administrators")]
    [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
    public class TaskController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;


        public JsonResult SearchTasks(string Search)
        {
            //int val;
            List<TaskVM> List = null;
            //int.TryParse(Search, out val);
            //p.task_ID.StartsWith(int.TryParse(Search, out val) ? Search : "0")
            //p.taskReference.StartsWith(String.IsNullOrEmpty(Search) ? "" : Search))

            if (Search != null || Search != "")
            {
                List = db.tbl_pmsTxTask
                .Where(p => p.taskReference.Contains(Search.ToString().Trim()))
                .OrderByDescending(p => p.taskDate)
                .Select(s => new TaskVM
                {
                    task_ID = s.task_ID,
                    taskDate = s.taskDate,
                    taskReference = s.taskReference,
                    customer = s.tbl_genCustomerMaster.customerName,
                    product = s.tbl_genMasProduct.productName,
                }).ToList();
            }

            return Json(List, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TasksDetails(string task_ID)
        {
            //tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(id);
            var task = from s in db.tbl_pmsTxTask
                       where s.task_ID == task_ID
                       orderby s.taskDate
                       select new
                       {
                           Task_ID = s.task_ID,
                           TaskDate = s.taskDate,
                           TaskReference = s.taskReference,
                           Remarks = s.remarks,
                           Client = s.tbl_genCustomerMaster.customerName,
                           Client_ID = s.customer_ID,
                           Product = s.tbl_genMasProduct.productName,
                           Product_ID = s.product_ID,
                           TaskType = s.tbl_genMasTaskType.taskType,
                           TaskType_ID = s.taskType_ID,
                           Module = s.tbl_genMasModule.moduleName,
                           Module_ID = s.module_ID,
                           Function = s.tbl_genMasFunction.functionName,
                           Function_ID = s.function_ID,
                           Priority = s.tbl_genMasPriority.priority,
                           Priority_ID = s.priority_ID,
                           TaskStatus = s.tbl_genMasStatus.status,
                           TaskStatus_ID = s.status_ID,
                           ReportedDate = s.reported_Date,
                           ReportedBy = s.reportedUser_ID,
                           CreatedBy = db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == s.createUser_ID).userName
                       };
            return Json(task, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Modal()
        {
            return View();
        }

        public JsonResult CheckEstimationMandatoryTasks(string task_ID)
        {
            bool isValid = true;
            var taskType = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == task_ID);
            if (taskType != null)
            {
                bool isMandatoryEstimation = db.tbl_genMasTaskType.FirstOrDefault(p => p.taskType_ID == taskType.taskType_ID).isMandatoryEstimation;
                if (isMandatoryEstimation)
                {
                    var task = db.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == task_ID);
                    if (task != null)
                        isValid = true;
                    else
                        isValid = false;
                }
                else
                    isValid = true;
            }

            return Json(isValid, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AttachmentDetails(string transaction_ID)
        {
            List<AttachmentVM> Attachment = db.tbl_sasAttachments
                .Where(p => p.transaction_ID == transaction_ID)
                .Select(s => new AttachmentVM
                {
                    transaction_ID = s.transaction_ID,
                    attachment_Index = s.attachment_Index,
                    form_ID = s.form_ID,
                    attachment = s.attachment,
                    displayName = s.dipsplayName

                }).ToList();

            //var attachment = from s in db.tbl_sasAttachments
            //           where s.transaction_ID == transaction_ID
            //           select new 
            //           {
            //               transaction_ID = s.transaction_ID,
            //               attachment_Index = s.attachment_Index,
            //               form_ID = s.form_ID,
            //               attachment = s.attachment,
            //               displayName = s.dipsplayName
            //           };

            return Json(Attachment, JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public ActionResult Create()
        {
            cls_HelpMethods.UserDetail();
            cls_HelpMethods.CompanyDetail();

            tbl_genMasStatus oStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new"));

            ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
            ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
            ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
            ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
            ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", oStatus.status_ID);
            ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
            ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
            return View();
        }

        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public ActionResult Create2()
        {
            cls_HelpMethods.UserDetail();
            cls_HelpMethods.CompanyDetail();

            string sStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new")).status_ID;
            ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
            ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
            ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
            ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
            ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", sStatus);
            ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
            ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
            return View();
        }

        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public ActionResult Create3()
        {
            cls_HelpMethods.UserDetail();
            cls_HelpMethods.CompanyDetail();

            //string sStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new")).status_ID;
            //ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
            //ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
            //ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
            //ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
            //ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", sStatus);
            //ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
            //ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
            return View();
        }

        // GET: Task/Edit/5
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public ActionResult Edit(string task_ID)
        {
            if (task_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(task_ID);
            if (tbl_pmsTxTask == null)
            {
                return HttpNotFound();
            }

            ViewBag.task_ID = tbl_pmsTxTask.task_ID;
            ViewBag.isCancel = tbl_pmsTxTask.isCancelled;

            ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName", tbl_pmsTxTask.customer_ID);
            ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName", tbl_pmsTxTask.function_ID);
            ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
            ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
            ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName", tbl_pmsTxTask.product_ID);
            ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", tbl_pmsTxTask.status_ID);
            ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);
            return View(tbl_pmsTxTask);
        }

        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public ActionResult Edit2(string task_ID)
        {
            if (task_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(task_ID);
            if (tbl_pmsTxTask == null)
            {
                return HttpNotFound();
            }

            ViewBag.task_ID = tbl_pmsTxTask.task_ID;
            ViewBag.isCancel = tbl_pmsTxTask.isCancelled;

            ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster, "customer_ID", "customerName", tbl_pmsTxTask.customer_ID);
            ViewBag.function_ID = new SelectList(db.tbl_genMasFunction, "function_ID", "functionName", tbl_pmsTxTask.function_ID);
            ViewBag.module_ID = new SelectList(db.tbl_genMasModule, "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
            ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority, "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
            ViewBag.product_ID = new SelectList(db.tbl_genMasProduct, "product_ID", "productName", tbl_pmsTxTask.product_ID);
            ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status", tbl_pmsTxTask.status_ID);
            ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType, "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);
            return View(tbl_pmsTxTask);
        }

        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public ActionResult Details(string task_ID)
        {
            if (task_ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.task_ID = task_ID;

            return View();
        }

        #region Transaction
        [HttpPost]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public JsonResult SaveTask(Task oTask)
        {
            bool status = false;
            string TaskID = "", Message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        var ExsistsRecords = db.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == oTask.task_ID);
                        if (ExsistsRecords == null)
                        {
                            oTask.task_ID = tbl_AutoCode.AutoCode((int)enumFormNames.Task);
                            if (oTask.task_ID != null)
                            {
                                //DateTime dtTaskDate = DateTime.Parse(oTask.taskDate.ToString() + " " + DateTime.Now.TimeOfDay.ToString());
                                DateTime dtTaskDate = new DateTime(oTask.taskDate.Year, oTask.taskDate.Month, oTask.taskDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                                tbl_pmsTxTask tblTask = new tbl_pmsTxTask(oTask.task_ID, dtTaskDate, oTask.taskReference, oTask.remarks,
                                    oTask.reportedDate, oTask.reportedUser_ID,
                                    oTask.customer_ID, oTask.product_ID, oTask.module_ID, oTask.function_ID, oTask.taskType_ID, oTask.priority_ID, oTask.status_ID,
                                    DateTime.Now, clsConfig.DefaultUser,
                                    false, sUser_ID, sUser_ID, sUser_ID, DateTime.Now, DateTime.Now, DateTime.Now, sCompany_ID, sCompanyBranch_ID);

                                db.tbl_pmsTxTask.Add(tblTask);
                                db.SaveChanges();

                                TaskID = oTask.task_ID;

                                status = true;
                                Message = "Task Saved Successfully";
                            }
                            else
                            {
                                Message = "Task ID is Empty...!";
                                status = false;
                            }
                        }
                        else
                        {
                            Message = "Already Create This Task";
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

            return new JsonResult { Data = new { status = status, TaskID = TaskID, Message = Message } };
        }

        // POST: Task/Edit/5
        [HttpPost]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public JsonResult UpdateTask(Task oTask)
        {
            bool status = false;
            string Message = "";
            try
            {
                if (ModelState.IsValid)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        var oldRecord = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oTask.task_ID);
                        if (oldRecord != null)
                        {
                            //oldRecord.taskDate = oTask.taskDate;
                            oldRecord.taskReference = oTask.taskReference;
                            oldRecord.remarks = oTask.remarks;

                            oldRecord.customer_ID = oTask.customer_ID;
                            oldRecord.function_ID = oTask.function_ID;
                            oldRecord.module_ID = oTask.module_ID;
                            oldRecord.priority_ID = oTask.priority_ID;
                            oldRecord.product_ID = oTask.product_ID;
                            oldRecord.reportedUser_ID = oTask.reportedUser_ID;
                            oldRecord.reported_Date = oTask.reportedDate;
                            oldRecord.status_ID = oTask.status_ID;
                            oldRecord.taskType_ID = oTask.taskType_ID;

                            oldRecord.modifiedUser_ID = sUser_ID;
                            oldRecord.dateModified = DateTime.Now;

                            db.SaveChanges();

                            status = true;
                            Message = "Task Updated Successfully...!";
                        }
                        else
                        {
                            Message = "Task Details are Empty...!";
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

        // POST: Task/Delete/5
        [HttpPost]
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        public JsonResult DeleteTask(string task_ID)
        {
            bool status = false;
            bool bIscancelled = false;
            string Message = "";
            try
            {
                if (task_ID != null)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        var oTask = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == task_ID);
                        if (oTask != null)
                        {
                            oTask.isCancelled = true;
                            oTask.deletedUser_ID = sUser_ID;
                            oTask.dateDeleted = DateTime.Now;

                            db.SaveChanges();

                            bIscancelled = oTask.isCancelled;

                            Message = "Task Cancelled Succefully...!";
                            status = true;
                        }
                        else
                        {
                            Message = "Task Details are Empty...!";
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
                    Message = "Task ID Empty...!";
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }
            return new JsonResult { Data = new { status = status, isCancelled = bIscancelled, Message = Message } };
        }
        #endregion

        #region Files Handle
        [HttpPost]
        public JsonResult UploadFiles(string TxID)
        {
            string sMessage = "";
            bool status = false;
            try
            {
                if (Request.Files.Count > 0)
                {
                    string path1 = Server.MapPath("~/Images/");
                    if (!System.IO.Directory.Exists(path1))
                    {
                        status = false;
                        sMessage = "File Upload Folder Not Found";
                    }
                    else
                    {
                        HttpFileCollectionBase FileList = Request.Files;
                        for (int i = 0; i < FileList.Count; i++)
                        {
                            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                            string Filename = Path.GetFileName(Request.Files[i].FileName);

                            HttpPostedFileBase File = FileList[i];
                            string sDestinationPath = File.FileName;

                            // Checking for Internet Explorer  
                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = File.FileName.Split(new char[] { '\\' });
                                sDestinationPath = testfiles[testfiles.Length - 1];
                            }


                            // Get the complete folder path and store the file inside it.  
                            sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
                            File.SaveAs(sDestinationPath);

                            tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++i, (int)enumFormNames.Task, Filename, Filename);
                            db.tbl_sasAttachments.Add(oAttachment);
                        }

                        var Task = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == TxID);
                        if (Task != null)
                        {
                            Task.isAttachment = true;
                            db.SaveChanges();
                        }

                        db.SaveChanges();

                        status = true;
                        sMessage = "File Uploaded Successfully!";
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                sMessage = "Error occurred. Error details: " + ex.Message;
            }

            return new JsonResult { Data = new { status = status, Message = sMessage } };
        }

        [HttpPost]
        public JsonResult UpdateFiles(string TxID)
        {
            string sMessage = "";
            bool status = false;
            try
            {
                if (Request.Files.Count > 0)
                {
                    int MaxNumber = 0;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        string Filename = Path.GetFileName(Request.Files[i].FileName);

                        HttpPostedFileBase File = files[i];
                        string sDestinationPath = File.FileName;

                        // Checking for Internet Explorer
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = File.FileName.Split(new char[] { '\\' });
                            sDestinationPath = testfiles[testfiles.Length - 1];
                        }

                        var oldRecord = db.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID);
                        if (oldRecord != null)
                        {
                            MaxNumber = db.tbl_sasAttachments.Where(p => p.transaction_ID == TxID).Max(p => p.attachment_Index);
                            sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
                            File.SaveAs(sDestinationPath);

                            tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++MaxNumber, (int)enumFormNames.Task, Filename, Filename);
                            db.tbl_sasAttachments.Add(oAttachment);
                        }
                        else
                        {
                            sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
                            File.SaveAs(sDestinationPath);

                            tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++MaxNumber, (int)enumFormNames.Task, Filename, Filename);
                            db.tbl_sasAttachments.Add(oAttachment);

                        }
                    }

                    var Task = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == TxID);
                    if (Task != null)
                    {
                        Task.isAttachment = true;
                        db.SaveChanges();
                    }

                    db.SaveChanges();

                    status = true;
                    sMessage = "File Uploaded Successfully!";
                }
            }
            catch (Exception ex)
            {
                status = false;
                sMessage = "Error occurred. Error details: " + ex.Message;
            }

            return new JsonResult { Data = new { status = status, Message = sMessage } };
        }

        [HttpPost]
        public JsonResult DeleteFiles(string TxID, int AttachmentIndex)
        {
            string sMessage = "";
            bool status = false;
            try
            {
                if (TxID != null && AttachmentIndex > 0)
                {
                    var oTask = db.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID && p.attachment_Index == AttachmentIndex);
                    if (oTask != null)
                    {
                        string fullPath = Path.Combine(Server.MapPath("~/Images/"), oTask.attachment);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);

                            db.tbl_sasAttachments.Remove(oTask);
                            db.SaveChanges();

                            sMessage = "File Uploaded Successfully!";
                            status = true;
                        }
                        else
                        {
                            sMessage = "This file is not exists in the current folder";
                            status = false;
                        }
                    }
                    else
                    {
                        sMessage = "Record Not Found...!";
                        status = false;
                    }
                }
                else
                {
                    sMessage = "Files Not Found...!";
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
                sMessage = "Error occurred. Error details: " + ex.Message;
            }

            return new JsonResult { Data = new { status = status, Message = sMessage } };
        }

        public JsonResult ViewFile(string sPath)
        {
            string sMessage = "";
            bool status = true;
            try
            {
                string fullPath = Path.Combine(Server.MapPath("~/Images/"), sPath);

                if (FolderPermission(fullPath))
                {
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.Diagnostics.Process.Start(fullPath);
                        sMessage = "File Processing";
                    }
                    else
                    {
                        status = false;
                        sMessage = "File Not Found...";
                    }
                }
                else
                {
                    sMessage = "You don't have write permissions";
                }
            }
            catch (Exception ex)
            {
                status = false;
                sMessage = "Error occurred. Error details: " + ex.Message;
            }

            return new JsonResult { Data = new { status = status, Message = sMessage } };
        }

        public JsonResult ViewDestinationFile()
        {
            string sMessage = "";
            bool status = true;
            if (Request.Files.Count > 0)
            {
                HttpFileCollectionBase FileList = Request.Files;

                for (int i = 1; i < FileList.Count; i++)
                {
                    HttpPostedFileBase sFile = FileList[i];
                    FilePathResult sPath = File(FileList[i].FileName, FileList[i].ContentType);

                    string file = sPath.FileName;
                    string downloadname = sPath.FileDownloadName;

                    //if (System.IO.File.Exists(sFile.FileName))
                    //    System.Diagnostics.Process.Start(sFile.FileName);

                    // Get the complete folder path and store the file inside it.  
                    //sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
                    //File.SaveAs(sDestinationPath);
                }

                status = true;
                sMessage = "File Uploaded Successfully!";
            }

            return new JsonResult { Data = new { status = status, Message = sMessage } };
        }

        #region Check Folder Permission
        private bool FolderPermission(string path)
        {
            bool bPermission = false;

            PermissionSet permissionSet = new PermissionSet(PermissionState.None);
            FileIOPermission AllPermission = new FileIOPermission(FileIOPermissionAccess.AllAccess, path);

            permissionSet.AddPermission(AllPermission);
            if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
            {
                bPermission = true;
            }
            else
            {
                bPermission = false;
            }

            return bPermission;
        }
        #endregion
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


//[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
//public ActionResult Delete(string id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(id);
//    if (tbl_pmsTxTask == null)
//    {
//        return HttpNotFound();
//    }
//    return View(tbl_pmsTxTask);
//}

//[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
//public ActionResult CreateOld()
//{
//    ViewBag.module_ID = new SelectList(db.tbl_genMasModule, "module_ID", "moduleName");
//    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority, "priority_ID", "priority");
//    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct, "product_ID", "productName");
//    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status", db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new")));
//    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType, "taskType_ID", "taskType");

//    return View();
//}

//[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
//public ActionResult EditOld(string task_ID)
//{
//    if (task_ID == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(task_ID);
//    if (tbl_pmsTxTask == null)
//    {
//        return HttpNotFound();
//    }

//    ViewBag.task_ID = tbl_pmsTxTask.task_ID;

//    ViewBag.module_ID = new SelectList(db.tbl_genMasModule, "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
//    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority, "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
//    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct, "product_ID", "productName", tbl_pmsTxTask.product_ID);
//    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status", tbl_pmsTxTask.status_ID);
//    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType, "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);

//    return View();
//}

//[HttpPost]
//[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
//public ActionResult Create(tbl_pmsTxTask Task)
//{
//    if (ModelState.IsValid)
//    {
//        Task.task_ID = tbl_AutoCode.AutoCode((int)enumFormNames.Task);
//        if (Task.task_ID != null)
//        {
//            Task.createUser_ID = sUser_ID;
//            Task.modifiedUser_ID = sUser_ID;
//            Task.deletedUser_ID = sUser_ID;

//            Task.assignedUser_ID = "-1";

//            Task.dateCreated = DateTime.Now;
//            Task.dateModified = DateTime.Now;
//            Task.dateDeleted = DateTime.Now;
//            Task.DeadlineDate = DateTime.Now;

//            Task.company_ID = sCompany_ID;
//            Task.companyBranch_ID = sCompanyBranch_ID;

//            db.tbl_pmsTxTask.Add(Task);
//            db.SaveChanges();

//            Session["Message"] = "Successfully Saved Task";

//            return RedirectToAction("Index", "TaskBucket");
//        }
//    }

//    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction, "function_ID", "functionName", Task.function_ID);
//    ViewBag.module_ID = new SelectList(db.tbl_genMasModule, "module_ID", "moduleName", Task.module_ID);
//    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority, "priority_ID", "priority", Task.priority_ID);
//    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct, "product_ID", "productName", Task.product_ID);
//    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status", Task.status_ID);
//    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType, "taskType_ID", "taskType", Task.taskType_ID);
//    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster, "customer_ID", "customerName", Task.customer_ID);

//    return View(Task);
//}

//[HttpPost]
//[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
//public ActionResult Edit(tbl_pmsTxTask Task)
//{
//    if (ModelState.IsValid)
//    {
//        var value = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == Task.task_ID);
//        if (value != null)
//        {
//            value.modifiedUser_ID = sUser_ID;
//            value.dateModified = DateTime.Now;

//            value.function_ID = Task.function_ID;
//            value.module_ID = Task.module_ID;
//            value.priority_ID = Task.priority_ID;
//            value.product_ID = Task.product_ID;
//            value.status_ID = Task.status_ID;
//            value.taskType_ID = Task.taskType_ID;
//            value.customer_ID = Task.customer_ID;
//            value.taskReference = Task.taskReference;

//            value.reportedUser_ID = Task.reportedUser_ID;
//            value.reported_Date = Task.reported_Date;

//            value.remarks = Task.remarks;

//            //db.Entry(Task).State = EntityState.Modified;
//            db.SaveChanges();
//            Session["Message"] = "Successfully Updated Task";

//            return RedirectToAction("Index", "TaskBucket");
//        }
//    }

//    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction, "function_ID", "functionName", Task.function_ID);
//    ViewBag.module_ID = new SelectList(db.tbl_genMasModule, "module_ID", "moduleName", Task.module_ID);
//    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority, "priority_ID", "priority", Task.priority_ID);
//    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct, "product_ID", "productName", Task.product_ID);
//    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status", Task.status_ID);
//    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType, "taskType_ID", "taskType", Task.taskType_ID);
//    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster, "customer_ID", "customerName", Task.customer_ID);

//    return View(Task);
//}

//[HttpPost, ActionName("Delete")]
//[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
//public ActionResult DeleteConfirmed(string id)
//{
//    if (id != null)
//    {
//        tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(id);
//        tbl_pmsTxTask.modifiedUser_ID = sUser_ID;
//        tbl_pmsTxTask.dateModified = DateTime.Now;

//        db.Entry(tbl_pmsTxTask).State = EntityState.Modified;
//        db.SaveChanges();
//        ViewBag.TaskMessage = "Successfully Cancelled Task";
//        return RedirectToAction("Index", "TaskBucket");
//    }
//    return View("Index");
//}

#region Delete Old Attachment
//public ActionResult UploadFiles(int FormID, string TransactionID, List<HttpPostedFileBase> files)
//{
//    if (files.Count > 0)
//    {
//        try
//        {
//            //HttpFileCollectionBase files = Request.Files;
//            for (int i = 0; i < files.Count; i++)
//            {
//                //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
//                string filename = Path.GetFileName(Request.Files[i].FileName);

//                HttpPostedFileBase file = files[i];
//                string fname;

//                // Checking for Internet Explorer  
//                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
//                {
//                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
//                    fname = testfiles[testfiles.Length - 1];
//                }
//                else
//                {
//                    fname = file.FileName;
//                }

//                // Get the complete folder path and store the file inside it.  
//                fname = Path.Combine(Server.MapPath("~/App_Data/Images/"), fname);
//                file.SaveAs(fname);

//                tbl_sasAttachments oAttachment = new tbl_sasAttachments(TransactionID, i, FormID, fname, fname);
//                db.tbl_sasAttachments.Add(oAttachment);
//            }
//            db.SaveChanges();

//            // Returns message that successfully uploaded  
//            return Json("File Uploaded Successfully!");
//        }
//        catch (Exception ex)
//        {
//            return Json("Error occurred. Error details: " + ex.Message);
//        }
//    }
//    else
//    {
//        return Json("No files selected.");
//    }
//}


//public void DropdownsList()
//{
//    string sStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new")).status_ID;
//    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
//    ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
//    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
//    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
//    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", sStatus);
//    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
//    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
//}

// GET: Task/Create

//[HttpPost]
//public JsonResult UploadFiles(List<AttachmentVM> oFile)
//{

//    //string fileName = System.IO.Path.GetFileName(filePath);
//    //int sAttachment_ID = clsHelpMethods_Local.GetAttachmentID(sTransaction_ID_Rev);
//    //string newFilePath = sTransaction_ID_Rev + "-" + sAttachment_ID + System.IO.Path.GetExtension(filePath);
//    //string sDestPath = @"" + clsConfig.sAttachmentPath_Server + "\\" + newFilePath;

//    //bool bStatus = FolderPermission(sDestPath);
//    //if (bStatus)
//    //{
//    //    if (!System.IO.File.Exists(sDestPath))
//    //    {
//    //        System.IO.File.Copy(filePath, sDestPath);
//    //        tbl_sasAttachments oAttachments = new tbl_sasAttachments(Transaction_ID, sAttachment_ID, iFormID, newFilePath, fileName);
//    //        oAttachments.Insert();
//    //    }
//    //    else
//    //        MessageBox.Show("File already exists in the current folder", "Information", MessageBoxButtons.OK);
//    //}

//    try
//    {
//        //foreach (AttachmentVM file in oFile)
//        //{
//        //    FileStream FileStream = new FileStream(file.attachment, FileMode.OpenOrCreate);
//        //    var fileName = Path.GetFileName(file.attachment);
//        //    var fileExtension = Path.GetExtension(file.attachment);

//        //    var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
//        //    FileStream CopiedFileStream = new FileStream(path, FileMode.OpenOrCreate);

//        //    FileStream.CopyTo(CopiedFileStream);
//        //}

//        foreach (string file in Request.Files)
//        {
//            var fileContent = Request.Files[file];
//            if (fileContent != null && fileContent.ContentLength > 0)
//            {
//                // get a stream
//                var stream = fileContent.InputStream;
//                // and optionally write the file to disk
//                var fileName = Path.GetFileName(file);
//                var path = Path.Combine(Server.MapPath("~/App_Data/Images"), fileName);
//                //using (var fileStream = File.Create(path))
//                //{
//                //    stream.CopyTo(fileStream);
//                //}
//            }
//        }

//    }
//    catch (Exception)
//    {
//        Response.StatusCode = (int)HttpStatusCode.BadRequest;
//        return Json("Upload failed");
//    }

//    return Json("File uploaded successfully");
//}








// GET: tbl_pmsTxTask
//public ActionResult Index()
//{
//    var tbl_pmsTxTask = db.tbl_pmsTxTask.Include(t => t.tbl_genCompanyBranchMaster).Include(t => t.tbl_genCompanyInfo).Include(t => t.tbl_genMasFunction).Include(t => t.tbl_genMasModule).Include(t => t.tbl_genMasPriority).Include(t => t.tbl_genMasProduct).Include(t => t.tbl_genMasStatus).Include(t => t.tbl_genMasTaskType);
//    return View(tbl_pmsTxTask.ToList());
//}
//if (TxID != null && AttachmentIndex > 0)
//{
//    var oTask = db.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID && p.attachment_Index == AttachmentIndex);
//    if (oTask != null)
//    {
//        string fullPath = Request.MapPath("~/Images/" + oTask.attachment);
//        if (System.IO.File.Exists(fullPath))
//        {
//            System.IO.File.Delete(fullPath);
//            sMessage = "File Uploaded Successfully!";
//        }
//        else
//            sMessage = "This file is not exists in the current folder";
//    }
//}
#endregion