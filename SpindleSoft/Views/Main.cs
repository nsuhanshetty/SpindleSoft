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
    using SpindleSoft.Model;
    using SpindleSoft.Savers;
    using SpindleSoft.Views;

    public partial class Main : Form
    {
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Customer Name/ Mobile No.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Order No.");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Alteration No.");
        }

        private void rdbSales_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSearchText("Search Sale No.");
        }


        private void UpdateSearchText(string _updateText)
        {
            lblSearchText.Text = _updateText;
            cmbSearch.Focus();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rdbOrders.Checked)
                new Winform_OrderDetails().ShowDialog();
            else if (rdbCustomer.Checked)
                new WinForm_CustomerDetails().ShowDialog();
            //else
            //    new Winform_AlterationsDetails().ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void cmbSearch_TextChanged(object sender, EventArgs e)
        {
            List<Customer> _custList = PeoplePracticeBuilder.GetCustomersList("",cmbSearch.Text,"");
            if (_custList.Count == 0)   
            {
                cmbSearch.DataSource = null;
            }
            else
            {
                cmbSearch.DataSource = new List<String>(_custList.Select(c => c.Mobile_No).Distinct());
            }
            return;

        }
    }

}
