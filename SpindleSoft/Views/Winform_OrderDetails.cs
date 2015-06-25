using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        Orders _order = new Orders();
        string[] orderTypeName;
        List<OrderItem> OrderItemsList = new List<OrderItem>();

        public Winform_OrderDetails()
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
            pcbCustImage.Image = _cust.Image;
        }

        #region Events

        private void Winform_OrderAdd_Load(object sender, EventArgs e)
        {
            //todo : Unique Orderno from the Db 
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);
            this.toolStripParent.Items.Add(this.NewOrderTypeToolStrip);

            try
            {
                List<OrderItem> orderTypeList = OrderBuilder.GetOrderTypeList();

                orderTypeName = orderTypeList.Select(x => x.Name).Distinct().ToArray<string>();
                this.OrderType.Items.AddRange(orderTypeName);

            }
            catch (Exception)
            {
                //log4 net
            }
            //dgvOrderItems.Columns["OrderType"].
            //item type - quatity - price - edit 1measurements - add design.

            // To avoid all the annoying error messages, handle the DataError event of the DataGridView:
            //dgvOrderItems.DataError += new DataGridViewDataErrorEventHandler(DataGridView1_DataError);
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
        }

        private void NewOrderTypeToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_OrderType().ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //item type - quatity - price - edit measurements - add design
            if (e.ColumnIndex == dgvOrderItems.Columns["OrderMeasurement"].Index)
            {
                OrderItem _orderItem = new OrderItem(dgvOrderItems.Rows["Name"].Cells[e.ColumnIndex].Value.ToString());
               new Winform_MeasurementAdd(_orderItem, e.RowIndex).ShowDialog();
            }

        }

        private void updateOrderItemList(OrderItem _item, int rIndex)
        {
            if (OrderItemsList.Count == 0)
                OrderItemsList.Add(_item);
            else
                OrderItemsList[rIndex] = _item;
        }

        private void btnMeasurement_Click(object sender, EventArgs e)
        {
            new Winform_MeasurementAdd().ShowDialog();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            //customerId, 
            _order.Customer = this._cust;

           // _order.ID = Convert.ToInt32(txtOrderNo.Text);
            _order.PromisedDate = dtpDeliveryDate.Value;

            _order.TotalPrice = Convert.ToInt32(txtTotAmnt.Text);
            _order.CurrentPayment = Convert.ToInt32(txtAmntPaid.Text);
        }

        private void txtAmntPaid_Validated(object sender, EventArgs e)
        {
            txtBalanceAmnt.Text = (Convert.ToInt32(txtTotAmnt.Text) - Convert.ToInt32(txtAmntPaid.Text)).ToString();
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
                    cb.Validated += new System.EventHandler(cbo_Validated);
                }
            }
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
            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            errorProvider1.SetError(txtAmntPaid, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtAmntPaid.Select(0, txtAmntPaid.TextLength);
            }
        }

        void cbo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var value = (sender as ComboBox).Text;
            if (this.OrderType.Items.IndexOf(value) == -1)
            {
                DataGridViewComboBoxCell cboCol = (DataGridViewComboBoxCell)dgvOrderItems.CurrentCell;

                this.OrderType.Items.Add(value);
                dgvOrderItems.CurrentCell.Value = value;
            }
        }

        void cbo_Validated(object sender, System.EventArgs e)
        {
            //Based on the datagrid rowindex insert the values into the OrderItem List
            OrderItem orderItem = OrderBuilder.GetOrderItem(_cust.ID, dgvOrderItems.CurrentCell.Value.ToString());
            //orderItem.OrderID = _order.ID;

            //todo: check if orderitem has measurement
            OrderItemsList[dgvOrderItems.CurrentCell.RowIndex] = orderItem;
        }
        #endregion _Validations

    }
}