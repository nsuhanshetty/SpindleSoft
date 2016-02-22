using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_SalaryRegister : winform_Register
    {
        public Winform_SalaryRegister()
        {
            InitializeComponent();
        }

        private void dtpFromSalaryDate_Validating(object sender, CancelEventArgs e)
        {
            if (DateTime.Compare(dtpFromSalaryDate.Value.Date, dtpToSalaryDate.Value.Date) > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Salary from date can't be greater than the to Date", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void toolStripBtnSearch_Click(object sender, EventArgs e)
        {
            IList salList = ExpenseBuilder.GetSalaryList(dtpFromSalaryDate.Value.Date, dtpToSalaryDate.Value.Date, txtName.Text);
            dgvSalaryItem.DataSource = null;
            if (salList.Count == 0)
            {
                dgvSalaryRegister.DataSource = null;
                UpdateStatus("No salary Items found", 100);
            }
            else
            {
                dgvSalaryRegister.DataSource = salList;
                dgvSalaryRegister.Columns["colDelete"].DisplayIndex = dgvSalaryRegister.Columns.Count - 1;
                dgvSalaryRegister.Columns["colDelete"].Visible = true;
                dgvSalaryRegister.Columns["ID"].Visible = false;
                UpdateStatus(salList.Count + " salaries found", 100);
            }

        }

        private void dgvSalaryRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int salaryID = int.Parse(dgvSalaryRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            if (e.ColumnIndex == dgvSalaryRegister.Columns["colDelete"].Index)
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
            else
            {
                this.Cursor = Cursors.WaitCursor;
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
                this.Cursor = Cursors.Arrow;
            }
        }

        private void dgvSalaryRegister_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int salaryID = int.Parse(dgvSalaryRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());

            Salary salary = ExpenseBuilder.GetSalary(salaryID);
            if (salary == null)
                return;

            new Winform_SalaryDetails(salary).ShowDialog();
            toolStripBtnSearch_Click(new object(), new EventArgs());
        }

        private void dgvSalaryRegister_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSalaryRegister_CellDoubleClick(this, new DataGridViewCellEventArgs(dgvSalaryRegister.CurrentCell.ColumnIndex, dgvSalaryRegister.CurrentCell.RowIndex));
            }
        }
    }
}
