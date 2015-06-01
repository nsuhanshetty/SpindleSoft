using SpindleSoft.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();
        Orders _order = new Orders();

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
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);

            //create dgv with coulumns
            //item type - quatity - price - edit measurements - add design
        }

        public void UpdateCustomerControl (Customer customer)
        {
            if (customer == null) return;

            this._cust = customer;

            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;
            pcbCustImage.Image = _cust.Image;
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
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
            //item type - quatity - price - edit measurements - add design
        }

        private void NewCustomerToolStrip_Click(object sender, EventArgs e)
        {
          

        }

        private void btnMeasurement_Click(object sender, EventArgs e)
        {
            new Winform_MeasurementAdd().ShowDialog();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            //customerId, 
            _order.CustomerID = this._cust.ID;

            _order.OrderID = Convert.ToInt32(txtOrderNo.Text);
            _order.PromisedDate = dtpDeliveryDate.Value;

            _order.TotalPrice = Convert.ToInt32(txtTotAmnt.Text);
            _order.CurrentPayment = Convert.ToInt32(txtAmntPaid.Text);
        }

        private void txtAmntPaid_Validated(object sender, EventArgs e)
        {
            txtBalanceAmnt.Text = (Convert.ToInt32(txtTotAmnt.Text) - Convert.ToInt32(txtAmntPaid.Text)).ToString(); 
        }
    }
}