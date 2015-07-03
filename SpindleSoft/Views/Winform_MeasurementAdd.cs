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
            txtLength.Text = this.orderItem.Length.ToString();
            txtWaist.Text = this.orderItem.Waist.ToString();
            txtChest.Text = this.orderItem.Chest.ToString();
            txtShoulder.Text = this.orderItem.Shoulder.ToString();
            txtFront.Text = this.orderItem.Front.ToString();
            txtBack.Text = this.orderItem.Back.ToString();
            txtD.Text = this.orderItem.D.ToString();
            txtHip.Text = this.orderItem.Hip.ToString();

            txtBotHip.Text = this.orderItem.BottomHip.ToString();
            txtBotWaist.Text = this.orderItem.BottomWaist.ToString();
            txtBotLength.Text = this.orderItem.BottomLength.ToString();

            txtSlvAHole.Text = this.orderItem.SleeveArmHole.ToString();
            txtSlvLength.Text = this.orderItem.SleeveLength.ToString();
            txtSlvLoose.Text = this.orderItem.SleeveLoose.ToString();
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

            _item.Length = txtLength.Text == null ? (float?)null : float.Parse(txtLength.Text);
            _item.Waist = String.IsNullOrEmpty(txtWaist.Text) ? (float?)null : float.Parse(txtWaist.Text);
            _item.Chest = String.IsNullOrEmpty(txtChest.Text) ? (float?)null : float.Parse(txtChest.Text);
            _item.Shoulder = String.IsNullOrEmpty(txtShoulder.Text) ? (float?)null : float.Parse(txtShoulder.Text);
            _item.Front = String.IsNullOrEmpty(txtFront.Text) ? (float?)null : float.Parse(txtFront.Text);
            _item.Back = String.IsNullOrEmpty(txtBack.Text) ? (float?)null : float.Parse(txtBack.Text);
            _item.D = String.IsNullOrEmpty(txtD.Text) ? (float?)null : float.Parse(txtD.Text);
            _item.Hip = String.IsNullOrEmpty(txtHip.Text) ? (float?)null : float.Parse(txtHip.Text);

            _item.BottomHip = String.IsNullOrEmpty(txtBotHip.Text) ? (float?)null : float.Parse(txtBotHip.Text);
            _item.BottomWaist = String.IsNullOrEmpty(txtBotWaist.Text) ? (float?)null : float.Parse(txtBotWaist.Text);
            _item.BottomWaist = String.IsNullOrEmpty(txtBotWaist.Text) ? (float?)null : float.Parse(txtBotWaist.Text);
            _item.BottomLength = String.IsNullOrEmpty(txtBotLength.Text) ? (float?)null : float.Parse(txtBotLength.Text);

            _item.SleeveArmHole = String.IsNullOrEmpty(txtSlvAHole.Text) ? (float?)null : float.Parse(txtSlvAHole.Text);
            _item.SleeveLength = String.IsNullOrEmpty(txtSlvLength.Text) ? (float?)null : float.Parse(txtSlvLength.Text);
            _item.SleeveLoose = String.IsNullOrEmpty(txtSlvLoose.Text) ? (float?)null : float.Parse(txtSlvLoose.Text);
            _item.Comment = txtComment.Text;

            Winform_OrderDetails orderDetails = Application.OpenForms["Winform_OrderDetails"] as Winform_OrderDetails;
            if (orderDetails != null)
                orderDetails.updateOrderItemList(_item);
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