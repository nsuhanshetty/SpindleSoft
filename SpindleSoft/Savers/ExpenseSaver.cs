using log4net;
using SpindleSoft.Builders;
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
        #region Expense
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

        public static bool DeleteExpenseItem(int _id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var item = session.Get<ExpenseItem>(_id);
                        session.Delete(item);
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }
        #endregion Expense

        #region Salary
        public static bool DeleteSalaryItem(int _id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    try
                    {
                        var item = session.Get<SalaryItem>(_id);
                        session.Delete(item);
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        return false;
                    }
                }
            }
        }

        public static bool SaveSalary(Salary _salary)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        foreach (SalaryItem _item in _salary.SalaryItemList)
                        {
                            _item.Salary = _salary;
                        }

                        /*Add expense to salary */
                        if (_salary.Expense == null)
                        {
                            List<ExpenseItem> expenseItemList = new List<ExpenseItem>();
                            Expense exp = new Expense(_salary.DateOfSalary, expenseItemList, _salary.TotalSalaryAmount);
                            expenseItemList.Add(new ExpenseItem(true, _salary.TotalSalaryAmount, "Staff Salary", "", exp));
                            session.Save(exp);
                            _salary.Expense = exp;
                        }
                        else
                        {
                            /* update expense*/
                            _salary.Expense.DateOfExpense = _salary.DateOfSalary;
                            _salary.Expense.TotalAmount = _salary.TotalSalaryAmount;

                            Expense exp = ExpenseBuilder.GetExpenseInfo(_salary.Expense.ID);
                            exp.DateOfExpense = _salary.DateOfSalary;
                            exp.TotalAmount = _salary.TotalSalaryAmount;

                            foreach (var item in exp.ExpenseItems)
                            {
                                item.Name = "StaffSalary_" + _salary.DateOfSalary.Date;
                                item.Type = "Fixed";
                                item.Amount = _salary.TotalSalaryAmount;
                            }
                        }

                        session.SaveOrUpdate(_salary);
                        transaction.Commit();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return false;
            }
        }

        public static bool DeleteSalary(int salaryID)
        {
            bool success = false;
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        Salary salary = session.Get<Salary>(salaryID);
                        session.Delete(salary);

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
        #endregion Salary
    }
}
