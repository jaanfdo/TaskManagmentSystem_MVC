namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create16 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "tbl_genCompanyInfo_company_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "tbl_genCompanyInfo_company_ID" });
            DropColumn("dbo.tbl_genCustomerMaster", "companyBranch_ID");
            DropColumn("dbo.tbl_pmsTxTask", "companyBranch_ID");
            RenameColumn(table: "dbo.tbl_genCustomerMaster", name: "tbl_genCompanyBranchMaster_company_ID", newName: "company_ID");
            RenameColumn(table: "dbo.tbl_genCustomerMaster", name: "tbl_genCompanyBranchMaster_companyBranch_ID", newName: "companyBranch_ID");
            RenameColumn(table: "dbo.tbl_pmsTxTask", name: "tbl_genCompanyBranchMaster_company_ID", newName: "company_ID");
            RenameColumn(table: "dbo.tbl_pmsTxTask", name: "tbl_genCompanyBranchMaster_companyBranch_ID", newName: "companyBranch_ID");
            RenameIndex(table: "dbo.tbl_genCustomerMaster", name: "IX_tbl_genCompanyBranchMaster_company_ID_tbl_genCompanyBranchMaster_companyBranch_ID", newName: "IX_company_ID_companyBranch_ID");
            RenameIndex(table: "dbo.tbl_pmsTxTask", name: "IX_tbl_genCompanyBranchMaster_company_ID_tbl_genCompanyBranchMaster_companyBranch_ID", newName: "IX_company_ID_companyBranch_ID");
            DropColumn("dbo.tbl_genCustomerMaster", "companyID");
            DropColumn("dbo.tbl_pmsTxTask", "companyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_pmsTxTask", "companyID", c => c.String(maxLength: 10));
            AddColumn("dbo.tbl_genCustomerMaster", "companyID", c => c.String(maxLength: 10));
            RenameIndex(table: "dbo.tbl_pmsTxTask", name: "IX_company_ID_companyBranch_ID", newName: "IX_tbl_genCompanyBranchMaster_company_ID_tbl_genCompanyBranchMaster_companyBranch_ID");
            RenameIndex(table: "dbo.tbl_genCustomerMaster", name: "IX_company_ID_companyBranch_ID", newName: "IX_tbl_genCompanyBranchMaster_company_ID_tbl_genCompanyBranchMaster_companyBranch_ID");
            RenameColumn(table: "dbo.tbl_pmsTxTask", name: "companyBranch_ID", newName: "tbl_genCompanyBranchMaster_companyBranch_ID");
            RenameColumn(table: "dbo.tbl_pmsTxTask", name: "company_ID", newName: "tbl_genCompanyBranchMaster_company_ID");
            RenameColumn(table: "dbo.tbl_genCustomerMaster", name: "companyBranch_ID", newName: "tbl_genCompanyBranchMaster_companyBranch_ID");
            RenameColumn(table: "dbo.tbl_genCustomerMaster", name: "company_ID", newName: "tbl_genCompanyBranchMaster_company_ID");
            AddColumn("dbo.tbl_pmsTxTask", "companyBranch_ID", c => c.String(maxLength: 20));
            AddColumn("dbo.tbl_genCustomerMaster", "companyBranch_ID", c => c.String(maxLength: 20));
            CreateIndex("dbo.tbl_pmsTxTask", "tbl_genCompanyInfo_company_ID");
            CreateIndex("dbo.tbl_genCustomerMaster", "tbl_genCompanyInfo_company_ID");
        }
    }
}
