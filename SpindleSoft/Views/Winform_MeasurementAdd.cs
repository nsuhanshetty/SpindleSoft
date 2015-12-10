using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_MeasurementAdd : Winform_DetailsFormat
    {
        OrderItem _orderItem = new OrderItem();
        int _index = 0;
        Customer _cust;
        List<string> _orderTypeList;

        public Winform_MeasurementAdd()
        {
            InitializeComponent();
        }

        public Winform_MeasurementAdd(int index, Customer cust, OrderItem orderItem)
        {
            InitializeComponent();
            this._index = index;
            this._cust = cust;
            this._orderItem = orderItem;
            this._orderTypeList = OrderBuilder.GetListOfClothingTypes();

            cmbType.DataSource = _orderTypeList;
        }

        private async Task UpdateControls(string custName, OrderItem orderItem)
        {
            this._orderItem = orderItem != null ? orderItem : new OrderItem();

            txtCustName.Text = custName;
            txtLength.Text = this._orderItem.Length;
            txtWaist.Text = this._orderItem.Waist;
            txtChest.Text = this._orderItem.Chest;
            txtShoulder.Text = this._orderItem.Shoulder;
            txtFront.Text = this._orderItem.Front;
            txtBack.Text = this._orderItem.Back;
            txtD.Text = this._orderItem.D;
            txtHip.Text = this._orderItem.Hip;

            txtBotHip.Text = this._orderItem.BottomHip;
            txtBotWaist.Text = this._orderItem.BottomWaist;
            txtBotLength.Text = this._orderItem.BottomLength;
            txtBotLoose.Text = this._orderItem.BottomLoose;

            txtSlvAHole.Text = this._orderItem.SleeveArmHole;
            txtSlvLength.Text = this._orderItem.SleeveLength;
            txtSlvLoose.Text = this._orderItem.SleeveLoose;
            txtComment.Text = this._orderItem.Comment;

            UpdateCmbType(this._orderItem.Name ?? cmbType.Text);
            nudQuantity.Value = this._orderItem.Quantity == 0 ? 1 : this._orderItem.Quantity;
            txtPrice.Text = this._orderItem.Price.ToString();

            if (this._orderItem.Image != null)
                pcbMaterialImage.Image = this._orderItem.Image;
            else if (pcbMaterialImage.Image == null)
                pcbMaterialImage.Image = await Utilities.Helper.GetDocumentAsync("/OrderItem_ProfilePictures", this._orderItem.ID.ToString());

            this._orderItem.Image = pcbMaterialImage.Image;
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

            OrderItem _item = _orderItem;

            _item.Name = cmbType.Text;
            _item.Price = float.Parse(txtPrice.Text);
            _item.Quantity = int.Parse(nudQuantity.Value.ToString());

            _item.Image = pcbMaterialImage.Image;

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
                orderDetails.UpdateOrderItemList(_item, _index);
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
            if (this._orderTypeList.IndexOf(value) == -1)
            {
                this._orderTypeList.Add(value);
                cmbType.DataSource = null;
                cmbType.DataSource = _orderTypeList;
            }
            cmbType.SelectedItem = value;
        }

        private async void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbType.Text) && (_orderItem == new OrderItem() || cmbType.Text != _orderItem.Name))
            {
                //fetch  previous measurement
                _orderItem = OrderBuilder.GetOrderItem(this._cust.ID, cmbType.Text);
                if (_orderItem != null) _orderItem.ID = 0;

                await UpdateControls(this._cust.Name, _orderItem);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Winform_ImageCapture _imageCapture = new Winform_ImageCapture(this.pcbMaterialImage);
            _imageCapture.ShowDialog();
        }

        private async void Winform_MeasurementAdd_Load(object sender, EventArgs e)
        {
            await UpdateControls(this._cust.Name, this._orderItem);
        }
    }
}