namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create121 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_genMasTaskType", "isMandatoryEstimation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.tbl_genMasTaskType", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_genMasTaskType", "isActive", c => c.Boolean());
            AlterColumn("dbo.tbl_genMasTaskType", "isMandatoryEstimation", c => c.Boolean());
        }
    }
}
