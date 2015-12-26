using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpindleSoft.Model;

namespace SpindleSoft.Views
{
    public partial class Winform_AddSalary : Winform_DetailsFormat
    {
        Staff _staff;
        SalaryItem _salary;
        int _index;

        public Winform_AddSalary()
        {
            InitializeComponent();
        }

        public Winform_AddSalary(int index, SalaryItem salary = null)
        {
            InitializeComponent();

            this._index = index;

            if (salary == null) return;
            this._salary = salary;
            UpdateStaffDetails(this._salary.Staff);
            nudSalaryAmount.Value = this._salary.Amount;
        }

        private void AddStaffToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_StaffRegister().ShowDialog();
        }

        private void Winform_AddSalary_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddStaffToolStrip);
        }

        public async void UpdateStaffDetails(Staff staff)
        {
            if (staff == null) return;

            errorProvider1.SetError(txtName, "");
            this._staff = staff;
            txtName.Text = _staff.Name;
            txtMobNo.Text = _staff.Mobile_No;
            txtPhoneNo.Text = _staff.Phone_No;
            pcbCustImage.Image = await Utilities.Helper.GetDocumentAsync("/Staff_ProfilePictures", this._staff.ID.ToString());

            //todo: Fetch his last salary
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (_staff == null)
            {
                MessageBox.Show("Staff Details is mandatory", "Add Staff Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProvider1.SetError(txtName, "Staff Details is manadatory");
                return;
            }

            if (this._salary == null)
                this._salary = new SalaryItem();

            this._salary.Staff = _staff;
            this._salary.Amount = nudSalaryAmount.Value;

            Winform_SalaryDetails salaryDetails = Application.OpenForms["Winform_SalaryDetails"] as Winform_SalaryDetails;
            if (salaryDetails != null)
            {
                var isAdded = salaryDetails.UpdateSalaryList(_salary, _index);
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
    }
}
