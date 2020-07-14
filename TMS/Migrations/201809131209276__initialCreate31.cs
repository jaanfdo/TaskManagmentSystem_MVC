namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _initialCreate31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_securityGroupPermission", "tbl_securityGroup_group_ID", c => c.String(maxLength: 10));
            AddColumn("dbo.tbl_securityUserMaster", "mobible", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_securityUserPermission", "permissionName", c => c.String(maxLength: 200));
            CreateIndex("dbo.tbl_genMasFunction", "module_ID");
            CreateIndex("dbo.tbl_genMasModule", "product_ID");
            CreateIndex("dbo.tbl_securityGroupPermission", "permission_ID");
            CreateIndex("dbo.tbl_securityGroupPermission", "tbl_securityGroup_group_ID");
            CreateIndex("dbo.tbl_securityUserMaster", "group_ID");
            AddForeignKey("dbo.tbl_genMasFunction", "module_ID", "dbo.tbl_genMasModule", "module_ID");
            AddForeignKey("dbo.tbl_genMasModule", "product_ID", "dbo.tbl_genMasProduct", "product_ID");
            AddForeignKey("dbo.tbl_securityGroupPermission", "tbl_securityGroup_group_ID", "dbo.tbl_securityGroup", "group_ID");
            AddForeignKey("dbo.tbl_securityGroupPermission", "permission_ID", "dbo.tbl_securityUserPermission", "permission_ID");
            AddForeignKey("dbo.tbl_securityUserMaster", "group_ID", "dbo.tbl_securityGroup", "group_ID");
            DropColumn("dbo.tbl_securityUserMaster", "moible");
            DropColumn("dbo.tbl_securityUserPermission", "permission_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_securityUserPermission", "permission_Name", c => c.String(maxLength: 200));
            AddColumn("dbo.tbl_securityUserMaster", "moible", c => c.String(maxLength: 50));
            DropForeignKey("dbo.tbl_securityUserMaster", "group_ID", "dbo.tbl_securityGroup");
            DropForeignKey("dbo.tbl_securityGroupPermission", "permission_ID", "dbo.tbl_securityUserPermission");
            DropForeignKey("dbo.tbl_securityGroupPermission", "tbl_securityGroup_group_ID", "dbo.tbl_securityGroup");
            DropForeignKey("dbo.tbl_genMasModule", "product_ID", "dbo.tbl_genMasProduct");
            DropForeignKey("dbo.tbl_genMasFunction", "module_ID", "dbo.tbl_genMasModule");
            DropIndex("dbo.tbl_securityUserMaster", new[] { "group_ID" });
            DropIndex("dbo.tbl_securityGroupPermission", new[] { "tbl_securityGroup_group_ID" });
            DropIndex("dbo.tbl_securityGroupPermission", new[] { "permission_ID" });
            DropIndex("dbo.tbl_genMasModule", new[] { "product_ID" });
            DropIndex("dbo.tbl_genMasFunction", new[] { "module_ID" });
            DropColumn("dbo.tbl_securityUserPermission", "permissionName");
            DropColumn("dbo.tbl_securityUserMaster", "mobible");
            DropColumn("dbo.tbl_securityGroupPermission", "tbl_securityGroup_group_ID");
        }
    }
}
