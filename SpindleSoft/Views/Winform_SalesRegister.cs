using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections;
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
    public partial class Winform_SalesRegister : winform_Register
    {
        #region ctor
        public Winform_SalesRegister()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void dgvSearch_ReloadRegister(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);
            List<Sale> salesList = (SaleBuilder.GetSalesList(txtName.Text, txtProCode.Text, txtMobNo.Text));
            if (salesList != null && salesList.Count != 0)
            {
                dgvSearch.DataSource = (from sale in salesList
                                        select new
                                        {
                                            sale.Customer.Name,
                                            SaleID = sale.ID,
                                            sale.TotalPrice,
                                            sale.AmountPaid,
                                            DateOfSale = sale.DateOfSale.Date.ToString("dd/MMM/yy")
                                        }).ToList();

                colDelete.Visible = true;
                colDelete.DisplayIndex = dgvSearch.Columns.Count - 1;
            }
            else
            {
                colDelete.Visible = false;
                dgvSaleItemDetails.DataSource = dgvSearch.DataSource = null;
            }
            UpdateStatus((dgvSearch.RowCount == 0) ? "No Results Found" : dgvSearch.RowCount + " Results Found", 100);
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int saleID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["SaleID"].Value.ToString());
            if (e.ColumnIndex == colDelete.Index)
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete Sale No. " + saleID, "Delete Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = SpindleSoft.Savers.SalesSaver.DeleteSale(saleID);
                if (success)
                {
                    dgvSearch_ReloadRegister(this, new EventArgs());
                    UpdateStatus("Sale Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Sale.", 100);
                }
            }
            else
            {
                if (dgvSearch.Rows.Count == 0) return;
                List<SKUItem> skuList = SaleBuilder.GetSalesItemList(dgvSearch.Rows[e.RowIndex].Cells["SaleID"].Value.ToString());
                dgvSaleItemDetails.DataSource = (skuList == null) ? null : (from s in skuList select new { s.Name, s.ProductCode, s.Color, s.Material, s.Size }).ToList();
            }
        }

        private void dgvSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSearch_CellClick(this, new DataGridViewCellEventArgs(dgvSearch.CurrentCell.ColumnIndex, dgvSearch.CurrentCell.RowIndex));
            }
        }

        private void Winform_SalesRegister_Load(object sender, EventArgs e)
        {
            dgvSearch_ReloadRegister(this, new EventArgs());
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_SalesDetails().ShowDialog();
            dgvSearch_ReloadRegister(this, new EventArgs());
        }
        #endregion
    }
}
