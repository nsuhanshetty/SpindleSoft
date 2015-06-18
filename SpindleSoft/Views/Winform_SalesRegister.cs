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
            //todo : Check txtboxes for sql injection
            List<Sale> salesList = (SaleBuilder.GetSalesList(txtName.Text, txtProCode.Text, txtMobNo.Text, txtSaleID.Text));
            if (salesList != null)
            {
                dgvSearch.DataSource = (from sale in salesList
                                        select new { SaleID = sale.ID, sale.TotalPrice, sale.AmountPaid, sale.DateOfSale }).ToList();
            }
            else
                dgvSearch.DataSource = null;
        }

        //dgv datasource = product name, code, selling price, sale date, quantity
    }
}
