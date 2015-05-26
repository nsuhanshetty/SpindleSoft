using SpindleSoft.Savers;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffDetails : Winform_DetailsFormat
    {
        SpindleSoft.Model.Staff _staff = new Model.Staff();

        public Winform_StaffDetails()
        {
            InitializeComponent();
        }

        #region Validations
        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Name\n" +
      "For example 'Geeta Prasad'";
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

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                string errorMsg = "Address field is mandatory";
                errorProvider1.SetError(txtAddress, errorMsg);
                e.Cancel = true;
                txtMobNo.Select(0, txtAddress.TextLength);
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }
        #endregion Validations

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Winform_ImageCapture _imageCapture = new Winform_ImageCapture(this.pcbStaffImage);
            _imageCapture.ShowDialog();
        }


        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };
            this.Close();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            UpdateStatus("Saving..", 25);
            //set customer
            this._staff.Name = txtName.Text;
            this._staff.MobileNo = txtMobNo.Text;
            this._staff.Address = txtAddress.Text;
            this._staff.Image = pcbStaffImage.Image;

            UpdateStatus("Saving..", 50);
            bool response = PeoplePracticeSaver.SaveStaffInfo(this._staff);

            UpdateStatus("Saving..", 75);
            response = PeoplePracticeSaver.SaveStaffImage(this._staff.Image, this._staff.MobileNo);

            if (response)
            {
                UpdateStatus("Saved", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error Saving Staff Details", 100);
            }
        }

    }
}