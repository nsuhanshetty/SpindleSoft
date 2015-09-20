using log4net;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpindleSoft.Savers
{
    public class ExpenseSaver
    {
        static ILog log = LogManager.GetLogger(typeof(ExpenseSaver));
        public static bool SaveExpenses(Expense expense)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in expense.ExpenseItems)
                        {
                            item.Expense = expense;
                        }

                        session.SaveOrUpdate(expense);
                        tx.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        tx.Rollback();
                    }
                }
            }
            return success;
        }

        public static bool DeleteExpense(int expenseID)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Expense expense = session.Get<Expense>(expenseID);
                        session.Delete(expense);
                        tx.Commit();
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        tx.Rollback();
                    }
                }
            }
            return success;
        }
    }
}
