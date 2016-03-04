using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_AddCustomer : Form
    {
        Customer _cust = new Customer();
        public Winform_AddCustomer(Customer _cust = null)
        {
            InitializeComponent();
            this._cust = _cust;
        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            new WinForm_CustomerDetails().ShowDialog();
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            DialogResult _dialogResult = MessageBox.Show("Do you want to Add Customer " +
                                         Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value),
                                         "Add Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            this.Cursor = Cursors.WaitCursor;
            var ID = dgvSearch.Rows[e.RowIndex].Cells["ID"].Value;
            this._cust = Builders.PeoplePracticeBuilder.GetCustomerInfo(int.Parse(ID.ToString()));

            Winform_OrderDetails orderDetails = Application.OpenForms["Winform_OrderDetails"] as Winform_OrderDetails;
            if (orderDetails != null)
                orderDetails.UpdateCustomerControl(_cust);

            WinForm_CustomerDetails custDetails = Application.OpenForms["WinForm_CustomerDetails"] as WinForm_CustomerDetails;
            if (custDetails != null)
                custDetails.UpdateCustomerControl(_cust);

            Winform_AlterationsDetails altDetails = Application.OpenForms["Winform_AlterationsDetails"] as Winform_AlterationsDetails;
            if (altDetails != null)
                altDetails.UpdateCustomerControl(_cust);

            Winform_SalesDetails saleDetails = Application.OpenForms["Winform_SalesDetails"] as Winform_SalesDetails;
            if (saleDetails != null)
                saleDetails.UpdateCustomerControl(_cust);

            this.Cursor = Cursors.Default;
            this.Close();
        }

        public void LoadDgv()
        {
            var custList = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomersList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
            dgvSearch.DataSource = custList != null && custList.Count != 0 ? custList : null;

            lblStatus.Text = (dgvSearch.RowCount == 0) ? "No Results Found" : dgvSearch.RowCount + " Results Found";
            progBarStatus.Value = 100;
        }

        private void txtMobNo_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Searching...";
            progBarStatus.Value = 50;

            LoadDgv();

            if (dgvSearch.RowCount == 0)
                lblStatus.Text = "No Results Found.";
            else
                lblStatus.Text = dgvSearch.RowCount + " Results Found.";
            progBarStatus.Value = 100;
        }
    }
}

