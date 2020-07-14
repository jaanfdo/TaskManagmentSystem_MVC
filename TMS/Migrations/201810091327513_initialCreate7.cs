namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_securityFunctionMaster",
                c => new
                    {
                        function_ID = c.Int(nullable: false, identity: true),
                        displayName = c.String(maxLength: 100),
                        counter = c.Int(nullable: false),
                        length = c.Int(nullable: false),
                        prefix1 = c.String(maxLength: 20),
                        isAutoGenerate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.function_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_securityFunctionMaster");
        }
    }
}
