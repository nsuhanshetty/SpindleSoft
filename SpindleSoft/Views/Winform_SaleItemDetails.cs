using SpindleSoft.Model;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_SaleItemDetails : Winform_DetailsFormat
    {
        int index;
        SaleItem saleItem;

        #region ctor
        public Winform_SaleItemDetails(int _index, SaleItem _saleItem)
        {
            InitializeComponent();

            this.index = _index;
            this.saleItem = _saleItem;
        } 
        #endregion

        #region Events
        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            ProcessTabKey(true);
            if (errorProvider1.GetError(txtUnitPrice) != "") return;

            UpdateStatus("Saving..", 25);
            SKUItem skuItem = SpindleSoft.Builders.SaleBuilder.GetSkuItemInfo(txtProductCode.Text);

            saleItem.Quantity = int.Parse(nudQuantity.Value.ToString());
            saleItem.Price = int.Parse(txtUnitPrice.Text);

            UpdateStatus("Saving..", 50);
            Winform_SalesDetails saleDetails = Application.OpenForms["Winform_SalesDetails"] as Winform_SalesDetails;
            if (saleDetails != null)
                saleDetails.UpdateSaleListControl(saleItem, index);

            UpdateStatus("Saved.", 100);
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtUnitPrice.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";

            errorProvider1.SetError(txtUnitPrice, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtUnitPrice.Text = "0";
                return;
            }
        }

        private void Winform_SaleItemDetails_Load(object sender, EventArgs e)
        {
            if (saleItem != null)
            {
                txtClothType.Text = saleItem.SKUItem.Name;
                txtProductCode.Text = saleItem.SKUItem.ProductCode;
                txtUnitPrice.Text = saleItem.Price.ToString();

                nudQuantity.Maximum = saleItem.SKUItem.Quantity;
                nudQuantity.Value = decimal.Parse(saleItem.Quantity.ToString());
            }
        } 
        #endregion
    }
}
