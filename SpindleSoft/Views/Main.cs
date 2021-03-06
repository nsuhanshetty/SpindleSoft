﻿using System;
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
    using SpindleSoft.Utilities;
    // using SpindleSoft.Views;
    using SpindleSoft.Views;
    using System.Collections;
    using System.Configuration;

    public partial class Main : Form
    {
        ILog log = LogManager.GetLogger(typeof(Main));
        private enum SearchStates { Order, Customer, Alteration, Sales }
        private SearchStates searchState { get; set; }

        static string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        static string CustomerImagePath = Secrets.FileLocation["CustomerImages"];

        #region SearchTxt
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Order No.");
            this.searchState = SearchStates.Order;

            RefreshDgvSearch();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search by Customer Name.");
            this.searchState = SearchStates.Customer;

            RefreshDgvSearch();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search by Alteration No.");
            this.searchState = SearchStates.Alteration;

            RefreshDgvSearch();
        }

        private void rdbSales_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search by Customer Name.");
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

            Setting setting = null;
            while (setting == null)
            {
                setting = SpindleSoft.Builders.SettingsBuilder.GetBaseImagePath();
                if (setting == null)
                    new Winform_Settings().ShowDialog();
            }
            Secrets.FileLocation["BaseDocDirectory"] = setting.Value;
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
            new Winform_StaffDetails(null, true).ShowDialog();
        }

        private void addVendorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails(null, true).ShowDialog();
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
            //new Winform_BackUpDB().ShowDialog();
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

        #region StatusWidget
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
                            if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                            {
                                message = "Shift selected Order to Ready To Collect";
                                status = 2;
                            }
                            else
                            {
                                message = "Shift selected Order to Ready To Stitch";
                                status = 0;
                            }
                            break;
                        case "dgvOrdR2C":
                            if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                SendSMS("dgvOrdR2C", _orderID);
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                message = "Shift selected Order to Stitch In Progress";
                                status = 1;
                            }
                            break;
                        default:
                            break;
                    }

                    //if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                    //{
                    //    if (dgv.Name == "dgvOrdSIP")
                    //    {
                    //        message = "Shift selected Order to Ready To Collect";
                    //        status = 2;
                    //    }
                    //    else if (dgv.Name == "dgvOrdR2C")
                    //    {
                    //        SendSMS("dgvOrdR2C", _orderID);
                    //    }
                    //}
                    if (string.IsNullOrEmpty(message) || status == -1) return;
                    if (message != string.Empty)
                    {
                        DialogResult dr = MessageBox.Show(message, "Shift Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.No) return;
                    }

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

        private void SendSMS(string dgvName, int _ID)
        {
            string smsMsg;
            string response = "";

            if (dgvName == "dgvOrdR2C")
            {
                var order = OrderBuilder.GetOrderInfo(_ID);
                smsMsg = "Your order #" + order.ID + " is ready to be Collected. Thanks for choosing Dee. Stay Beautiful. Pending Amount Rs." + (order.TotalPrice - order.CurrentPayment).ToString() + ".";
                response = SMSGateway.SendSMS(smsMsg, order.Customer, SMSLog.SectionType.Order);
            }
            else if (dgvName == "dgvAltR2C")
            {
                var alt = AlterationBuilder.GetAlterationInfo(_ID);
                smsMsg = "Your order #" + alt.ID + " has is ready to be Collected. Thanks for choosing Dee. Stay Beautiful. Pending Amount Rs." + (alt.TotalPrice - alt.CurrentPayment).ToString() + ".";
                response = SMSGateway.SendSMS(smsMsg, alt.Customer, SMSLog.SectionType.Alteration);
            }
            if (!string.IsNullOrEmpty(response))
            {
                MessageBox.Show(response);
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
                            //message = "Shift selected Alteration to Ready To Alter";
                            //status = 0;
                            //break;
                            if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                            {
                                message = "Shift selected Alteration to Ready To Collect";
                                status = 2;
                            }
                            else
                            {
                                message = "Shift selected Alteration to Ready To Stitch";
                                status = 0;
                            }
                            break;
                        case "dgvAltR2C":
                            //message = "Shift selected Alteration to Alteration In Progress";
                            //status = 1;
                            //break;
                            if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                            {
                                this.Cursor = Cursors.WaitCursor;
                                SendSMS("dgvAltR2C", _altID);
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                message = "Shift selected Alteration to Stitch In Progress";
                                status = 1;
                            }
                            break;
                        default:
                            break;
                    }

                    //if (dgv.Columns.Count > 3 && e.ColumnIndex == dgv.Columns[3].Index)
                    //{
                    //    message = "Shift selected Alteration to Ready To Collect";
                    //    status = 2;
                    //}
                    if (string.IsNullOrEmpty(message) || status == -1) return;

                    DialogResult dr = MessageBox.Show(message, "Shift Alteration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    //update ord status in db

                    MainSaver.UpdateAlterStatus(_altID, status);
                    UpdateAlterationReadyDgv();
                }
                else
                {
                    new Winform_AlterationsDetails(AlterationBuilder.GetAlterationInfo(_altID)).ShowDialog();
                    UpdateAlterationReadyDgv();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        #endregion StatusWidget

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

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                switch (searchState.ToString())
                {
                    case "Customer":

                        var _ID = dgvSearch.Rows[e.RowIndex].Cells[0].Value.ToString();

                        if (String.IsNullOrEmpty(_ID)) return;

                        Customer _cust = PeoplePracticeBuilder.GetCustomerInfo(int.Parse(_ID));
                        string filePath = string.Format("{0}/{1}/{2}.png", baseDoc, CustomerImagePath, _cust.ID);
                        _cust.Image = Utilities.ImageHelper.GetDocumentLocal(filePath);

                        if (_cust == null) return;

                        new WinForm_CustomerDetails(_cust).ShowDialog();

                        break;
                    case "Order":
                        var orderID = dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                        if (String.IsNullOrEmpty(orderID)) return;

                        Orders order = OrderBuilder.GetOrderInfo(int.Parse(orderID));
                        if (order == null) return;
                        new Winform_OrderDetails(order).ShowDialog();
                        break;
                    case "Alteration":
                        //var orderID = dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
                        //if (String.IsNullOrEmpty(orderID)) return;

                        //Orders order = OrderBuilder.GetOrderInfo(int.Parse(orderID));
                        //if (order == null) return;
                        //new Winform_OrderDetails(order).ShowDialog();
                        break;
                    case "Sales":
                        break;
                    default:
                        MessageBox.Show("Invalid Search State.Try again");
                        break;
                }
                this.Cursor = Cursors.Default;
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

        private void salaryDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Winform_SalaryDetails().ShowDialog();
        }

        private void salaryRegisterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Winform_SalaryRegister().ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_About().ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_Settings().ShowDialog();
        }

        private void backUpDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_BackUpDB().ShowDialog();
        }

        private void restoreDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_RestoreDB().ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Exit the Application with BackUp", "Exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                new Winform_BackUpDB().ShowDialog();
            }
            else if (dr == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void sMSReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SMSRegister().ShowDialog();
        }

        private void sendSMSToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Winform_SMSSend().ShowDialog();
        }
    }

}
