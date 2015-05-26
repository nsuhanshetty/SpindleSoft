using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffRegister : Form
    {
        public Winform_StaffRegister()
        {
            InitializeComponent();
        }

        #region Validation
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text)) return;

            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtName, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtName.TextLength);
            }
        }

        private void txtMobNo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMobNo.Text)) return;

            Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtMobNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtMobNo.Select(0, txtMobNo.TextLength);
            }
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPhoneNo.Text)) return;

            Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtPhoneNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPhoneNo.Select(0, txtPhoneNo.TextLength);
            }
        }
        #endregion Validation

        #region Events
        private void dgvStaffRregister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvStaffRregister.DataSource = SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
        }
        #endregion Events
    }
}