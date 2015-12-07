using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_SalesDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        List<SKUItem> sKUItems = new List<SKUItem>();
        Sale sale = new Sale();
        List<SaleItem> saleItems = new List<SaleItem>();
        DataTable dt = new DataTable();

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

        public Winform_SalesDetails()
        {
            InitializeComponent();
        }

        public Winform_SalesDetails(Sale _sale)
        {
            InitializeComponent();

            //setting the controls
            //UpdateCustomerControl(_sale.Customer);

           for (int i = 0; i < _sale.SaleItems.Count; i++)
			{
                UpdateSaleListControl(_sale.SaleItems[i], i); ;
			}

           dgvSaleItem.Enabled = false;
           dgvSearch.Enabled = false;

        }

        #region Events
        private async  void Winform_SalesDetails_Load(object sender, EventArgs e)
        {
            if (sale.ID != 0)
            {
                _cust = PeoplePracticeBuilder.GetCustomer(sale.Customer.ID);
                this._cust.Image = await Utilities.Helper.GetDocumentAsync(string.Format("/customer_ProfilePictures/{0}.png", this._cust.ID));
                UpdateCustomerControl(_cust);
            }

            this.toolStripParent.Items.Add(this.AddCustToolStrip);

            //Load ComboBox
            var ComboBoxResults = SaleBuilder.GetVariationValues();

            //todo: Can we add Items in a better way
            cmbSize.Items.Add("All");
            cmbSize.Items.AddRange(ComboBoxResults[2].ToArray());

            cmbColor.Items.Add("All");
            cmbColor.Items.AddRange(ComboBoxResults[0].ToArray());

            cmbMaterial.Items.Add("All");
            cmbMaterial.Items.AddRange(ComboBoxResults[1].ToArray());
        }

        private void AddCustToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer().ShowDialog();
        }

        private void txtSrcName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSrcName.Text) && string.IsNullOrEmpty(txtSrcProCode.Text) && string.IsNullOrEmpty(txtDesc.Text))
            {
                dgvSearch.DataSource = null;
                return;
            }

            dgvSearch.DataSource = (from sku in SaleBuilder.GetSKUItems(txtSrcName.Text, txtSrcProCode.Text, txtDesc.Text, cmbColor.Text, cmbSize.Text, cmbMaterial.Text)
                                    select new { sku.Name, sku.ProductCode, sku.Quantity }).ToList();

            UpdateStatus(dgvSearch.Rows.Count == 0 ? "No" : dgvSearch.Rows.Count.ToString() + " Results Found", 100);
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            string _proname = dgvSearch.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            //Add SaleItem to Cart
            string _proCode = dgvSearch.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString();
            var skuItem = SaleBuilder.GetSkuItemInfo(_proCode);
            if (skuItem != null && ((from s in sKUItems where s.ProductCode == skuItem.ProductCode select s).Count() == 0))
            {
                SaleItem _saleItem = new SaleItem(skuItem, 1, skuItem.SellingPrice);
                saleItems.Add(_saleItem);
            }

            LoadDGVSale();
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

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dgvSaleItem.Rows.Count < 1) return;

        //    DialogResult dr = MessageBox.Show("Continue deleting selected Sale items", "Delete Sale Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    if (dr == DialogResult.No) return;

        //    foreach (DataGridViewRow item in dgvSaleItem.SelectedRows)
        //    {
        //        sKUItems.RemoveAt(item.Index);
        //    }
        //    LoadDGVSale();
        //}

        //private void dgvSaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    //if (dgvSaleItem.Columns[e.ColumnIndex].HeaderText == ("Quantity") || dgvSaleItem.Columns[e.ColumnIndex].HeaderText == ("Price"))
        //    //{
        //    //    var quantityCell = dgvSaleItem.Rows[e.RowIndex].Cells["Quantity"];
        //    //    int price;
        //    //    int.TryParse(dgvSaleItem.Rows[e.RowIndex].Cells["Price"].Value.ToString(), out price);

        //    //    //check if quantity within the limits
        //    //    int quantity;
        //    //    int.TryParse(quantityCell.Value.ToString(), out quantity);
        //    //    var limit = (from s in sKUItems
        //    //                 where s.ProductCode == dgvSaleItem.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString()
        //    //                 select s.Quantity).Single();

        //    //    quantityCell.ErrorText = (limit < quantity) || quantity == 0 ? "Quantity cannot exceed Limit OR Zero" : "";

        //    //    //Update the total Amount as per quantity if quantity within limits
        //    //    if (quantityCell.ErrorText == "")
        //    //    {
        //    //        //todo : Method to handle payment amount
        //    //        int total = 0;
        //    //        foreach (DataGridViewRow dr in dgvSaleItem.Rows)
        //    //        {
        //    //            int quant;
        //    //            int.TryParse(dr.Cells["Quantity"].Value.ToString(), out quant);
        //    //            total += (quant * int.Parse(dr.Cells["Price"].Value.ToString()));
        //    //        }

        //    //        txtTotAmnt.Text = total.ToString();
        //    //        txtBalanceAmnt.Text = (total - int.Parse(txtAmntPaid.Text)).ToString();
        //    //    }
        //    //}

        //    //if (dgvSaleItem.Columns["colDelete"].Index == e.ColumnIndex)
        //    //{
        //    //    if (e.ColumnIndex == dgvSaleItem.Columns["colDelete"].Index && dgvSaleItem.Rows[e.RowIndex].IsNewRow != true)
        //    //    {
        //    //        DialogResult dr = MessageBox.Show("Continue deleting selected Sale items?", "Delete Sale Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //    //        if (dr == DialogResult.No) return;

        //    //        bool success = false;

        //    //        if (sKUItems.Count != 0 && e.RowIndex + 1 <= sKUItems.Count)
        //    //        {
        //    //            if (sKUItems[e.RowIndex].ID != 0)
        //    //                success = SalesSaver.DeleteSaleItems(sKUItems[e.RowIndex].ID);

        //    //            if (success || sKUItems[e.RowIndex].ID == 0) // "ID == 0" => Not yet Added to the db 
        //    //            {
        //    //                sKUItems.RemoveAt(e.RowIndex);
        //    //            }
        //    //            else
        //    //            {
        //    //                MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
        //    //                return;
        //    //            }
        //    //        }

        //    //        dgvSaleItem.Rows.RemoveAt(e.RowIndex);
        //    //        CalculatePaymentDetails();
        //    //    }
        //    //}
        //}

        private void CalculatePaymentDetails()
        {
            //todo : Method to handle payment amount
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

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            List<string> exceptionlist = new List<string>() { "grpBxSearch", "pcbCustImage","txtPhoneNo" };
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
                    MessageBox.Show("Thanks for choosing our product. We lend free alternations within fours days from date of Delivery.");
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
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Sale Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }
        #endregion Events

        private void LoadDGVSale()
        {
            dgvSaleItem.DataSource = ToDataTable((from saleItem in saleItems
                                                  select new { saleItem.SKUItem.Name, saleItem.SKUItem.ProductCode, saleItem.Quantity, Price = saleItem.Price, saleItem.ID }).ToList());
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
            pcbCustImage.Image = _cust.Image;
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

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void dgvSaleItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvSaleItem.Columns["colDelete"].Index == e.ColumnIndex)
            {
                if (e.ColumnIndex == dgvSaleItem.Columns["colDelete"].Index && dgvSaleItem.Rows[e.RowIndex].IsNewRow != true)
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
        }

        private void dgvSaleItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            new Winform_SaleItemDetails(e.RowIndex, saleItems[e.RowIndex]).ShowDialog();
        }
    }
}
