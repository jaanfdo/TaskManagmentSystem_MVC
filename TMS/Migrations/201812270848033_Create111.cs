namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_sasAttachments", "attachment", c => c.String(maxLength: 500));
            AlterColumn("dbo.tbl_sasAttachments", "dipsplayName", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_sasAttachments", "dipsplayName", c => c.String(maxLength: 100));
            AlterColumn("dbo.tbl_sasAttachments", "attachment", c => c.String(maxLength: 50));
        }
    }
}
