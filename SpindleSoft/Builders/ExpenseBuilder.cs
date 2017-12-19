using log4net;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate.Criterion;
using System.Collections;

namespace SpindleSoft.Builders
{
    class ExpenseBuilder
    {
        static ILog log = LogManager.GetLogger(typeof(AlterationBuilder));

        public static List<String> GetExpenseNames(bool IsFixed, string expenseName = "")
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

        public static IList GetExpenses(DateTime fromExpenseDate, DateTime toExpenseDate)
        {
            IList expenseList;
            using (var session = NHibernateHelper.OpenSession())
            {
                expenseList = (from exp in session.Query<Expense>()
                               where exp.DateOfExpense.Date >= fromExpenseDate.Date &&
                                     exp.DateOfExpense.Date <= toExpenseDate.Date
                               select new { ExpenseID = exp.ID, exp.DateOfExpense.Date, exp.TotalAmount }).ToList();
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

        public static IList GetSalaryItemList(int salaryID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return (from salItem in session.Query<SalaryItem>()
                            join staff in session.Query<Staff>() on salItem.Staff equals staff
                            where (salItem.Salary.ID == salaryID)
                            select new { ID = salItem.ID, Staff_Name = staff.Name, Amount_Paid = salItem.Amount }).ToList();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }

        }

        public static IList GetSalaryList(DateTime fromDate, DateTime toDate, string _name = "")
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return ((from sal in session.Query<Salary>()
                             join salItem in session.Query<SalaryItem>() on sal equals salItem.Salary
                             join staff in session.Query<Staff>() on salItem.Staff equals staff
                             where (staff.Name.StartsWith(_name) && (salItem.Salary.DateOfSalary.Date >= fromDate.Date && salItem.Salary.DateOfSalary.Date <= toDate.Date))
                             select new { ID = sal.ID, sal.TotalSalaryAmount, sal.DateOfSalary.Date }).ToList()).GroupBy(x => x.ID).Select(y => y.First()).ToList();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }

        }

        public static Salary GetSalary(int salaryID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    Salary sal = session.Get<Salary>(salaryID);
                    sal.SalaryItemList = session.QueryOver<SalaryItem>()
                        .Where(i => i.Salary.ID == salaryID)
                        .Fetch(s => s.Salary).Eager
                        .Fetch(s => s.Salary.Expense).Eager
                        .Fetch(s => s.Staff).Eager
                        .Future().ToList();
                    return sal;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    return null;
                }
            }
        }

        public static decimal GetLastSalary(int _staffID)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                try
                {
                    //var _salAmount = (from sal in session.Query<SalaryItem>()
                    //                  where sal.Staff.ID == _staffID
                    //                  orderby sal.ID descending
                    //                  select sal.Amount).SingleOrDefault();
                    var _salAmount = session.Query<SalaryItem>().Where(x => x.Staff.ID == _staffID).Select(x => x.Amount).SingleOrDefault();
                    return _salAmount == 0 ? 1 : _salAmount;
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    throw;
                }
            }
        }
    }
}
