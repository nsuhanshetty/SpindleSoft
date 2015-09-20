using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_ExpenseDetails : Winform_DetailsFormat
    {
        List<ExpenseItem> expenseList = new List<ExpenseItem>();
        Expense expense;

        public decimal totalAmount = 0;
        public decimal TotalAmount { get; set; }

        public Winform_ExpenseDetails()
        {
            InitializeComponent();
        }

        public Winform_ExpenseDetails(Expense _expense)
        {
            InitializeComponent();

            this.expense = _expense;
            dtpDeliveryDate.Value = expense.DateOfExpense.Date;
            txtTotalAmount.Text = expense.TotalAmount.ToString();
            //expenseList = (List<ExpenseItem>)expense.ExpenseItems;

            foreach (var item in expense.ExpenseItems)
            {
                UpdateExpenseItems(item, expense.ExpenseItems.IndexOf(item));
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseItemDetails(dgvExpenseItem.Rows.Count).ShowDialog();
        }

        internal void UpdateExpenseItems(ExpenseItem _item, int _index)
        {
            if (expenseList.Count == 0 || expenseList.Count < _index + 1)
            {
                expenseList.Add(_item);
                dgvExpenseItem.Rows.Add();
            }
            else
                expenseList[_index] = _item;

            dgvExpenseItem.Rows[_index].Cells["colName"].Value = _item.Name;
            dgvExpenseItem.Rows[_index].Cells["colType"].Value = _item.Type;
            dgvExpenseItem.Rows[_index].Cells["colAmount"].Value = _item.Amount;
            dgvExpenseItem.Rows[_index].Cells["colComment"].Value = _item.Comment;

            CalculatePaymentDetails();
        }

        private void CalculatePaymentDetails()
        {
            totalAmount = 0;
            foreach (var item in expenseList)
            {
                totalAmount += item.Amount;
            }

            TotalAmount = totalAmount;
            txtTotalAmount.Text = TotalAmount.ToString();
        }

        private void dgvExpenseItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var row = dgvExpenseItem.Rows[e.RowIndex];

            ExpenseItem item = expenseList[e.RowIndex];
            new Winform_ExpenseItemDetails(e.RowIndex, item).ShowDialog();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (expenseList == null || expenseList.Count == 0)
            {
                MessageBox.Show("Expense Cart Cannot be Empty. Enter Expense values", "Add Expense Items", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateStatus("Saving..", 50);

            if (expense == null)
                expense = new Expense(dtpDeliveryDate.Value, expenseList, decimal.Parse(txtTotalAmount.Text));
            else
            {
                expense.DateOfExpense = dtpDeliveryDate.Value.Date;
                expense.ExpenseItems = expenseList;
                expense.TotalAmount = decimal.Parse(txtTotalAmount.Text);
            }

            bool success = Savers.ExpenseSaver.SaveExpenses(expense);

            if (success)
            {
                UpdateStatus("Saved", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error While Saving", 100);
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
