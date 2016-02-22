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
            dgvSearch_ReloadRegister(this, new EventArgs());
        }

        private void dgvSearch_ReloadRegister(object sender, EventArgs e)
        {
            dgvSearch.Columns["colDelete"].Visible = false;

            System.Collections.IList OrdersList = (OrderBuilder.GetOrdersList(txtName.Text, txtMobNo.Text, txtOrderId.Text));
            if (OrdersList != null && OrdersList.Count != 0)
            {
                dgvSearch.DataSource = OrdersList;

                dgvSearch.Columns["colDelete"].DisplayIndex = dgvSearch.Columns.Count - 1;
                dgvSearch.Columns["colDelete"].Visible = true;
            }
            else
            {
                dgvSearch.DataSource = null;
                dgvSearch.Columns["colDelete"].Visible = true;
            }
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == dgvSearch.Columns["colDelete"].Index) return;

            this.Cursor = Cursors.WaitCursor;
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
            this.Cursor = Cursors.Arrow;
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

        private void dgvSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSearch_CellDoubleClick(this, new DataGridViewCellEventArgs(dgvSearch.CurrentCell.ColumnIndex, dgvSearch.CurrentCell.RowIndex));
            }
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int orderID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            if (dgvSearch.Columns["colDelete"].Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete Order " + dgvSearch.Rows[e.RowIndex].Cells["Name"].Value + "?", "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool success = Savers.PeoplePracticeSaver.DeleteCustomer(custID);
                if (success)
                {
                    dgvCustomerRegister_ReloadRegister(this, new EventArgs());
                    UpdateStatus("Customer Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Customer. ", 100);
                }
            }
            else
            {
                bool _inEdit = false;
                if (dgvCustomerRegister.Columns["colEdit"].Index == e.ColumnIndex)
                {
                    DialogResult dr = MessageBox.Show("Do you want to Edit Customer " + dgvCustomerRegister.Rows[e.RowIndex].Cells["Name"].Value + " details", "Edit Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                    _inEdit = true;
                }

                Customer _customer = PeoplePracticeBuilder.GetCustomerInfo(custID);
                new WinForm_CustomerDetails(_customer, _inEdit).ShowDialog();
                dgvCustomerRegister_ReloadRegister(this, new EventArgs());
            }
        }
    }
}