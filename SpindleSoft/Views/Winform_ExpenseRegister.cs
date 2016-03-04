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
        #region Ctor
        public Winform_ExpenseRegister()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void Winform_ExpenseRegister_Load(object sender, EventArgs e)
        {
            ReloadExpenseRegister();
        }

        private void dtpExpenseDate_ValueChanged(object sender, EventArgs e)
        {
            ReloadExpenseRegister();
        }

        private void dgvExpense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvExpense.Rows.Count == 0) return;
            int expenseID = int.Parse(dgvExpense.Rows[e.RowIndex].Cells["ExpenseID"].Value.ToString());

            if (e.ColumnIndex == colDelete.Index)
            {
                DeleteExpense(expenseID);
                ReloadExpenseRegister();
            }
            else if (e.ColumnIndex == colEdit.Index)
            {
                var exp = ExpenseBuilder.GetExpenseInfo(expenseID);
                new Winform_ExpenseDetails(exp, true).ShowDialog();
                ReloadExpenseRegister();
            }
            else
            {
                DisplayExpenseTypeDetails(expenseID);
            }
        }

        private void dgvExpense_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvExpense_CellClick(this, new DataGridViewCellEventArgs(dgvExpense.CurrentCell.ColumnIndex, dgvExpense.CurrentCell.RowIndex));
            }
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseDetails().ShowDialog();
            ReloadExpenseRegister();
        }
        #endregion

        #region Custom
        private void ReloadExpenseRegister()
        {
            UpdateStatus("Searching", 50);
            dgvFixedExpense.DataSource = dgvVariableExpense.DataSource = null;
            dgvExpense.DataSource = ExpenseBuilder.GetExpenses(dtpFromExpenseDate.Value, dtpToExpenseDate.Value);

            if (dgvExpense.Rows.Count != 0)
            {
                colDelete.Visible = colEdit.Visible = true;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvExpense.Columns.Count - 1;
            }
            else
            {
                colDelete.Visible = colEdit.Visible = false;
                dgvExpense.DataSource = null;
            }
            
        }

        private void DisplayExpenseTypeDetails(int expenseID)
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
                dgvFixedExpense.DataSource = dgvVariableExpense.DataSource = null;
            }
        }

        private void DeleteExpense(int expenseID)
        {
            DialogResult dr = MessageBox.Show("Delete Expense No. " + expenseID + "?", "Delete Expense", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            bool success = SpindleSoft.Savers.ExpenseSaver.DeleteExpense(expenseID);
            if (success == true)
            {
                ReloadExpenseRegister();
                UpdateStatus("Expense Deleted", 100);
            }
            return;
        }
        #endregion
    }
}