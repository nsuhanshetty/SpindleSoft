using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderType : Winform_DetailsFormat
    {
        public Winform_OrderType()
        {
            InitializeComponent();
        }

        private void txtOrderTypePrice_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtOrderTypePrice.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '250'" : "";
            errorProvider1.SetError(txtOrderTypePrice, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtOrderTypePrice.Select(0, txtOrderTypePrice.TextLength);
            }
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.IsNullOrEmpty(this, false))
            {
                return;
            }

            if (!chkbxBasicMeasure.Checked && !chkbxBasicMeasure.Checked && !chkbxBasicMeasure.Checked)
            {
                MessageBox.Show("Atleast One Measurement details must be included?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            //OrderType ordertype = new OrderType(txtOrderTypeName.Text, txtOrderTypePrice.Text, chkbxBasicMeasure.Checked, chkbxBottomMeasure.Checked, chkbxSleeveMeasure.Checked);

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

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Order type Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }
    }
}
