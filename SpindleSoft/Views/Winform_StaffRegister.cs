using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;
using SpindleSoft.Builders;
using System.Threading.Tasks;
using SpindleSoft.Model;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffRegister : winform_Register
    {
        #region ctor
        public Winform_StaffRegister()
        {
            InitializeComponent();
        }
        #endregion ctor

        #region Events
        private void Winform_StaffRegister_ReloadRegister(object sender, EventArgs e)
        {
            UpdateStatus("Searching..", 50);
            var colEdit = dgvStaffRregister.Columns["colEdit"];
            var colDelete = dgvStaffRregister.Columns["colDelete"];

            var staffList = SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
            if (staffList != null && staffList.Count != 0)
            {
                dgvStaffRregister.DataSource = staffList;
                colEdit.Visible = colDelete.Visible = true;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvStaffRregister.Columns.Count - 1;
            }
            else
            {
                dgvStaffRregister.DataSource = null;
                colEdit.Visible = colDelete.Visible = false;
            }
            UpdateStatus((dgvStaffRregister.RowCount == 0) ? "No Results Found." : dgvStaffRregister.RowCount + " Results Found.", 100);
        }

        private void Winform_StaffRegister_Load(object sender, EventArgs e)
        {
            Winform_StaffRegister_ReloadRegister(this, new EventArgs());
        }

        private void dgvStaffRregister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int staffID = int.Parse(dgvStaffRregister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            Winform_AddSalary addSalary = Application.OpenForms["Winform_AddSalary"] as Winform_AddSalary;
            if (addSalary != null)
            {
                DialogResult _dialogResult = MessageBox.Show("Do you want to add Staff Details to Add Salary form",
                                            "Add Staff Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                            MessageBoxDefaultButton.Button2);

                if (_dialogResult == DialogResult.No) return;

                Staff _staff = PeoplePracticeBuilder.GetStaffInfo(staffID);
                addSalary.UpdateStaffDetails(_staff);
                this.Close();
            }
            else
            {
                if (dgvStaffRregister.Columns["colDelete"].Index == e.ColumnIndex)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete Staff " + dgvStaffRregister.Rows[e.RowIndex].Cells["Name"].Value + "?", "Delete Staff", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    bool success = Savers.PeoplePracticeSaver.DeleteStaff(staffID);
                    if (success)
                    {
                        Winform_StaffRegister_ReloadRegister(this, new EventArgs());
                        UpdateStatus("Staff Deleted.", 100);
                    }
                    else
                    {
                        UpdateStatus("Error deleting Staff. ", 100);
                    }
                }
                else
                {
                    bool _inEdit = false;
                    if (dgvStaffRregister.Columns["colEdit"].Index == e.ColumnIndex)
                    {
                        DialogResult dr = MessageBox.Show("Do you want to Edit Staff " + dgvStaffRregister.Rows[e.RowIndex].Cells["Name"].Value + " details ?", "Edit Staff Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.No) return;
                        _inEdit = true;
                    }

                    Staff _staff = PeoplePracticeBuilder.GetStaffInfo(staffID);
                    PeoplePracticeBuilder.GetSecurityDocumentListLocal(_staff.SecurityDocuments);
                    new Winform_StaffDetails(_staff, _inEdit).ShowDialog();
                    Winform_StaffRegister_ReloadRegister(this, new EventArgs());
                }
            }
        }

        private void dgvStaffRregister_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvStaffRregister_CellClick(this, new DataGridViewCellEventArgs(dgvStaffRregister.CurrentCell.ColumnIndex, dgvStaffRregister.CurrentCell.RowIndex));
            }
        }

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_StaffDetails().ShowDialog();
            Winform_StaffRegister_ReloadRegister(this, new EventArgs());
        }
        #endregion Events
    }
}