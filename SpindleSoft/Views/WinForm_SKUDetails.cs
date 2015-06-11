using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class WinForm_SKUDetails : Winform_DetailsFormat
    {
        SaleItem saleItem = new SaleItem();
        Vendors vendor;
        public WinForm_SKUDetails()
        {
            InitializeComponent();
        }

        #region Events
        private void WinForm_Sale_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.NewVendToolStrip);

            var ComboBoxResults = SaleBuilder.GetVariationValues();

            //load the combobox size
            cmbSize.Items.AddRange(ComboBoxResults[2].ToArray());
            //load the combobox color
            cmbColor.Items.AddRange(ComboBoxResults[0].ToArray());
            //load the combobox material
            cmbMaterial.Items.AddRange(ComboBoxResults[1].ToArray());
        }

        private void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_VendorsRegister().ShowDialog();
        }

        private void rdbSelfMade_CheckedChanged(object sender, EventArgs e)
        {
            this.NewVendToolStrip.Enabled = rdbSelfMade.Checked ? false : true;
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            string[] input = { "txtVendMobile", "txtVendName" };
            var list = rdbVendorMade.Checked ? null : new List<string>(input);

            if (Utilities.Validation.IsNullOrEmpty(this, true, list))
            {
                return;
            }

            //todo: use delegate to cut overhead of UpdateStatus();
            UpdateStatus("Saving..", 25);
            saleItem.Name = txtName.Text;
            saleItem.Description = txtDesc.Text;
            saleItem.CostPrice = Convert.ToInt32(txtCP.Text);
            saleItem.SellingPrice = Convert.ToInt32(txtSP.Text);
            saleItem.Size = cmbSize.Text;
            saleItem.Color = cmbColor.Text;
            saleItem.Material = cmbMaterial.Text;
            saleItem.IsSelfMade = (rdbSelfMade.Checked) ? true : false;
            saleItem.VendorID = (rdbSelfMade.Checked) ? 0 : this.vendor.ID;
            saleItem.ProductCode = txtCode.Text;

            UpdateStatus("Saving..", 75);
            bool response = SalesSaver.SaveSaleItemInfo(saleItem);

            if (response)
            {
                UpdateStatus("Saved", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error Saving Sale", 100);
            }

        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Sale Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        #endregion Events

        #region Validation
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            var txtbox = (sender as TextBox);
            if (txtbox.Text == String.Empty)
                return;

            //allow only signed int/ float
            Match _match = Regex.Match(txtbox.Text, "^[0-9]*$");
            string errorMsg = _match.Success ? "" : "Invalid Input for fields\n" +
                                                    " For example '340'";
            errorProvider1.SetError(txtbox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtbox.Select(0, txtbox.TextLength);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            var txtbox = (sender as TextBox);
            if (txtbox.Text == String.Empty)
                return;

            string errorMsg;
            if (txtbox.Text.Length > 2)
            {
                bool exists = SaleBuilder.IsExistingName(txtName.Text);
                errorMsg = !exists ? "" : "Product Name already exists. Name needs to be unique";
            }
            else
                errorMsg = "Product Name must have more than two characters.";

            errorProvider1.SetError(txtbox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtbox.Select(0, txtbox.TextLength);
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbColor.Text) || string.IsNullOrEmpty(cmbMaterial.Text)
                || string.IsNullOrEmpty(cmbSize.Text) || string.IsNullOrEmpty(txtName.Text))
                return;

            var nameArray = txtName.Text.Split(' ');
            string code = string.Empty;
            foreach (var s in nameArray)
            {
                code += s.Substring(0, 3);
            }

            var varcode = "-" + cmbMaterial.Text.Substring(0, 3) + "-";
            varcode += cmbColor.Text.Substring(0, 1) + cmbColor.Text.Substring(cmbColor.Text.Length - 1, 1) + cmbSize.Text;

            //todo: is it possible to do directly
            //check if prodcode already exists
            int index = 0;
            bool exists = true;
            while (exists)
                exists = SaleBuilder.IsExistingProdCode(code + (++index).ToString() + varcode);

            txtCode.Text = code + (index).ToString() + varcode;
        }

        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            var cmbbox = (sender as ComboBox);
            if (string.IsNullOrEmpty(cmbbox.Text)) return;

            string errorMsg = "";
            if (cmbbox.Text.Length < 3)
            {
                errorMsg = "Material Type must have more than two characters.";
                errorProvider1.SetError(cmbbox, errorMsg);
            }
            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                cmbbox.Select(0, cmbbox.Text.Length);
            }

        }
        #endregion Validation

        public void UpdateVendorDetails(Vendors vend)
        {
            this.vendor = vend;
            txtVendMobile.Text = vend.MobileNo;
            txtVendName.Text = vend.Name;
        }


    }
}
