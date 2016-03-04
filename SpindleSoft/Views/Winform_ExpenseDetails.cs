using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_ExpenseDetails : Winform_DetailsFormat
    {
        List<ExpenseItem> expenseList = new List<ExpenseItem>();
        Expense expense = new Expense();

        public decimal totalAmount = 0;
        public decimal TotalAmount { get; set; }

        #region ctor
        public Winform_ExpenseDetails()
        {
            InitializeComponent();
            InEdit = true;
        }

        public Winform_ExpenseDetails(Expense _expense, bool _inEdit = false)
        {
            this.expense = _expense;
            this.InEdit = _inEdit;

            InitializeComponent();
            if (!InEdit)
            {
                WinFormControls_InEdit(this);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }
        #endregion

        #region Events
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseItemDetails(dgvExpenseItem.Rows.Count, _inEdit: InEdit).ShowDialog();
        }

        private void dgvExpenseItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvExpenseItem.Rows[e.RowIndex].IsNewRow == true) return;

            if (colDelete.Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Continue deleting Expense Item Salary?", "Delete Expense Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = false;
                if (expenseList.Count != 0 && e.RowIndex + 1 <= expenseList.Count)
                {
                    if (expenseList[e.RowIndex].ID != 0)
                        success = ExpenseSaver.DeleteExpenseItem(expenseList[e.RowIndex].ID);

                    if (success || expenseList[e.RowIndex].ID == 0)
                    {
                        expenseList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                        return;
                    }
                }
                dgvExpenseItem.Rows.RemoveAt(e.RowIndex);
                CalculatePaymentDetails();
            }
            else
            {
                new Winform_ExpenseItemDetails(e.RowIndex, item: expenseList[e.RowIndex], _inEdit: InEdit).ShowDialog();
            }
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

            bool success = ExpenseSaver.SaveExpenses(expense);
            if (success)
            {
                UpdateStatus("Expense Saved", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error While Saving Expense", 100);
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Winform_ExpenseDetails_Load(object sender, EventArgs e)
        {
            if (expense.ID == 0) return;

            dtpDeliveryDate.Value = expense.DateOfExpense.Date;
            txtTotalAmount.Text = expense.TotalAmount.ToString();
            foreach (var item in expense.ExpenseItems)
            {
                UpdateExpenseItems(item, expense.ExpenseItems.IndexOf(item));
            }
        }

        private void dgvExpenseItem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvExpenseItem_CellClick(this, new DataGridViewCellEventArgs(dgvExpenseItem.CurrentCell.ColumnIndex, dgvExpenseItem.CurrentCell.RowIndex));
            }
        }
        #endregion

        #region custom
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
        #endregion

        
    }
}
