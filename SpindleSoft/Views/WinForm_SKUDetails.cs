using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Savers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;
using SpindleSoft.Utilities;

namespace SpindleSoft.Views
{
    public partial class WinForm_SKUDetails : Winform_DetailsFormat
    {
        Vendor vendor;
        SKUItem skuItem = new SKUItem();
        List<SKUItemDocument> docList = new List<SKUItemDocument>();

        #region ctor
        public WinForm_SKUDetails()
        {
            InitializeComponent();
            InEdit = true;
        }

        public WinForm_SKUDetails(SKUItem _saleItem, bool _inEdit = false)
        {
            this.skuItem = _saleItem;
            this.InEdit = _inEdit;

            InitializeComponent();
            if (!InEdit)
            {
                var exList = new List<string>() { "dgvItemSKUDoc", "groupBox6", "toolStripParent" };
                WinFormControls_InEdit(this, exList);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }
        #endregion

        #region Events
        private void WinForm_Sale_Load(object sender, EventArgs e)
        {
            this.toolStripParent.Items.Add(this.NewVendToolStrip);
            this.NewVendToolStrip.Alignment = ToolStripItemAlignment.Right;
            this.EditToolStrip.Visible = true;

            txtName.Text = this.skuItem.Name;
            txtCode.Text = this.skuItem.ProductCode;
            txtDesc.Text = this.skuItem.Description;
            txtQuantity.Text = this.skuItem.Quantity.ToString();
            txtCP.Text = this.skuItem.CostPrice.ToString();
            txtSP.Text = this.skuItem.SellingPrice.ToString();

            cmbColor.Text = this.skuItem.Color;
            cmbMaterial.Text = this.skuItem.Material;
            cmbSize.Text = this.skuItem.Size;

            if (skuItem.SKUItemDocuments != null && skuItem.SKUItemDocuments.Count != 0)
            {
                string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
                string _skuItemDocPath = Secrets.FileLocation["SKUItemDocs"];
                docList = this.skuItem.SKUItemDocuments.ToList();
                foreach (SKUItemDocument doc in docList)
                {
                    int index = docList.IndexOf(doc);
                    dgvItemSKUDoc.Rows.Add();
                    dgvItemSKUDoc.Rows[index].Cells["colDocType"].Value = doc.Type;

                    string filePath = string.Format("{0}/{1}/{2}_{3}.png", baseDoc, _skuItemDocPath, skuItem.ID, doc.Type);
                    doc.Image = Utilities.ImageHelper.GetDocumentLocal(filePath);
                }
            }

            if (!InEdit)
                dgvItemSKUDoc.Columns["ColDelete"].Visible = false;

            if (this.skuItem.IsSelfMade)
            {
                rdbSelfMade.Checked = true;
                txtVendName.Text = "";
                txtVendMobile.Text = "";
            }
            else
            {
                rdbVendorMade.Checked = true;
                vendor = SaleBuilder.GetVendorsInfo(this.skuItem.VendorID);
                if (vendor != null)
                {
                    txtVendMobile.Text = vendor.MobileNo;
                    txtVendName.Text = vendor.Name;
                }
            }

            var ComboBoxResults = SaleBuilder.GetVariationValues();
            cmbSize.Items.AddRange(ComboBoxResults[2].ToArray());
            cmbColor.Items.AddRange(ComboBoxResults[0].ToArray());
            cmbMaterial.Items.AddRange(ComboBoxResults[1].ToArray());
        }

        private void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_VendorsRegister().ShowDialog();
        }

