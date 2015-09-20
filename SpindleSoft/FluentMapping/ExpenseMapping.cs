using FluentNHibernate.Mapping;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.FluentMapping
{
    class ExpenseMapping : ClassMap<Expense>
    {
        public ExpenseMapping()
        {
            Id(x => x.ID);
            Map(x => x.DateOfExpense);
            HasMany(x => x.ExpenseItems).KeyColumn("ExpenseID")
                                         .Inverse()
                                         .Cascade.All();
            Map(x => x.TotalAmount);
        }
    }

    class ExpenseItemMapping : ClassMap<ExpenseItem>
    {
        public ExpenseItemMapping()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            References(x => x.Expense).Class<Expense>()
                                    .Columns("ExpenseID")
                                    .Cascade.None();
            Map(x => x.Type);
            Map(x => x.Amount);
            Map(x => x.Comment);
        }
    }
}
