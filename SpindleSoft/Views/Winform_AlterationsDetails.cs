using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_AlterationsDetails : Winform_DetailsFormat
    {
        Customer _cust = new Customer();

        public Winform_AlterationsDetails()
        {
            InitializeComponent();
        }

        private void Winform_AlterationsDetails_Load(object sender, System.EventArgs e)
        {
            this.toolStripParent.Items.Add(this.AddCustomerToolStrip);
        }

        public void UpdateCustomerControl(Customer customer)
        {
            if (customer == null) return;

            this._cust = customer;

            txtName.Text = _cust.Name;
            txtMobNo.Text = _cust.Mobile_No;
            txtPhoneNo.Text = _cust.Phone_No;
            pcbMemImage.Image = _cust.Image;
        }

        private void AddCustomerToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AddCustomer(this._cust).ShowDialog();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {

            string[] input = { "txtAltNo"};
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            //Alteration alt = new Alteration(this._cust.ID,dtpDeliveryDate.Text, txtDesc.Text);

            UpdateStatus("Saving OrderTypeInfo..", 50);
           //bool response = SpindleSoft.Savers.OrderSaver.SaveOrderTypeInfo(ordertype);

            //if (response)
            //{
            //    UpdateStatus("Saved", 100);
            //    this.Close();
            //}
            //else
            //{
            //    UpdateStatus("Error in Saving OrderTypeInfo..", 100);
            //}
        }
    }
}