namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_pmsTxTask", "taskDate", c => c.DateTime());
            AlterColumn("dbo.tbl_pmsTxTask", "reported_Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_pmsTxTask", "reported_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "taskDate", c => c.DateTime(nullable: false));
        }
    }
}
