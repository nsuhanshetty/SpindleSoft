using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_DocumentDetails : Winform_DetailsFormat
    {
        Document document;
        public Winform_DocumentDetails(Document _document = null, bool _inEdit = false)
        {
            InitializeComponent();
            this.document = _document;
            InEdit = _inEdit;

            if (_document != null)
            {
                document = _document;
                pcbDocImage.Image = _document.Image;
            }
            
            if (!InEdit)
            {
                WinFormControls_InEdit(this);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }

        private void Winform_DocumentDetails_Load(object sender, EventArgs e)
        {
            List<string> docTypeList = null;

            /*load and autopopulate all the document Types from db*/
            Winform_StaffDetails staffDetails = Application.OpenForms["Winform_StaffDetails"] as Winform_StaffDetails;
            if (Application.OpenForms["Winform_StaffDetails"] as Winform_StaffDetails != null)
            {
                docTypeList = Builders.PeoplePracticeBuilder.GetSecurityDocumentTypeList();
            }
            else if (Application.OpenForms["Winform_MeasurementAdd"] as Winform_MeasurementAdd != null)
            {
                docTypeList = Builders.OrderBuilder.GetOrderItemDocumentTypeList();
            }
            else if (Application.OpenForms["WinForm_SKUDetails"] as WinForm_SKUDetails != null)
            {
                docTypeList = Builders.SaleBuilder.GetSKUItemDocumentTypeList();
            }


            if (document != null && docTypeList.IndexOf(document.Type) == -1)
                docTypeList.Add(document.Type);

            cmbDocType.DataSource = null;
            cmbDocType.DataSource = docTypeList;

            string[] docNames = docTypeList.ToArray();
            var nameCollection = new AutoCompleteStringCollection();
            nameCollection.AddRange(docNames);

            cmbDocType.AutoCompleteCustomSource = nameCollection;
            cmbDocType.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbDocType.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (document != null)
            {
                cmbDocType.SelectedIndex = docTypeList.IndexOf(document.Type);
            }
        }

        private void cmbDocType_Validating(object sender, CancelEventArgs e)
        {
            string errorText = string.Empty;
            if (string.IsNullOrEmpty(cmbDocType.Text))
                errorText = "Document Type cannot be Empty";

            //regex
            Match _match = Regex.Match(cmbDocType.Text, "^[a-zA-Z\\s]+$");
            string errorMsg = _match.Success ? "" : "Invalid Input for Name\n" +
                                                    "For example 'abcDocument'";
            errorProvider1.SetError(cmbDocType, errorMsg);

            if (errorMsg != "")
            {
                e.Cancel = true;
                cmbDocType.Select(0, cmbDocType.Text.Length);
            }
        }

        private void cmbDocType_Validated(object sender, EventArgs e)
        {
            cmbDocType.Text = Utilities.Validation.ToTitleCase(cmbDocType.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.Cancel) return;

            pcbDocImage.Image = new System.Drawing.Bitmap(openFileDialog1.FileName);
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            ProcessTabKey(true);

            if (String.IsNullOrEmpty(cmbDocType.Text))
            {
                errorProvider1.SetError(cmbDocType, "Select Document Type.");
                return;
            }
            else if (pcbDocImage.Image == null)
            {
                MessageBox.Show("Select Document to be added", "Add Document", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (document == null)
                document = new Document();
            document.Type = cmbDocType.Text;
            document.Image = pcbDocImage.Image;

            Winform_StaffDetails staffDetails = Application.OpenForms["Winform_StaffDetails"] as Winform_StaffDetails;
            if (staffDetails != null)
            {
                bool success = staffDetails.UpdateDocumentItemList(document);
                if (!success)
                {
                    MessageBox.Show("Cannot add new Document of type " + document.Type + " as it already exits.", "Document already exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Winform_MeasurementAdd measurementDetails = Application.OpenForms["Winform_MeasurementAdd"] as Winform_MeasurementAdd;
            if (measurementDetails != null)
            {
                bool success = measurementDetails.UpdateDocumentItemList(document);
                if (!success)
                {
                    MessageBox.Show("Cannot add new Document of type " + document.Type + " as it already exits.", "Document already exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            WinForm_SKUDetails _skuDetails = Application.OpenForms["WinForm_SKUDetails"] as WinForm_SKUDetails;
            if (_skuDetails != null)
            {
                bool success = _skuDetails.UpdateDocumentItemList(document);
                if (!success)
                {
                    MessageBox.Show("Cannot add new Document of type " + document.Type + " as it already exits.", "Document already exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCaptureImage_Click(object sender, EventArgs e)
        {
            Winform_ImageCapture _imageCapture = new Winform_ImageCapture(this.pcbDocImage);
            _imageCapture.ShowDialog();
        }
    }
}
