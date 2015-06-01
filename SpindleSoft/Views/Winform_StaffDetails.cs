using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffDetails : Winform_DetailsFormat
    {
        Staff _staff = new Staff();

        #region Ctor
        public Winform_StaffDetails()
        {
            InitializeComponent();
        }

        public Winform_StaffDetails(Staff _staff)
        {
            InitializeComponent();

            this._staff = _staff;

            /*Load Controls*/
            txtAddress.Text = _staff.Address;
            txtMobNo.Text = _staff.Mobile_No;
            txtName.Text = _staff.Name;
            txtPhoneNo.Text = _staff.Phone_No;
            pcbStaffImage.Image = _staff.Image;

            if (_staff.IsTemporary)
            {
                rdbPerm.Checked = false;
                rdbTemp.Checked = true;
            }
            else
            {
                rdbPerm.Checked = true;
                rdbTemp.Checked = false;
            }
        }
        #endregion Ctor

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

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhoneNo.Text == String.Empty)
                return;

            Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Phone Number\n" +
  " For example '8012345678'";
            errorProvider1.SetError(txtPhoneNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPhoneNo.Select(0, txtPhoneNo.TextLength);
            }
        }
        #endregion Validations

        #region Events
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
            //need to handle this situation well
            string[] input = { "txtPhoneNo" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            UpdateStatus("Validating..", 25);
            //set customer
            this._staff.Name = txtName.Text;
            this._staff.Mobile_No = txtMobNo.Text;
            this._staff.Address = txtAddress.Text;
            this._staff.Phone_No = txtPhoneNo.Text;
            this._staff.Image = pcbStaffImage.Image;
            this._staff.IsTemporary = rdbPerm.Checked == true ? false : true;

            UpdateStatus("Saving Staff Info..", 50);
            bool response = PeoplePracticeSaver.SaveStaffInfo(this._staff);

            UpdateStatus("Saving Staff Image..", 75);
            response = PeoplePracticeSaver.SaveStaffImage(this._staff.Image, this._staff.Mobile_No);

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
        #endregion events

    }
}