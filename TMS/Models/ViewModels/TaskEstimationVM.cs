namespace TMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TaskEstimation_VM
    {
        public string estimation_ID { get; set; }

        public DateTime? estimationDate { get; set; }

        public string task_ID { get; set; }

        public string task { get; set; }

        public decimal? totalEstimatedHours { get; set; }

        public string remarks { get; set; }

        public bool? isApproved { get; set; }

        public bool? isCancelled { get; set; }
    }
}
