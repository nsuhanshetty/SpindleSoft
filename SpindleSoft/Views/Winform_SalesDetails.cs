using SpindleSoft.Builders;
using SpindleSoft.Model;
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

        public Winform_SalesDetails()
        {
            InitializeComponent();
        }

        #region Events
        private void Winform_SalesDetails_Load(object sender, EventArgs e)
        {
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
        #endregion Events

        public void UpdateCustomerControl(Customer customer)
        {
            if (customer == null) return;

            this._cust = customer;

            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;
            pcbCustImage.Image = _cust.Image;
        }

        private void txtSrcName_TextChanged(object sender, EventArgs e)
        {
            //todo : how do we add vendors name along with salename
            //bool isSelfMade = cmbSource.Text == "Self" ? true : false;
            dgvSearch.DataSource = (from sku in SaleBuilder.GetSaleItems(txtSrcName.Text, txtSrcProCode.Text, txtDesc.Text, cmbColor.Text, cmbSize.Text, cmbMaterial.Text)
                                    select new { sku.Name, sku.ProductCode, sku.Quantity }).ToList();
            //dgvSearch.Columns.Remove("ID");
            //dgvSearch.Columns.Remove("IsSelfMade");
            //dgvSearch.Columns.Remove("Description");
            //dgvSearch.Columns.Remove("VendorID");
            //dgvSearch.Columns.Remove("CostPrice");
            //dgvSearch.Columns.Remove("SellingPrice");
            //dgvSearch.Columns.Remove("Color");
            //dgvSearch.Columns.Remove("Size");
            //dgvSearch.Columns.Remove("Material");
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string _proname = dgvSearch.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            DialogResult dr = MessageBox.Show("Do you want to add Product " + _proname + " to Sales cart?", "Sale Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No) return;

            string _proCode = dgvSearch.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString();

            var a = SaleBuilder.GetSaleItemInfo(_proCode);
            if (a != null && ((from s in sKUItems where s.ProductCode == a.ProductCode select s).Count() == 0))
            {
                sKUItems.Add(a);
            }
            LoadDGVSale();
        }

        private void LoadDGVSale()
        {
            dt = ToDataTable((from sku in sKUItems
                              select new { sku.Name, sku.ProductCode, sku.Quantity, Price = sku.SellingPrice, sku.ID }).ToList());

            //make quantity columns readable
            foreach (var col in dt.Columns)
            {
                ((DataColumn)col).ReadOnly = true;
            }
            dt.Columns["Quantity"].ReadOnly = false;
            dt.Columns["Price"].ReadOnly = false;

            dgvSaleItem.DataSource = dt;
            dgvSaleItem.Columns["ID"].Visible = false;

            //update amount paid.
            if (dgvSaleItem.Rows.Count != 0)
            {
                txtTotAmnt.Text = sKUItems.Select(x => (x.SellingPrice * x.Quantity)).Sum().ToString();
                txtAmntPaid.Text = "0";
                txtBalanceAmnt.Text = txtTotAmnt.Text;
            }
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            bool exists = SpindleSoft.Utilities.Validation.IsNullOrEmpty(this, true, "grpBxSearch");
            if (exists) return;
            if (dgvSaleItem.Rows.Count == 0)
            {
                MessageBox.Show("Products Must be selected to make a Sale. Do Add Products to Cart grid");
                return;
            }

            for (int i = 0; i < dgvSaleItem.Rows.Count; i++)
            {
                if (dgvSaleItem.Rows[i].Cells["Quantity"].ErrorText != "")
                {
                    MessageBox.Show("Quantity limit exceed for product " + dgvSaleItem.Rows[i].Cells["Name"].Value);
                    dgvSaleItem.Rows[i].Cells["Quantity"].Selected = true;
                    return;
                }
            }

            sale.CustID = this._cust.ID;
            int j;
            int.TryParse(txtAmntPaid.Text, out j);
            sale.AmountPaid = j;
            sale.TotalPrice = int.Parse(txtTotAmnt.Text);
            sale.SaleItems = new List<SaleItem>();

            foreach (DataGridViewRow row in dgvSaleItem.Rows)
            {
                SaleItem saleItem = new SaleItem(int.Parse(row.Cells["ID"].Value.ToString()), int.Parse(row.Cells["Quantity"].Value.ToString()));
                sale.SaleItems.Add(saleItem);
            }

            //save saleitem
            //update SKU stock

            //sendSMS
            if (txtTotAmnt.Text == txtAmntPaid.Text)
            {
                MessageBox.Show("SMS Sent to " + this._cust.Name);
            }
        }

        private void txtAmntPaid_KeyPress(object sender, KeyEventArgs e)
        {
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSaleItem.Rows.Count < 1) return;

            DialogResult dr = MessageBox.Show("Continue deleting selected Sale items", "Delete Sale Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            foreach (DataGridViewRow item in dgvSaleItem.SelectedRows)
            {
                sKUItems.RemoveAt(item.Index);
            }
            LoadDGVSale();
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

        private void dgvSaleItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSaleItem.Columns[e.ColumnIndex].HeaderText == ("Quantity") || dgvSaleItem.Columns[e.ColumnIndex].HeaderText == ("Price"))
            {
                var quantityCell = dgvSaleItem.Rows[e.RowIndex].Cells["Quantity"];
                int price;
                int.TryParse(dgvSaleItem.Rows[e.RowIndex].Cells["Price"].Value.ToString(), out price);

                //check if quantity within the limits
                int quantity;
                int.TryParse(quantityCell.Value.ToString(), out quantity);
                var limit = (from s in sKUItems
                             where s.ProductCode == dgvSaleItem.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString()
                             select s.Quantity).Single();

                quantityCell.ErrorText = (limit < quantity) || quantity == 0 ? "Quantity cannot exceed Limit OR Zero" : "";

                //else update the price as per quantity
                if (quantityCell.ErrorText == "")
                {
                    //todo : Method to handle payment amount
                    int total = 0;
                    foreach(DataGridViewRow dr in dgvSaleItem.Rows)
                    {
                        total += (int.Parse(dr.Cells["Quantity"].Value.ToString()) * int.Parse(dr.Cells["Price"].Value.ToString()));
                    }

                    txtTotAmnt.Text = total.ToString();
                    txtBalanceAmnt.Text = (int.Parse(txtTotAmnt.Text) - int.Parse(txtAmntPaid.Text)).ToString();
                }
            }
        }

        private void dgvSaleItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewCell cell;
            if (dgvSaleItem.Columns[e.ColumnIndex].HeaderText == "Quantity")
                cell = dgvSaleItem.Rows[e.RowIndex].Cells["Quantity"];
            else if (dgvSaleItem.Columns[e.ColumnIndex].HeaderText == "Price")
                cell = dgvSaleItem.Rows[e.RowIndex].Cells["Price"];
            else
                return;

            //check for valid input (int's only)
            Match _match = Regex.Match(cell.Value.ToString(), "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            if (!String.IsNullOrEmpty(_errorMsg))
            {
                cell.ErrorText = _errorMsg;
                return;
            }

        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Order Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }
    }
}
