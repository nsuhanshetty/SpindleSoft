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
    using SpindleSoft.Builders;
    using SpindleSoft.Helpers;
    using SpindleSoft.Model;
    using SpindleSoft.Savers;
    using SpindleSoft.Views;

    public partial class Main : Form
    {
        private enum SearchStates { Order, Customer, Alteration, Sales }

        private SearchStates searchState { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void bulkSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_OrderDetails().ShowDialog();
        }

        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SMSSend().ShowDialog();
        }

        private void searchOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_OrderRegister().ShowDialog();
        }

        #region SearchTxt
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Customer Mobile No.");
            this.searchState = SearchStates.Customer;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Order No.");
            this.searchState = SearchStates.Order;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Alteration No.");
            this.searchState = SearchStates.Alteration;
        }

        private void rdbSales_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Sale No.");
            this.searchState = SearchStates.Sales;
        }

        private void UpdateSearchText(string _updateText)
        {
            lblSearchText.Text = _updateText;
            txtSearch.Focus();
        }
        #endregion SearchTxt

        private void Main_Load(object sender, EventArgs e)
        {
            /*load delivery dgv*/
            /*load alteration dgv*/
        }

        #region toolstrip
        private void addCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new WinForm_CustomerDetails().ShowDialog();
        }

        private void customerRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_CustomerRegister().ShowDialog();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_StaffDetails().ShowDialog();
        }

        private void staffRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_StaffRegister().ShowDialog();
            //todo : salary add advance
            //todo:  salary register must showen based on time interval (week, month, year)
        }

        private void addGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_GroupAdd().ShowDialog();
        }

        private void addAlterationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_AlterationsDetails().ShowDialog();
        }

        private void searchAlterationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_AlterationRegister().ShowDialog();
        }

        private void viewExpenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseRegister().ShowDialog();
        }

        private void addExpensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_ExpenseDetails().ShowDialog();
        }

        private void viewSMSRegistryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SMSRegister().ShowDialog();
        }

        private void catalogueRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion toolstrip

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rdbOrders.Checked)
                new Winform_OrderDetails().ShowDialog();
            else if (rdbCustomer.Checked)
                new WinForm_CustomerDetails().ShowDialog();
            else if (rdbAlteration.Checked)
                new Winform_AlterationsDetails().ShowDialog();
            else if (rdbSales.Checked)
                new Winform_SalesDetails().ShowDialog();
        }

        private void salaryRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //link salary to expense
        }

        private void importCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //export excel Sheet/ google spreadsheet
            //
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSearch.Text)) return;
            dgvSearch.DataSource = Main_Helper.GetDataSource(this.searchState.ToString(), txtSearch.Text);
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var mobileNo = dgvSearch.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (String.IsNullOrEmpty(mobileNo))
                return;

            Customer _cust = PeoplePracticeBuilder.GetCustomerInfo(mobileNo);
            _cust.Image = PeoplePracticeBuilder.GetCustomerImage(mobileNo);

            //shouldnt happen but for safety.
            //todo: Let customer know that bad has happened
            if (_cust == null && _cust.Image == null) return;

            new WinForm_CustomerDetails(_cust).ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Alteration
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            *Date
            *Customer Name
            *MobileNo
            *send sms
            //*postpone - 2mrw 
            */

            /*get pending and today's Alterations*/
        }

        private void dgvUpCominAlt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            *Date
            *Customer Name
            *MobileNo
            *send sms
            *pick Order
            */

            /*get upcoming's Alteration*/
        }
        #endregion Alteration

        #region Order
        private void dgvDeliverToday_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             *Date
             *Customer Name
             *MobileNo
             *send sms
             //*postpone - 2mrw 
             */

            /*get pending and today's orders*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
             *Date
             *Customer Name
             *MobileNo
             *send sms
             *pick Order
             */

            /*get upcoming's orders*/
        }
        #endregion Order

        private void addCatalogueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_SalesDetails().ShowDialog();
        }

        private void stockCheckToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Winform_SKURegister().ShowDialog();
        }

        private void addVendorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails().ShowDialog();
        }

        private void vendorRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_VendorsRegister().ShowDialog();
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails().ShowDialog();
        }
    }

}
