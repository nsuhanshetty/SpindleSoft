using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_SalaryRegister : winform_Register
    {
        #region ctor
        public Winform_SalaryRegister()
        {
            InitializeComponent();
        }
        #endregion

        #region Validation
        private void dtpFromSalaryDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(dtpFromSalaryDate.Value.Date, dtpToSalaryDate.Value.Date) > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Salary from date can't be greater than the to Date", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region Events
        private void toolStripBtnSearch_Click(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);
            IList salList = ExpenseBuilder.GetSalaryList(dtpFromSalaryDate.Value.Date, dtpToSalaryDate.Value.Date, txtName.Text);

            if (salList.Count == 0)
            {
                dgvSalaryRegister.DataSource = dgvSalaryItem.DataSource = null;
                colDelete.Visible = colEdit.Visible = false;
            }
            else
            {
                dgvSalaryRegister.DataSource = salList;
                dgvSalaryRegister.Columns["ID"].Visible = false;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvSalaryRegister.Columns.Count - 1;
                colDelete.Visible = colEdit.Visible = true;
                dgvSalaryItem.DataSource = null;
            }
            UpdateStatus((dgvSalaryRegister.RowCount == 0) ? "No Results Found" : dgvSalaryRegister.RowCount + " Results Found", 100);
        }

        private void dgvSalaryRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int salaryID = int.Parse(dgvSalaryRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            if (e.ColumnIndex == colDelete.Index)
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete Salary of date " + dgvSalaryRegister.Rows[e.RowIndex].Cells["DateOfSalary"].Value.ToString(), "Delete Salary Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = SpindleSoft.Savers.ExpenseSaver.DeleteSalary(salaryID);
                if (success == true)
                {
                    toolStripBtnSearch_Click(this, new EventArgs());
                    UpdateStatus("Salary Deleted", 100);
                }
                return;
            }
            else if (e.ColumnIndex == colEdit.Index)
            {
                Salary salary = ExpenseBuilder.GetSalary(salaryID);
                if (salary != null)
                {
                    new Winform_SalaryDetails(salary).ShowDialog();
                    toolStripBtnSearch_Click(new object(), new EventArgs());
                }
            }
            else
            {
                IList salItemList = ExpenseBuilder.GetSalaryItemList(salaryID);

                if (salItemList.Count == 0)
                {
                    dgvSalaryItem.DataSource = null;
                }
                else
                {
                    dgvSalaryItem.DataSource = salItemList;
                    dgvSalaryItem.Columns["ID"].Visible = false;
                }
            }
        }

        private void dgvSalaryRegister_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSalaryRegister_CellClick(this, new DataGridViewCellEventArgs(dgvSalaryRegister.CurrentCell.ColumnIndex, dgvSalaryRegister.CurrentCell.RowIndex));
            }
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_SalaryDetails().ShowDialog();
        }

        private void Winform_SalaryRegister_Load(object sender, EventArgs e)
        {
            this.toolStrip1.Items.Add(this.toolStripBtnSearch);
        }
        #endregion
    }
}
