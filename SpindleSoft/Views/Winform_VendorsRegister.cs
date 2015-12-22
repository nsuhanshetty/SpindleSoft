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
    public partial class Winform_VendorsRegister : winform_Register
    {
        Vendor vendor = new Vendor();
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
            var dgvValue =PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text);

            if (dgvValue.Count == 0)
            {
                dgvSearch.DataSource = null;
            }
            else
            {
                var venList = (from vend in dgvValue select new { vend.ID, vend.Name, vend.MobileNo, vend.Address }).ToList();
                dgvSearch.DataSource = venList;
                dgvSearch.Columns["ID"].Visible = false;
            }

            UpdateStatus(dgvSearch.RowCount + " Results found.", 100);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;
            if (string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text))
            {
                UpdateStatus("No Results found.", 100);
                return;
            }

            UpdateStatus("Searching..", 50);
            LoadDgv();
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var row = dgvSearch.Rows[e.RowIndex];

            WinForm_SKUDetails skuDetails = Application.OpenForms["WinForm_SKUDetails"] as WinForm_SKUDetails;
            if (skuDetails != null)
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to add Vendor Details to Sale " +
                                            Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value),
                                            "Add Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2);

                if (_dialogResult == DialogResult.No) return;


                vendor.MobileNo = row.Cells["MobileNo"].Value.ToString();
                vendor.Name = row.Cells["Name"].Value.ToString();
                vendor.ID = Convert.ToInt32(row.Cells["ID"].Value);

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

                vendor = PeoplePracticeBuilder.GetVendorInfo(int.Parse(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString()));
                new Winform_VendorDetails(vendor).ShowDialog();
            }

        }

    }
}
