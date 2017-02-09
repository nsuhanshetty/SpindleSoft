using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using SpindleSoft.Utilities;

namespace SpindleSoft.Views
{
    public partial class Winform_SMSSend : Form
    {
        List<Customer> custList = new List<Customer>();
        public Winform_SMSSend()
        {
            InitializeComponent();
        }

        private void Winform_SMSSend_Load(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Empty message cannot be sent to recipients", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else if (dgvToList.Rows.Count == 0)
            {
                MessageBox.Show("No Recipients found", "Send SMS", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            statusStrip1.Text = "Sending SMS";
            UseWaitCursor = true;
            var responseList = SMSGateway.SendBulkSMS(txtMessage.Text, custList);
            UseWaitCursor = false;

            //on success
            if (responseList != null)
            {
                var unsentCount = responseList.Where(i => i.Status != "SMS Sent").Select(i => i).ToList().Count();
                if (unsentCount == 0)
                {
                    MessageBox.Show("All SMS sent Successfully");
                    return;
                }

                DialogResult dr = MessageBox.Show(unsentCount + " of " + responseList.Count + " SMS not delivered. Do you want to send them again?", "SMS Status", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                custList = responseList.Where(i => i.Status != "SMS Sent").Select(i => i.Customer).ToList();
                UpdateCustomerList(custList);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new WinForm_AddMultipleCustomer(custList).ShowDialog();
        }

        public void UpdateCustomerList(List<Customer> _custList)
        {
            this.custList = _custList;
            dgvToList.DataSource = (from cust in this.custList
                                    select new { cust.Name, cust.Mobile_No }).ToList();
        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            int leng = txtMessage.Text.Length;
            if (leng > 160)
                e.Handled = true;
            else
                lblLimit.Text = leng.ToString();
        }
    }
}