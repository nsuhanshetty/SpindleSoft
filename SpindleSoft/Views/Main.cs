using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft
{
    using log4net;
    using SpindleSoft.Builders;
    using SpindleSoft.Helpers;
    using SpindleSoft.Model;
    using SpindleSoft.Savers;
    using SpindleSoft.Views;
    using System.Collections;

    public partial class Main : Form
    {
        ILog log = LogManager.GetLogger(typeof(Main));
        private enum SearchStates { Order, Customer, Alteration, Sales }
        private SearchStates searchState { get; set; }

        #region SearchTxt
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Order No.");
            this.searchState = SearchStates.Order;

            RefreshDgvSearch();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Customer Mobile No.");
            this.searchState = SearchStates.Customer;

            RefreshDgvSearch();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Alteration No.");
            this.searchState = SearchStates.Alteration;

            RefreshDgvSearch();
        }

        private void rdbSales_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Sale No.");
            this.searchState = SearchStates.Sales;

            RefreshDgvSearch();
        }

        private void RefreshDgvSearch()
        {
            dgvSearch.DataSource = "";
            txtSearch.Text = string.Empty;
            lblSearchCount.Text = "0";
        }
        private void UpdateSearchText(string _updateText)
        {
            lblSearchText.Text = _updateText;
            txtSearch.Focus();
        }
        #endregion SearchTxt

        #region ctor
        public Main()
        {
            InitializeComponent();
            UpdateOrderReadyDgv();
            UpdateAlterationReadyDgv();
        }
        #endregion ctor

        #region Toolstrip_Click

        private void addAlterationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_AlterationsDetails().ShowDialog();
        }

        private void addCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SalesDetails().ShowDialog();
        }

        private void addCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new WinForm_CustomerDetails().ShowDialog();
        }

        private void addExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseDetails().ShowDialog();
        }

        private void addGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_GroupAdd().ShowDialog();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WinForm_SKUDetails().ShowDialog();
        }

        private void addOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_OrderDetails().ShowDialog();
            UpdateOrderReadyDgv();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_StaffDetails().ShowDialog();
        }

        private void addVendorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails().ShowDialog();
        }

        private void bulkSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void catalogueRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_CustomerRegister().ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Exit the Application", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void importCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //export excel Sheet/ google spreadsheet
            //
        }

        private void salaryRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //link salary to expense
        }

        private void SalesRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SalesRegister().ShowDialog();
        }

        private void searchAlterationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_AlterationRegister().ShowDialog();
            UpdateAlterationReadyDgv();
        }

        private void searchOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_OrderRegister().ShowDialog();
            UpdateOrderReadyDgv();
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SMSSend().ShowDialog();
        }

        private void staffRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_StaffRegister().ShowDialog();
            //todo : salary add advance
            //todo:  salary register must showen based on time interval (week, month, year)
        }

        private void stockCheckToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Winform_SKURegister().ShowDialog();
        }
        private void vendorRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_VendorsRegister().ShowDialog();
        }
        private void viewExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseRegister().ShowDialog();
        }
        private void viewSMSRegistryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SMSRegister().ShowDialog();
        }
        #endregion Toolstrip_Click

        #region Alteration
        private void dgvOrdR2S_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = ((DataGridView)sender);
                int _orderID = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                string message = string.Empty;
                int status = -1;

                if (e.ColumnIndex == dgv.Columns[2].Index ||
                    (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index))
                {
                    switch (dgv.Name)
                    {
                        case "dgvOrdR2S":
                            message = "Shift selected Order to Stitch In Progress";
                            status = 1;
                            break;
                        case "dgvOrdSIP":
                            message = "Shift selected Order to Ready To Stitch";
                            status = 0;
                            break;
                        case "dgvOrdR2C":
                            message = "Shift selected Order to Stitch In Progress";
                            status = 1;
                            break;
                        default:
                            break;
                    }

                    if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                    {
                        message = "Shift selected Order to Ready To Collect";
                        status = 2;
                    }
                    if (string.IsNullOrEmpty(message) || status == -1) return;

                    DialogResult dr = MessageBox.Show(message, "Shift Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    //update ord status in db

                    MainSaver.UpdateOrderStatus(_orderID, status);
                    UpdateOrderReadyDgv();
                }
                else
                {
                    new Winform_OrderDetails(OrderBuilder.GetOrderInfo(_orderID)).ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void dgvAltR2A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = ((DataGridView)sender);
                int _altID = int.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
                string message = string.Empty;
                int status = -1;

                if (e.ColumnIndex == dgv.Columns[2].Index ||
                    (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index))
                {
                    switch (dgv.Name)
                    {
                        case "dgvAltR2A":
                            message = "Shift selected Order to Alteration In Progress";
                            status = 1;
                            break;
                        case "dgvAltSIP":
                            message = "Shift selected Alteration to Ready To Alter";
                            status = 0;
                            break;
                        case "dgvAltR2C":
                            message = "Shift selected Alteration to Alteration In Progress";
                            status = 1;
                            break;
                        default:
                            break;
                    }

                    if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                    {
                        message = "Shift selected Alteration to Ready To Collect";
                        status = 2;
                    }
                    if (string.IsNullOrEmpty(message) || status == -1) return;

                    DialogResult dr = MessageBox.Show(message, "Shift Alteration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    //update ord status in db

                    MainSaver.UpdateAlterStatus(_altID, status);
                    UpdateAlterationReadyDgv();
                }
                else
                {
                    new Winform_AlterationsDetails(AlterationBuilder.GetAlteration(_altID)).ShowDialog();
                    UpdateAlterationReadyDgv();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        #endregion Order

        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //todo: Update Status based from the Child Controls load method
            if (rdbOrders.Checked)
            {
                new Winform_OrderDetails().ShowDialog();
            }
            else if (rdbCustomer.Checked)
            {
                new WinForm_CustomerDetails().ShowDialog();
            }
            else if (rdbAlteration.Checked)
            {
                new Winform_AlterationsDetails().ShowDialog();
                UpdateAlterationReadyDgv();
            }
            else if (rdbSales.Checked)
            {
                new Winform_SalesDetails().ShowDialog();
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(cmbSearch.Text))
            //    return;

            //Customer _cust = PeoplePracticeBuilder.GetCustomerInfo(cmbSearch.Text);
            //_cust.Image = PeoplePracticeBuilder.GetCustomerImage(cmbSearch.Text);

            ////shouldnt happen but for safety.
            ////todo: Let customer know that bad has happened
            //if (_cust == null && _cust.Image == null) return;

            //new WinForm_CustomerDetails(_cust).ShowDialog();
        }

        private async void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (searchState.ToString())
                {
                    case "Customer":

                        var _ID = dgvSearch.Rows[e.RowIndex].Cells[0].Value.ToString();

                        if (String.IsNullOrEmpty(_ID)) return;

                        Customer _cust = PeoplePracticeBuilder.GetCustomerInfo(int.Parse(_ID));
                        _cust.Image = await PeoplePracticeBuilder.GetDocumentAsync(string.Format("/customer_ProfilePictures/{0}.png", _cust.ID));

                        if (_cust == null && _cust.Image == null) return;

                        new WinForm_CustomerDetails(_cust).ShowDialog();
                        break;
                    case "Order":
                        var orderID = dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                        if (String.IsNullOrEmpty(orderID)) return;

                        Orders order = OrderBuilder.GetOrderInfo(int.Parse(orderID));
                        if (order == null) return;
                        new Winform_OrderDetails(order).ShowDialog();
                        break;

                    default:
                        MessageBox.Show("Invalid Search State.Try again");
                        break;
                }
                Cursor.Current = Cursors.Arrow;
            }

            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show("Something Nasty happened.Try again");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSearch.DataSource = String.IsNullOrEmpty(txtSearch.Text) ? null : Main_Helper.GetDataSource(this.searchState.ToString(), txtSearch.Text);
            lblSearchCount.Text = dgvSearch.Rows.Count.ToString();
        }
        #endregion Event

        #region Custom
        public void UpdateOrderReadyDgv()
        {
            IList OrderItemsList;

            OrderItemsList = MainBuilder.GetOrdersList_BasedOnStatus(0);
            lblOrdR2SCount.Text = Main_Helper.FillDatagrid(OrderItemsList, dgvOrdR2S).ToString();

            OrderItemsList = MainBuilder.GetOrdersList_BasedOnStatus(1);
            lblOrdSIPCount.Text = Main_Helper.FillDatagrid(OrderItemsList, dgvOrdSIP).ToString();

            OrderItemsList = MainBuilder.GetOrdersList_BasedOnStatus(2);
            lblOrdCollectCount.Text = Main_Helper.FillDatagrid(OrderItemsList, dgvOrdR2C).ToString();
        }

        public void UpdateAlterationReadyDgv()
        {
            IList AlterationItemsList;

            AlterationItemsList = MainBuilder.GetAlterList_BasedOnStatus(0);
            lblAltR2ACount.Text = Main_Helper.FillDatagrid(AlterationItemsList, dgvAltR2A).ToString();

            AlterationItemsList = MainBuilder.GetAlterList_BasedOnStatus(1);
            lblAltAIPCount.Text = Main_Helper.FillDatagrid(AlterationItemsList, dgvAltSIP).ToString();

            AlterationItemsList = MainBuilder.GetAlterList_BasedOnStatus(2);
            lblAltCollectCount.Text = Main_Helper.FillDatagrid(AlterationItemsList, dgvAltR2C).ToString();
        }
        private void UpdateStatus(string _status = "Ready")
        {
            lblStatus.Text = _status;
        }
        #endregion Custom

    }

}
