namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create141 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_pmsTxTask", "taskReference", c => c.String(maxLength: 1000));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "remarks", c => c.String(maxLength: 1000));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "remarks", c => c.String(maxLength: 1000));
            AlterColumn("dbo.tbl_pmsTxTimeSheet_Detail", "remarks", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_pmsTxTimeSheet_Detail", "remarks", c => c.String(maxLength: 200));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "remarks", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_pmsTxTaskEstimation", "remarks", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_pmsTxTask", "taskReference", c => c.String(maxLength: 500));
        }
    }
}
