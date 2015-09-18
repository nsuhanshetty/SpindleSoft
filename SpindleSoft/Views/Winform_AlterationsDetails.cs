using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using log4net;
using System.Data;
using System.Reflection;
using SpindleSoft.Savers;

namespace SpindleSoft.Views
{
    public partial class Winform_AlterationsDetails : Winform_DetailsFormat
    {
        //todo: Centralize log functionality
        static ILog log = LogManager.GetLogger(typeof(Winform_AlterationsDetails));

        Alteration _alteration = new Alteration();
        Customer _cust = new Customer();
        List<OrderItem> orderItemList = new List<OrderItem>();
        List<AlterationItem> _altItemList = new List<AlterationItem>();

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
                txtAmntPaid.Text = amntPaid.ToString();
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
        public Winform_AlterationsDetails()
        {
            InitializeComponent();

            cmbStatus.SelectedIndex = 0;
            cmbStatus.Enabled = false;
            this.dtpDueDate.MinDate = System.DateTime.Today;
        }

        public Winform_AlterationsDetails(Alteration alt)
        {
            InitializeComponent();

            _alteration = alt;
            _altItemList = alt.AlterationItems.ToList<AlterationItem>();

            if (_altItemList != null && _altItemList.Count != 0)
            {
                foreach (var item in _altItemList)
                {
                    int index = dgvAlterationItems.Rows.Add();
                    dgvAlterationItems.Rows[index].Cells["AltType"].Value = item.Name;
                    dgvAlterationItems.Rows[index].Cells["AltQuantity"].Value = item.Quantity;
                    dgvAlterationItems.Rows[index].Cells["AltPrice"].Value = item.Price;
                    dgvAlterationItems.Rows[index].Cells["AltComment"].Value = item.Comment;
                    dgvAlterationItems.CurrentCell = dgvAlterationItems.Rows[index].Cells["AltComment"];
                    //dgvAlterationItems.NotifyCurrentCellDirty(true);
                    //dgvAlterationItems.NotifyCurrentCellDirty(false);
                }
            }
        }
        #endregion ctor

        #region Validation

