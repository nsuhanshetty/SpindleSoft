﻿using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using log4net;
using SpindleSoft.Savers;
using System.Threading.Tasks;
using System.Configuration;
using SpindleSoft.Utilities;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderDetails : Winform_DetailsFormat
    {
        ILog log = LogManager.GetLogger(typeof(Winform_OrderDetails));
        Orders order = new Orders();
        Customer _cust = new Customer();
        List<OrderItem> OrderItemsList = new List<OrderItem>();
        private enum OrderStatus { ReadyToStitch, ReadyToCollect, Delivered };

        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        static string CustomerImagePath = Secrets.FileLocation["CustomerImages"];

        #region Property
        private int amntPaid = 0;
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

        private int balAmnt = 0;
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

        private int totalAmnt = 0;
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
        public Winform_OrderDetails()
        {
            InitializeComponent();
            cmbStatus.SelectedIndex = 0;
            cmbStatus.Enabled = false;
            this.dtpDeliveryDate.MinDate = System.DateTime.Today;

            InEdit = true;
        }

        public Winform_OrderDetails(Orders order, bool _inEdit = false)
        {
            this.order = order;
            this.InEdit = _inEdit;

            InitializeComponent();
            if (!InEdit)
            {
                var exList = new List<string>() { "dgvOrderItems", "groupBox2", "toolStripParent", "EditToolStrip" };
                WinFormControls_InEdit(this, exList);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }
        #endregion ctor

        #region Custom
        public void UpdateCustomerControl(Customer customer)
        {
            if (customer == null) return;

            this._cust = customer;
            this.order.Customer = customer;
            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;
            string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, _cust.ID);
            pcbCustImage.Image = this._cust.Image = Utilities.ImageHelper.GetDocumentLocal(filePath);


        }

        internal void UpdateOrderItemList(OrderItem _item, int _index)
        {
            if (OrderItemsList.Count == 0 || OrderItemsList.Count < _index + 1)
            {
                OrderItemsList.Add(_item);
                dgvOrderItems.Rows.Add();
            }
            else
                OrderItemsList[_index] = _item;

            dgvOrderItems.Rows[_index].Cells["OrderType"].Value = _item.Name;
            dgvOrderItems.Rows[_index].Cells["OrderPrice"].Value = _item.Price;
            dgvOrderItems.Rows[_index].Cells["OrderQuantity"].Value = _item.Quantity;

            CalculateTotalPaymentDetails();
        }
        #endregion Custom

        #region Events

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

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            UpdateStatus("Saving..");
            ProcessTabKey(true);

            string errorMsg = string.Empty;
            if (this._cust.ID == 0)
                errorMsg = "Add Customer, as it is mandatory for Order details.";
            else if (this.OrderItemsList == null || this.OrderItemsList.Count == 0)
                errorMsg = "Select items to cart to make the Order.";
            else if ((dtpDeliveryDate.Value.Date.CompareTo(DateTime.Today.Date)) < 0)
                errorMsg = "The Promised date must not be earlier than today.";

            if (errorMsg != string.Empty)
            {
                MessageBox.Show(errorMsg, "Mandatory Info Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateStatus("Saving..", 25);
            order.Customer = this._cust;
            order.PromisedDate = dtpDeliveryDate.Value;
            order.OrdersItems = OrderItemsList;
            order.TotalPrice = TotalAmount;
            order.CurrentPayment = AmountPaid;
            order.Status = cmbStatus.SelectedIndex;

            UpdateStatus("Saving..", 50);
            bool success = OrderSaver.SaveOrder(order);
            if (success)
            {
                UpdateStatus("Order Saved.", 100);
                if (order.Status == 0 || order.Status == 2 || order.Status == 3)
                {
                    DialogResult dr = MessageBox.Show("Send SMS to customer regarding the order", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string _orderMessage = string.Empty;
                        if (order.Status == 0)
                            _orderMessage = "Your order #" + order.ID + " of amount " + order.TotalPrice + " has been placed with delivery date on " + order.PromisedDate.Date.ToString("dd/MMMM/yyyy") + ". Thanks for choosing Dee. Stay Beautiful.";
                        else
                            if (order.Status == 2)
                                _orderMessage = "Your order #" + order.ID + " is ready to be Collected. Thanks for choosing Dee. Stay Beautiful. Pending Amount " + (order.TotalPrice - order.CurrentPayment).ToString() + ".";
                            else if (order.Status == 3)
                                _orderMessage = "Your order #" + order.ID + " has been delivered. We provide alteration within 4 days of delivery. Thanks for choosing Dee. Stay Beautiful.";
                        SMSGateway.SendSMS(_orderMessage, order.Customer, SMSLog.SectionType.Order);
                    }
                }
                this.Close();
            }
            else
                UpdateStatus("Error in Saving Order.", 100);
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
            GetExistingCredit();
        }

        private void GetExistingCredit()
        {
            //customer not added OR is an exisiting order
            if (this.order.ID != 0 || this._cust.ID == 0) return;

            //get customer credit amount
            var ordList = OrderBuilder.GetCustomerOrderCredit(this.order);
            foreach (var ord in ordList)
            {
                var dr = MessageBox.Show("An Earlier credit exists. Do you want to pay it now?", "Order Credit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //dr = MessageBox.Show("An Earlier credit exists with Order #" + ord.ID + ". Do you want to pay it now?", "Order Credit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                var ordTemp = OrderBuilder.GetOrderInfo(ord.ID);
                new Winform_OrderDetails(ordTemp).ShowDialog();
            }
        }

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

        private void CalculateTotalPaymentDetails()
        {
            int total = 0;
            foreach (DataGridViewRow dr in dgvOrderItems.Rows)
            {
                if (dr.IsNewRow || dr.Cells["OrderPrice"].Value == null || dr.Cells["OrderQuantity"].Value == null) continue;

                total += (int.Parse(dr.Cells["OrderQuantity"].Value.ToString()) * int.Parse(dr.Cells["OrderPrice"].Value.ToString()));
            }

            int amntPaid = 0;
            int.TryParse(txtAmntPaid.Text, out amntPaid);
            AmountPaid = amntPaid;
            TotalAmount = total;
            BalanceAmount = TotalAmount - AmountPaid;
        }

        private void Winform_OrderDetails_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);
            this.AddCustomerToolStrip.Alignment = ToolStripItemAlignment.Right;
            this.EditToolStrip.Visible = true;

            if (order.ID != 0)
            {
                this.OrderItemsList = this.order.OrdersItems as List<OrderItem>;
                dtpDeliveryDate.Value = order.PromisedDate;
                cmbStatus.SelectedIndex = order.Status;

                TotalAmount = order.TotalPrice;
                AmountPaid = order.CurrentPayment;

                _cust = PeoplePracticeBuilder.GetCustomer(order.Customer.ID);
                UpdateCustomerControl(_cust);
                GetExistingCredit();
            }

            if (OrderItemsList != null && OrderItemsList.Count != 0)
            {
                foreach (var item in OrderItemsList)
                {
                    dgvOrderItems.Rows.Add();
                    int index = dgvOrderItems.Rows.Count - 1;
                    dgvOrderItems.Rows[index].Cells["OrderType"].Value = item.Name;
                    dgvOrderItems.Rows[index].Cells["OrderQuantity"].Value = item.Quantity;
                    dgvOrderItems.Rows[index].Cells["OrderPrice"].Value = item.Price;
                }
            }

            if (!InEdit)
                OrderDelete.Visible = false;
        }

        private void dgvOrderItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == dgvOrderItems.Columns["OrderDelete"].Index && dgvOrderItems.Rows[e.RowIndex].IsNewRow != true)
            {
                DialogResult dr = MessageBox.Show("Continue deleting selected Order items?", "Delete Order Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = false;

                if (OrderItemsList.Count != 0 && e.RowIndex + 1 <= OrderItemsList.Count)
                {
                    if (OrderItemsList[e.RowIndex].ID != 0)
                        success = OrderSaver.DeleteOrderItems(OrderItemsList[e.RowIndex].ID);

                    if (success || OrderItemsList[e.RowIndex].ID == 0) // "ID == 0" => Not yet Added to the db 
                    {
                        OrderItemsList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                        return;
                    }
                }

                dgvOrderItems.Rows.RemoveAt(e.RowIndex);
                CalculateTotalPaymentDetails();
            }
            else if (e.ColumnIndex == dgvOrderItems.Columns["MeasurePrint"].Index && dgvOrderItems.Rows[e.RowIndex].IsNewRow != true)
            {
                if (OrderItemsList.Count != 0 && e.RowIndex + 1 <= OrderItemsList.Count)
                {
                    if (OrderItemsList[e.RowIndex].ID != 0)
                    {
                        MeasurementReport page = new MeasurementReport(OrderItemsList[e.RowIndex], this._cust);
                        String pageContent = page.TransformText();
                        System.IO.File.WriteAllText("MeasurementReport.html", pageContent);
                        System.Diagnostics.Process.Start("MeasurementReport.html");
                    }                    
                }               
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                OrderItem _item = OrderItemsList[e.RowIndex];
                new Winform_MeasurementAdd(e.RowIndex, this._cust, _item, InEdit).ShowDialog();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (this._cust.ID == 0)
            {
                MessageBox.Show("Add Customer, as it is mandatory to edit Measurement details.", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            new Winform_MeasurementAdd(dgvOrderItems.Rows.Count, this._cust, null, InEdit).ShowDialog();
        }

        private void txtAmntPaid_TextChanged(object sender, EventArgs e)
        {
            txtAmntPaid_Validating(txtAmntPaid, new System.ComponentModel.CancelEventArgs());
        }

        private void Winform_OrderDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main main = Application.OpenForms["Main"] as Main;
            if (main != null)
                main.UpdateOrderReadyDgv();
        }

        private void dgvOrderItems_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvOrderItems_CellClick(this, new DataGridViewCellEventArgs(dgvOrderItems.CurrentCell.ColumnIndex, dgvOrderItems.CurrentCell.RowIndex));
            }
        }
        #endregion Events

        #region _Validations
        private void txtAmntPaid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int amntPaid, totAmnt;
            int.TryParse(txtAmntPaid.Text, out amntPaid);
            int.TryParse(txtTotAmnt.Text, out totAmnt);

            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            if (_errorMsg == "" && 0 < amntPaid && amntPaid > totAmnt)
                _errorMsg = "Amount Paid cannot be greater than Total Amount Or less than zero";

            errorProvider1.SetError(txtAmntPaid, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtAmntPaid.Text = "";
                AmountPaid = 0;
                return;
            }
            else
            {
                AmountPaid = !string.IsNullOrEmpty(txtAmntPaid.Text) ? int.Parse(txtAmntPaid.Text) : 0;
            }
        }
        #endregion _Validations
    }
}