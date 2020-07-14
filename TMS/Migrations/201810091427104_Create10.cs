namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_genCustomerMaster", "companyBranch_ID", "dbo.tbl_genCompanyBranchMaster");
            DropForeignKey("dbo.tbl_pmsTxTask", "companyBranch_ID", "dbo.tbl_genCompanyBranchMaster");
            DropForeignKey("dbo.tbl_genCustomerMaster", "companyID", "dbo.tbl_genCompanyInfo");
            DropForeignKey("dbo.tbl_pmsTxTask", "companyID", "dbo.tbl_genCompanyInfo");
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "companyID" });
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "companyBranch_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "companyID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "companyBranch_ID" });
            DropPrimaryKey("dbo.tbl_genCompanyBranchMaster");
            DropPrimaryKey("dbo.tbl_genCompanyInfo");
            AddColumn("dbo.tbl_genCompanyBranchMaster", "company_ID", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.tbl_genCompanyBranchMaster", "address", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_genCustomerMaster", "tbl_genCompanyBranchMaster_company_ID", c => c.String(maxLength: 10));
            AddColumn("dbo.tbl_genCustomerMaster", "tbl_genCompanyBranchMaster_companyBranch_ID", c => c.String(maxLength: 20));
            AddColumn("dbo.tbl_genCustomerMaster", "tbl_genCompanyInfo_company_ID", c => c.String(maxLength: 10));
            AddColumn("dbo.tbl_genCompanyInfo", "company_ID", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.tbl_pmsTxTask", "tbl_genCompanyBranchMaster_company_ID", c => c.String(maxLength: 10));
            AddColumn("dbo.tbl_pmsTxTask", "tbl_genCompanyBranchMaster_companyBranch_ID", c => c.String(maxLength: 20));
            AddColumn("dbo.tbl_pmsTxTask", "tbl_genCompanyInfo_company_ID", c => c.String(maxLength: 10));
            AddPrimaryKey("dbo.tbl_genCompanyBranchMaster", new[] { "company_ID", "companyBranch_ID" });
            AddPrimaryKey("dbo.tbl_genCompanyInfo", "company_ID");
            CreateIndex("dbo.tbl_genCompanyBranchMaster", "company_ID");
            CreateIndex("dbo.tbl_genCustomerMaster", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" });
            CreateIndex("dbo.tbl_genCustomerMaster", "tbl_genCompanyInfo_company_ID");
            CreateIndex("dbo.tbl_pmsTxTask", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" });
            CreateIndex("dbo.tbl_pmsTxTask", "tbl_genCompanyInfo_company_ID");
            AddForeignKey("dbo.tbl_genCompanyBranchMaster", "company_ID", "dbo.tbl_genCompanyInfo", "company_ID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_genCustomerMaster", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" }, "dbo.tbl_genCompanyBranchMaster", new[] { "company_ID", "companyBranch_ID" });
            AddForeignKey("dbo.tbl_pmsTxTask", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" }, "dbo.tbl_genCompanyBranchMaster", new[] { "company_ID", "companyBranch_ID" });
            AddForeignKey("dbo.tbl_genCustomerMaster", "tbl_genCompanyInfo_company_ID", "dbo.tbl_genCompanyInfo", "company_ID");
            AddForeignKey("dbo.tbl_pmsTxTask", "tbl_genCompanyInfo_company_ID", "dbo.tbl_genCompanyInfo", "company_ID");
            DropColumn("dbo.tbl_genCompanyBranchMaster", "companyCountry_ID");
            DropColumn("dbo.tbl_genCompanyBranchMaster", "adress");
            DropColumn("dbo.tbl_genCompanyInfo", "companyID");
            DropColumn("dbo.tbl_genCompanyInfo", "companyMDName");
            DropColumn("dbo.tbl_genCompanyInfo", "mdTelephone");
            DropColumn("dbo.tbl_genCompanyInfo", "databaseName");
            DropColumn("dbo.tbl_genCompanyInfo", "edition");
            DropColumn("dbo.tbl_genCompanyInfo", "serialNo1");
            DropColumn("dbo.tbl_genCompanyInfo", "serialNo2");
            DropColumn("dbo.tbl_genCompanyInfo", "serialNo3");
            DropColumn("dbo.tbl_genCompanyInfo", "serialNo4");
            DropColumn("dbo.tbl_genCompanyInfo", "month_ID");
            DropColumn("dbo.tbl_genCompanyInfo", "startDate");
            DropColumn("dbo.tbl_genCompanyInfo", "theme_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_genCompanyInfo", "theme_ID", c => c.Int());
            AddColumn("dbo.tbl_genCompanyInfo", "startDate", c => c.DateTime());
            AddColumn("dbo.tbl_genCompanyInfo", "month_ID", c => c.String(maxLength: 10));
            AddColumn("dbo.tbl_genCompanyInfo", "serialNo4", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_genCompanyInfo", "serialNo3", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_genCompanyInfo", "serialNo2", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_genCompanyInfo", "serialNo1", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_genCompanyInfo", "edition", c => c.Int());
            AddColumn("dbo.tbl_genCompanyInfo", "databaseName", c => c.String(maxLength: 100));
            AddColumn("dbo.tbl_genCompanyInfo", "mdTelephone", c => c.String(maxLength: 25));
            AddColumn("dbo.tbl_genCompanyInfo", "companyMDName", c => c.String(maxLength: 100));
            AddColumn("dbo.tbl_genCompanyInfo", "companyID", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.tbl_genCompanyBranchMaster", "adress", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_genCompanyBranchMaster", "companyCountry_ID", c => c.String(maxLength: 20));
            DropForeignKey("dbo.tbl_pmsTxTask", "tbl_genCompanyInfo_company_ID", "dbo.tbl_genCompanyInfo");
            DropForeignKey("dbo.tbl_genCustomerMaster", "tbl_genCompanyInfo_company_ID", "dbo.tbl_genCompanyInfo");
            DropForeignKey("dbo.tbl_pmsTxTask", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" }, "dbo.tbl_genCompanyBranchMaster");
            DropForeignKey("dbo.tbl_genCustomerMaster", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" }, "dbo.tbl_genCompanyBranchMaster");
            DropForeignKey("dbo.tbl_genCompanyBranchMaster", "company_ID", "dbo.tbl_genCompanyInfo");
            DropIndex("dbo.tbl_pmsTxTask", new[] { "tbl_genCompanyInfo_company_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" });
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "tbl_genCompanyInfo_company_ID" });
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "tbl_genCompanyBranchMaster_company_ID", "tbl_genCompanyBranchMaster_companyBranch_ID" });
            DropIndex("dbo.tbl_genCompanyBranchMaster", new[] { "company_ID" });
            DropPrimaryKey("dbo.tbl_genCompanyInfo");
            DropPrimaryKey("dbo.tbl_genCompanyBranchMaster");
            DropColumn("dbo.tbl_pmsTxTask", "tbl_genCompanyInfo_company_ID");
            DropColumn("dbo.tbl_pmsTxTask", "tbl_genCompanyBranchMaster_companyBranch_ID");
            DropColumn("dbo.tbl_pmsTxTask", "tbl_genCompanyBranchMaster_company_ID");
            DropColumn("dbo.tbl_genCompanyInfo", "company_ID");
            DropColumn("dbo.tbl_genCustomerMaster", "tbl_genCompanyInfo_company_ID");
            DropColumn("dbo.tbl_genCustomerMaster", "tbl_genCompanyBranchMaster_companyBranch_ID");
            DropColumn("dbo.tbl_genCustomerMaster", "tbl_genCompanyBranchMaster_company_ID");
            DropColumn("dbo.tbl_genCompanyBranchMaster", "address");
            DropColumn("dbo.tbl_genCompanyBranchMaster", "company_ID");
            AddPrimaryKey("dbo.tbl_genCompanyInfo", "companyID");
            AddPrimaryKey("dbo.tbl_genCompanyBranchMaster", "companyBranch_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "companyBranch_ID");
            CreateIndex("dbo.tbl_pmsTxTask", "companyID");
            CreateIndex("dbo.tbl_genCustomerMaster", "companyBranch_ID");
            CreateIndex("dbo.tbl_genCustomerMaster", "companyID");
            AddForeignKey("dbo.tbl_pmsTxTask", "companyID", "dbo.tbl_genCompanyInfo", "companyID");
            AddForeignKey("dbo.tbl_genCustomerMaster", "companyID", "dbo.tbl_genCompanyInfo", "companyID");
            AddForeignKey("dbo.tbl_pmsTxTask", "companyBranch_ID", "dbo.tbl_genCompanyBranchMaster", "companyBranch_ID");
            AddForeignKey("dbo.tbl_genCustomerMaster", "companyBranch_ID", "dbo.tbl_genCompanyBranchMaster", "companyBranch_ID");
        }
    }
}
