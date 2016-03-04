using System;
using System.Windows.Forms;
using SpindleSoft.Model;
using System.Configuration;

namespace SpindleSoft.Views
{
    public partial class Winform_AddSalary : Winform_DetailsFormat
    {
        Staff _staff;
        SalaryItem _salaryItem;
        int _index;

        #region ctor
        public Winform_AddSalary()
        {
            InitializeComponent();
        }

        public Winform_AddSalary(int index, SalaryItem salaryItem = null)
        {
            InitializeComponent();

            this._index = index;
            if (salaryItem == null) return;
            this._salaryItem = salaryItem;
        } 
        #endregion

        #region Events
        private void AddStaffToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_StaffRegister().ShowDialog();
        }

        private void Winform_AddSalary_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddStaffToolStrip);

            if (_salaryItem != null)
            {
                UpdateStaffDetails(this._salaryItem.Staff);
                nudSalaryAmount.Value = this._salaryItem.Amount;
            }
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (_staff == null)
            {
                MessageBox.Show("Staff Details is mandatory", "Add Staff Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProvider1.SetError(txtName, "Staff Details is manadatory");
                return;
            }

            if (this._salaryItem == null)
                this._salaryItem = new SalaryItem();

            this._salaryItem.Staff = _staff;
            this._salaryItem.Amount = nudSalaryAmount.Value;

            Winform_SalaryDetails salaryDetails = Application.OpenForms["Winform_SalaryDetails"] as Winform_SalaryDetails;
            if (salaryDetails != null)
            {
                var isAdded = salaryDetails.UpdateSalaryList(_salaryItem, _index);
                if (isAdded)
                    this.Close();
                else
                    MessageBox.Show("Staff salary Already exists.", "Duplicate Salary", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Custom
        public void UpdateStaffDetails(Staff staff)
        {
            if (staff == null) return;

            errorProvider1.SetError(txtName, "");
            this._staff = staff;
            txtName.Text = _staff.Name;
            txtMobNo.Text = _staff.Mobile_No;
            txtPhoneNo.Text = _staff.Phone_No;

            string baseDoc = ConfigurationManager.AppSettings["BaseDocDirectory"];
            string StaffImagePath = ConfigurationManager.AppSettings["StaffImages"];
            string _fileName = string.Format("{0}/{1}/{2}.png", baseDoc, StaffImagePath, _staff.ID);
            pcbCustImage.Image = Utilities.ImageHelper.GetDocumentLocal(_fileName);

            nudSalaryAmount.Value = SpindleSoft.Builders.ExpenseBuilder.GetLastSalary(_staff.ID);
        } 
        #endregion
    }
}
