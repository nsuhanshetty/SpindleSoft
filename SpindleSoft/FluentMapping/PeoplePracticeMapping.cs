using FluentNHibernate.Mapping;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.FluentMapping
{
    class PeoplePracticeMapping
    {

    }

    class CustomerMapping : ClassMap<Customer>
    {
        public CustomerMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Mobile_No);
            Map(x => x.Phone_No);
            Map(x => x.Address);
            Map(x => x.Email);
            Map(x => x.ReferralID);
        }
    }

    class StaffMapping : ClassMap<Staff>
    {
        public StaffMapping()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Mobile_No);
            Map(x => x.Phone_No);
            Map(x => x.Address);
            Map(x => x.Designation);
            Map(x => x.Type);
            Map(x => x.PayCycle);
            Map(x => x.BankUserName);
            Map(x => x.AccNo);
            Map(x => x.IfscCode);
            HasMany(x => x.SecurityDocuments).KeyColumn("StaffID")
                                                        .Inverse()
                                                        .Cascade.All();
            References(x => x.Bank).Class<Bank>()
                                  .Columns("BankID")
                                  .Cascade.None();
        }
    }

    class VendorMapping : ClassMap<Vendor>
    {
        public VendorMapping()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            Map(x => x.MobileNo);
            Map(x => x.Address);
            Map(x => x.BankUserName);
            Map(x => x.AccNo);
            Map(x => x.OfferingType);
            Map(x => x.IsProduct);
            Map(x => x.IFSCCode);
            References(x => x.Bank).Class<Bank>()
                                   .Columns("BankID")
                                   .Cascade.None();
        }
    }

    class BankMapping : ClassMap<Bank>
    {
        public BankMapping()
        {
            Id(x => x.ID);
            Map(x => x.Name);
        }
    }

    class SalaryMapping : ClassMap<Salary>
    {
        public SalaryMapping()
        {
            Id(x => x.ID);
            Map(x => x.DateOfSalary);
            Map(x => x.TotalSalaryAmount);
            HasMany(x => x.SalaryItemList).KeyColumn("SalaryID")
                                          .Inverse()
                                          .Cascade.All();
            References(x => x.Expense).Class<Expense>()
                                      .Columns("ExpenseID")
                                      .Cascade.None();
        }
    }

    class SalaryItemMapping : ClassMap<SalaryItem>
    {
        public SalaryItemMapping()
        {
            Id(x => x.ID);
            Map(x => x.Amount);
            References(x => x.Staff).Class<Staff>()
                                   .Columns("StaffID")
                                   .Cascade.None();
            References(x => x.Salary).Class<Salary>()
                                   .Columns("SalaryID")
                                   .Cascade.None();
        }
    }
}
