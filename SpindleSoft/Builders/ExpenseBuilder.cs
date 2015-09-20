using log4net;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace SpindleSoft.Builders
{
    class ExpenseBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(AlterationBuilder));

        public static List<String> GetExpenseNames(bool IsFixed,string expenseName="")
        {
            var namesList = new List<String>();
            using (var session = NHibernateHelper.OpenSession())
            {
                namesList = (from exp in session.Query<ExpenseItem>()
                             where exp.Type == (IsFixed ? "Fixed" : "Variable")
                             select exp.Name).Distinct().ToList();
            }
            return namesList;
        }

        public static List<Expense> GetExpenses(DateTime fromExpenseDate, DateTime toExpenseDate)
        {
            var expenseList = new List<Expense>();
            using (var session = NHibernateHelper.OpenSession())
            {
                expenseList = (from exp in session.Query<Expense>()
                               where exp.DateOfExpense.Date >= fromExpenseDate.Date &&
                                     exp.DateOfExpense.Date <= toExpenseDate.Date
                               select exp).ToList();
            }
            return expenseList;
        }

        public static List<ExpenseItem> GetExpenseItems(int expenseID)
        {
            var expenseItemsList = new List<ExpenseItem>();
            using (var session = NHibernateHelper.OpenSession())
            {
                expenseItemsList = (from item in session.Query<ExpenseItem>()
                                    where item.Expense.ID == expenseID
                                    select item).ToList();
            }
            return expenseItemsList;
        }

        public static Expense GetExpenseInfo(int _ID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    Expense _exp = (from exp in session.Query<Expense>()
                                    where exp.ID == _ID
                                    select exp).SingleOrDefault();

                    _exp.ExpenseItems = session.QueryOver<ExpenseItem>()
                        .Where(x => x.Expense.ID == _ID)
                        .Fetch(o => o.Expense).Eager
                        .Future().ToList();

                    return _exp;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }

            }
        }
    }
}
