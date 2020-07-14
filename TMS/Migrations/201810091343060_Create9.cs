namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create9 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tbl_securityFunctionMaster");
            AlterColumn("dbo.tbl_securityFunctionMaster", "function_ID", c => c.Int(nullable: false, identity: false));
            AddPrimaryKey("dbo.tbl_securityFunctionMaster", "function_ID");
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.tbl_securityFunctionMaster");
            AlterColumn("dbo.tbl_securityFunctionMaster", "function_ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tbl_securityFunctionMaster", "function_ID");
        }
    }
}
