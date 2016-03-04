using SpindleSoft.Model;
using System;
using System.Windows.Forms;
using SpindleSoft.Builders;
using SpindleSoft.Savers;

namespace SpindleSoft.Views
{
    public partial class Winform_OrderRegister : winform_Register
    {
        #region ctor
        public Winform_OrderRegister()
        {
            InitializeComponent();
        }
        #endregion ctor

        #region Event
        private void Winform_OrderRegister_Load(object sender, EventArgs e)
        {
            dgvSearch_ReloadRegister(this, new EventArgs());
        }

        private void dgvSearch_ReloadRegister(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);
            System.Collections.IList OrdersList = (OrderBuilder.GetOrdersList(txtName.Text, txtMobNo.Text, txtOrderId.Text));
            if (OrdersList != null && OrdersList.Count != 0)
            {
                dgvSearch.DataSource = OrdersList;
                colEdit.Visible = colDelete.Visible = true;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvSearch.Columns.Count - 1;
            }
            else
            {
                dgvSearch.DataSource = null;
                colEdit.Visible = colDelete.Visible = false;
            }
            UpdateStatus((dgvSearch.RowCount == 0) ? "No Results Found" : dgvSearch.RowCount + " Results Found", 100);
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_OrderDetails().ShowDialog();
            dgvSearch_ReloadRegister(this, new EventArgs());
        }

        private void dgvSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSearch_CellClick(this, new DataGridViewCellEventArgs(dgvSearch.CurrentCell.ColumnIndex, dgvSearch.CurrentCell.RowIndex));
            }
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int orderID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString());
            if (dgvSearch.Columns["colDelete"].Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete Order " + dgvSearch.Rows[e.RowIndex].Cells["Name"].Value + "?",
                                  "Delete Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                bool success = OrderSaver.DeleteOrder(orderID);
                if (success)
                {
                    dgvSearch_ReloadRegister(this, new EventArgs());
                    UpdateStatus("Order Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Order. ", 100);
                }
            }
            else
            {
                bool _inEdit = false;
                if (dgvSearch.Columns["colEdit"].Index == e.ColumnIndex)
                {
                    DialogResult dr = MessageBox.Show("Do you want to Edit Customer " + dgvSearch.Rows[e.RowIndex].Cells["Name"].Value + " details",
                                     "Edit Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                    _inEdit = true;
                }

                Orders order = OrderBuilder.GetOrderInfo(orderID);
                new Winform_OrderDetails(order, _inEdit).ShowDialog();
                dgvSearch_ReloadRegister(this, new EventArgs());
            }
        }
        #endregion Event
    }
}