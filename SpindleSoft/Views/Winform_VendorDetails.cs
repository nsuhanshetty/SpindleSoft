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
        Vendor _vendor;

        public Winform_VendorDetails(Vendor vendor)
        {
            InitializeComponent();
            this._vendor = vendor;

            //load Controls
            txtName.Text = _vendor.Name;
            txtMobNo.Text = _vendor.MobileNo;
            txtAddress.Text = _vendor.Address;

            txtBankUserName.Text = _vendor.BankUserName;
            txtIfscCode.Text = _vendor.IFSCCode;
            txtAccNo.Text = _vendor.AccNo;
            //cmbBankName.Text = _vendor.Bank;
        }

        public Winform_VendorDetails()
        {
            InitializeComponent();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.IsNullOrEmpty(this, true))
            {
                return;
            }

            UpdateStatus("fetching vendor data..", 33);

            if (this._vendor == null)
                this._vendor = new Vendor();

            _vendor.BankUserName = txtBankUserName.Text;

            if (!PeoplePracticeBuilder.IfBankExits(cmbBankName.Text))
                this._vendor.Bank = new Bank(cmbBankName.Text);
            else
                this._vendor.Bank = Builders.PeoplePracticeBuilder.GetBankNames(cmbBankName.Text);

            _vendor.IFSCCode = txtIfscCode.Text;
            _vendor.AccNo = txtAccNo.Text;

            _vendor.Name = txtName.Text;
            _vendor.Address = txtAddress.Text;
            _vendor.MobileNo = txtMobNo.Text;

            UpdateStatus("Saving..", 66);
            bool response = PeoplePracticeSaver.SaveVendorInfo(this._vendor);

            if(response)
                UpdateStatus("Saved.", 100);
            else
                UpdateStatus("Error Saving Vendor Details.", 100);

            Winform_VendorsRegister addSaleReg = Application.OpenForms["Winform_VendorsRegister"] as Winform_VendorsRegister;
            if (addSaleReg != null)
                addSaleReg.LoadDgv();

            this.Close();

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

        #region Validation

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

        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
        }

        #endregion Validation

        private void Winform_VendorDetails_Load(object sender, EventArgs e)
        {

            List<Bank> BankList = PeoplePracticeBuilder.GetBankNames();
            cmbBankName.DataSource = BankList;
            cmbBankName.DisplayMember = "Name";
            cmbBankName.ValueMember = "ID";

            string[] bankNames = BankList.Select(x => x.Name).ToArray();
            var nameCollection = new AutoCompleteStringCollection();
            nameCollection.AddRange(bankNames);

            cmbBankName.AutoCompleteCustomSource = nameCollection;
            cmbBankName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBankName.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbBankName.Text = "";
            if (this._vendor != null)
                cmbBankName.SelectedText = this._vendor.Bank.Name;
        }
    }
}
