using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using System.Text.RegularExpressions;
using Equin.ApplicationFramework;

namespace SpindleSoft.Views
{
    public partial class Winform_CustomerRegister : winform_Register
    {
        public Winform_CustomerRegister()
        {
            InitializeComponent();
        }

        #region Events
        private void Winform_CustomerRegister_Load(object sender, EventArgs e)
        {
            dgvCustomerRegister_ReloadRegister(this, new EventArgs());
        }

        private void dgvCustomerRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int custID = int.Parse(dgvCustomerRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            Customer _cust = Builders.PeoplePracticeBuilder.GetCustomerInfo(int.Parse(custID.ToString()));

            Winform_OrderDetails orderDetails = Application.OpenForms["Winform_OrderDetails"] as Winform_OrderDetails;
            if (orderDetails != null)
            {
                orderDetails.UpdateCustomerControl(_cust);
                this.Close();
                return;
            }

            WinForm_CustomerDetails custDetails = Application.OpenForms["WinForm_CustomerDetails"] as WinForm_CustomerDetails;
            if (custDetails != null)
            {
                custDetails.UpdateCustomerControl(_cust);
                this.Close();
                return;
            }

            Winform_AlterationsDetails altDetails = Application.OpenForms["Winform_AlterationsDetails"] as Winform_AlterationsDetails;
            if (altDetails != null)
            {
                altDetails.UpdateCustomerControl(_cust);
                this.Close();
                return;
            }

            Winform_SalesDetails saleDetails = Application.OpenForms["Winform_SalesDetails"] as Winform_SalesDetails;
            if (saleDetails != null)
            {
                saleDetails.UpdateCustomerControl(_cust);
                this.Close();
                return;
            }

            if (dgvCustomerRegister.Columns["colDelete"].Index == e.ColumnIndex)
            {
                DialogResult dr = MessageBox.Show("Do you want to delete Customer " + dgvCustomerRegister.Rows[e.RowIndex].Cells["Name"].Value + "?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

                new WinForm_CustomerDetails(_cust, _inEdit).ShowDialog();
                dgvCustomerRegister_ReloadRegister(this, new EventArgs());
            }
        }

        private void dgvCustomerRegister_ReloadRegister(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);

            var custList = PeoplePracticeBuilder.GetCustomersList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
            if (custList != null && custList.Count != 0)
            {
                dgvCustomerRegister.DataSource = custList;
                colEdit.Visible = colDelete.Visible = true;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvCustomerRegister.Columns.Count - 1;
            }
            else
            {
                dgvCustomerRegister.DataSource = null;
                colEdit.Visible = colDelete.Visible = false;
            }
            UpdateStatus((dgvCustomerRegister.RowCount == 0) ? "No Results Found" : dgvCustomerRegister.RowCount + " Results Found", 100);
        }

        private void dgvCustomerRegister_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvCustomerRegister_CellClick(this, new DataGridViewCellEventArgs(dgvCustomerRegister.CurrentCell.ColumnIndex, dgvCustomerRegister.CurrentCell.RowIndex));
            }
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new WinForm_CustomerDetails().ShowDialog();
            dgvCustomerRegister_ReloadRegister(this, new EventArgs());
        }
        #endregion Events
    }
}
