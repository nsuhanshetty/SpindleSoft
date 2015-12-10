using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using System.Text.RegularExpressions;
using Equin.ApplicationFramework;

namespace SpindleSoft.Views
{
    public partial class Winform_CustomerRegister : winform_Register
    {
        public Winform_CustomerRegister()
        {
            InitializeComponent();
        }

        private void Winform_StaffRegister_Load(object sender, EventArgs e)
        {
            /*todo: Akash : get Customer based on updated desc*/
            //dgvCustomerRegister.DataSource = PeoplePracticeBuilder.GetCustomersList("", "", "");
        }

        #region Events
        private async void dgvCustomerRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Customer " +
                                         Convert.ToString(dgvCustomerRegister.Rows[e.RowIndex].Cells[1].Value),
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            int flags;
            if (!Utilities.Validation.InternetGetConnectedState(out flags, 0))
            {
                UpdateStatus("Checking for internet connection", 50);
                MessageBox.Show("Error connecting to Internet, check the network and try again.", "Error connecting to Internet",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Error connecting to Internet.", 0);
                return;
            }

            int _ID = int.Parse(dgvCustomerRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            Customer _customer = PeoplePracticeBuilder.GetCustomerInfo(_ID);
            //_customer.Image = ;

            new WinForm_CustomerDetails(_customer).ShowDialog();
            txtName_TextChanged(this, new EventArgs());
        }

        private async void dgvCustomerRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (dgvCustomerRegister.Columns["colDelete"].Index == e.ColumnIndex)
            {
                int custID = int.Parse(dgvCustomerRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                DialogResult dr = MessageBox.Show("Do you want to delete Customer " + custID, "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool success = await Savers.PeoplePracticeSaver.DeleteCustomer(custID);
                if (success)
                {
                    txtName_TextChanged(this, new EventArgs());
                    UpdateStatus("Customer Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Customer. ", 100);
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);

            List<Customer> custList = new List<Customer>();
            custList = PeoplePracticeBuilder.GetCustomersList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);

            if (custList != null && custList.Count != 0)
            {
                dgvCustomerRegister.DataSource = (from cust in custList
                                                  select new
                                                  {
                                                      cust.ID,
                                                      cust.Name,
                                                      cust.Mobile_No,
                                                      cust.Phone_No
                                                  })
                                                    .ToList();
                dgvCustomerRegister.Columns["colDelete"].Visible = true;
                dgvCustomerRegister.Columns["colDelete"].DisplayIndex = dgvCustomerRegister.Columns.Count - 1;
            }
            else
            {
                dgvCustomerRegister.DataSource = null;
                dgvCustomerRegister.Columns["colDelete"].Visible = false;
            }

            UpdateStatus((dgvCustomerRegister.RowCount == 0) ? "No Results Found" : dgvCustomerRegister.RowCount + " Results Found", 100);
        }
        #endregion Events       

        #region Validation
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
        #endregion Validation
    }
}
