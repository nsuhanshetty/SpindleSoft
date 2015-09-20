using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    public class Expense
    {
        public virtual int ID { get; set; }

        public virtual DateTime DateOfExpense { get; set; }

        public virtual IList<ExpenseItem> ExpenseItems { get; set; }

        public virtual decimal TotalAmount { get; set; }

        public Expense() { }

        public Expense(DateTime expenseDate, List<ExpenseItem> expenseList, decimal totalAmount)
        {
            this.DateOfExpense = expenseDate;
            this.ExpenseItems = expenseList;
            this.TotalAmount = totalAmount;
        }
    }

    public class ExpenseItem
    {
        public virtual int ID { get; set; }

        public virtual Expense Expense { get; set; }

        public virtual string Type { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual string Name { get; set; }

        public virtual string Comment { get; set; }

        public ExpenseItem() { }

        public ExpenseItem(bool isFixed, decimal amount, string name, string comment,Expense expense)
        {
            this.Name = name;
            this.Type = isFixed ? "Fixed" : "Variable";
            this.Amount = amount;
            this.Comment = comment;
            this.Expense = expense;
        }
    }
}