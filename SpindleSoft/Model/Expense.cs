using System;
using System.Collections.Generic;

namespace SpindleSoft.Model
{
    internal class Expense
    {
        public int ExpenseID { get; set; }

        public DateTime DateOfExpense { get; set; }

        public List<ExpenseItem> ExpenseItems { get; set; }

        public float ExpenseTotalAmount { get; set; }
    }

    internal class ExpenseItem
    {
        public int ExpenseItemID { get; set; }

        public string ExpenseItemType { get; set; }

        public float ExpenseItemAmount { get; set; }
    }
}