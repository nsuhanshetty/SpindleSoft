﻿using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using SpindleSoft.Savers;
using System.Threading.Tasks;

namespace SpindleSoft.Views
{
    public partial class WinForm_CustomerDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        Customer refCust = new Customer();
        public WinForm_CustomerDetails()
        {
            InitializeComponent();
        }

        public WinForm_CustomerDetails(Customer _cust)
        {
            InitializeComponent();

            this._cust = _cust;

            /*Load Controls*/
            txtAddress.Text = _cust.Address;
            txtEmailID.Text = _cust.Email;
            txtMobNo.Text = _cust.Mobile_No;
            txtName.Text = _cust.Name;
            txtPhoneNo.Text = _cust.Phone_No;
            pcbCustImage.Image = _cust.Image;
            refCust = PeoplePracticeBuilder.GetCustomerInfo(_cust.ReferralID);
        }

        #region Events
        private void AddReferralToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer().ShowDialog();
        }

        private void MeasurementDetailsToolStrip_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMobNo.Text))
            {
                MessageBox.Show("");
                return;
            }
        }

        private async void WinForm_CustomerDetails_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.toolStripParent.Items.Add(this.AddReferralToolStrip);

            if (refCust.ReferralID != 0)
                await LoadReferral();
            Cursor.Current = Cursors.Arrow;
        }

        private void btnCapture_Click_1(object sender, EventArgs e)
        {
            Winform_ImageCapture _imageCapture = new Winform_ImageCapture(this.pcbCustImage);
            _imageCapture.ShowDialog();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (Validation.controlIsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        protected async override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            //need to handle this situation well
            string[] input = { "txtAddress", "txtEmailID", "txtRefMob", "txtRefName", "pcbReferral", "txtPhoneNo", "pcbCustImage" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            //todo: use delegate to cut overhead of UpdateStatus();
            UpdateStatus("Saving..", 25);
            this._cust.Name = txtName.Text;
            this._cust.Mobile_No = txtMobNo.Text;
            this._cust.Phone_No = txtPhoneNo.Text;
            this._cust.Email = txtEmailID.Text;
            this._cust.Address = txtAddress.Text;
            this._cust.Image = pcbCustImage.Image;
            if (refCust != null)
                this._cust.ReferralID = refCust.ID;

            UpdateStatus("Saving..", 50);
            bool response = await PeoplePracticeSaver.SaveCustomerInfo(this._cust);

            if (response)
            {
                UpdateStatus("Saved", 100);

                DialogResult dr = MessageBox.Show("Send SMS to customer regarding the registration", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    MessageBox.Show("Customer Added.");
                }
                this.Close();
            }
            else
            {
                UpdateStatus("Error Saving Customer", 100);
            }

            Winform_AddCustomer addCust = Application.OpenForms["Winform_AddCustomer"] as Winform_AddCustomer;
            if (addCust != null)
                addCust.LoadDgv();
        }
        #endregion Events

        #region _Validations
        private void txtEmailID_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmailID.Text == String.Empty)
                return;

            string errorMsg = "";
            Match _match = Regex.Match(txtEmailID.Text, "^[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+\\.[A-Za-z]{2,6}$");
            errorMsg = _match.Success ? "" : "e-mail address must be valid e-mail address format.\n" +
      "For example 'someone@example.com' ";
            errorProvider1.SetError(txtEmailID, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtEmailID.TextLength);
            }
        }

        private void txtMobNo_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtMobNo, errorMsg);

            //bool isUnique = PeoplePracticeBuilder.IsCustomerMobileNoUnique(txtMobNo.Text);
            //!isUnique?"Mobile Number entered is a Duplicate. Kindly Check again";

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtMobNo.Select(0, txtMobNo.TextLength);
            }

            //Check if mobile no is unique

        }

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
        #endregion _Validations

        private async Task LoadReferral()
        {

            if (refCust == null) return;

            txtRefMob.Text = refCust.Mobile_No;
            txtRefName.Text = refCust.Name;
            pcbReferral.Image = await PeoplePracticeBuilder.GetDocumentAsync(string.Format("/customer_ProfilePictures/{0}.png", refCust.ID));
        }

        public void UpdateCustomerControl(Customer refCustomer)
        {
            if (refCustomer == null) return;

            this.refCust = refCustomer;

            txtRefName.Text = refCustomer.Name;
            txtRefMob.Text = refCustomer.Mobile_No;
            pcbReferral.Image = refCustomer.Image;
        }
    }
}