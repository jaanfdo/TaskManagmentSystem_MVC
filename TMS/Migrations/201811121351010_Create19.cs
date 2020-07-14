namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create19 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_securityFunctionMaster",
                c => new
                {
                    function_ID = c.String(nullable: false, maxLength: 10),
                    displayName = c.String(maxLength: 100),
                    counter = c.Int(),
                    length = c.Int(),
                    prefix1 = c.String(maxLength: 20),
                    isAutoGenerate = c.Boolean(),
                    
                })
                .PrimaryKey(t => t.function_ID);
        }
        
        public override void Down()
        {
        }
    }
}
