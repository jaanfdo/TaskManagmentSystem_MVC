using TMS.Common;
using TMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Controllers
{
    [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;

        //string[] Roles = {  "Administrators", "Managers", "Employees" };
        [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Managers) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        public ActionResult Index()
        {
            cls_HelpMethods.UserDetail();
            cls_HelpMethods.CompanyDetail();

            TotalTask_Status();

            return View();
        }

        private void TotalTask_Status()
        {
            ViewBag.Users = db.tbl_securityUserMaster.Count(p => p.employeeID != "-1");

            if (sUser_ID != "")
            {
                decimal dCount = db.tbl_pmsTxTask.Where(p => p.status_ID == "1" && p.assignedUser_ID == sUser_ID).Count();
                ViewBag.NewStatus_Count = dCount;

                DateTime dtNow = DateTime.Now.Date;
                decimal dDeadlineCount = db.tbl_pmsTxTask.Where(p => p.DeadlineDate >= dtNow && p.DeadlineDate <= EntityFunctions.AddDays(dtNow, 7) && p.assignedUser_ID == sUser_ID).Count();
                ViewBag.Deadline_Count = dDeadlineCount;

                decimal dDueCount = db.tbl_pmsTxTask.Where(p => DateTime.Now > p.DeadlineDate && p.assignedUser_ID == sUser_ID).Count();
                ViewBag.Due_Count = dDueCount;
            }
        }
    }
}