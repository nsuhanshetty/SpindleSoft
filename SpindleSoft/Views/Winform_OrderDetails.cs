using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderDetails : Winform_DetailsFormat
    {
        public Winform_OrderDetails()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Winform_OrderAdd_Load(object sender, EventArgs e)
        {
            //todo : Unique Orderno from the Db 
            //todo : AddCustomer toolstrip button
            //todo : 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        #region _Validations
        private void txtAmntPaid_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Match _match = Regex.Match(txtAmntPaid.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";
            errorProvider1.SetError(txtAmntPaid, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtAmntPaid.TextLength);
            }
        }
        #endregion _Validations

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //item type - quatity - price - edit measurements 
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {

        }

        private void NewCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new WinForm_CustomerDetails().ShowDialog();

        }
    }
}