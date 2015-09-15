using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_MeasurementAdd : Winform_DetailsFormat
    {
        OrderItem orderItem = new OrderItem();
        int index = 0;
        Customer cust;
        List<string> orderTypeList;

        public Winform_MeasurementAdd()
        {
            InitializeComponent();
        }

        public Winform_MeasurementAdd(int _index, Customer cust, OrderItem orderItem)
        {
            InitializeComponent();
            this.index = _index;
            this.cust = cust;

            orderTypeList = OrderBuilder.GetListOfClothingTypes();
            cmbType.DataSource = orderTypeList;

            UpdateControls(cust.Name, orderItem);
        }

        private void UpdateControls(string custName, OrderItem orderItem)
        {
            this.orderItem = orderItem != null ? orderItem : new OrderItem();

            txtCustName.Text = custName;

            //if (orderItem == null) return;
            txtLength.Text = this.orderItem.Length;
            txtWaist.Text = this.orderItem.Waist;
            txtChest.Text = this.orderItem.Chest;
            txtShoulder.Text = this.orderItem.Shoulder;
            txtFront.Text = this.orderItem.Front;
            txtBack.Text = this.orderItem.Back;
            txtD.Text = this.orderItem.D;
            txtHip.Text = this.orderItem.Hip;

            txtBotHip.Text = this.orderItem.BottomHip;
            txtBotWaist.Text = this.orderItem.BottomWaist;
            txtBotLength.Text = this.orderItem.BottomLength;
            txtBotLoose.Text = this.orderItem.BottomLoose;

            txtSlvAHole.Text = this.orderItem.SleeveArmHole;
            txtSlvLength.Text = this.orderItem.SleeveLength;
            txtSlvLoose.Text = this.orderItem.SleeveLoose;
            txtComment.Text = this.orderItem.Comment;

            UpdateCmbType(this.orderItem.Name ?? cmbType.Text);
            nudQuantity.Value = this.orderItem.Quantity == 0 ? 1 : this.orderItem.Quantity;
            txtPrice.Text = this.orderItem.Price.ToString();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            //todo: check if is in edit
            bool hasValue = SpindleSoft.Utilities.Validation.controlIsInEdit(grbxProdDetails, true);

            if (hasValue != true)
            {
                MessageBox.Show("No values found in Product Details, Add values and Save", "No Values Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //todo: Convert to _orderItem object

            OrderItem _item = orderItem;

            _item.Name = cmbType.Text;
            _item.Price = float.Parse(txtPrice.Text);
            _item.Quantity = int.Parse(nudQuantity.Value.ToString());

            _item.Length = txtLength.Text;
            _item.Waist = txtWaist.Text;
            _item.Chest = txtChest.Text;
            _item.Shoulder = txtShoulder.Text;
            _item.Front = txtFront.Text;
            _item.Back = txtBack.Text;
            _item.D = txtD.Text;
            _item.Hip = txtHip.Text;

            _item.BottomHip = txtBotHip.Text;
            _item.BottomWaist = txtBotWaist.Text;
            _item.BottomWaist = txtBotWaist.Text;
            _item.BottomLength = txtBotLength.Text;
            _item.BottomLoose = txtBotLoose.Text;

            _item.SleeveArmHole = txtSlvAHole.Text;
            _item.SleeveLength = txtSlvLength.Text;
            _item.SleeveLoose = txtSlvLoose.Text;
            _item.Comment = txtComment.Text;
            _item.DateUpdated = DateTime.Now;

            Winform_OrderDetails orderDetails = Application.OpenForms["Winform_OrderDetails"] as Winform_OrderDetails;
            if (orderDetails != null)
                orderDetails.UpdateOrderItemList(_item, index);
            //else
            //    MessageBox.Show("Unable to Update the Order Cart as List not found.","Order Details not found",MessageBoxButtons.OK,MessageBoxIcon.Error);

            //Winform_AlterationsDetails altDetails = Application.OpenForms["Winform_AlterationsDetails"] as Winform_AlterationsDetails;
            //if (altDetails != null)
            //    altDetails.updateOrderItemList(_item);
            //else
            //    MessageBox.Show("Unable to Update the Order Cart as List not found.", "Alteration Details not found", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Measurement Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            var txtbox = (sender as TextBox);
            if (txtbox.Text == String.Empty)
                return;

            //allow only signed int/ float
            Match _match = Regex.Match(txtbox.Text, "^[0-9]+(\\.[0-9]+)?$");
            string errorMsg = _match.Success ? "" : "Invalid Input for fields\n" +
                                                    " For example '34.2'";
            errorProvider1.SetError(txtbox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtbox.Select(0, txtbox.TextLength);
            }
        }

        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
            var value = (sender as ComboBox).Text;
            if (string.IsNullOrEmpty(value)) return;

            UpdateCmbType(value);
        }

        private void UpdateCmbType(string value)
        {
            if (this.orderTypeList.IndexOf(value) == -1)
            {
                this.orderTypeList.Add(value);
                cmbType.DataSource = null;
                cmbType.DataSource = orderTypeList;
            }
            cmbType.SelectedItem = value;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbType.Text) && (orderItem == new OrderItem() || cmbType.Text != orderItem.Name))
            {
                //fetch  previous measurement
                orderItem = OrderBuilder.GetOrderItem(this.cust.ID, cmbType.Text);
                if (orderItem != null) orderItem.ID = 0;

                UpdateControls(this.cust.Name, orderItem);
            }
        }
    }
}