        private void txtAmntPaid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int AmntPaid, TotAmnt;
            int.TryParse(txtAmntPaid.Text, out AmntPaid);
            int.TryParse(txtTotAmnt.Text, out TotAmnt);

            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            if (_errorMsg == "" && 0 < AmntPaid && AmntPaid > TotAmnt)
            {
                _errorMsg = "Amount Paid cannot be greater than the Total Amount Or less than 0";
            }

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                errorProvider1.SetError(txtAmntPaid, _errorMsg);
                e.Cancel = true;
                txtAmntPaid.Text = "";
            }
            else
            {
                txtBalanceAmnt.Text = (TotAmnt - AmntPaid).ToString();
                errorProvider1.SetError(txtAmntPaid, _errorMsg);
            }
        }

        private void txtOrderID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var txtBox = (ComboBox)sender;
            if (txtBox.Text == String.Empty)
                return;

            Match _match = Regex.Match(txtBox.Text, "\\d$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Order ID" + Environment.NewLine +
                                                    " For example '10'";
            errorProvider1.SetError(txtBox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtBox.Select(0, txtBox.Text.Length);
            }
        }

        /// <summary>
        /// update GridView based on entered OrderID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderID_Validated(object sender, EventArgs e)
        {
            int _orderID;
            var txtBox = (ComboBox)sender;
            int.TryParse(txtBox.Text, out _orderID);
            UpdateStatus("Fetching Order Items..");

            orderItemList = AlterationBuilder.GetOrderItems(_orderID, this._cust.ID);

            if (orderItemList == null || orderItemList.Count == 0)
            {
                UpdateStatus("No Order Items exists for entered Order ID..");
                dgvSearch.DataSource = null;
                UpdateCustomerControl(null);
                return;
            }

            UpdateStatus("Updating Grid View..");
            dgvSearch.DataSource = (from oitem in orderItemList
                                    select new { ID = oitem.ID, ProductName = oitem.Name, DeliveryDate = oitem.Order.PromisedDate, oitem.Comment, oitem.Quantity, oitem.Price }).ToList();

            dgvSearch.Columns["ID"].Visible = false;

            if (this._cust.ID == 0)
            {
                UpdateStatus("Updating Customer Details");
                this._cust = Builders.PeoplePracticeBuilder.GetCustomer(orderItemList[0].Order.Customer.ID);
                UpdateCustomerControl(this._cust);
            }
            UpdateStatus();
        }
        #endregion Validation

        #region Events
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

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            #region validation
            string errorMsg = string.Empty;

            if (this._cust.ID == 0)
                errorMsg = "Add Customer, as it is mandatory for Order details.";
            else if (dgvAlterationItems.RowCount == 0 || dgvAlterationItems.Rows[0].IsNewRow)
                errorMsg = "Add items to cart to make the Alterations.";
            else if (dtpDueDate.Value.Date.CompareTo(DateTime.Today.Date) < 0)
                errorMsg = "The Promised date must not be less than today.";

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg, "Error In Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion validation

            int total, amntPaid;
            int.TryParse(txtTotAmnt.Text, out total);
            int.TryParse(txtAmntPaid.Text, out amntPaid);

            _alteration.Customer = this._cust;
            _alteration.PromisedDate = dtpDueDate.Value;
            _alteration.AlterationItems = _altItemList;
            _alteration.CurrentPayment = amntPaid;
            _alteration.TotalPrice = total;
            _alteration.Status = cmbStatus.SelectedIndex;

            bool success = AlterationSaver.SaveAlterationInfo(_alteration);

            if (success)
            {
                DialogResult dr = MessageBox.Show("Do you want Send SMS to notify the Customer.", "Send SMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //todo: Replace with SMS funtion.
                    MessageBox.Show("Thanks for choosing our Product. We lend free alternations within fours days from date of Delivery.");
                }
                this.Close();
            }
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //todo: Test

        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value == null) return;

            if (this._cust.ID == 0)
                UpdateCustomerControl(this._cust);

            var itemVal = (from oitem in orderItemList
                           where oitem.ID == int.Parse(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString())
                           select oitem);

            var rowVal = (from oitem in itemVal
                          select new { oitem.Name, oitem.Quantity, OrderID = oitem.Order.ID, oitem.Order }).ToArray();

            AlterationItem _item = new AlterationItem(rowVal[0].Name, rowVal[0].Quantity, 0, "");
            UpdateAlterationListControl(_item, dgvAlterationItems.Rows.Count);
        }

        private void dgvAlterationItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //try
            //{
            //    if (dgvAlterationItems.CurrentCell == dgvAlterationItems.CurrentRow.Cells["AltType"])
            //    {
            //        ComboBox cb = e.Control as ComboBox;
            //        if (cb != null)
            //        {
            //            cb.DropDownStyle = ComboBoxStyle.DropDown;
            //            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //            cb.Validating += new System.ComponentModel.CancelEventHandler(cbo_Validating);
            //            //cb.Validated += new System.EventHandler(cbo_Validated);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}
        }

        private void Winform_AlterationsDetails_Load(object sender, System.EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);

            try
            {
                UpdateCustomerControl(PeoplePracticeBuilder.GetCustomer(_alteration.Customer.ID));

                TotalAmount = _alteration.TotalPrice;
                AmountPaid = _alteration.CurrentPayment;
                dtpDueDate.Value = _alteration.PromisedDate;
                cmbStatus.SelectedIndex = _alteration.Status;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        void cbo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var value = (sender as ComboBox).Text;
            //if (string.IsNullOrEmpty(value)) return;

            //if (this.AltType.Items.IndexOf(value) == -1)
            //{
            //    DataGridViewComboBoxCell cboCell = (DataGridViewComboBoxCell)dgvAlterationItems.CurrentCell;

            //    this.AltType.Items.Add(value);
            //    cboCell.Value = value;
            //}
        }
        #endregion Events

        public void UpdateCustomerControl(Customer customer)
        {
            //todo: Move to abstract Transaction Class (parent of Sale, Alteration and Order classes)
            if (customer == null) return;

            this._cust = customer;
            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;
            pcbCustImage.Image = this._cust.Image = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomerImage(_cust.ID);

            ////todo: add this as event listner onCustomerControlUpdation
            cmbOrder.DataSource = AlterationBuilder.GetOrderIDs(_cust.ID).ToArray();
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

        private bool IsItemDuplicate(DataGridViewCellEventArgs e, DataGridViewRow row)
        {
            if (_altItemList.Count == 0) return false;

            string itemName = row.Cells["AltType"].Value != null ? row.Cells["AltType"].Value.ToString() : "";
            string comment = row.Cells["AltComment"].Value != null ? row.Cells["AltComment"].Value.ToString() : "";

            bool exists = _altItemList.Exists(item => (item.Comment == comment && item.Name == itemName &&
                                                       _altItemList.IndexOf(item) != -1 && _altItemList.IndexOf(item) != e.RowIndex));
            return exists;
        }

        private void CalculatePaymentDetails()
        {
            //todo : Method to handle payment amount
            /*Calculate Total*/
            int total = 0;
            foreach (DataGridViewRow dr in dgvAlterationItems.Rows)
            {
                if (dr.IsNewRow) continue;

                if (dr.Cells["AltPrice"].Value == null) dr.Cells["AltPrice"].Value = 0;
                if (dr.Cells["AltQuantity"].Value == null) dr.Cells["AltQuantity"].Value = 1;

                total += (int.Parse(dr.Cells["AltQuantity"].Value.ToString()) * int.Parse(dr.Cells["AltPrice"].Value.ToString()));
            }

            int amntPaid = 0;
            int.TryParse(txtAmntPaid.Text, out amntPaid);
            AmountPaid = amntPaid;
            TotalAmount = total;
            BalanceAmount = TotalAmount - AmountPaid;
            /*Calculate Total - end*/
        }

        private void dgvAlterationItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvAlterationItems.Rows[e.RowIndex].IsNewRow == true) return;

            if (dgvAlterationItems.Columns["colDelete"].Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Continue deleting selected Alteration items?", "Delete Alteration Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = false;

                if (_altItemList.Count != 0 && e.RowIndex + 1 <= _altItemList.Count)
                {
                    if (_altItemList[e.RowIndex].ID != 0)
                        success = AlterationSaver.DeleteAlterationItems(_altItemList[e.RowIndex].ID);

                    if (success || _altItemList[e.RowIndex].ID == 0)
                    {
                        _altItemList.RemoveAt(e.RowIndex);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                        return;
                    }
                }
                dgvAlterationItems.Rows.RemoveAt(e.RowIndex);
                CalculatePaymentDetails();
            }
            else
            {
                new Winform_AlterationItemDetails(e.RowIndex, _altItemList[e.RowIndex]).ShowDialog();
            }
        }

        private void dgvAlterationItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log.Error(e.Exception);
            var test = dgvAlterationItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new Winform_AlterationItemDetails(dgvAlterationItems.Rows.Count, null).ShowDialog();
        }

        public void UpdateAlterationListControl(AlterationItem _item, int _index)
        {
            if (_altItemList.Count == 0 || _altItemList.Count < _index + 1)
            {
                _altItemList.Add(_item);
                dgvAlterationItems.Rows.Add();
            }
            else
                _altItemList[_index] = _item;

            dgvAlterationItems.Rows[_index].Cells["AltType"].Value = _item.Name;
            dgvAlterationItems.Rows[_index].Cells["AltPrice"].Value = _item.Price;
            dgvAlterationItems.Rows[_index].Cells["AltQuantity"].Value = _item.Quantity;
            dgvAlterationItems.Rows[_index].Cells["AltComment"].Value = _item.Comment;

            CalculatePaymentDetails();
        }

        private void cmbOrder_TextChanged(object sender, EventArgs e)
        {
            txtOrderID_Validating(cmbOrder, new System.ComponentModel.CancelEventArgs());
            txtOrderID_Validated(cmbOrder, e);
        }

        private void txtAmntPaid_TextChanged(object sender, EventArgs e)
        {
            txtAmntPaid_Validating(txtAmntPaid, new System.ComponentModel.CancelEventArgs());
        }

        private void Winform_AlterationsDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main main = Application.OpenForms["Main"] as Main;
            if (main != null)
                main.UpdateAlterationReadyDgv();
        }
    }
}