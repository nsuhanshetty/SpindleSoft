using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using SpindleSoft.Builders;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffDetails : Winform_DetailsFormat
    {
        Staff _staff = new Staff();
        List<Document> docList = new List<Document>();

        #region Ctor
        public Winform_StaffDetails()
        {
            InitializeComponent();
        }

        public Winform_StaffDetails(Staff _staff)
        {
            InitializeComponent();

            this._staff = _staff;

            /*Load Controls*/
            txtAddress.Text = _staff.Address;
            txtMobNo.Text = _staff.Mobile_No;
            txtName.Text = _staff.Name;
            txtPhoneNo.Text = _staff.Phone_No;
            pcbStaffImage.Image = _staff.Image;

            txtBankName.Text = _staff.BankName;
            txtUserBankName.Text = _staff.BankUserName;
            txtAccNo.Text = _staff.AccNo;
            txtIFSCNo.Text = _staff.IfscCode;

            if (_staff.SecurityDocuments!= null && _staff.SecurityDocuments.Count != 0)
            {
                foreach (DataGridViewRow dr in dgvSecurityDoc.Rows)
                {
                    int index = dgvSecurityDoc.NewRowIndex;
                    dr.Cells[0].Value = _staff.SecurityDocuments[index].Type;
                    dr.Cells[1].Value = _staff.SecurityDocuments[index].Path;

                    dgvSecurityDoc.NotifyCurrentCellDirty(true);
                    dgvSecurityDoc.EndEdit();
                    dgvSecurityDoc.NotifyCurrentCellDirty(false);

                    docList.Add(_staff.SecurityDocuments[index]);
                }
            }

            if (_staff.IsTemporary)
            {
                rdbPerm.Checked = false;
                rdbTemp.Checked = true;
            }
            else
            {
                rdbPerm.Checked = true;
                rdbTemp.Checked = false;
            }
        }
        #endregion Ctor

        #region Validations
        private void txtName_Validated(object sender, EventArgs e)
        {
            txtName.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(txtName.Text);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtName.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Name\n" +
      "For example 'Geeta Prasad'";
            errorProvider1.SetError(txtName, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtName.Select(0, txtName.TextLength);
            }
        }

        private void txtMobNo_Validating(object sender, CancelEventArgs e)
        {
            Match _match = Regex.Match(txtMobNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Mobile Number\n" +
      "For example '9880123456'";
            errorProvider1.SetError(txtMobNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtMobNo.Select(0, txtMobNo.TextLength);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                string errorMsg = "Address field is mandatory";
                errorProvider1.SetError(txtAddress, errorMsg);
                e.Cancel = true;
                txtMobNo.Select(0, txtAddress.TextLength);
            }
            else
            {
                errorProvider1.SetError(txtAddress, "");
            }
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhoneNo.Text == String.Empty)
                return;

            Match _match = Regex.Match(txtPhoneNo.Text, "\\d{10}$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Phone Number\n" +
  " For example '8012345678'";
            errorProvider1.SetError(txtPhoneNo, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtPhoneNo.Select(0, txtPhoneNo.TextLength);
            }
        }
        #endregion Validations

        #region Events
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Winform_ImageCapture _imageCapture = new Winform_ImageCapture(this.pcbStaffImage);
            _imageCapture.ShowDialog();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };
            this.Close();
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            //need to handle this situation well
            string[] input = { "txtPhoneNo" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            UpdateStatus("Validating..", 25);
            //set customer
            this._staff.Name = txtName.Text;
            this._staff.Mobile_No = txtMobNo.Text;
            this._staff.Address = txtAddress.Text;
            this._staff.Phone_No = txtPhoneNo.Text;
            this._staff.Image = pcbStaffImage.Image;
            this._staff.IsTemporary = rdbPerm.Checked == true ? false : true;
            this._staff.BankName = txtBankName.Text;
            this._staff.BankUserName = txtUserBankName.Text;
            this._staff.AccNo = txtAccNo.Text;
            this._staff.IfscCode = txtIFSCNo.Text;

            this._staff.SecurityDocuments = docList;

            UpdateStatus("Saving Staff Info..", 50);
            int _ID = PeoplePracticeSaver.SaveStaffInfo(this._staff);

            UpdateStatus("Saving Staff Image..", 75);
            bool response = _ID != 0 ? PeoplePracticeSaver.SaveStaffImage(this._staff.Image, _ID) : false;

            response = response ? PeoplePracticeSaver.SaveStaffDocument(docList, _ID) : false;

            if (response)
            {
                UpdateStatus("Saved", 100);
                this.Close();
            }
            else
            {
                UpdateStatus("Error Saving Staff Details", 100);
            }
        }
        #endregion events

        private void dgvSecurityDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value))
            {
                MessageBox.Show("Document Type is Mandatory", "Enter Document Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Document doc = new Document();
            switch (e.ColumnIndex)
            {
                //dgvSecurityDoc.Columns["colDocAdd"].Index
                case 2:
                    DialogResult dr = openFileDialog1.ShowDialog();
                    if (dr == DialogResult.Cancel) return;

                    Document _doc = new Document();
                    _doc.Type = dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value.ToString();
                    _doc.Image = new System.Drawing.Bitmap(openFileDialog1.FileName);
                    UpdateDocumentList(_doc);

                    dgvSecurityDoc.Rows[e.RowIndex].Cells[1].Value = openFileDialog1.FileName;
                    dgvSecurityDoc.CurrentCell = dgvSecurityDoc.Rows[e.RowIndex].Cells[1];
                    dgvSecurityDoc.NotifyCurrentCellDirty(true);
                    dgvSecurityDoc.NotifyCurrentCellDirty(false);
                    break;

                //dgvSecurityDoc.Columns["colDocView"].Index
                case 3:
                    if (IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[1].Value) ||
                        IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value))
                        return;

                    new Winform_PictureBox(dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value.ToString(), dgvSecurityDoc.Rows[e.RowIndex].Cells[1].Value.ToString()).ShowDialog();
                    break;

                //dgvSecurityDoc.Columns["colDocDelete"].Index
                case 4:
                    if (IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[1].Value) ||
                        IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value))
                        return;
                    if (dgvSecurityDoc.Columns["colDelete"].Index == e.ColumnIndex)
                    {
                        DialogResult dres = MessageBox.Show("Continue deleting selected Document?", "Delete Document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dres == DialogResult.No) return;

                        bool success = false;

                        if (docList.Count != 0 && e.RowIndex + 1 <= docList.Count)
                        {
                            if (docList[e.RowIndex].ID != 0)
                                success = PeoplePracticeSaver.DeleteStaffDocument(docList[e.RowIndex].ID);

                            if (success || docList[e.RowIndex].ID == 0)
                            {
                                docList.RemoveAt(e.RowIndex);
                            }
                            else
                            {
                                MessageBox.Show("Could not delete the Item. Soemthing Nasty happened!!");
                                return;
                            }
                        }
                        dgvSecurityDoc.Rows.RemoveAt(e.RowIndex);
                    }
                    break;
                default:
                    break;
            }
        }

        internal void UpdateDocumentList(Document _doc)
        {
            var index = docList.IndexOf(docList.Where(x => x.Type == _doc.Type).SingleOrDefault());

            if (docList.Count == 0 || index == -1)
                docList.Add(_doc);
            else
                docList[index] = _doc;
        }

        void cbo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var currCell = (DataGridViewComboBoxCell)dgvOrderItems.CurrentCell;

            var value = (sender as ComboBox).Text;
            if (string.IsNullOrEmpty(value)) return;

            //if Product already selected inform to update.
            foreach (DataGridViewRow rows in dgvSecurityDoc.Rows)
            {
                if (rows != dgvSecurityDoc.CurrentRow && !rows.IsNewRow
                    && rows.Cells["colDocType"].Value.ToString() == value)
                {
                    MessageBox.Show("Document Selected Already exists in the Cart!", "Duplicate Document", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    (sender as ComboBox).Text = String.Empty;
                    e.Cancel = true;
                    return;
                }
            }

            if (this.colDocType.Items.IndexOf(value) == -1)
            {
                DataGridViewComboBoxCell cboCell = (DataGridViewComboBoxCell)dgvSecurityDoc.CurrentCell;

                this.colDocType.Items.Add(Utilities.Validation.ToTitleCase(value));
                cboCell.Value = value;
            }
        }

        private void dgvSecDocumet_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //Order item - select/ add item if not present.

            if (dgvSecurityDoc.CurrentCell == dgvSecurityDoc.CurrentRow.Cells["colDocType"])
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                    cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                    cb.Validating += new System.ComponentModel.CancelEventHandler(cbo_Validating);
                    //cb.Validated += new System.EventHandler(cbo_Validated);
                }
            }
        }

        private void Winform_StaffDetails_Load(object sender, EventArgs e)
        {
            List<string> docTypeList = PeoplePracticeBuilder.GetDocumentTypeList();
            if (docTypeList != null && docTypeList.Count != 0)
                this.colDocType.Items.AddRange(docTypeList.ToArray());
        }

        private void dgvSecurityDoc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Winform_StaffDetails));
            log.Error(e.Context);
        }
    }
}