namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_pmsTxTimeSheet_Detail", "status_ID", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_pmsTxTimeSheet_Detail", "status_ID");
        }
    }
}
