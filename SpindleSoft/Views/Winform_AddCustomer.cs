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

namespace SpindleSoft.Views
{
    public partial class Winform_AddCustomer : Form
    {
        //public event EventHandler<DatagridViewEventArgs> CustomerSelected;

        Customer _cust = new Customer();
        public Winform_AddCustomer(Customer _cust)
        {
            InitializeComponent();
            this._cust = _cust;
        }

        public Winform_AddCustomer()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new WinForm_CustomerDetails().ShowDialog();
        }

        private void Winform_AddCustomer_Load(object sender, EventArgs e)
        {
            //todo: add radiobutton columns to dgv
            //dgv.datasource = getStaffList based on last added first
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Do you want to Create Order for Customer " +
                                         Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value), 
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            var mobNo = dgvSearch.Rows[e.RowIndex].Cells["Mobile_No"].Value;
            this._cust = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomerInfo(mobNo.ToString());
            this._cust.Image = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomerImage(mobNo.ToString());

            Winform_OrderDetails orderDetails = Application.OpenForms["Winform_OrderDetails"] as Winform_OrderDetails;
            if (orderDetails != null)
                orderDetails.UpdateCustomerControl(_cust);

            WinForm_CustomerDetails custDetails = Application.OpenForms["WinForm_CustomerDetails"] as WinForm_CustomerDetails;
            if (custDetails != null)
                custDetails.UpdateCustomerControl(_cust);

            this.Close();
        }

        public void LoadDgv()
        {
            dgvSearch.DataSource = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomersList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
            dgvSearch.Columns.RemoveAt(0);
            dgvSearch.Columns.RemoveAt(4);
            dgvSearch.Columns.Remove("image");
            dgvSearch.Columns.Remove("address");
        }

        //public void OnCustomerSelected(DatagridViewEventArgs args )
        //{
        //    if (CustomerSelected != null)
        //    {
        //        CustomerSelected(this, args);
        //    }
        //}

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //return the selected customers
            if (this._cust == null)
            {
                MessageBox.Show("Select a Customer to be added to the Order");
                return;
            }
            else
            {
                /*hope referenced customer has changed 
                *some behavior in the orders page
                 */
                this.Close();
            }
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

       

      //  #region Validation
      //  private void txtName_Validating(object sender, CancelEventArgs e)
      //  {
      //      if (String.IsNullOrEmpty(txtName.Text)) return;

      //      Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
      //      string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      //"For example '9880123456'";
      //      errorProvider1.SetError(txtName, errorMsg);

      //      if (errorMsg != "")
      //      {
      //          // Cancel the event and select the text to be corrected by the user.
      //          e.Cancel = true;
      //          txtName.Select(0, txtName.TextLength);
      //      }
      //  }

      //  private void txtMobNo_Validating(object sender, CancelEventArgs e)
      //  {
      //      if (String.IsNullOrEmpty(txtMobNo.Text)) return;

      //      Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
      //      string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      //"For example '9880123456'";
      //      errorProvider1.SetError(txtMobNo, errorMsg);

      //      if (errorMsg != "")
      //      {
      //          // Cancel the event and select the text to be corrected by the user.
      //          e.Cancel = true;
      //          txtMobNo.Select(0, txtMobNo.TextLength);
      //      }
      //  }

      //  private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
      //  {
      //      if (String.IsNullOrEmpty(txtPhoneNo.Text)) return;

      //      Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
      //      string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      //"For example '9880123456'";
      //      errorProvider1.SetError(txtPhoneNo, errorMsg);

      //      if (errorMsg != "")
      //      {
      //          // Cancel the event and select the text to be corrected by the user.
      //          e.Cancel = true;
      //          txtPhoneNo.Select(0, txtPhoneNo.TextLength);
      //      }
      //  }
      //  #endregion Validation
    }

    class DatagridViewEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string Mobile_No { get; set; }
        public string Phone_No { get; set; }

        public DatagridViewEventArgs(string name, string mobNo, string phNo)
        {
            this.Name = name;
            this.Mobile_No = mobNo;
            this.Phone_No = phNo;
        }

    }
}
