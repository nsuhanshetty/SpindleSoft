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

        #region Ctor
        public Winform_VendorsRegister()
        {
            InitializeComponent();
        }
        #endregion Ctor

        #region Events
        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_VendorDetails().ShowDialog();
            dgvSearch_ReloadRegister(this, new EventArgs());
        }

        private void dgvSearch_ReloadRegister(object sender, EventArgs e)
        {
            dgvSearch.DataSource = null;
            UpdateStatus("Searching..", 50);
            LoadDgv();
        }

        private void Winform_VendorsRegister_Load(object sender, EventArgs e)
        {
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
                int vendID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                if (dgvSearch.Columns["colDelete"].Index == e.ColumnIndex)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete Vendor " + dgvSearch.Rows[e.RowIndex].Cells["Name"].Value + "?", "Delete Vendor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    bool success = Savers.PeoplePracticeSaver.DeleteVendor(vendID);
                    if (success)
                    {
                        dgvSearch_ReloadRegister(this, new EventArgs());
                        UpdateStatus("Vendor Deleted.", 100);
                    }
                    else
                    {
                        UpdateStatus("Error deleting Vendor. ", 100);
                    }
                }
                else
                {
                    bool _inEdit = false;
                    if (dgvSearch.Columns["colEdit"].Index == e.ColumnIndex)
                    {
                        DialogResult _dialogResult = MessageBox.Show("Do you want to Edit " +
                                                   Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["Name"].Value),
                                                   "Add Vendor Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                   MessageBoxDefaultButton.Button2);
                        if (_dialogResult == DialogResult.No) return;
                        _inEdit = true;
                    }

                    vendor = PeoplePracticeBuilder.GetVendorInfo(vendID);
                    new Winform_VendorDetails(vendor, _inEdit).ShowDialog();
                    dgvSearch_ReloadRegister(this, new EventArgs());
                }
            }
        }
        #endregion Events

        #region Custom
        public void LoadDgv()
        {
            dgvSearch.DataSource = null;
            var colEdit = dgvSearch.Columns["colEdit"];
            var colDelete = dgvSearch.Columns["colDelete"];

            var dgvValue = PeoplePracticeBuilder.GetVendorsList(txtName.Text, txtMobNo.Text);
            if (dgvValue.Count == 0)
            {
                dgvSearch.DataSource = null;
                colEdit.Visible = colDelete.Visible = false;
            }
            else
            {
                dgvSearch.DataSource = dgvValue;
                dgvSearch.Columns["ID"].Visible = false;
                colEdit.Visible = colDelete.Visible = true;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvSearch.Columns.Count - 1;
            }

            UpdateStatus((dgvSearch.RowCount == 0) ? "No Results Found" : dgvSearch.RowCount + " Results Found", 100);
        }
        #endregion Custom
    }
}
