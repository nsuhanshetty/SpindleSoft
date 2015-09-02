using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using SpindleSoft.Builders;
using SpindleSoft.Savers;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderRegister : Form
    {
        public Winform_OrderRegister()
        {
            InitializeComponent();
        }

        private void Winform_OrderRegister_Load(object sender, EventArgs e)
        {
            txtName_TextChanged(this, new EventArgs());
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //todo : Check txtboxes for sql injection
            List<Orders> OrdersList = (OrderBuilder.GetOrdersList(txtName.Text, txtMobNo.Text, txtOrderId.Text));
            if (OrdersList != null)
            {
                dgvSearch.DataSource = (from order in OrdersList
                                        select new
                                        {
                                            OrderID = order.ID,
                                            order.TotalPrice,
                                            AmountPaid = order.CurrentPayment,
                                            PromisedDate = order.PromisedDate
                                        }).ToList();
                dgvSearch.Columns["colDelete"].DisplayIndex = dgvSearch.Columns.Count - 1;
            }
            else
                dgvSearch.DataSource = null;
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == dgvSearch.Columns["colDelete"].Index) return;

            statusStrip1.Text = "Gathering Data..";
            toolStripProgressBar1.Value = 25;
            if (dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value == null) return;
            int orderID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());

            statusStrip1.Text = "Gathering Data..";
            toolStripProgressBar1.Value = 50;

            Orders order = OrderBuilder.GetOrderInfo(orderID);
            if (order == null)
            {
                statusStrip1.Text = "Error While Fetching Data..";
                toolStripProgressBar1.Value = 100;
                return;
            }
            statusStrip1.Text = "Setting Up Controls.";
            toolStripProgressBar1.Value = 100;
            new Winform_OrderDetails(order).ShowDialog();
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value == null) return;
            int orderID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());

            if (e.ColumnIndex == dgvSearch.Columns["colDelete"].Index)
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete Order " + orderID, "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = OrderSaver.DeleteOrder(orderID);
                if (success == true)
                {
                    Winform_OrderRegister_Load(this, new EventArgs());
                    statusStrip1.Text = "Order Deleted.";
                }
                return;
            }
        }
    }
}