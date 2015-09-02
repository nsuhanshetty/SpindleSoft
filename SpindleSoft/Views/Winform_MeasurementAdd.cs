using SpindleSoft.Model;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_MeasurementAdd : Winform_DetailsFormat
    {
        OrderItem orderItem = new OrderItem();

        public Winform_MeasurementAdd()
        {
            InitializeComponent();
        }

        public Winform_MeasurementAdd(string _productName, string custName, OrderItem orderItem = null)
        {
            InitializeComponent();

            this.orderItem = orderItem;

            //loading Controls
            txtCustName.Text = custName;
            txtClothingType.Text = _productName;

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
        }

        private void Winform_MeasurementAdd_Load(object sender, System.EventArgs e)
        {
            // txtOrderNo.Text = _orderItem.OrderID.ToString();
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
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

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            //todo: check if is in edit
            bool hasValue = SpindleSoft.Utilities.Validation.controlIsInEdit(grpBxMeasurements, true);

            if (hasValue != true)
            {
                MessageBox.Show("No values found in Measurement Details, Add values and Save", "No alues Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //todo: Convert to _orderItem object

            OrderItem _item = orderItem;

            _item.Name = txtClothingType.Text;
            _item.Price = this.orderItem.Price;
            _item.Quantity = this.orderItem.Quantity;

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
                orderDetails.UpdateOrderItemList(_item);
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
    }
}