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

namespace SpindleSoft.Views
{
    public partial class Winform_SKURegister : Form
    {
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
            //todo : how do we add vendors name along with salename
            //bool isSelfMade = cmbSource.Text == "Self" ? true : false;
            dgvSearch.DataSource = SaleBuilder.GetSaleItems(txtName.Text, txtProCode.Text, txtDesc.Text, cmbColor.Text, cmbSize.Text, cmbMaterial.Text);

            dgvSearch.Columns.Remove("ID");
            dgvSearch.Columns.Remove("IsSelfMade");
            dgvSearch.Columns.Remove("Description");
            dgvSearch.Columns.Remove("VendorID");
            dgvSearch.Columns.Remove("SellingPrice");
            dgvSearch.Columns.Remove("CostPrice");

            //List<SaleItem> listSource =
            //listSource.Select(x => new {Name= x.Name,ProductCode = x.ProductCode, Color = x.Color, Size = x.Size, Material = x.Material, Vendor = x.}
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
            //load if the register is selected for add sku or edit sku
            Winform_SKURegister addSkuReg = Application.OpenForms["Winform_SKURegister"] as Winform_SKURegister;
            if (addSkuReg != null)
                addSkuReg.txtName_TextChanged(this, new EventArgs());
            else
            {
                try
                {
                    var procode = dgvSearch.Rows[e.RowIndex].Cells["ProductCode"].Value.ToString();
                    SKUItem _saleItem = SaleBuilder.GetSaleItemInfo(procode);
                    if (_saleItem != null)
                        new WinForm_SKUDetails(_saleItem).ShowDialog();
                }
                catch (Exception)
                {
                    //todo: log4net/ Spundle
                }
            }

        }

        //private void cmbSource_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    //cmbVendorName.Visible= cmbSource.Text == "Self" ? false : true;
        //}
    }
}
