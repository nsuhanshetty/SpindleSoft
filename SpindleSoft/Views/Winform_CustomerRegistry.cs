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

namespace SpindleSoft.Views
{
    public partial class Winform_CustomerRegister : Form
    {
        public Winform_CustomerRegister()
        {
            InitializeComponent();
        }

        private void Winform_StaffRegister_Load(object sender, EventArgs e)
        {
            /*todo: Akash : get Customer based on updated desc*/
            dgvCustomerRegister.DataSource = PeoplePracticeBuilder.GetCustomersList("", "", "");
        }

        #region Events
        private void dgvCustomerRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Customer " +
                                         Convert.ToString(dgvCustomerRegister.Rows[e.RowIndex].Cells[1].Value),
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;
            
            Customer _customer = PeoplePracticeBuilder.GetCustomerInfo(dgvCustomerRegister.Rows[e.RowIndex].Cells[2].Value.ToString());
            new WinForm_CustomerDetails(_customer).ShowDialog();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            dgvCustomerRegister.DataSource = PeoplePracticeBuilder.GetCustomersList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
        }
        #endregion Events

        #region Validation
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text)) return;

            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtName, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtName.TextLength);
            }
        }

        private void txtMobNo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMobNo.Text)) return;

            Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtMobNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtMobNo.Select(0, txtMobNo.TextLength);
            }
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtPhoneNo.Text)) return;

            Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtPhoneNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPhoneNo.Select(0, txtPhoneNo.TextLength);
            }
        }
        #endregion Validation
    }
}
