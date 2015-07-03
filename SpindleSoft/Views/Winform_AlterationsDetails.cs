using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_AlterationsDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        List<AlterationItem> altItemList = new List<AlterationItem>();
        List<OrderItem> orderItemList = new List<OrderItem>();

        public Winform_AlterationsDetails()
        {
            InitializeComponent();
        }

        public void UpdateCustomerControl(Customer customer)
        {
            if (customer == null) return;

            this._cust = customer;

            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;
            pcbMemImage.Image = _cust.Image;
        }

        //internal void updateOrderItemList(OrderItem _item)
        //{
        //    var index = altItemList.IndexOf(altItemList.Where(x => x.Name == _item.Name).SingleOrDefault());

        //    if (altItemList.Count == 0 || index == -1)
        //        altItemList.Add(_item);
        //    else
        //        altItemList[index] = _item;
        //}

        #region Validation
        private void txtAmntPaid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int AmntPaid, TotAmnt;
            int.TryParse(txtAmntPaid.Text, out AmntPaid);
            int.TryParse(txtTotAmnt.Text, out TotAmnt);

            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            _errorMsg = (_errorMsg == "" && AmntPaid > TotAmnt) ? "Amount Paid cannot be greater than Total Amount" : "";
            errorProvider1.SetError(txtAmntPaid, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtAmntPaid.Text = "";
            }
            else
            {
                txtBalanceAmnt.Text = (TotAmnt - AmntPaid).ToString();
            }
        }

        private void txtSrcName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtOrderID.Text == String.Empty)
                return;

            Match _match = Regex.Match(txtOrderID.Text, "\\d$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Order ID\n" +
  " For example '10'";
            errorProvider1.SetError(txtOrderID, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtOrderID.Select(0, txtOrderID.TextLength);
            }
        }

        private void dgvOrderItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderItems.Rows[e.RowIndex].Cells["AltType"].Value == null &&
                dgvOrderItems.Rows[e.RowIndex].Cells["AltPrice"].Value != null)
            {
                dgvOrderItems.Rows.RemoveAt(e.RowIndex);
                return;
            }
            else if (e.ColumnIndex == dgvOrderItems.Columns["AltPrice"].Index)
            {
                /*Validation*/
                DataGridViewCell cell = (sender as DataGridView).CurrentCell;
                if (cell.Value == null) return;

                Match _match = Regex.Match(cell.Value.ToString(), "^\\d*$");
                cell.ErrorText = (!_match.Success) ? "Invalid Amount input data type.\nExample: '10'" : "";

                if (cell.ErrorText != "")
                {
                    cell.Value = null;
                    return;
                }
                /*Validation - end*/

                //todo : Method to handle payment amount
                /*Calculate Total*/
                UpdateAlterationPrice();
                /*Calculate Total - end*/
            }
        }

        private void UpdateAlterationPrice()
        {
            int total = 0;
            foreach (DataGridViewRow dr in dgvOrderItems.Rows)
            {
                if (dr.IsNewRow) continue;

                if (dr.Cells["AltPrice"].Value == null) dr.Cells["AltPrice"].Value = 0;
                //if|| dr.Cells["AltQuantity"].Value == null)

                total += (int.Parse(dr.Cells["AltQuantity"].Value.ToString()) * int.Parse(dr.Cells["AltPrice"].Value.ToString()));
            }

            int amntPaid = 0;
            txtTotAmnt.Text = total.ToString();
            int.TryParse(txtAmntPaid.Text, out amntPaid);
            txtBalanceAmnt.Text = (total - amntPaid).ToString();
        }
        #endregion Validation

        #region Events
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.Rows.Count < 2 || dgvOrderItems.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("Continue deleting selected Alteration items?", "Delete Alteration Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            foreach (DataGridViewRow item in dgvOrderItems.SelectedRows)
            {
                var index = altItemList.IndexOf(altItemList.Where(x => x.Name == item.Cells["AltType"].Value.ToString()).SingleOrDefault());
                altItemList.RemoveAt(index);
                dgvOrderItems.Rows.RemoveAt(item.Index);
            }
        }

        private void Winform_AlterationsDetails_Load(object sender, System.EventArgs e)
        {
           // this.toolStripParent.Items.Add(this.AddCustomerToolStrip);
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value == null) return;

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                //if item already added
                if (row.IsNewRow == false && row.Cells["AltType"].Value.ToString() == dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value.ToString()
                    && row.Cells["OrderID"].Value.ToString() == txtOrderID.Text)
                {
                    return;
                }
            }

            UpdateCustomerControl(this._cust);

            var itemVal = (from oitem in orderItemList
                           where oitem.Name == dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value.ToString()
                           select oitem);

            //altItemList.Add(itemVal.SingleOrDefault());
            
            var rowVal = (from oitem in itemVal
                          select new { oitem.Name, oitem.Quantity, OrderID = oitem.Order.ID,oitem.Order }).ToArray();
            
            altItemList.Add(new AlterationItem(rowVal[0].Name,rowVal[0].Quantity,rowVal[0].Order));

            var newRowIndex = dgvOrderItems.NewRowIndex;
            dgvOrderItems.Rows[newRowIndex].Cells["AltType"].Value = rowVal[0].Name;
            dgvOrderItems.Rows[newRowIndex].Cells["OrderID"].Value = rowVal[0].OrderID;
            dgvOrderItems.Rows[newRowIndex].Cells["AltQuantity"].Value = rowVal[0].Quantity;
            dgvOrderItems.CurrentCell = dgvOrderItems.Rows[newRowIndex].Cells["AltQuantity"];
            dgvOrderItems.NotifyCurrentCellDirty(true);
            dgvOrderItems.NotifyCurrentCellDirty(false);

            UpdateAlterationPrice();
        }

        private void txtOrderID_TextChanged(object sender, EventArgs e)
        {
            int _orderID;
            int.TryParse(txtOrderID.Text, out _orderID);

            orderItemList = AlterationBuilder.GetOrderItems(_orderID,this._cust.ID);

            if (orderItemList==null || orderItemList.Count == 0) return;
            dgvSearch.DataSource = (from oitem in orderItemList
                                    select new { ProductName = oitem.Name, oitem.Comment, oitem.Quantity, oitem.Price }).ToList();

            dtpDelivery.Value = orderItemList[0].Order.PromisedDate;
            this._cust = Builders.PeoplePracticeBuilder.GetCustomer(orderItemList[0].Order.Customer.ID);

            
        }

        //private void dgvOrderItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == dgvOrderItems.Columns["OrderMeasurement"].Index)
        //    {
        //        var curRow = dgvOrderItems.Rows[e.RowIndex];

        //        //check if clothing name exists.
        //        var _productName = curRow.Cells["AltType"].Value;

        //        if (_productName == null || String.IsNullOrEmpty(_productName.ToString()))
        //        {
        //            MessageBox.Show("Add Clothing Type, as it is mandatory to edit Measurement details.", "Add Clothing Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        else if (this._cust.ID == 0)
        //        {
        //            MessageBox.Show("Add Customer, as it is mandatory to edit Measurement details.", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        //else if (curRow.Cells["AltQuantity"].Value == null)
        //        //{
        //        //    MessageBox.Show("Add Price and Quantity, as it is mandatory for Order details.", "Add Price and Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //    return;
        //        //}

        //        OrderItem item;
        //        item = altItemList.Where(x => (x.Name == _productName.ToString())).SingleOrDefault();

        //        //if (item == null) item = new OrderItem();
        //        //item.Quantity = int.Parse(curRow.Cells["OrderQuantity"].Value.ToString());
        //        //item.Price = int.Parse(curRow.Cells["OrderPrice"].Value.ToString());
        //        new Winform_MeasurementAdd(_productName.ToString(), this._cust.Name, item).ShowDialog();
        //    }
        //}

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            string errorMsg = string.Empty;
            if (this._cust.ID == 0)
                errorMsg = "Add Customer, as it is mandatory for Order details.";
            else if (this.altItemList == null || this.altItemList.Count == 0)
                errorMsg = "Select items to cart to make the Alterations.";
            else if (dtpDeliveryDate.Value.Date.CompareTo(DateTime.Today.Date) > 0)
                errorMsg = "The Promised date must not be less than today.";

            foreach (DataGridViewRow row in dgvOrderItems.Rows)
            {
                if (row.IsNewRow) continue;
                int index = altItemList.IndexOf(altItemList.Where(x => (x.Name == row.Cells["AltType"].Value.ToString())).SingleOrDefault());
                altItemList[index].Comment = row.Cells["AltComment"].Value == null ? "" :row.Cells["AltComment"].Value.ToString();

                int intPrice;
                int.TryParse(row.Cells["AltPrice"].Value.ToString(),out intPrice);
                altItemList[index].Price = intPrice;
            }

            if (errorMsg != string.Empty)
            {
                MessageBox.Show(errorMsg, "Mandatory Info Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int total, amntPaid;
            int.TryParse(txtTotAmnt.Text, out total);
            int.TryParse(txtAmntPaid.Text, out amntPaid);


            Alteration _alteration = new Alteration(this._cust, dtpDeliveryDate.Value, altItemList, total, amntPaid);
            bool success = SpindleSoft.Savers.AlterationSaver.SaveAlterationInfo(_alteration);

            if (success)
            {
                //Send msg if the balance == 0
                //if (total - amntPaid == 0)
                //{
                //    MessageBox.Show("Thanks for choosing our Product. We lend free alternations within fours days from date of Delivery.");
                //}
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(grpbxCustomerDetails, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Order Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }
        #endregion Events
    }
}