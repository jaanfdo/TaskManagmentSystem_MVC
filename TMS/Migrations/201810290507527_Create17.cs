namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_pmsTxTask", "DeadlineDate", c => c.DateTime());
            AddColumn("dbo.tbl_pmsTxTask", "assignedUser_ID", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_pmsTxTask", "assignedUser_ID");
            DropColumn("dbo.tbl_pmsTxTask", "DeadlineDate");
        }
    }
}
