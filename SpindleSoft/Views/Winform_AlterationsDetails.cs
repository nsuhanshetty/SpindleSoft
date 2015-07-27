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
        ILog log = LogManager.GetLogger(typeof(Winform_AlterationsDetails));

        Alteration _alteration;
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
        }

        public Winform_AlterationsDetails(Alteration alt)
        {
            InitializeComponent();

            _alteration = alt;
            _altItemList = alt.AlterationItems.ToList<AlterationItem>();
        }
        #endregion ctor

        #region Validation
        private void dgvOrderItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvAlterationItems.Rows[e.RowIndex];

            if (row.Cells["AltType"].Value == null &&
                (row.Cells["AltPrice"].Value != null || row.Cells["AltQuantity"].Value != null || row.Cells["AltComment"].Value != null))
            {
                dgvAlterationItems.Rows.RemoveAt(e.RowIndex);
                return;
            }

            else if (e.ColumnIndex == dgvAlterationItems.Columns["AltPrice"].Index ||
                     e.ColumnIndex == dgvAlterationItems.Columns["AltQuantity"].Index)
            {
                /*price and Quantity must have a default value even if the user fails to add one
                 * And it also must be a number*/

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

                UpdateAlterationPrice();
            }

            //todo : Remove if the dgvValidation of row leave works fine.
            //else if (e.ColumnIndex == dgvAlterationItems.Columns["AltComment"].Index)
            //{
            //    //Check if unique for the product name i.e comment exists for the sam item name in different row
            //    DataGridViewCell cell = (sender as DataGridView).CurrentCell;
            //    bool itemAlreadyexists = IsAlterationItemUnique(dgvAlterationItems.Rows[e.RowIndex].Cells["AltType"].Value.ToString(), cell, e.RowIndex);

            //    if (itemAlreadyexists)
            //    {
            //        cell.ErrorText = "Duplicate Item Found!. No two product can have the same Comment";
            //        cell.Value = null;
            //        return;
            //    }
            //}
        }

        //private bool IsAlterationItemUnique(string itemName, string itemComment, int rowIndex)
        //{
        //    bool itemAlreadyexists = false;

        //    if (_altItemList.Count != 0)
        //    {
        //        var _altitem = _altItemList.Where(x => (x.Comment == itemComment && x.Name == itemName)).SingleOrDefault();
        //        if (_altitem != null && this.AltType.Items.IndexOf(_altitem) != rowIndex)
        //        {
        //            //if item exists and if its not the current row
        //            itemAlreadyexists = true;
        //        }
        //    }
        //    return itemAlreadyexists;
        //}

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

        /// <summary>
        /// update GridView based on entered OrderID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderID_Validated(object sender, EventArgs e)
        {
            int _orderID;
            int.TryParse(txtOrderID.Text, out _orderID);
            UpdateStatus("Fetching Order Items..");

            orderItemList = AlterationBuilder.GetOrderItems(_orderID, this._cust.ID);

            if (orderItemList == null || orderItemList.Count == 0)
            { UpdateStatus("No Order Items exists for entered Order ID.."); return; }

            UpdateStatus("Updating Grid View..");
            dgvSearch.DataSource = (from oitem in orderItemList
                                    select new { ProductName = oitem.Name, DeliveryDate = oitem.Order.PromisedDate, oitem.Comment, oitem.Quantity, oitem.Price }).ToList();

            if (this._cust.ID == 0)
            {
                UpdateStatus("Updating Customer Details");
                this._cust = Builders.PeoplePracticeBuilder.GetCustomer(orderItemList[0].Order.Customer.ID);
                UpdateCustomerControl(this._cust);
            }
            UpdateStatus();
        }

        private void UpdateAlterationPrice()
        {
            int total = 0, quantity, price;

            foreach (DataGridViewRow dr in dgvAlterationItems.Rows)
            {
                if (dr.IsNewRow) continue;
                quantity = 1;
                price = 0;

                if (dr.Cells["AltPrice"].Value == null)
                    dr.Cells["AltPrice"].Value = 0;
                else
                    int.TryParse(dr.Cells["AltPrice"].Value.ToString(), out price);

                if (dr.Cells["AltQuantity"].Value == null)
                    dr.Cells["AltQuantity"].Value = 1;
                else
                    int.TryParse(dr.Cells["AltQuantity"].Value.ToString(), out quantity);

                total += quantity * price;
            }

            int amntPaid = 0;
            int.TryParse(txtAmntPaid.Text, out amntPaid);

            TotalAmount = total;
            AmountPaid = amntPaid;

            //txtTotAmnt.Text = total.ToString();
            //txtBalanceAmnt.Text = (total - amntPaid).ToString();
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
            string errorMsg = string.Empty;
            if (this._cust.ID == 0)
                errorMsg = "Add Customer, as it is mandatory for Order details.";
            else if (dgvAlterationItems.RowCount == 0 || dgvAlterationItems.Rows[0].IsNewRow)
                errorMsg = "Add items to cart to make the Alterations.";
            else if (dtpDueDate.Value.Date.CompareTo(DateTime.Today.Date) < 0)
                errorMsg = "The Promised date must not be less than today.";

            if (errorMsg != string.Empty)
            {
                MessageBox.Show(errorMsg, "Mandatory Info Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //add alt items to list
            string comment;
            int price, quant;


            foreach (DataGridViewRow row in dgvAlterationItems.Rows)
            {
                if (row.IsNewRow) continue;

                //todo: Not sure price and quant in dgv would ever be null
                price = 0;
                int.TryParse(row.Cells["AltPrice"].Value.ToString(), out price);

                quant = 0;
                int.TryParse(row.Cells["AltQuantity"].Value.ToString(), out quant);

                comment = string.Empty;
                comment = row.Cells["AltComment"].Value == null ? "" : row.Cells["AltComment"].Value.ToString();

                //altItemList.Add(new AlterationItem(row.Cells["AltType"].Value.ToString(), quant, price, comment));
            }

            int total, amntPaid;
            int.TryParse(txtTotAmnt.Text, out total);
            int.TryParse(txtAmntPaid.Text, out amntPaid);

            _alteration.Customer = this._cust;
            _alteration.PromisedDate = dtpDueDate.Value;
            _alteration.AlterationItems = _altItemList;
            _alteration.CurrentPayment = amntPaid;
            _alteration.TotalPrice = total;

            bool success = AlterationSaver.SaveAlterationInfo(_alteration);

            if (success)
            {
                //Send msg if the balance == 0
                //if (total - amntPaid == 0)
                //{
                //    MessageBox.Show("Thanks for choosing our Product. We lend free alternations within fours days from date of Delivery.");
                //}

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
            if (dgvAlterationItems.Rows.Count < 2 || dgvAlterationItems.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("Continue deleting selected Alteration items?", "Delete Alteration Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;

            bool success = false;
            foreach (DataGridViewRow item in dgvAlterationItems.SelectedRows)
            {
                if (_altItemList.Count != 0 && item.Index+1 <= _altItemList.Count )
                {
                    if ( _altItemList[item.Index].ID != 0)
                    success = AlterationSaver.DeleteAlterationItems(_altItemList[item.Index].ID);

                    if (success)
                    {
                        _altItemList.RemoveAt(item.Index);
                    }
                    else
                    {
                        MessageBox.Show("Could not delete the Item. Soemthing Nasty happened!!");
                        return;
                    }
                }
                dgvAlterationItems.Rows.RemoveAt(item.Index);
            }
            UpdateAlterationPrice();
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value == null) return;

            //foreach (DataGridViewRow row in dgvAlterationItems.Rows)
            //{
            //    //if item already added
            //    if (row.IsNewRow == false)
            //    {
            //        return;
            //    }
            //}

            if (this._cust.ID == 0)
                UpdateCustomerControl(this._cust);

            var itemVal = (from oitem in orderItemList
                           where oitem.Name == dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value.ToString()
                           select oitem);

            //altItemList.Add(itemVal.SingleOrDefault());

            var rowVal = (from oitem in itemVal
                          select new { oitem.Name, oitem.Quantity, OrderID = oitem.Order.ID, oitem.Order }).ToArray();

            // altItemList.Add(new AlterationItem(rowVal[0].Name, rowVal[0].Quantity, rowVal[0].Order));

            var newRowIndex = dgvAlterationItems.NewRowIndex;
            dgvAlterationItems.Rows[newRowIndex].Cells["AltType"].Value = rowVal[0].Name;
            dgvAlterationItems.Rows[newRowIndex].Cells["AltQuantity"].Value = rowVal[0].Quantity;
            dgvAlterationItems.CurrentCell = dgvAlterationItems.Rows[newRowIndex].Cells["AltQuantity"];
            dgvAlterationItems.NotifyCurrentCellDirty(true);
            dgvAlterationItems.NotifyCurrentCellDirty(false);

            UpdateAlterationPrice();
        }

        private void dgvAlterationItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgvAlterationItems.CurrentCell == dgvAlterationItems.CurrentRow.Cells["AltType"])
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void Winform_AlterationsDetails_Load(object sender, System.EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);

            try
            {
                List<string> orderTypeList = OrderBuilder.GetListOfClothingTypes();
                this.AltType.Items.AddRange(orderTypeList.ToArray());

                UpdateCustomerControl(PeoplePracticeBuilder.GetCustomer(_alteration.Customer.ID));

                TotalAmount = _alteration.TotalPrice;
                AmountPaid = _alteration.CurrentPayment;
                dtpDueDate.Value = _alteration.PromisedDate;

                if (_altItemList != null && _altItemList.Count != 0)
                {
                    foreach (var item in _altItemList)
                    {
                        int index = dgvAlterationItems.NewRowIndex;
                        dgvAlterationItems.Rows[index].Cells["AltType"].Value = item.Name;
                        dgvAlterationItems.Rows[index].Cells["AltQuantity"].Value = item.Quantity;
                        dgvAlterationItems.Rows[index].Cells["AltPrice"].Value = item.Price;
                        dgvAlterationItems.Rows[index].Cells["AltComment"].Value = item.Comment;
                        dgvAlterationItems.CurrentCell = dgvAlterationItems.Rows[index].Cells["AltComment"];
                        dgvAlterationItems.NotifyCurrentCellDirty(true);
                        dgvAlterationItems.NotifyCurrentCellDirty(false);
                    }
                }

                //DataTable _dataTable = null;
                //dgvAlterationItems.AutoGenerateColumns = false;
                //_dataTable = ToDataTable((from al in _altItemList
                //                          select new { Name = al.Name, Comment = al.Comment, Price = al.Price, Quantity = al.Quantity })
                //                                .ToList());
                //foreach (DataColumn col in _dataTable.Columns)
                //{
                //    col.ReadOnly = false;
                //}

                //dgvAlterationItems.DataSource = _dataTable;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        void cbo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

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
            pcbMemImage.Image = _cust.Image;

            //todo: add this as event listner onCustomerControlUpdation
            txtOrderID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtOrderID.AutoCompleteCustomSource.AddRange(AlterationBuilder.GetOrderIDs(_cust.ID).ToArray());
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

        /// <summary>
        /// create/update/report list once the row has changed based on the uniqueness of the row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAlterationItems_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvAlterationItems.Rows[e.RowIndex].IsNewRow) return;

            /*Rule1: Comment is Mandatory*/
            DataGridViewRow dgvRow = (sender as DataGridView).Rows[e.RowIndex];
            DataGridViewCell cellComment = dgvRow.Cells["AltComment"];
            cellComment.ErrorText = "";
            if (cellComment.Value == null)
            {
                cellComment.ErrorText = "Comment is Mandatory and Cannot be Empty";
                return;
            }

            /*Rule2: Every row must be unique whenitem name and comment is combined*/
            string itemName = dgvRow.Cells["AltType"].Value.ToString();
            AlterationItem _altitem;



            /*Rule3: Update if item already exists else create*/
            if (e.RowIndex + 1 <= _altItemList.Count)
            {
                //update item and itemlist by reference
                _altitem = _altItemList[e.RowIndex];
                _altitem.Name = itemName;
                _altitem.Price = int.Parse(dgvRow.Cells["AltPrice"].Value.ToString());
                _altitem.Quantity = int.Parse(dgvRow.Cells["AltQuantity"].Value.ToString());
                _altitem.Comment = cellComment.Value.ToString();
            }
            else
            {
                if (_altItemList.Count != 0)
                {
                    //if another item of the name already exist => report
                    _altitem = _altItemList.Where(x => (x.Comment == cellComment.Value.ToString() &&
                                                            x.Name == itemName)).SingleOrDefault();

                    if (_altitem != null && this.AltType.Items.IndexOf(_altitem) != e.RowIndex) //if item exists
                    {
                        //And if its not the current row
                        cellComment.ErrorText = "Duplicate Item Found!." + Environment.NewLine +
                                         " Two products of the same Name cannot have the same Comment.";
                        cellComment.Value = null;
                        return;
                    }
                }

                //create
                _altItemList.Add(new AlterationItem(itemName, int.Parse(dgvRow.Cells["AltQuantity"].Value.ToString()),
                                                    int.Parse(dgvRow.Cells["AltPrice"].Value.ToString()), cellComment.Value.ToString()));
            }
        }

    }
}