namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create101 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_pmsTxTask", "priority_ID", "dbo.tbl_genMasPriority");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "priority_ID" });
            AlterColumn("dbo.tbl_pmsTxTask", "priority_ID", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.tbl_pmsTxTask", "priority_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "priority_ID", "dbo.tbl_genMasPriority", "priority_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_pmsTxTask", "priority_ID", "dbo.tbl_genMasPriority");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "priority_ID" });
            AlterColumn("dbo.tbl_pmsTxTask", "priority_ID", c => c.String(maxLength: 20));
            CreateIndex("dbo.tbl_pmsTxTask", "priority_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "priority_ID", "dbo.tbl_genMasPriority", "priority_ID");
        }
    }
}
