using SpindleSoft.Builders;
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
using System.Configuration;

namespace SpindleSoft.Views
{
    public partial class WinForm_CustomerDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        Customer refCust = new Customer();

        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        static string CustomerImagePath = Secrets.FileLocation["CustomerImages"];

        #region Ctor
        public WinForm_CustomerDetails()
        {
            InitializeComponent();
            this.InEdit = true;
        }

        public WinForm_CustomerDetails(Customer _cust, bool inEdit = false)
        {
            this._cust = _cust;
            this.InEdit = inEdit;

            InitializeComponent();
            if (!InEdit)
            {
                var exList = new List<string> { "toolStripParent"};
                WinFormControls_InEdit(this, exList);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }
        #endregion Ctor

        #region Events
        private void WinForm_CustomerDetails_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.toolStripParent.Items.Add(this.AddReferralToolStrip);
            this.EditToolStrip.Visible = true;

            /*Load Controls*/
            txtAddress.Text = _cust.Address;
            txtEmailID.Text = _cust.Email;
            txtMobNo.Text = _cust.Mobile_No;
            txtName.Text = _cust.Name;
            txtPhoneNo.Text = _cust.Phone_No;

            if (_cust.ReferralID != 0)
            {
                refCust = PeoplePracticeBuilder.GetCustomerInfo(_cust.ReferralID);
                UpdateCustomerControl(this.refCust);
            }

            string _fileName = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, _cust.ID);
            pcbCustImage.Image = this._cust.Image = Utilities.ImageHelper.GetDocumentLocal(_fileName);
            Cursor.Current = Cursors.Arrow;
        }

        private void btnCapture_Click(object sender, EventArgs e)
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

            this.InEdit = false;
            this.Close();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            string[] input = { "txtPhoneNo", "txtAddress", "txtEmailID", "pcbCustImage", "txtRefMob", "txtRefName", "pcbReferral" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

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
            bool response = PeoplePracticeSaver.SaveCustomerInfo(this._cust);

            if (response)
            {
                UpdateStatus("Customer Saved", 100);
                //DialogResult dr = MessageBox.Show("Send SMS to customer regarding the registration", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (dr == DialogResult.Yes)
                //{
                //    //Send SMS
                //}
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

        private void AddReferralToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer().ShowDialog();
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

        #region Custom
        private void LoadReferral()
        {
            if (refCust == null) return;

            string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, refCust.ID);
            txtRefMob.Text = refCust.Mobile_No;
            txtRefName.Text = refCust.Name;
            pcbReferral.Image = Utilities.ImageHelper.GetDocumentLocal(filePath);
        }

        public void UpdateCustomerControl(Customer refCustomer)
        {
            if (refCustomer == null) return;

            string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, refCustomer.ID);
            this.refCust = refCustomer;

            txtRefName.Text = refCustomer.Name;
            txtRefMob.Text = refCustomer.Mobile_No;
            pcbReferral.Image = refCustomer.Image = Utilities.ImageHelper.GetDocumentLocal(filePath);
        }
        #endregion Custom
    }
}