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
using Dropbox.Api;
using System.Threading.Tasks;

namespace SpindleSoft.Views
{
    public partial class Winform_StaffDetails : Winform_DetailsFormat
    {
        Staff _staff;
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
            txtDesignation.Text = _staff.Designation;

            txtUserBankName.Text = _staff.BankUserName;
            txtAccNo.Text = _staff.AccNo;
            txtIFSCNo.Text = _staff.IfscCode;

            rdbPerm.Checked = !_staff.IsTemporary;
            rdbTemp.Checked = _staff.IsTemporary;

            if (_staff.SecurityDocuments != null && _staff.SecurityDocuments.Count != 0)
            {
                docList = _staff.SecurityDocuments as List<Document>;
                foreach (Document doc in _staff.SecurityDocuments)
                {
                    int index = _staff.SecurityDocuments.IndexOf(doc);
                    dgvSecurityDoc.Rows.Add();

                    dgvSecurityDoc.Rows[index].Cells["colDocType"].Value = doc.Type;
                }
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
            string[] input = { "txtPhoneNo", "pcbStaffImage" };
            if (Utilities.Validation.IsNullOrEmpty(this, true, new List<string>(input)))
            {
                return;
            }

            UpdateStatus("Validating..", 25);
            //set customer

            if (this._staff == null)
                this._staff = new Staff();

            this._staff.Name = txtName.Text;
            this._staff.Mobile_No = txtMobNo.Text;
            this._staff.Address = txtAddress.Text;
            this._staff.Phone_No = txtPhoneNo.Text;
            this._staff.Image = pcbStaffImage.Image;
            this._staff.Designation = txtDesignation.Text;
            this._staff.IsTemporary = rdbPerm.Checked == true ? false : true;

            if (!PeoplePracticeBuilder.IfBankExits(cmbBankName.Text))
                this._staff.Bank = new Bank(cmbBankName.Text);
            else
                this._staff.Bank = Builders.PeoplePracticeBuilder.GetBankNames(cmbBankName.Text);

            //this._staff.Bank = cmbBankName.Text;
            this._staff.BankUserName = txtUserBankName.Text;
            this._staff.AccNo = txtAccNo.Text;
            this._staff.IfscCode = txtIFSCNo.Text;

            this._staff.SecurityDocuments = docList;

            UpdateStatus("Saving..", 25);

            UpdateStatus("Saving Staff Info..", 50);
            int _ID = PeoplePracticeSaver.SaveStaffInfo(this._staff);

            bool response = false;
            if (_ID != 0)
            {
            UpdateStatus("Saving Staff Documents..", 75);
            //Task<bool> _task = PeoplePracticeSaver.SaveStaffDocumentAsync(docList, _ID);
            //_task.Start();
            response = PeoplePracticeSaver.SaveStaffDocumentAsync(docList, _ID);
            }
            
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
            if (e.RowIndex == -1) return;

            if (IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value))
            {
                MessageBox.Show("Document Type is Mandatory", "Enter Document Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                DialogResult dr = MessageBox.Show("Continue Editing the Documents?", "Edit Document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //open document
                    new Winform_DocumentDetails(_staff.SecurityDocuments[e.RowIndex]).ShowDialog();
                }
            }
            else if (e.ColumnIndex == 1) //delete Document
            {
                if (IsNullOrEmpty(dgvSecurityDoc.Rows[e.RowIndex].Cells[0].Value))
                    return;

                if (dgvSecurityDoc.Columns["colDelete"].Index == e.ColumnIndex)
                {
                    DialogResult dres = MessageBox.Show("Continue deleting selected Document?", "Delete Document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dres == DialogResult.No) return;

                    if (docList.Count != 0 && e.RowIndex + 1 <= docList.Count)
                    {
                        bool success = false;
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
            }
        }

        private void Winform_StaffDetails_Load(object sender, EventArgs e)
        {


            List<string> docTypeList = PeoplePracticeBuilder.GetDocumentTypeList();
            List<Bank> BankList = PeoplePracticeBuilder.GetBankNames();

            cmbBankName.DataSource = BankList;
            cmbBankName.DisplayMember = "Name";
            cmbBankName.ValueMember = "ID";

            string[] bankNames = BankList.Select(x => x.Name).ToArray();
            var nameCollection = new AutoCompleteStringCollection();
            nameCollection.AddRange(bankNames);

            cmbBankName.AutoCompleteCustomSource = nameCollection;
            cmbBankName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbBankName.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbBankName.Text = "";
            if (this._staff != null)
                cmbBankName.SelectedText = this._staff.Bank.Name;
        }

        private void dgvSecurityDoc_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Winform_StaffDetails));
            log.Error(e.Context);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new Winform_DocumentDetails().ShowDialog();
        }

        internal bool UpdateDocumentItemList(Document _doc)
        {
            var docindex = docList.IndexOf(docList.Where(x => x.Type == _doc.Type).SingleOrDefault());
            if (docindex != -1 && _doc.ID == 0)
            {
                return false;
            }
            else if (docList.Count == 0 || docindex == -1)
            {
                docList.Add(_doc);
                dgvSecurityDoc.Rows.Add();
                docindex = dgvSecurityDoc.Rows.Count - 1;
            }
            else
                docList[docindex] = _doc;

            dgvSecurityDoc.Rows[docindex].Cells["colDocType"].Value = _doc.Type;
            return true;
        }
    }
}