namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create171 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_securityUserMaster", "userLoged_ID", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_securityUserMaster", "userLoged_ID");
        }
    }
}
