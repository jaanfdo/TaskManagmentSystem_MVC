namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _initialCreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_genCompanyBranchMaster",
                c => new
                    {
                        companyBranch_ID = c.String(nullable: false, maxLength: 20),
                        branchName = c.String(maxLength: 50),
                        companyCountry_ID = c.String(maxLength: 20),
                        adress = c.String(maxLength: 50),
                        telephone = c.String(maxLength: 50),
                        fax = c.String(maxLength: 50),
                        hotline = c.String(maxLength: 100),
                        email = c.String(maxLength: 50),
                        website = c.String(maxLength: 50),
                        contactPerson = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.companyBranch_ID);
            
            CreateTable(
                "dbo.tbl_genCustomerMaster",
                c => new
                    {
                        customer_ID = c.String(nullable: false, maxLength: 20),
                        customerCode = c.String(maxLength: 50),
                        customerName = c.String(maxLength: 250),
                        addressRegister = c.String(maxLength: 500),
                        addressDelivery = c.String(maxLength: 500),
                        telephone = c.String(maxLength: 50),
                        mobile = c.String(maxLength: 50),
                        fax = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        url = c.String(maxLength: 50),
                        businessRegistraionNo = c.String(maxLength: 50),
                        vatRegistrationNo = c.String(maxLength: 50),
                        nbtRegistrationNo = c.String(maxLength: 50),
                        svatRegistrationNo = c.String(maxLength: 50),
                        remark = c.String(maxLength: 100),
                        isBlacklisted = c.Boolean(),
                        isLocked = c.Boolean(),
                        isDeleted = c.Boolean(),
                        country_ID = c.String(maxLength: 10),
                        province_ID = c.String(maxLength: 10),
                        district_ID = c.String(maxLength: 10),
                        city_ID = c.String(maxLength: 10),
                        town_ID = c.String(maxLength: 10),
                        area_ID = c.String(maxLength: 10),
                        route_ID = c.String(maxLength: 20),
                        customerType_ID = c.String(maxLength: 10),
                        customerCategory_ID = c.String(maxLength: 10),
                        customerClass_ID = c.String(maxLength: 10),
                        currency_ID = c.String(maxLength: 10),
                        salesManager_ID = c.String(maxLength: 20),
                        areaManager_ID = c.String(maxLength: 20),
                        salesRep_ID = c.String(maxLength: 20),
                        salesExecutive_ID = c.String(maxLength: 20),
                        gl_ID = c.String(maxLength: 20),
                        isVATenable = c.Boolean(),
                        isSVATenable = c.Boolean(),
                        isNBTenable = c.Boolean(),
                        isCustomerPricingEnable = c.Boolean(),
                        isCustomerWiseItemCode = c.Boolean(),
                        title = c.String(maxLength: 20),
                        nicNo = c.String(maxLength: 20),
                        dateOfBirth = c.DateTime(),
                        customerAccountType_ID = c.String(maxLength: 20),
                        isPostingEnable_VAT = c.Boolean(),
                        isPostingEnable_NBT = c.Boolean(),
                        salesReturnedGL_ID = c.String(maxLength: 20),
                        isCashCustomer = c.Boolean(),
                        companyID = c.String(maxLength: 10),
                        companyBranch_ID = c.String(maxLength: 20),
                        itemPriceMode = c.Int(),
                        itemPriceCategory = c.String(maxLength: 20),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        createTerminal_ID = c.String(maxLength: 50),
                        modifiedTerminal_ID = c.String(maxLength: 50),
                        deletedTerminal_ID = c.String(maxLength: 50),
                        dateCreate = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                        sales_Gl_ID = c.String(maxLength: 20),
                        isPOSCustomer = c.Boolean(),
                    })
                .PrimaryKey(t => t.customer_ID)
                .ForeignKey("dbo.tbl_genCompanyBranchMaster", t => t.companyBranch_ID)
                .ForeignKey("dbo.tbl_genCompanyInfo", t => t.companyID)
                .Index(t => t.companyID)
                .Index(t => t.companyBranch_ID);
            
            CreateTable(
                "dbo.tbl_genCompanyInfo",
                c => new
                    {
                        companyID = c.String(nullable: false, maxLength: 10),
                        companyName = c.String(maxLength: 200),
                        address = c.String(maxLength: 1000),
                        telephone1 = c.String(maxLength: 25),
                        telephone2 = c.String(maxLength: 25),
                        telephone3 = c.String(maxLength: 25),
                        fax = c.String(maxLength: 25),
                        email = c.String(maxLength: 50),
                        url = c.String(maxLength: 50),
                        vatRegisterNo = c.String(maxLength: 20),
                        companyMDName = c.String(maxLength: 100),
                        mdTelephone = c.String(maxLength: 25),
                        databaseName = c.String(maxLength: 100),
                        businessRegisterNo = c.String(maxLength: 20),
                        edition = c.Int(),
                        serialNo1 = c.String(maxLength: 50),
                        serialNo2 = c.String(maxLength: 50),
                        serialNo3 = c.String(maxLength: 50),
                        serialNo4 = c.String(maxLength: 50),
                        financialYear_ID = c.String(maxLength: 20),
                        month_ID = c.String(maxLength: 10),
                        startDate = c.DateTime(),
                        theme_ID = c.Int(),
                        productKey = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.companyID);
            
            CreateTable(
                "dbo.tbl_pmsTxTask",
                c => new
                    {
                        task_ID = c.String(nullable: false, maxLength: 20),
                        taskDate = c.DateTime(),
                        taskReference = c.String(maxLength: 200),
                        remarks = c.String(maxLength: 200),
                        reported_Date = c.DateTime(),
                        reportedUser_ID = c.String(maxLength: 20),
                        client_ID = c.String(maxLength: 20),
                        product_ID = c.String(maxLength: 20),
                        module_ID = c.String(maxLength: 20),
                        function_ID = c.String(maxLength: 20),
                        taskType_ID = c.String(maxLength: 20),
                        priority_ID = c.String(maxLength: 20),
                        status_ID = c.String(maxLength: 20),
                        isAttachment = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                        companyID = c.String(maxLength: 10),
                        companyBranch_ID = c.String(maxLength: 20),
                        tbl_genCustomerMaster_customer_ID = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.task_ID)
                .ForeignKey("dbo.tbl_genCompanyBranchMaster", t => t.companyBranch_ID)
                .ForeignKey("dbo.tbl_genCompanyInfo", t => t.companyID)
                .ForeignKey("dbo.tbl_genCustomerMaster", t => t.tbl_genCustomerMaster_customer_ID)
                .ForeignKey("dbo.tbl_genMasFunction", t => t.function_ID)
                .ForeignKey("dbo.tbl_genMasModule", t => t.module_ID)
                .ForeignKey("dbo.tbl_genMasPriority", t => t.priority_ID)
                .ForeignKey("dbo.tbl_genMasProduct", t => t.product_ID)
                .ForeignKey("dbo.tbl_genMasStatus", t => t.status_ID)
                .ForeignKey("dbo.tbl_genMasTaskType", t => t.taskType_ID)
                .Index(t => t.product_ID)
                .Index(t => t.module_ID)
                .Index(t => t.function_ID)
                .Index(t => t.taskType_ID)
                .Index(t => t.priority_ID)
                .Index(t => t.status_ID)
                .Index(t => t.companyID)
                .Index(t => t.companyBranch_ID)
                .Index(t => t.tbl_genCustomerMaster_customer_ID);
            
            CreateTable(
                "dbo.tbl_genMasFunction",
                c => new
                    {
                        function_ID = c.String(nullable: false, maxLength: 20),
                        functionName = c.String(maxLength: 200),
                        module_ID = c.String(maxLength: 20),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.function_ID);
            
            CreateTable(
                "dbo.tbl_genMasModule",
                c => new
                    {
                        module_ID = c.String(nullable: false, maxLength: 20),
                        moduleName = c.String(maxLength: 200),
                        product_ID = c.String(maxLength: 20),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.module_ID);
            
            CreateTable(
                "dbo.tbl_genMasPriority",
                c => new
                    {
                        priority_ID = c.String(nullable: false, maxLength: 20),
                        priority = c.String(maxLength: 200),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.priority_ID);
            
            CreateTable(
                "dbo.tbl_genMasProduct",
                c => new
                    {
                        product_ID = c.String(nullable: false, maxLength: 20),
                        productName = c.String(maxLength: 200),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.product_ID);
            
            CreateTable(
                "dbo.tbl_genMasStatus",
                c => new
                    {
                        status_ID = c.String(nullable: false, maxLength: 20),
                        status = c.String(maxLength: 200),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.status_ID);
            
            CreateTable(
                "dbo.tbl_genMasTaskType",
                c => new
                    {
                        taskType_ID = c.String(nullable: false, maxLength: 20),
                        taskType = c.String(maxLength: 200),
                        isMandatoryEstimation = c.Boolean(),
                        priority_ID = c.String(maxLength: 20),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.taskType_ID);
            
            CreateTable(
                "dbo.tbl_pmsTxTaskEstimation",
                c => new
                    {
                        estimation_ID = c.String(nullable: false, maxLength: 20),
                        estimationDate = c.DateTime(),
                        task_ID = c.String(nullable: false, maxLength: 20),
                        totalEstimatedHours = c.Decimal(precision: 18, scale: 2),
                        isApproved = c.Boolean(),
                        isCancelled = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        approvedYser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                        dateApproved = c.DateTime(),
                        company_ID = c.String(maxLength: 10),
                        companyBranch_ID = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.estimation_ID)
                .ForeignKey("dbo.tbl_pmsTxTask", t => t.task_ID, cascadeDelete: true)
                .Index(t => t.task_ID);
            
            CreateTable(
                "dbo.tbl_pmsTxTaskEstimation_Detail",
                c => new
                    {
                        line_No = c.Int(nullable: false),
                        estimation_ID = c.String(nullable: false, maxLength: 20),
                        subTask_ID = c.String(nullable: false, maxLength: 20),
                        estimatedHours = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.line_No, t.estimation_ID, t.subTask_ID })
                .ForeignKey("dbo.tbl_genMasSubTask", t => t.subTask_ID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_pmsTxTaskEstimation", t => t.estimation_ID, cascadeDelete: true)
                .Index(t => t.estimation_ID)
                .Index(t => t.subTask_ID);
            
            CreateTable(
                "dbo.tbl_genMasSubTask",
                c => new
                    {
                        subTask_ID = c.String(nullable: false, maxLength: 20),
                        subTaskName = c.String(maxLength: 200),
                        isMandatoryRemarks = c.Boolean(),
                        isActive = c.Boolean(),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                    })
                .PrimaryKey(t => t.subTask_ID);
            
            CreateTable(
                "dbo.tbl_pmsTxTimeSheet",
                c => new
                    {
                        timeSheet_ID = c.String(nullable: false, maxLength: 20),
                        timeSheetDate = c.DateTime(),
                        subTask_ID = c.String(nullable: false, maxLength: 20),
                        remarks = c.String(maxLength: 200),
                        totalUtilizedHours = c.Decimal(precision: 18, scale: 2),
                        isCancelled = c.Boolean(),
                        user_ID = c.String(maxLength: 20),
                        createUser_ID = c.String(maxLength: 20),
                        modifiedUser_ID = c.String(maxLength: 20),
                        deletedUser_ID = c.String(maxLength: 20),
                        dateCreated = c.DateTime(),
                        dateModified = c.DateTime(),
                        dateDeleted = c.DateTime(),
                        company_ID = c.String(maxLength: 10),
                        companyBranch_ID = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.timeSheet_ID)
                .ForeignKey("dbo.tbl_genMasSubTask", t => t.subTask_ID, cascadeDelete: true)
                .Index(t => t.subTask_ID);
            
            CreateTable(
                "dbo.tbl_pmsTxTimeSheet_Detail",
                c => new
                    {
                        line_No = c.Int(nullable: false),
                        timeSheet_ID = c.String(nullable: false, maxLength: 20),
                        task_ID = c.String(nullable: false, maxLength: 20),
                        utilizedHours = c.Decimal(precision: 18, scale: 2),
                        remarks = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => new { t.line_No, t.timeSheet_ID, t.task_ID })
                .ForeignKey("dbo.tbl_pmsTxTask", t => t.task_ID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_pmsTxTimeSheet", t => t.timeSheet_ID, cascadeDelete: true)
                .Index(t => t.timeSheet_ID)
                .Index(t => t.task_ID);
            
            CreateTable(
                "dbo.tbl_sasAttachments",
                c => new
                    {
                        transaction_ID = c.String(nullable: false, maxLength: 20),
                        attachment_Index = c.Int(nullable: false),
                        form_ID = c.Int(),
                        attachment = c.String(maxLength: 50),
                        dipsplayName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => new { t.transaction_ID, t.attachment_Index });
            
            CreateTable(
                "dbo.tbl_securityGroup",
                c => new
                    {
                        group_ID = c.String(nullable: false, maxLength: 10),
                        groupName = c.String(maxLength: 50),
                        is_Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.group_ID);
            
            CreateTable(
                "dbo.tbl_securityGroupPermission",
                c => new
                    {
                        group_ID = c.String(nullable: false, maxLength: 20),
                        permission_ID = c.String(maxLength: 20),
                        company_ID = c.String(maxLength: 20),
                        branch_ID = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.group_ID);
            
            CreateTable(
                "dbo.tbl_securityUserMaster",
                c => new
                    {
                        user_ID = c.String(nullable: false, maxLength: 20),
                        userName = c.String(maxLength: 50),
                        password = c.String(maxLength: 50),
                        password2 = c.String(maxLength: 50),
                        employeeID = c.String(maxLength: 10),
                        email = c.String(maxLength: 50),
                        moible = c.String(maxLength: 50),
                        computerName = c.String(maxLength: 50),
                        computerIP = c.String(maxLength: 50),
                        lastLogedDateTime = c.DateTime(),
                        isLoged = c.Boolean(),
                        isBlocked = c.Boolean(),
                        isLocked = c.Boolean(),
                        group_ID = c.String(maxLength: 10),
                        image = c.Binary(storeType: "image"),
                        lastPWChangedDateTime = c.DateTime(),
                        lastPWChangedUser_ID = c.String(maxLength: 20),
                        lastPWChangedTerminal_ID = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.user_ID);
            
            CreateTable(
                "dbo.tbl_securityUserPermission",
                c => new
                    {
                        permission_ID = c.String(nullable: false, maxLength: 20),
                        permission_Name = c.String(maxLength: 200),
                        isReport_Permission = c.Boolean(),
                    })
                .PrimaryKey(t => t.permission_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_pmsTxTaskEstimation_Detail", "estimation_ID", "dbo.tbl_pmsTxTaskEstimation");
            DropForeignKey("dbo.tbl_pmsTxTimeSheet_Detail", "timeSheet_ID", "dbo.tbl_pmsTxTimeSheet");
            DropForeignKey("dbo.tbl_pmsTxTimeSheet_Detail", "task_ID", "dbo.tbl_pmsTxTask");
            DropForeignKey("dbo.tbl_pmsTxTimeSheet", "subTask_ID", "dbo.tbl_genMasSubTask");
            DropForeignKey("dbo.tbl_pmsTxTaskEstimation_Detail", "subTask_ID", "dbo.tbl_genMasSubTask");
            DropForeignKey("dbo.tbl_pmsTxTaskEstimation", "task_ID", "dbo.tbl_pmsTxTask");
            DropForeignKey("dbo.tbl_pmsTxTask", "taskType_ID", "dbo.tbl_genMasTaskType");
            DropForeignKey("dbo.tbl_pmsTxTask", "status_ID", "dbo.tbl_genMasStatus");
            DropForeignKey("dbo.tbl_pmsTxTask", "product_ID", "dbo.tbl_genMasProduct");
            DropForeignKey("dbo.tbl_pmsTxTask", "priority_ID", "dbo.tbl_genMasPriority");
            DropForeignKey("dbo.tbl_pmsTxTask", "module_ID", "dbo.tbl_genMasModule");
            DropForeignKey("dbo.tbl_pmsTxTask", "function_ID", "dbo.tbl_genMasFunction");
            DropForeignKey("dbo.tbl_pmsTxTask", "tbl_genCustomerMaster_customer_ID", "dbo.tbl_genCustomerMaster");
            DropForeignKey("dbo.tbl_pmsTxTask", "companyID", "dbo.tbl_genCompanyInfo");
            DropForeignKey("dbo.tbl_pmsTxTask", "companyBranch_ID", "dbo.tbl_genCompanyBranchMaster");
            DropForeignKey("dbo.tbl_genCustomerMaster", "companyID", "dbo.tbl_genCompanyInfo");
            DropForeignKey("dbo.tbl_genCustomerMaster", "companyBranch_ID", "dbo.tbl_genCompanyBranchMaster");
            DropIndex("dbo.tbl_pmsTxTimeSheet_Detail", new[] { "task_ID" });
            DropIndex("dbo.tbl_pmsTxTimeSheet_Detail", new[] { "timeSheet_ID" });
            DropIndex("dbo.tbl_pmsTxTimeSheet", new[] { "subTask_ID" });
            DropIndex("dbo.tbl_pmsTxTaskEstimation_Detail", new[] { "subTask_ID" });
            DropIndex("dbo.tbl_pmsTxTaskEstimation_Detail", new[] { "estimation_ID" });
            DropIndex("dbo.tbl_pmsTxTaskEstimation", new[] { "task_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "tbl_genCustomerMaster_customer_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "companyBranch_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "companyID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "status_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "priority_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "taskType_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "function_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "module_ID" });
            DropIndex("dbo.tbl_pmsTxTask", new[] { "product_ID" });
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "companyBranch_ID" });
            DropIndex("dbo.tbl_genCustomerMaster", new[] { "companyID" });
            DropTable("dbo.tbl_securityUserPermission");
            DropTable("dbo.tbl_securityUserMaster");
            DropTable("dbo.tbl_securityGroupPermission");
            DropTable("dbo.tbl_securityGroup");
            DropTable("dbo.tbl_sasAttachments");
            DropTable("dbo.tbl_pmsTxTimeSheet_Detail");
            DropTable("dbo.tbl_pmsTxTimeSheet");
            DropTable("dbo.tbl_genMasSubTask");
            DropTable("dbo.tbl_pmsTxTaskEstimation_Detail");
            DropTable("dbo.tbl_pmsTxTaskEstimation");
            DropTable("dbo.tbl_genMasTaskType");
            DropTable("dbo.tbl_genMasStatus");
            DropTable("dbo.tbl_genMasProduct");
            DropTable("dbo.tbl_genMasPriority");
            DropTable("dbo.tbl_genMasModule");
            DropTable("dbo.tbl_genMasFunction");
            DropTable("dbo.tbl_pmsTxTask");
            DropTable("dbo.tbl_genCompanyInfo");
            DropTable("dbo.tbl_genCustomerMaster");
            DropTable("dbo.tbl_genCompanyBranchMaster");
        }
    }
}
