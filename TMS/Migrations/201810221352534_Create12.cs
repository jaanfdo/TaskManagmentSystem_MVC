namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_pmsTxTaskEstimation", "approvedUser_ID", c => c.String(maxLength: 20));
            DropColumn("dbo.tbl_pmsTxTaskEstimation", "approvedYser_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_pmsTxTaskEstimation", "approvedYser_ID", c => c.String(maxLength: 20));
            DropColumn("dbo.tbl_pmsTxTaskEstimation", "approvedUser_ID");
        }
    }
}
