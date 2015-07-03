using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using log4net;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        Orders order = new Orders();
        List<OrderItem> OrderItemsList = new List<OrderItem>();
        ILog log = LogManager.GetLogger(typeof(Winform_OrderDetails));

        //public int TotalAmount { get; set; }

        public Winform_OrderDetails()
        {
            InitializeComponent();

        }

        public Winform_OrderDetails(Orders order)
        {
            InitializeComponent();

            UpdateCustomerControl(PeoplePracticeBuilder.GetCustomer(order.Customer.ID));

            this.order = OrderBuilder.GetOrderInfo(order.ID);
            this.OrderItemsList = this.order.OrdersItems as List<OrderItem>;
            dtpDeliveryDate.Value = order.PromisedDate;
            txtTotAmnt.Text = order.TotalPrice.ToString();
            txtAmntPaid.Text = order.CurrentPayment.ToString();

            int amntPaid = 0;
            int total;
            txtTotAmnt.Text = txtTotAmnt.Text;

            int.TryParse(txtAmntPaid.Text, out amntPaid);
            int.TryParse(txtTotAmnt.Text, out total);
            txtBalanceAmnt.Text = (total - amntPaid).ToString();
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

        internal void updateOrderItemList(OrderItem _item)
        {
            var index = OrderItemsList.IndexOf(OrderItemsList.Where(x => x.Name == _item.Name).SingleOrDefault());

            if (OrderItemsList.Count == 0 || index == -1)
                OrderItemsList.Add(_item);
            else
                OrderItemsList[index] = _item;
        }

        #region Events

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrderItems.Rows.Count < 2 || dgvOrderItems.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("Continue deleting selected Order items?", "Delete Order Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            foreach (DataGridViewRow item in dgvOrderItems.SelectedRows)
            {
                var index = OrderItemsList.IndexOf(OrderItemsList.Where(x => x.Name == item.Cells["OrderType"].Value.ToString()).SingleOrDefault());
                OrderItemsList.RemoveAt(index);
                dgvOrderItems.Rows.RemoveAt(item.Index);
            }
        }

        private void Winform_OrderAdd_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);

            //todo: removing NewOrderTypeToolStrip in designer
            //this.toolStripParent.Items.Add(this.NewOrderTypeToolStrip);

            if (OrderItemsList != null && OrderItemsList.Count != 0)
            {
                foreach (var item in OrderItemsList)
                {
                    int index = dgvOrderItems.NewRowIndex;
                    dgvOrderItems.Rows[index].Cells["OrderType"].Value = item.Name;
                    dgvOrderItems.Rows[index].Cells["OrderQuantity"].Value = item.Quantity;
                    dgvOrderItems.Rows[index].Cells["OrderPrice"].Value = item.Price;
                    dgvOrderItems.CurrentCell = dgvOrderItems.Rows[index].Cells["OrderPrice"];
                    dgvOrderItems.NotifyCurrentCellDirty(true);
                    dgvOrderItems.NotifyCurrentCellDirty(false);
                }
            }

            try
            {
                List<string> orderTypeList = OrderBuilder.GetOrderTypeList();
                this.OrderType.Items.AddRange(orderTypeList.ToArray());
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvOrderItems.Columns["OrderMeasurement"].Index)
            {
                var curRow = dgvOrderItems.Rows[e.RowIndex];

                //check if clothing name exists.
                var _productName = curRow.Cells["OrderType"].Value;

                if (_productName == null || String.IsNullOrEmpty(_productName.ToString()))
                {
                    MessageBox.Show("Add Clothing Type, as it is mandatory to edit Measurement details.", "Add Clothing Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (this._cust.ID == 0)
                {
                    MessageBox.Show("Add Customer, as it is mandatory to edit Measurement details.", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if ((curRow.Cells["OrderQuantity"].Value == null) && (curRow.Cells["OrderPrice"].Value == null))
                {
                    MessageBox.Show("Add Price and Quantity, as it is mandatory for Order details.", "Add Price and Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OrderItem item;
                item = OrderItemsList.Where(x => (x.Name == _productName.ToString())).SingleOrDefault();

                if (item == null) item = new OrderItem();
                item.Quantity = int.Parse(curRow.Cells["OrderQuantity"].Value.ToString());
                item.Price = int.Parse(curRow.Cells["OrderPrice"].Value.ToString());
                new Winform_MeasurementAdd(_productName.ToString(), this._cust.Name, item).ShowDialog();
            }
        }

        private void dgvOrderItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Order item - select/ add item if not present.

            if (dgvOrderItems.CurrentCell == dgvOrderItems.CurrentRow.Cells["OrderType"])
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                    cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                    cb.Validating += new System.ComponentModel.CancelEventHandler(cbo_Validating);
                    //cb.Validated += new System.EventHandler(cbo_Validated);
                }
            }
        }

        private void dgvOrderItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrderItems.CurrentCell == dgvOrderItems.CurrentRow.Cells["OrderType"])
            {
                //todo: 
                //get values from db and 
                //load the orderList with order items

                //OrderItem orderItem = OrderBuilder.GetOrderItem(_cust.ID, dgvOrderItems.CurrentCell.Value.ToString());

                ////todo: check if orderitem has measurement
                //OrderItemsList[dgvOrderItems.CurrentCell.RowIndex] = orderItem;
            }
            else if (e.ColumnIndex == dgvOrderItems.Columns["OrderQuantity"].Index || e.ColumnIndex == dgvOrderItems.Columns["OrderPrice"].Index)
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
                int total = 0;
                foreach (DataGridViewRow dr in dgvOrderItems.Rows)
                {
                    if (dr.IsNewRow || dr.Cells["OrderPrice"].Value == null || dr.Cells["OrderQuantity"].Value == null) continue;

                    total += (int.Parse(dr.Cells["OrderQuantity"].Value.ToString()) * int.Parse(dr.Cells["OrderPrice"].Value.ToString()));
                }

                int amntPaid = 0;
                txtTotAmnt.Text = total.ToString();
                int.TryParse(txtAmntPaid.Text, out amntPaid);
                txtBalanceAmnt.Text = (total - amntPaid).ToString();
                /*Calculate Total - end*/
            }
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            UpdateStatus("Saving..");
            string errorMsg = string.Empty;
            if (this._cust.ID == 0)
                errorMsg = "Add Customer, as it is mandatory for Order details.";
            else if (this.OrderItemsList == null || this.OrderItemsList.Count == 0)
                errorMsg = "Select items to cart to make the Order.";
            else if ((dtpDeliveryDate.Value.Date.CompareTo(DateTime.Today.Date)) < 0)
                errorMsg = "The Promised date must not be less than today.";
            else if (dgvOrderItems.Rows.Count - 1 != OrderItemsList.Count)
                errorMsg = "Measurement details for all Product is mandatory.";

            if (errorMsg != string.Empty)
            {
                MessageBox.Show(errorMsg, "Mandatory Info Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateStatus("Saving..", 25);
            int total, amntPaid;
            int.TryParse(txtTotAmnt.Text, out total);
            int.TryParse(txtAmntPaid.Text, out amntPaid);

            //order = new Orders(this._cust, dtpDeliveryDate.Value, OrderItemsList, total, amntPaid);

            order.Customer = this._cust;
            order.PromisedDate = dtpDeliveryDate.Value;
            order.OrdersItems = OrderItemsList;
            order.TotalPrice = total;
            order.CurrentPayment = amntPaid;

            UpdateStatus("Saving..", 50);
            bool success = SpindleSoft.Savers.OrderSaver.SaveOrder(order);

            UpdateStatus("Saving..", 100);
            if (success)
            {
                //Send msg if the balance == 0
                if (total - amntPaid == 0)
                {
                    MessageBox.Show("Thanks for choosing our Product. We lend free alternations within fours days from date of Delivery.");

                }
                this.Close();
            }
            else
                UpdateStatus("Error in Saving Order.", 100);
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(grpBoxCustomer, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Order Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        #endregion Events

        #region _Validations
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

        //private void txtAmntPaid_Validated(object sender, EventArgs e)
        //{
        //    int AmntPaid, TotAmnt;
        //    int.TryParse(txtAmntPaid.Text, out AmntPaid);
        //    int.TryParse(txtTotAmnt.Text, out TotAmnt);

        //    if (AmntPaid > TotAmnt)
        //    {
        //        // Cancel the event and select the text to be corrected by the user.
        //        e. = true;
        //        txtAmntPaid.Select(0, txtAmntPaid.TextLength);
        //        errorProvider1.SetError(txtAmntPaid, "Amount Paid cannot be greater than Total Amount");
        //    }
        //    else
        //    {
        //        txtBalanceAmnt.Text = (TotAmnt - AmntPaid).ToString();
        //    }
        //    txtBalanceAmnt.Text = (Convert.ToInt32(txtTotAmnt.Text) - Convert.ToInt32(txtAmntPaid.Text)).ToString();
        //}

        void cbo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var currCell = (DataGridViewComboBoxCell)dgvOrderItems.CurrentCell;

            var value = (sender as ComboBox).Text;
            if (string.IsNullOrEmpty(value)) return;

            //if Product already selected inform to update.
            foreach (DataGridViewRow rows in dgvOrderItems.Rows)
            {
                if (rows != dgvOrderItems.CurrentRow && !rows.IsNewRow
                    && rows.Cells["OrderType"].Value.ToString() == value)
                {
                    MessageBox.Show("Product Selected Already exists in the Cart!", "Duplicate Product", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    (sender as ComboBox).Text = String.Empty;
                    e.Cancel = true;
                    return;
                }
            }

            if (this.OrderType.Items.IndexOf(value) == -1)
            {
                DataGridViewComboBoxCell cboCell = (DataGridViewComboBoxCell)dgvOrderItems.CurrentCell;

                this.OrderType.Items.Add(value);
                cboCell.Value = value;
            }
        }

        void cbo_Validated(object sender, System.EventArgs e)
        {
            //remove the selected item name from the to item list 
            //to restrict the selection of the item again

            //if (dgvOrderItems.CurrentCell.Value == null) return;

            //var value = dgvOrderItems.CurrentCell.Value.ToString();
            //if (this.OrderType.Items.IndexOf(value) != -1)
            //    this.OrderType.Items.Remove(value);

            ////Based on the datagrid rowindex insert the values into the OrderItem List
            ////1: Append/ create a orderitem if not already present in orderItemList
            //OrderItemsList.Add(new OrderItem());

            //OrderItem orderItem = OrderBuilder.GetOrderItem(_cust.ID, dgvOrderItems.CurrentCell.Value.ToString());
            ////orderItem.OrderID = _order.ID;

            ////todo: check if orderitem has measurement
            //OrderItemsList[dgvOrderItems.CurrentCell.RowIndex] = orderItem;


        }
        #endregion _Validations


    }
}