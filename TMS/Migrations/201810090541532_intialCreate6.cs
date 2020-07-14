namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialCreate6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_pmsTxTask", "tbl_genCustomerMaster_customer_ID", "dbo.tbl_genCustomerMaster");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "tbl_genCustomerMaster_customer_ID" });
            RenameColumn(table: "dbo.tbl_pmsTxTask", name: "tbl_genCustomerMaster_customer_ID", newName: "customer_ID");
            AlterColumn("dbo.tbl_pmsTxTask", "customer_ID", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.tbl_pmsTxTask", "customer_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "customer_ID", "dbo.tbl_genCustomerMaster", "customer_ID", cascadeDelete: true);
            DropColumn("dbo.tbl_pmsTxTask", "client_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_pmsTxTask", "client_ID", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.tbl_pmsTxTask", "customer_ID", "dbo.tbl_genCustomerMaster");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "customer_ID" });
            AlterColumn("dbo.tbl_pmsTxTask", "customer_ID", c => c.String(maxLength: 20));
            RenameColumn(table: "dbo.tbl_pmsTxTask", name: "customer_ID", newName: "tbl_genCustomerMaster_customer_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "tbl_genCustomerMaster_customer_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "tbl_genCustomerMaster_customer_ID", "dbo.tbl_genCustomerMaster", "customer_ID");
        }
    }
}
