namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_pmsTxTaskEstimation", "remarks", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "remarks", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_pmsTxTimeSheet", "remarks", c => c.String(maxLength: 200));
            DropColumn("dbo.tbl_pmsTxTaskEstimation", "remarks");
        }
    }
}
