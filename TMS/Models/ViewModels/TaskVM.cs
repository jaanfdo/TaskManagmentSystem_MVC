using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMS.Models.ViewModels
{
    public class TaskVM
    {
        public string task_ID { get; set; }
        
        public DateTime? taskDate { get; set; }
        
        public string taskReference { get; set; }
        
        public string remarks { get; set; }
        
        public DateTime? reported_Date { get; set; }
        
        public string reportedUser_ID { get; set; }
        
        public string customer { get; set; }
        
        public string product { get; set; }
        
        public string module { get; set; }
        
        public string function { get; set; }
        
        public string taskType { get; set; }

        public string priority { get; set; }
        
        public string status { get; set; }
        
        public DateTime? DeadlineDate { get; set; }
        
        public string assignedUser { get; set; }
        
        public bool isAttachment { get; set; }
    }
}