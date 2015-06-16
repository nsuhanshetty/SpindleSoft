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
    public partial class Winform_VendorsRegister : Form
    {
        Vendors vendor = new Vendors();
        public Winform_VendorsRegister()
        {
            InitializeComponent();
        }

        private void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails().ShowDialog();
        }

        public void LoadDgv()
        {
            dgvSearch.DataSource = PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text);
            dgvSearch.Columns.Remove("BankUserName");
            dgvSearch.Columns.Remove("BankName");
            dgvSearch.Columns.Remove("IFSCCode");
            dgvSearch.Columns.Remove("Address");
            dgvSearch.Columns.Remove("AccNo");

            //todo: remove the additional columns on load itself
            //dgvSearch.DataSource = SpindleSoft.Builders.PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text);

            if (dgvSearch.RowCount == 0)
                lblStatus.Text = "No Results found.";
            else
                lblStatus.Text = dgvSearch.RowCount + " Results found.";
            progBarStatus.Value = 100;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Searching..";
            progBarStatus.Value = 50;

            LoadDgv();
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.RowCount == 0) return;

            WinForm_SKUDetails skuDetails = Application.OpenForms["WinForm_SKUDetails"] as WinForm_SKUDetails;
            if (skuDetails != null)
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to add Vendor Details to Sale " +
                                            Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value),
                                            "Add Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2);

                if (_dialogResult == DialogResult.No) return;

                vendor.MobileNo = dgvSearch.Rows[e.RowIndex].Cells["MobileNo"].Value.ToString();
                vendor.Name = dgvSearch.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                vendor.ID = Convert.ToInt32(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value);

                skuDetails.UpdateVendorDetails(vendor);
                this.Close();
            }
            else
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to Edit " +
                                           Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value),
                                           "Add Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button2);
                if (_dialogResult == DialogResult.No) return;

                vendor = PeoplePracticeBuilder.GetVendorInfo(dgvSearch.Rows[e.RowIndex].Cells["MobileNo"].Value.ToString());
                new Winform_VendorDetails(vendor).ShowDialog();
            }

        }

    }
}
