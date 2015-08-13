﻿using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;
using SpindleSoft.Builders;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffRegister : Form
    {
        public Winform_StaffRegister()
        {
            InitializeComponent();
        }

        #region Validation
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtName.Text)) return;

            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtName, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtName.TextLength);
            }
        }

      //  private void txtMobNo_Validating(object sender, CancelEventArgs e)
      //  {
      //      if (String.IsNullOrEmpty(txtMobNo.Text)) return;

      //      Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
      //      string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      //"For example '9880123456'";
      //      errorProvider1.SetError(txtMobNo, errorMsg);

      //      if (errorMsg != "")
      //      {
      //          // Cancel the event and select the text to be corrected by the user.
      //          e.Cancel = true;
      //          txtMobNo.Select(0, txtMobNo.TextLength);
      //      }
      //  }

      //  private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
      //  {
      //      if (String.IsNullOrEmpty(txtPhoneNo.Text)) return;

      //      Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
      //      string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      //"For example '9880123456'";
      //      errorProvider1.SetError(txtPhoneNo, errorMsg);

      //      if (errorMsg != "")
      //      {
      //          // Cancel the event and select the text to be corrected by the user.
      //          e.Cancel = true;
      //          txtPhoneNo.Select(0, txtPhoneNo.TextLength);
      //      }
      //  }
        #endregion Validation

        #region Events
        private void dgvStaffRregister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Staff " +
                                         Convert.ToString(dgvStaffRregister.Rows[e.RowIndex].Cells[1].Value),
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            int _ID = int.Parse(dgvStaffRregister.Rows[e.RowIndex].Cells[0].Value.ToString());
            SpindleSoft.Model.Staff _staff = PeoplePracticeBuilder.GetStaffInfo(_ID);
            _staff.Image = PeoplePracticeBuilder.GetStaffImage(_staff.ID);
            _staff.SecurityDocuments = PeoplePracticeBuilder.GetDocumentList(_staff.SecurityDocuments);

            new Winform_StaffDetails(_staff).ShowDialog();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Searching..";
            progBarStatus.Value = 50;
            dgvStaffRregister.DataSource =
                (from _staff in (SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text))
                select new { _staff.ID,_staff.Name,_staff.Mobile_No,_staff.Phone_No}).ToList();

            if (dgvStaffRregister.RowCount == 0)
                lblStatus.Text = "No Results found.";
            else
                lblStatus.Text = dgvStaffRregister.RowCount + " Results found.";
            progBarStatus.Value = 100;
        }
        #endregion Events
    }
}