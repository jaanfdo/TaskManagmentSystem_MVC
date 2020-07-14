namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create18 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.tbl_securityFunctionMaster");
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_securityFunctionMaster");
        }
    }
}
