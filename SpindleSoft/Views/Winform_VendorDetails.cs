using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_VendorDetails : Winform_DetailsFormat
    {
        Vendor _vendor = new Vendor();

        #region Ctor
        public Winform_VendorDetails(Vendor vendor, bool inEdit = false)
        {
            this._vendor = vendor;
            this.InEdit = inEdit;

            InitializeComponent();
            if (!InEdit)
            {
                WinFormControls_InEdit(this);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }

        public Winform_VendorDetails()
        {
            InitializeComponent();
        }
        #endregion Ctor

        #region Validation

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for textbox\n" +
      "For example ''";
            errorProvider1.SetError(txtName, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtName.TextLength);
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
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

        private void cmbSectionType_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(cmbSectionType.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for SectionType\n" +
      "For example 'Electrician'";
            errorProvider1.SetError(cmbSectionType, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, cmbSectionType.SelectedText.Length);
            }
        }

        private void cmbSectionType_Validated(object sender, EventArgs e)
        {
            cmbSectionType.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(cmbSectionType.Text);
        }
        #endregion Validation

        #region Event
        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            string[] input = { "txtBankUserName", "cmbBankName", "txtAccNo", "txtIfscNo" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            UpdateStatus("fetching vendor data..", 33);

            if (this._vendor == null)
                this._vendor = new Vendor();

            _vendor.BankUserName = txtBankUserName.Text;

            if (!IsNullOrEmpty(cmbBankName.Text) && !PeoplePracticeBuilder.IfBankExits(cmbBankName.Text))
                this._vendor.Bank = new Bank(cmbBankName.Text);
            else
                this._vendor.Bank = Builders.PeoplePracticeBuilder.GetBankByName(cmbBankName.Text);

            _vendor.IFSCCode = txtIfscNo.Text;
            _vendor.AccNo = txtAccNo.Text;

            _vendor.Name = txtName.Text;
            _vendor.Address = txtAddress.Text;
            _vendor.MobileNo = txtMobNo.Text;

            _vendor.IsProduct = rdbProd.Checked ? true : false;
            _vendor.OfferingType = cmbSectionType.Text;

            UpdateStatus("Saving..", 66);
            bool response = PeoplePracticeSaver.SaveVendorInfo(this._vendor);

            if (response)
            {
                UpdateStatus("Vendor Saved.", 100);
                this.Close();
            }
            else
                UpdateStatus("Error Saving Vendor Details.", 100);

            Winform_VendorsRegister addSaleReg = Application.OpenForms["Winform_VendorsRegister"] as Winform_VendorsRegister;
            if (addSaleReg != null)
                addSaleReg.LoadDgv();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };
            this.Close();
        }

        private void Winform_VendorDetails_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            //load Controls
            txtName.Text = _vendor.Name;
            txtMobNo.Text = _vendor.MobileNo;
            txtAddress.Text = _vendor.Address;

            txtBankUserName.Text = _vendor.BankUserName;
            txtIfscNo.Text = _vendor.IFSCCode;
            txtAccNo.Text = _vendor.AccNo;
            if (_vendor.IsProduct)
                rdbProd.Checked = true;
            else
                rdnServ.Checked = true;

            List<Bank> BankList = PeoplePracticeBuilder.GetBankNames();
            cmbBankName.DataSource = BankList;
            cmbBankName.DisplayMember = "Name";
            cmbBankName.ValueMember = "ID";
            AutoCompletionSource(BankList.Select(x => x.Name).ToList(), cmbBankName);

            cmbBankName.Text = cmbSectionType.Text = "";

            if (this._vendor != null)
            {
                if (this._vendor.Bank != null)
                    cmbBankName.SelectedText = this._vendor.Bank.Name;
                if (this._vendor.OfferingType != null)
                    cmbSectionType.SelectedText = this._vendor.OfferingType;
            }
        }

        private void AutoCompletionSource(List<string> srcList, ComboBox cmb)
        {
            var autoCollection = new AutoCompleteStringCollection();
            autoCollection.AddRange(srcList.ToArray());

            cmb.AutoCompleteCustomSource = autoCollection;
            cmb.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void rdbProd_CheckedChanged(object sender, EventArgs e)
        {
            var offeringList = PeoplePracticeBuilder.GetVendorOfferingType(rdbProd.Checked).ToList();
            cmbSectionType.DataSource = offeringList;
            AutoCompletionSource(offeringList, cmbSectionType);
        }
        #endregion Event
    }
}
