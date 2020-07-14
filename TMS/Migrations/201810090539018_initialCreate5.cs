namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_pmsTxTask", "module_ID", "dbo.tbl_genMasModule");
            DropForeignKey("dbo.tbl_pmsTxTask", "product_ID", "dbo.tbl_genMasProduct");
            DropForeignKey("dbo.tbl_pmsTxTask", "status_ID", "dbo.tbl_genMasStatus");
            DropForeignKey("dbo.tbl_pmsTxTask", "taskType_ID", "dbo.tbl_genMasTaskType");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "product_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "module_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "taskType_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "status_ID" });
            AlterColumn("dbo.tbl_pmsTxTask", "reportedUser_ID", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "client_ID", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "product_ID", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "module_ID", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "taskType_ID", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "status_ID", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.tbl_pmsTxTask", "product_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "module_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "taskType_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "status_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "module_ID", "dbo.tbl_genMasModule", "module_ID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_pmsTxTask", "product_ID", "dbo.tbl_genMasProduct", "product_ID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_pmsTxTask", "status_ID", "dbo.tbl_genMasStatus", "status_ID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_pmsTxTask", "taskType_ID", "dbo.tbl_genMasTaskType", "taskType_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_pmsTxTask", "taskType_ID", "dbo.tbl_genMasTaskType");
            DropForeignKey("dbo.tbl_pmsTxTask", "status_ID", "dbo.tbl_genMasStatus");
            DropForeignKey("dbo.tbl_pmsTxTask", "product_ID", "dbo.tbl_genMasProduct");
            DropForeignKey("dbo.tbl_pmsTxTask", "module_ID", "dbo.tbl_genMasModule");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "status_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "taskType_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "module_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "product_ID" });
            AlterColumn("dbo.tbl_pmsTxTask", "status_ID", c => c.String(maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "taskType_ID", c => c.String(maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "module_ID", c => c.String(maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "product_ID", c => c.String(maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "client_ID", c => c.String(maxLength: 20));
            AlterColumn("dbo.tbl_pmsTxTask", "reportedUser_ID", c => c.String(maxLength: 20));
            CreateIndex("dbo.tbl_pmsTxTask", "status_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "taskType_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "module_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "product_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "taskType_ID", "dbo.tbl_genMasTaskType", "taskType_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "status_ID", "dbo.tbl_genMasStatus", "status_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "product_ID", "dbo.tbl_genMasProduct", "product_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "module_ID", "dbo.tbl_genMasModule", "module_ID");
        }
    }
}
