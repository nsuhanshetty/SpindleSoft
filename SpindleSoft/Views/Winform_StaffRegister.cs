using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Linq;
using SpindleSoft.Builders;
using System.Threading.Tasks;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffRegister : winform_Register
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
        private async void dgvStaffRregister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Staff " +
                                         Convert.ToString(dgvStaffRregister.Rows[e.RowIndex].Cells[1].Value),
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;

            int flags;
            if (!Utilities.Validation.InternetGetConnectedState(out flags, 0))
            {
                UpdateStatus("Checking for internet connection", 50);
                UpdateStatus("Error connecting to Internet.", 0);
                DialogResult dr = MessageBox.Show("Error connecting to Internet, Do you want to continue as some of the documents might be missing", "Error connecting to Internet", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dr == DialogResult.No)
                    return;
            }

            this.Cursor = Cursors.WaitCursor;
            int _ID = int.Parse(dgvStaffRregister.Rows[e.RowIndex].Cells[0].Value.ToString());
            SpindleSoft.Model.Staff _staff = PeoplePracticeBuilder.GetStaffInfo(_ID);
            await PeoplePracticeBuilder.GetDocumentListAsync(_staff.SecurityDocuments);
            //_staff.Image = await Utilities.Helper.GetDocumentAsync("/staff_ProfilePictures", _staff.ID.ToString());

            new Winform_StaffDetails(_staff).ShowDialog();
            UpdateStatus("Ready", 0);
            this.Cursor = Cursors.Arrow;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvStaffRregister.DataSource = null;
            if (string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtPhoneNo.Text))
            {
                UpdateStatus("No Results found.", 100);
                return;
            }

            UpdateStatus("Searching..", 50);

            var staffList = (from _staff in (SpindleSoft.Builders.PeoplePracticeBuilder.GetStaffList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text))
                             select new { _staff.ID, _staff.Name, _staff.Mobile_No, _staff.Phone_No }).ToList();

            dgvStaffRregister.DataSource = staffList.Count == 0 ? null : staffList;

            UpdateStatus(dgvStaffRregister.RowCount + " Results found.", 100);
        }
        #endregion Events
    }
}