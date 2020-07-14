namespace TMS.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TMS.Models.ApplicationDbContext context)
        {
            //add default record for relavant table
            var company = new List<tbl_genCompanyInfo>{

                new tbl_genCompanyInfo {
                    company_ID = "company1",
                    companyName = "Digiteq Solution Pvt Ltd",
                    address = ""
                }
            };
            company.ForEach(s => context.tbl_genCompanyInfo.AddOrUpdate(p => p.company_ID, s));
            context.SaveChanges();

            var companyBranch = new List<tbl_genCompanyBranchMaster>{
                new tbl_genCompanyBranchMaster {
                    company_ID = "company1",
                    companyBranch_ID = "1",
                    branchName = "Head Office",
                    address = ""
                }
            };
            companyBranch.ForEach(s => context.tbl_genCompanyBranchMaster.AddOrUpdate(p => p.companyBranch_ID, s));
            context.SaveChanges();

            var customerMaster = new List<tbl_genCustomerMaster>{
                new tbl_genCustomerMaster {
                    company_ID = "company1",
                    companyBranch_ID = "1",
                    customer_ID = "-1",
                    customerCode = "-1",
                    customerName = "-",

                }
            };
            customerMaster.ForEach(s => context.tbl_genCustomerMaster.AddOrUpdate(p => p.customer_ID, s));
            context.SaveChanges();

            var productMaster = new List<tbl_genMasProduct>{
                new tbl_genMasProduct {
                    product_ID = "-1",
                    productName = "-1",
                    isActive = false
                }
            };
            productMaster.ForEach(s => context.tbl_genMasProduct.AddOrUpdate(p => p.product_ID, s));
            context.SaveChanges();

            var moduleMaster = new List<tbl_genMasModule>{
                new tbl_genMasModule {
                    module_ID = "-1",
                    moduleName = "-",
                    product_ID = "-1",
                    isActive = false
                }
            };
            moduleMaster.ForEach(s => context.tbl_genMasModule.AddOrUpdate(p => p.module_ID, s));
            context.SaveChanges();

            var functionMaster = new List<tbl_genMasFunction>{
                new tbl_genMasFunction {
                    function_ID = "-1",
                    functionName = "-",
                    module_ID = "-1",
                    isActive = false
                }
            };
            functionMaster.ForEach(s => context.tbl_genMasFunction.AddOrUpdate(p => p.function_ID, s));
            context.SaveChanges();

            var priorityMaster = new List<tbl_genMasPriority>{
                new tbl_genMasPriority {
                    priority_ID = "-1",
                    priority = "-",
                    isActive = false
                }
            };
            priorityMaster.ForEach(s => context.tbl_genMasPriority.AddOrUpdate(p => p.priority_ID, s));
            context.SaveChanges();

            var taskTypeMaster = new List<tbl_genMasTaskType>{
                new tbl_genMasTaskType {
                    taskType_ID = "-1",
                    taskType = "-",
                    priority_ID = "-1",
                    isActive = false,
                }
            };
            taskTypeMaster.ForEach(s => context.tbl_genMasTaskType.AddOrUpdate(p => p.taskType_ID, s));
            context.SaveChanges();

            var statusMaster = new List<tbl_genMasStatus>{
                new tbl_genMasStatus {
                    status_ID = "-1",
                    status = "-",
                    isActive = false
                }
            };
            statusMaster.ForEach(s => context.tbl_genMasStatus.AddOrUpdate(p => p.status_ID, s));
            context.SaveChanges();


            var subTaskMaster = new List<tbl_genMasSubTask>{
                new tbl_genMasSubTask {
                    subTask_ID= "-1",
                    subTaskName = "-",
                    isMandatoryRemarks = false,
                    isActive = false
                }
            };
            subTaskMaster.ForEach(s => context.tbl_genMasSubTask.AddOrUpdate(p => p.subTask_ID, s));
            context.SaveChanges();

            var userMaster = new List<tbl_securityUserMaster>{
                new tbl_securityUserMaster {
                    user_ID= "-1",
                    userName = "-",
                    isLocked = false,
                    isLoged = false,
                    isBlocked = false
                }
            };
            userMaster.ForEach(s => context.tbl_securityUserMaster.AddOrUpdate(p => p.user_ID, s));
            context.SaveChanges();

        }
    }
}