        private void rdbSelfMade_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSelfMade.Checked)
            {
                UpdateVendorDetails();
                this.NewVendToolStrip.Enabled = false;
            }
            else
            {
                this.NewVendToolStrip.Enabled = true;
            }
        }


        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            string[] input = { "txtVendMobile", "txtVendName", "txtCP" };
            var list = rdbVendorMade.Checked ? null : new List<string>(input);

            if (Utilities.Validation.IsNullOrEmpty(this, true, list))
            {
                return;
            }

            //todo: use delegate to cut overhead of UpdateStatus();
            UpdateStatus("Saving..", 25);
            skuItem.Name = txtName.Text;
            skuItem.Description = txtDesc.Text;
            skuItem.CostPrice = string.IsNullOrEmpty(txtCP.Text) ? 0 : Convert.ToInt32(txtCP.Text);
            skuItem.SellingPrice = string.IsNullOrEmpty(txtSP.Text) ? 0 : Convert.ToInt32(txtSP.Text);
            skuItem.Size = cmbSize.Text;
            skuItem.Color = cmbColor.Text;
            skuItem.Material = cmbMaterial.Text;
            skuItem.IsSelfMade = (rdbSelfMade.Checked) ? true : false;
            skuItem.VendorID = (rdbSelfMade.Checked) ? (int?)null : this.vendor.ID;
            skuItem.ProductCode = txtCode.Text;
            skuItem.Quantity = Convert.ToInt32(txtQuantity.Text);

            UpdateStatus("Saving..", 75);
            bool response = SalesSaver.SaveSkuItemInfo(skuItem);

            if (response)
            {
                UpdateStatus("Saved", 100);

                Winform_SKURegister addSkuReg = Application.OpenForms["Winform_SKURegister"] as Winform_SKURegister;
                if (addSkuReg != null)
                    addSkuReg.dgvSearch_ReloadRegister(this, new EventArgs());
                this.Close();
            }
            else
            {
                UpdateStatus("Error Saving Sale", 100);
            }
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, true))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Sale Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }
        #endregion Events

        #region Validation
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            var txtbox = (sender as TextBox);
            if (txtbox.Text == String.Empty)
                return;

            /*allow only signed int/ float*/
            Match _match = Regex.Match(txtbox.Text, "^[0-9]*$");
            string errorMsg = _match.Success ? "" : "Invalid Input for fields\n" +
                                                    " For example '340'";
            errorProvider1.SetError(txtbox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtbox.Select(0, txtbox.TextLength);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            var txtbox = (sender as TextBox);
            if (txtbox.Text == String.Empty)
                return;

            string errorMsg;
            if (txtbox.Text.Length < 3)
            {
                errorMsg = "Product Name must have more than two characters.";
                errorProvider1.SetError(txtbox, errorMsg);
                if (errorMsg != "")
                {
                    // Cancel the event and select the text to be corrected by the user.
                    e.Cancel = true;
                    txtbox.Select(0, txtbox.TextLength);
                }
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCode.Text)) return;

            if (string.IsNullOrEmpty(cmbColor.Text) || string.IsNullOrEmpty(cmbMaterial.Text)
                || string.IsNullOrEmpty(cmbSize.Text) || string.IsNullOrEmpty(txtName.Text))
                return;

            var nameArray = txtName.Text.Split(' ');
            string code = string.Empty;
            foreach (var s in nameArray)
            {
                code += s.Length < 4 ? s : s.Substring(0, 3);
            }

            var varcode = "-" + cmbMaterial.Text.Substring(0, 3) + "-";
            varcode += cmbColor.Text.Substring(0, 1) + cmbColor.Text.Substring(cmbColor.Text.Length - 1, 1) + cmbSize.Text;

            int index = 0;
            bool exists = true;
            while (exists)
                exists = SaleBuilder.IsExistingProdCode(code + (++index).ToString() + varcode);

            txtCode.Text = code + (index).ToString() + varcode;
        }

        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            var cmbbox = (sender as ComboBox);
            if (string.IsNullOrEmpty(cmbbox.Text)) return;

            string errorMsg = "";
            if (cmbbox.Text.Length < 3)
            {
                errorMsg = "Material Type must have more than two characters.";
                errorProvider1.SetError(cmbbox, errorMsg);
            }
            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                cmbbox.Select(0, cmbbox.Text.Length);
            }

        }
        #endregion Validation

        #region Custom
        internal bool UpdateDocumentItemList(Document _doc)
        {
            var docindex = docList.IndexOf(docList.Where(x => x.Type == _doc.Type).SingleOrDefault());
            if (docList.Count == 0 || docindex == -1)
            {
                docList.Add(new SKUItemDocument
                {
                    Image = _doc.Image,
                    Type = _doc.Type,
                });
                dgvItemSKUDoc.Rows.Add();
                docindex = dgvItemSKUDoc.Rows.Count - 1;
            }
            else
            {
                docList[docindex].Image = _doc.Image;
                docList[docindex].Type = _doc.Type;
            }

            dgvItemSKUDoc.Rows[docindex].Cells["colDocType"].Value = _doc.Type;
            skuItem.SKUItemDocuments = docList;
            return true;
        }

        public void UpdateVendorDetails(Vendor vend = null)
        {
            this.vendor = vend;
            if (vend != null)
            {
                txtVendMobile.Text = vend.MobileNo;
                txtVendName.Text = vend.Name;
            }
            else
            {
                txtVendMobile.Text = string.Empty;
                txtVendName.Text = string.Empty;
            }
        }
        #endregion

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new Winform_DocumentDetails(null, InEdit).ShowDialog();
        }

        private void dgvOrderItemDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (IsNullOrEmpty(dgvItemSKUDoc.Rows[e.RowIndex].Cells[0].Value))
            {
                MessageBox.Show("Document Type is Mandatory", "Enter Document Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (e.ColumnIndex == 0)
            {
                new Winform_DocumentDetails(docList[e.RowIndex], InEdit).ShowDialog();
            }
            else if (e.ColumnIndex == 1) //delete Document
            {
                if (IsNullOrEmpty(dgvItemSKUDoc.Rows[e.RowIndex].Cells[0].Value))
                    return;

                if (dgvItemSKUDoc.Columns["colDelete"].Index == e.ColumnIndex)
                {
                    DialogResult dres = MessageBox.Show("Continue deleting selected Document?", "Delete Document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dres == DialogResult.No) return;

                    if (docList.Count != 0 && e.RowIndex + 1 <= docList.Count)
                    {
                        bool success = false;
                        if (docList[e.RowIndex].ID != 0)
                            success = SpindleSoft.Savers.SalesSaver.DeleteSKUItemDocument(docList[e.RowIndex].ID);

                        if (success || docList[e.RowIndex].ID == 0)
                        {
                            docList.RemoveAt(e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("Could not delete the Item. Something Nasty happened!!");
                            return;
                        }
                    }
                    dgvItemSKUDoc.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
