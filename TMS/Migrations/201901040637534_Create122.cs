namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create122 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_pmsTxTask", "isCancelled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_pmsTxTask", "taskReference", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_pmsTxTask", "remarks", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_pmsTxTask", "remarks", c => c.String(maxLength: 200));
            AlterColumn("dbo.tbl_pmsTxTask", "taskReference", c => c.String(maxLength: 200));
            DropColumn("dbo.tbl_pmsTxTask", "isCancelled");
        }
    }
}
