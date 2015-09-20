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
    public partial class Winform_SalesRegister : Form
    {
        //private void LoadDGV()
        //{
        //    DataGridTableStyle myDataGridTableStyle = new DataGridTableStyle();
        //    DataGridTextBoxColumn txtColSaleID = new DataGridTextBoxColumn();
        //    DataGridTextBoxColumn txtColName = new DataGridTextBoxColumn();
        //    DataGridTextBoxColumn txtColMobileNo = new DataGridTextBoxColumn();
        //    DataGridTextBoxColumn txtColTotalPrice = new DataGridTextBoxColumn();
        //    DataGridTextBoxColumn txtColAmountPaid = new DataGridTextBoxColumn();
        //    DataGridTextBoxColumn txtColDateOfSale = new DataGridTextBoxColumn();

        //    txtColName.MappingName = "Name";
        //    txtColName.HeaderText = "Name";

        //    txtColSaleID.MappingName = "ID";
        //    txtColSaleID.HeaderText = "SaleID";

        //    txtColMobileNo.MappingName = "Mobile_No";
        //    txtColMobileNo.HeaderText = "MobileNo";

        //    txtColTotalPrice.MappingName = "TotalPrice";
        //    txtColTotalPrice.HeaderText = "TotalPrice";

        //    txtColAmountPaid.MappingName = "AmountPaid";
        //    txtColAmountPaid.HeaderText = "AmountPaid";

        //    txtColDateOfSale.MappingName = "DateOfSale";
        //    txtColDateOfSale.HeaderText = "DateOfSale";

        //    myDataGridTableStyle.GridColumnStyles.Add(txtColSaleID);
        //    myDataGridTableStyle.GridColumnStyles.Add(txtColName);
        //    myDataGridTableStyle.GridColumnStyles.Add(txtColMobileNo);
        //    myDataGridTableStyle.GridColumnStyles.Add(txtColTotalPrice);
        //    myDataGridTableStyle.GridColumnStyles.Add(txtColAmountPaid);
        //    myDataGridTableStyle.GridColumnStyles.Add(txtColDateOfSale);

        //    DataGrid datagrid = new DataGrid();
        //    datagrid.TableStyles.Add(myDataGridTableStyle);

        //}

        public Winform_SalesRegister()
        {
            InitializeComponent();
        }

        private void txtMobNo_TextChanged(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;
            dgvSearch.Columns["colDelete"].Visible = false;

            if (string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtProCode.Text))
                return;

            List<Sale> salesList = (SaleBuilder.GetSalesList(txtName.Text, txtProCode.Text, txtMobNo.Text));
            if (salesList != null)
            {
                dgvSearch.DataSource = (from sale in salesList
                                        select new
                                        {
                                            sale.Customer.Name,
                                            SaleID = sale.ID,
                                            sale.TotalPrice,
                                            sale.AmountPaid,
                                            sale.DateOfSale.Date
                                        }).ToList();

                dgvSearch.Columns["colDelete"].Visible = true;
                dgvSearch.Columns["colDelete"].DisplayIndex = dgvSearch.Columns.Count - 1;
            }

            dgvSaleItemDetails.DataSource = null;
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == dgvSearch.Columns["colDelete"].Index) return;

            //toolStrip_Label.Text = "Gathering Data..";
            //toolStripProgressBar1.Value = 25;
            //if (dgvSearch.Rows[e.RowIndex].Cells["SaleID"].Value == null) return;
            //int saleID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["SaleID"].Value.ToString());

            //toolStrip_Label.Text = "Gathering Data..";
            //toolStripProgressBar1.Value = 50;

            //Sale sale = SaleBuilder.GetSaleInfo(saleID);
            //if (sale == null)
            //{
            //    toolStrip_Label.Text = "Error While Fetching Data..";
            //    toolStripProgressBar1.Value = 100;
            //    return;
            //}
            //toolStrip_Label.Text = "Setting Up Controls.";
            //toolStripProgressBar1.Value = 100;
            //new Winform_SalesDetails(sale).ShowDialog();
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            int saleID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["SaleID"].Value.ToString());

            if (e.ColumnIndex == dgvSearch.Columns["colDelete"].Index)
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete Sale No. " + saleID, "Delete Sale", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = SpindleSoft.Savers.SalesSaver.DeleteSale(saleID);
                if (success == true)
                {
                    txtMobNo_TextChanged(this, new EventArgs());
                    toolStrip_Label.Text = "Sale Deleted.";
                }
                return;
            }

            if (dgvSearch.Rows.Count == 0) return;
            List<SKUItem> skuList = SaleBuilder.GetSalesItemList(dgvSearch.Rows[e.RowIndex].Cells["SaleID"].Value.ToString());

            if (skuList != null)
            {
                dgvSaleItemDetails.DataSource = (from s in skuList
                                                 select new { s.Name, s.ProductCode, s.Color, s.Material, s.Size }).ToList();
            }
            else
                dgvSaleItemDetails.DataSource = null;
        }

    }
}
