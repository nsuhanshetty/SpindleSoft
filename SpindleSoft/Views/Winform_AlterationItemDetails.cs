using SpindleSoft.Builders;
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
    public partial class Winform_AlterationItemDetails : Winform_DetailsFormat
    {
        int index;
        AlterationItem item;
        List<String> clothList;

        public Winform_AlterationItemDetails(int _index, AlterationItem _item)
        {
            InitializeComponent();
            this.index = _index;

            clothList = AlterationBuilder.GetListOfClothingTypes();

            cmbClothType.DataSource = clothList;
            cmbClothType.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbClothType.AutoCompleteCustomSource.AddRange(clothList.ToArray());
            cmbClothType.AutoCompleteMode = AutoCompleteMode.Suggest;

            if (_item == null) return;
            this.item = _item;

            txtComment.Text = _item.Comment;
            txtUnitPrice.Text = _item.Price.ToString();
            nudQuantity.Value = _item.Quantity;
            UpdateCmbType(_item.Name ?? cmbClothType.Text);
        }

        private void UpdateCmbType(string value)
        {
            if (this.clothList.IndexOf(value) == -1)
            {
                this.clothList.Add(value);
                cmbClothType.DataSource = null;
                cmbClothType.DataSource = clothList;
            }
            cmbClothType.SelectedItem = value;
        }

        private void txtUnitPrice_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtUnitPrice.Text, "^\\d*$");
            string _errorMsg = !_match.Success ? "Invalid Amount input data type.\nExample: '1100'" : "";

            errorProvider1.SetError(txtUnitPrice, _errorMsg);

            if (_errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtUnitPrice.Text = "0";
                return;
            }
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            ProcessTabKey(true);
            #region Validation
            errorProvider1.SetError(cmbClothType, "");
            if (errorProvider1.GetError(txtUnitPrice) != "") return;

            if (String.IsNullOrEmpty(cmbClothType.Text))
            {
                errorProvider1.SetError(cmbClothType, "selecting Clothing type is mandatory");
                return;
            }
            #endregion Validation

            UpdateStatus("Saving..", 25);
            AlterationItem altItem = new AlterationItem(cmbClothType.Text, int.Parse(nudQuantity.Value.ToString()), int.Parse(txtUnitPrice.Text), txtComment.Text);

            UpdateStatus("Saving..", 50);
            Winform_AlterationsDetails altDetails = Application.OpenForms["Winform_AlterationsDetails"] as Winform_AlterationsDetails;
            if (altDetails != null)
                altDetails.UpdateAlterationListControl(altItem, index);

            UpdateStatus("Saving..", 100);
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
