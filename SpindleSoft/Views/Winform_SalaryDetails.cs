using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SpindleSoft.Model;
using SpindleSoft.Savers;

namespace SpindleSoft.Views
{
    public partial class Winform_SalaryDetails : Winform_DetailsFormat
    {
        List<SalaryItem> salaryList = new List<SalaryItem>();
        Salary _salary;

        #region Ctor
        public Winform_SalaryDetails()
        {
            InitializeComponent();
        }

        public Winform_SalaryDetails(Salary salary)
        {
            InitializeComponent();

            this._salary = salary;
            this.salaryList = this._salary.SalaryItemList.ToList();
        }
        #endregion

        #region Custom
        internal bool UpdateSalaryList(SalaryItem _salary, int _index)
        {
            var staffindex = salaryList.IndexOf(salaryList.Where(x => (x.Staff.ID == _salary.Staff.ID && salaryList.IndexOf(x) != _index)).SingleOrDefault());
            if (staffindex != -1)
            {
                return false;
            }
            else if (salaryList.Count == 0 || salaryList.Count < _index + 1)
            {
                salaryList.Add(_salary);
                dgvSalaryItems.Rows.Add();
            }
            else
                salaryList[_index] = _salary;

            dgvSalaryItems.Rows[_index].Cells[0].Value = _salary.Staff.Name;
            dgvSalaryItems.Rows[_index].Cells[1].Value = _salary.Amount;

            CalculatePaymentDetails();
            return true;
        }

        private void CalculatePaymentDetails()
        {
            int total = 0;
            foreach (DataGridViewRow dr in dgvSalaryItems.Rows)
            {
                if (dr.IsNewRow) continue;

                total += int.Parse(dr.Cells[1].Value.ToString());
            }

            txtTotalSalaryPaid.Text = total.ToString();
        }
        #endregion

        #region Events
        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Salary Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };
            this.Close();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (dgvSalaryItems.Rows.Count == 0)
            {
                MessageBox.Show("Add Salaries to Continue Saving", "Add Salaries", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this._salary == null)
                _salary = new Salary();

            this._salary.DateOfSalary = dtpSalary.Value;
            this._salary.SalaryItemList = salaryList;
            this._salary.TotalSalaryAmount = decimal.Parse(txtTotalSalaryPaid.Text);

            bool sucess = ExpenseSaver.SaveSalary(_salary);

            if (sucess)
            {
                UpdateStatus("Salary Saved", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error saving the salary", 100);
            }
        }

        private void dgvOrderItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvSalaryItems.Rows[e.RowIndex].IsNewRow == true) return;

            if (dgvSalaryItems.Columns["colDelete"].Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Continue deleting selected Salary?", "Delete Salary Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = false;
                if (salaryList.Count != 0 && e.RowIndex + 1 <= salaryList.Count)
                {
                    if (salaryList[e.RowIndex].ID != 0)
                        success = ExpenseSaver.DeleteSalaryItem(salaryList[e.RowIndex].ID);

                    if (success || salaryList[e.RowIndex].ID == 0)
                    {
                        salaryList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                        return;
                    }
                }
                dgvSalaryItems.Rows.RemoveAt(e.RowIndex);
                CalculatePaymentDetails();
            }
            else
            {
                new Winform_AddSalary(e.RowIndex, salaryList[e.RowIndex]).ShowDialog();
            }
        }

        private void Winform_SalaryDetails_Load(object sender, EventArgs e)
        {
            if (_salary != null)
            {
                dtpSalary.Value = _salary.DateOfSalary;
                foreach (var salItem in this.salaryList)
                {
                    dgvSalaryItems.Rows.Add();

                    var _index = this.salaryList.IndexOf(salItem);
                    dgvSalaryItems.Rows[_index].Cells[0].Value = salItem.Staff.Name;
                    dgvSalaryItems.Rows[_index].Cells[1].Value = salItem.Amount;
                }
                CalculatePaymentDetails();
            }
        }

        private void btnAddSalary_Click(object sender, EventArgs e)
        {
            new Winform_AddSalary(dgvSalaryItems.Rows.Count, null).ShowDialog();
        }

        private void dgvSalaryItem_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvOrderItems_CellClick(this, new DataGridViewCellEventArgs(dgvSalaryItems.CurrentCell.ColumnIndex, dgvSalaryItems.CurrentCell.RowIndex));
            }
        }
        #endregion
    }

}