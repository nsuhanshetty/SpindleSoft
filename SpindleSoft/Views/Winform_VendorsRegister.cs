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
            dgvSearch.DataSource = SpindleSoft.Builders.PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text);
            //dgvSearch.Columns.RemoveAt(0);
            //dgvSearch.Columns.RemoveAt(4);
            //dgvSearch.Columns.Remove("image");
            //dgvSearch.Columns.Remove("address");

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
            Vendors vendor = new Vendors();

            if (dgvSearch.RowCount == 0) return;

            DialogResult _dialogResult = MessageBox.Show("Do you want to add Vendor Details to Sale " +
                                        Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value),
                                        "Add Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            vendor.MobileNo = dgvSearch.Rows[e.RowIndex].Cells["MobileNo"].Value.ToString();
            vendor.Name = dgvSearch.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            vendor.ID = Convert.ToInt32(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value);

            WinForm_SKUDetails skuDetails = Application.OpenForms["WinForm_SKUDetails"] as WinForm_SKUDetails;
            if (skuDetails != null)
            {
                skuDetails.UpdateVendorDetails(vendor);
                this.Close();
            }
        }

    }
}
