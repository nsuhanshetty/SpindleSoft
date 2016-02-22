using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_ExpenseRegister : winform_Register
    {
        List<Expense> expenseList;
        public Winform_ExpenseRegister()
        {
            InitializeComponent();
        }

        private void Winform_ExpenseRegister_Load(object sender, EventArgs e)
        {
            LoadExpenseDGV();
        }

        private void LoadExpenseDGV()
        {
            dgvExpense.Columns["colDelete"].Visible = false;
            expenseList = ExpenseBuilder.GetExpenses(dtpFromExpenseDate.Value, dtpToExpenseDate.Value);
            dgvExpense.DataSource = (from exp in expenseList
                                     select new { ExpenseID = exp.ID, exp.DateOfExpense.Date, exp.TotalAmount }).ToList();

            if (dgvExpense.Rows.Count != 0)
            {
                dgvExpense.Columns["colDelete"].Visible = true;
                dgvExpense.Columns["colDelete"].DisplayIndex = dgvExpense.Columns.Count - 1;
            }

            dgvFixedExpense.DataSource = null;
            dgvVariableExpense.DataSource = null;

            UpdateStatus(dgvExpense.Rows.Count.ToString() + " Results Found.", 100);
        }

        private void dtpExpenseDate_ValueChanged(object sender, EventArgs e)
        {
            LoadExpenseDGV();
        }

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvExpense.Rows.Count == 0) return;
            int expenseID = int.Parse(dgvExpense.Rows[e.RowIndex].Cells["ExpenseID"].Value.ToString());

            if (e.ColumnIndex == dgvExpense.Columns["colDelete"].Index)
            {
                DeleteExpense(expenseID);
                return;
            }

            UpdateExpenseTypeDetails(expenseID);
        }

        private void UpdateExpenseTypeDetails(int expenseID)
        {
            List<ExpenseItem> expenseItemList = ExpenseBuilder.GetExpenseItems(expenseID);

            if (expenseItemList != null)
            {
                var fixList = (from s in expenseItemList
                               where s.Type == "Fixed"
                               select new { s.Name, s.Comment, s.Amount }).ToList();
                dgvFixedExpense.DataSource = fixList.Count == 0 ? null : fixList;

                var varList = (from s in expenseItemList
                               where s.Type == "Variable"
                               select new { s.Name, s.Comment, s.Amount }).ToList();
                dgvVariableExpense.DataSource = varList.Count == 0 ? null : varList;
            }
            else
            {
                dgvFixedExpense.DataSource = null;
                dgvVariableExpense.DataSource = null;
            }
        }

        private void DeleteExpense(int expenseID)
        {
            DialogResult dr = MessageBox.Show("Do you want to Delete Expense No. " + expenseID, "Delete Expense", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            bool success = SpindleSoft.Savers.ExpenseSaver.DeleteExpense(expenseID);
            if (success == true)
            {
                LoadExpenseDGV();
                UpdateStatus("Expense Deleted", 100);
            }
            return;
        }

        private void dgvExpense_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvExpense.Rows.Count == 0) return;
            int expenseID = int.Parse(dgvExpense.Rows[e.RowIndex].Cells["ExpenseID"].Value.ToString());

            var exp = ExpenseBuilder.GetExpenseInfo(expenseID);
            new Winform_ExpenseDetails(exp).ShowDialog();

            LoadExpenseDGV();
        }

        private void dgvExpense_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvExpense_CellDoubleClick(this, new DataGridViewCellEventArgs(dgvExpense.CurrentCell.ColumnIndex, dgvExpense.CurrentCell.RowIndex));
            }
        }
    }
}