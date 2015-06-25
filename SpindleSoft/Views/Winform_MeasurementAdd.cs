using SpindleSoft.Model;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_MeasurementAdd : Winform_DetailsFormat
    {
        OrderItem _orderItem = new OrderItem();
        int rindex;

        public Winform_MeasurementAdd()
        {
            InitializeComponent();
        }

        public Winform_MeasurementAdd(OrderItem _orderItem,int rindex)
        {
            InitializeComponent();

            this._orderItem = _orderItem;
            this.rindex = rindex;

            //loading Controls
            //txtOrderType.Text = this._orderItem.OrderID.ToString();

            txtLength.Text = this._orderItem.Length.ToString();
            txtWaist.Text = this._orderItem.Waist.ToString();
            txtChest.Text = this._orderItem.Chest.ToString();
            txtShoulder.Text = this._orderItem.Shoulder.ToString();
            txtFront.Text = this._orderItem.Front.ToString();
            txtBack.Text = this._orderItem.Back.ToString();
            txtD.Text = this._orderItem.D.ToString();
            txtHip.Text = this._orderItem.Hip.ToString();

            txtBotHip.Text = this._orderItem.BottomHip.ToString();
            txtBotWaist.Text = this._orderItem.BottomWaist.ToString();
            txtBotLength.Text = this._orderItem.BottomLength.ToString();

            txtSlvAHole.Text = this._orderItem.SleeveArmHole.ToString();
            txtSlvLength.Text = this._orderItem.SleeveLength.ToString();
            txtSlvLoose.Text = this._orderItem.SleeveLoose.ToString();
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
            //todo: Convert to _orderItem object
            txtLength.Text = this._orderItem.Length.ToString();
            txtWaist.Text = this._orderItem.Waist.ToString();
            txtChest.Text = this._orderItem.Chest.ToString();
            txtShoulder.Text = this._orderItem.Shoulder.ToString();
            txtFront.Text = this._orderItem.Front.ToString();
            txtBack.Text = this._orderItem.Back.ToString();
            txtD.Text = this._orderItem.D.ToString();
            txtHip.Text = this._orderItem.Hip.ToString();

            txtBotHip.Text = this._orderItem.BottomHip.ToString();
            txtBotWaist.Text = this._orderItem.BottomWaist.ToString();
            txtBotLength.Text = this._orderItem.BottomLength.ToString();

            txtSlvAHole.Text = this._orderItem.SleeveArmHole.ToString();
            txtSlvLength.Text = this._orderItem.SleeveLength.ToString();
            txtSlvLoose.Text = this._orderItem.SleeveLoose.ToString();

            
        }
    }
}