namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_pmsTxTask", "taskDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "reported_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "isAttachment", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "dateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "dateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "dateDeleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "estimationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "totalEstimatedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "isApproved", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "isCancelled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateDeleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateApproved", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation_Detail", "estimatedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "timeSheetDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "totalUtilizedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "isCancelled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "dateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "dateModified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "dateDeleted", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTimeSheet_Detail", "utilizedHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_pmsTxTimeSheet_Detail", "utilizedHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "dateDeleted", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "dateModified", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "dateCreated", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "isCancelled", c => c.Boolean());
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "totalUtilizedHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "timeSheetDate", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation_Detail", "estimatedHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateApproved", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateDeleted", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateModified", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "dateCreated", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "isCancelled", c => c.Boolean());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "isApproved", c => c.Boolean());
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "totalEstimatedHours", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "estimationDate", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTask", "dateDeleted", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTask", "dateModified", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTask", "dateCreated", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTask", "isAttachment", c => c.Boolean());
            AlterColumn("dbo.tbl_pmsTxTask", "reported_Date", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTask", "taskDate", c => c.DateTime());
        }
    }
}
