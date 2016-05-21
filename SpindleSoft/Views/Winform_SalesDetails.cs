using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using SpindleSoft.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_SalesDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        Sale sale = new Sale();
        List<SaleItem> saleItems = new List<SaleItem>();
        List<SKUItem> sKUItems = new List<SKUItem>();



        #region Property
        private int amntPaid = 0;
        private int balAmnt = 0;
        private int totalAmnt = 0;
        public int AmountPaid
        {
            get
            {
                return amntPaid;
            }
            set
            {
                amntPaid = value;
                txtAmntPaid.Text = amntPaid.ToString() == "0" ? "" : amntPaid.ToString();
                BalanceAmount = TotalAmount - AmountPaid;
            }
        }

        public int BalanceAmount
        {
            get
            {
                return balAmnt;
            }
            set
            {
                balAmnt = value;
                txtBalanceAmnt.Text = balAmnt.ToString();
            }
        }

        public int TotalAmount
        {
            get
            {
                return totalAmnt;
            }
            set
            {
                totalAmnt = value;
                txtTotAmnt.Text = totalAmnt.ToString();
            }
        }
        #endregion Property

        #region ctor
        public Winform_SalesDetails()
        {
            InitializeComponent();
            InEdit = true;
        }

        public Winform_SalesDetails(Sale _sale)
        {
            InitializeComponent();
            this.sale = _sale;
        }
        #endregion

        #region Events
        private void Winform_SalesDetails_Load(object sender, EventArgs e)
        {
            if (sale.ID != 0)
            {
                _cust = PeoplePracticeBuilder.GetCustomer(sale.Customer.ID);
                UpdateCustomerControl(_cust);

                for (int i = 0; i < sale.SaleItems.Count; i++)
                {
                    UpdateSaleListControl(sale.SaleItems[i], i); ;
                }

                dgvSaleItem.Enabled = false;
                dgvSearch.Enabled = false;
            }

            this.toolStripParent.Items.Add(this.AddCustToolStrip);

            var ComboBoxResults = SaleBuilder.GetVariationValues();

            cmbSize.Items.Add("All");
            cmbSize.Items.AddRange(ComboBoxResults[2].ToArray());

            cmbColor.Items.Add("All");
            cmbColor.Items.AddRange(ComboBoxResults[0].ToArray());

            cmbMaterial.Items.Add("All");
            cmbMaterial.Items.AddRange(ComboBoxResults[1].ToArray());
        }

        private void AddCustToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_CustomerRegister().ShowDialog();
        }

        private void txtSrcName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSrcName.Text) && string.IsNullOrEmpty(txtSrcProCode.Text) && string.IsNullOrEmpty(txtDesc.Text))
            {
                dgvSearch.DataSource = null;
                return;
            }

            dgvSearch.DataSource = SaleBuilder.GetSKUItemList(txtSrcName.Text, txtSrcProCode.Text, txtDesc.Text, cmbColor.Text, cmbSize.Text, cmbMaterial.Text);
            if (dgvSearch.DataSource != null)
                colCart.DisplayIndex = dgvSearch.Columns.Count - 1;
            else
                colCart.Visible = false;
            UpdateStatus(dgvSearch.Rows.Count == 0 ? "No" : dgvSearch.Rows.Count.ToString() + " Results Found");
        }

        private void txtAmntPaid_KeyPress(object sender, KeyEventArgs e)
        {
            //check if valid
            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            errorProvider1.SetError(txtAmntPaid, _errorMsg);

            int AmntPaid, TotAmnt;
            int.TryParse(txtAmntPaid.Text, out AmntPaid);
            int.TryParse(txtTotAmnt.Text, out TotAmnt);

            if (_errorMsg != "" || string.IsNullOrEmpty(txtTotAmnt.Text) || AmntPaid > TotAmnt)
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Handled = true;
                txtAmntPaid.Select(0, txtAmntPaid.TextLength);
                errorProvider1.SetError(txtAmntPaid, "Amount Paid cannot be greater than Total Amount");
            }
            else
            {
                txtBalanceAmnt.Text = (TotAmnt - AmntPaid).ToString();
            }
        }

        private void CalculatePaymentDetails()
        {
            /*Calculate Total*/
            int total = 0;
            foreach (DataGridViewRow dr in dgvSaleItem.Rows)
            {
                if (dr.IsNewRow || dr.Cells["colPrice"].Value == null || dr.Cells["colQuantity"].Value == null) continue;

                total += (int.Parse(dr.Cells["colQuantity"].Value.ToString()) * int.Parse(dr.Cells["colPrice"].Value.ToString()));
            }

            int amntPaid = 0;
            int.TryParse(txtAmntPaid.Text, out amntPaid);
            AmountPaid = amntPaid;
            TotalAmount = total;
            BalanceAmount = TotalAmount - AmountPaid;
            /*Calculate Total - end*/
        }

        protected override async void SaveToolStrip_Click(object sender, EventArgs e)
        {
            List<string> exceptionlist = new List<string>() { "grpBxSearch", "pcbCustImage", "txtPhoneNo" };
            bool exists = SpindleSoft.Utilities.Validation.IsNullOrEmpty(this, true, exceptionlist);
            if (exists) return;
            if (dgvSaleItem.Rows.Count == 0)
            {
                MessageBox.Show("Products Must be selected to make a Sale. Do Add Products to Cart grid");
                return;
            }
            else if (txtAmntPaid.Text == "0" || errorProvider1.GetError(txtAmntPaid) != "")
            {
                MessageBox.Show("Amount not Paid. Save on Amount Paid", "Amount Not Paid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (saleItems.Count == 0)
            {
                MessageBox.Show("Sale Cart cannot be Empty.", "Empty Sale Cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateStatus("Saving Sale..", 25);
            sale.Customer = this._cust;

            int AmntPaid;
            int.TryParse(txtAmntPaid.Text, out AmntPaid);
            sale.AmountPaid = AmntPaid;
            sale.TotalPrice = int.Parse(txtTotAmnt.Text);
            sale.DateOfSale = DateTime.Now;

            UpdateStatus("Saving Sale..", 50);
            sale.SaleItems = saleItems;
            bool success = SalesSaver.SaveSaleItemInfo(sale);

            if (success)
            {
                UpdateStatus("Saved.", 100);

                DialogResult dr = MessageBox.Show("Send SMS to customer regarding the sale", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    string message = "Your sale of #" + sale.ID + " has been delivered, of amount " + sale.TotalPrice + ".  We provide alteration within 4 days of delivery. Thanks for choosing Dee. Stay Beautiful.";
                    await SpindleSoft.Utilities.SMSGateway.SendSMS(message, sale.Customer, 3);
                }
                this.Close();
            }
            else
                UpdateStatus("Error in Saving Order.", 100);
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Sale Details", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        private void dgvSaleItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvSaleItem.Columns["colDelete"].Index == e.ColumnIndex)
            {
                if (e.ColumnIndex == colDelete.Index && dgvSaleItem.Rows[e.RowIndex].IsNewRow != true)
                {
                    DialogResult dr = MessageBox.Show("Continue deleting selected Sale items?", "Delete Sale Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.No) return;

                    bool success = false;

                    if (saleItems.Count != 0 && e.RowIndex + 1 <= saleItems.Count)
                    {
                        if (saleItems[e.RowIndex].ID != 0)
                            success = SalesSaver.DeleteSaleItems(sKUItems[e.RowIndex].ID);

                        if (success || saleItems[e.RowIndex].ID == 0) // "ID == 0" => Not yet Added to the db 
                        {
                            saleItems.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                            return;
                        }
                    }

                    dgvSaleItem.Rows.RemoveAt(e.RowIndex);
                    CalculatePaymentDetails();
                }
            }
            else
            {
                new Winform_SaleItemDetails(e.RowIndex, saleItems[e.RowIndex]).ShowDialog();
                LoadDGVSale();
            }
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            string _ID = dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            var skuItem = SaleBuilder.GetSkuItemInfo(_ID);
            if (colCart.Index == e.ColumnIndex)
            {
                bool _exits = saleItems.Any(x => (x.SKUItem.ID == int.Parse(_ID.ToString())));
                if (_exits)
                {
                    MessageBox.Show("Selected SKU item is already added to cart, Update quantity if required.", "Duplicate SKU Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    SaleItem _saleItem = new SaleItem(skuItem, 1, skuItem.SellingPrice);
                    saleItems.Add(_saleItem);
                    LoadDGVSale();
                }
            }
            else
            {
                new WinForm_SKUDetails(skuItem, false).ShowDialog();
            }
        }
        #endregion Events

        #region Custom
        private void LoadDGVSale()
        {
            dgvSaleItem.DataSource = (from saleItem in saleItems
                                      select new { saleItem.SKUItem.Name, saleItem.SKUItem.ProductCode, saleItem.Quantity, Price = saleItem.Price, saleItem.ID })
                                      .ToList();
            dgvSaleItem.Columns["ID"].Visible = false;
            CalculatePaymentDetails();
        }

        public void UpdateCustomerControl(Customer customer)
        {
            if (customer == null) return;
            this._cust = customer;

            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;

            /*todo: Load the image from single source*/
            string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
            string CustomerImagePath = Secrets.FileLocation["CustomerImages"];
            string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, _cust.ID);
            pcbCustImage.Image = this._cust.Image = Utilities.ImageHelper.GetDocumentLocal(filePath);
        }

        public void UpdateSaleListControl(SaleItem _saleitem, int _index)
        {
            if (saleItems.Count == 0 || saleItems.Count < _index + 1)
                saleItems.Add(_saleitem);
            else
                saleItems[_index] = _saleitem;

            if (dgvSaleItem.Rows.Count < saleItems.Count)
            {
                dgvSaleItem.Rows.Add();
                dgvSaleItem.Rows[_index].Cells["colName"].Value = _saleitem.SKUItem.Name;
                dgvSaleItem.Rows[_index].Cells["colProductCode"].Value = _saleitem.SKUItem.ProductCode;
            }

            dgvSaleItem.Rows[_index].Cells["colPrice"].Value = _saleitem.Price;
            dgvSaleItem.Rows[_index].Cells["colQuantity"].Value = _saleitem.Quantity;

            CalculatePaymentDetails();
        }
        #endregion
    }
}
