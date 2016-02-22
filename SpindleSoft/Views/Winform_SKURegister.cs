using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace SpindleSoft.Views
{
    public partial class Winform_SKURegister : Form
    {
        ILog log = LogManager.GetLogger(typeof(Winform_SKURegister));
        public Winform_SKURegister()
        {
            InitializeComponent();
        }

        private void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new WinForm_SKUDetails().ShowDialog();
        }

        public void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesc.Text) && string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtProCode.Text))
            {
                dgvSearch.DataSource = null;
                return;
            }

            //todo : how do we add vendors name along with salename
            //bool isSelfMade = cmbSource.Text == "Self" ? true : false;
            dgvSearch.DataSource = null;
            List<SKUItem> skulist = SaleBuilder.GetSKUItems(txtName.Text, txtProCode.Text, txtDesc.Text, cmbColor.Text, cmbSize.Text, cmbMaterial.Text);

            if (skulist == null || skulist.Count == 0) return;
            dgvSearch.DataSource = (from s in skulist
                                    select new { s.Name, s.ProductCode, s.Quantity, s.Size, s.Color, s.Material }).ToList();
        }

        private void Winform_SKURegister_Load(object sender, EventArgs e)
        {
            //Load ComboBox
            var ComboBoxResults = SaleBuilder.GetVariationValues();

            //todo: Can we add Items in a better way
            cmbSize.Items.Add("All");
            cmbSize.Items.AddRange(ComboBoxResults[2].ToArray());
            //cmbSize.Text = "All";

            cmbColor.Items.Add("All");
            cmbColor.Items.AddRange(ComboBoxResults[0].ToArray());
            //cmbColor.Text = "All";

            cmbMaterial.Items.Add("All");
            cmbMaterial.Items.AddRange(ComboBoxResults[1].ToArray());
            //cmbMaterial.Text = "All";

            //cmbVendorName.Items.AddRange(SaleBuilder.GetVendorNames().ToArray());
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var procode = dgvSearch.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString();
                SKUItem _saleItem = SaleBuilder.GetSkuItemInfo(procode);
                if (_saleItem != null)
                    new WinForm_SKUDetails(_saleItem).ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void dgvSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSearch_CellDoubleClick(this, new DataGridViewCellEventArgs(dgvSearch.CurrentCell.ColumnIndex, dgvSearch.CurrentCell.RowIndex));
            }
        }
    }
}
