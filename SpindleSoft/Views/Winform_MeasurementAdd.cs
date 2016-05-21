using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_MeasurementAdd : Winform_DetailsFormat
    {
        OrderItem _orderItem = new OrderItem();
        List<OrderItemDocument> docList = new List<OrderItemDocument>();

        int _index = 0;
        Customer _cust;
        List<string> _orderTypeList;

        #region Ctor
        public Winform_MeasurementAdd()
        {
            InitializeComponent();
        }

        public Winform_MeasurementAdd(int index, Customer cust, OrderItem orderItem, bool _inEdit = false)
        {
            InitializeComponent();
            this._index = index;
            this._cust = cust;
            this._orderItem = orderItem;
            this._orderTypeList = OrderBuilder.GetListOfClothingTypes();

            cmbType.DataSource = _orderTypeList;
            InEdit = _inEdit;

            if (!InEdit)
            {
                var exList = new List<string>() { "dgvOrderItemDoc", "groupBox6" };
                WinFormControls_InEdit(this, exList);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }
        #endregion

        #region Events
        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            bool hasValue = SpindleSoft.Utilities.Validation.controlIsInEdit(grbxProdDetails, true);

            if (hasValue != true)
            {
                MessageBox.Show("No values found in Product Details, Add values and Save", "No Values Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (int.Parse(txtPrice.Text) == 0)
            {
                MessageBox.Show("Price is Mandatory", "No Price Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (String.IsNullOrEmpty(cmbType.Text))
            {
                MessageBox.Show("Order Item Type is Mandatory", "No Order Item Type Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OrderItem _item = _orderItem;

            _item.Name = cmbType.Text;
            _item.Price = float.Parse(txtPrice.Text);
            _item.Quantity = int.Parse(nudQuantity.Value.ToString());

            _item.Length = txtLength.Text;
            _item.Waist = txtWaist.Text;
            _item.Chest = txtChest.Text;
            _item.Shoulder = txtShoulder.Text;
            _item.Front = txtFront.Text;
            _item.Back = txtBack.Text;
            _item.D = txtD.Text;
            _item.Hip = txtHip.Text;

            _item.BottomHip = txtBotHip.Text;
            _item.BottomWaist = txtBotWaist.Text;
            _item.BottomWaist = txtBotWaist.Text;
            _item.BottomLength = txtBotLength.Text;
            _item.BottomLoose = txtBotLoose.Text;

            _item.SleeveArmHole = txtSlvAHole.Text;
            _item.SleeveLength = txtSlvLength.Text;
            _item.SleeveLoose = txtSlvLoose.Text;
            _item.Comment = txtComment.Text;
            _item.DateUpdated = DateTime.Now;

            if (_item.OrderItemDocuments == null)
                _item.OrderItemDocuments = new List<OrderItemDocument>();

            Winform_OrderDetails orderDetails = Application.OpenForms["Winform_OrderDetails"] as Winform_OrderDetails;
            if (orderDetails != null)
                orderDetails.UpdateOrderItemList(_item, _index);
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (SpindleSoft.Utilities.Validation.controlIsInEdit(this, false))
            {
                var _dialogResult = MessageBox.Show("Do you want to Exit?", "Exit Measurement Details", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (_dialogResult == DialogResult.No)
                    return;
            };

            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbType.Text) && (_orderItem == new OrderItem() || cmbType.Text != _orderItem.Name))
            {
                //fetch  previous measurement
                _orderItem = OrderBuilder.GetOrderItemLatestMeasurementBasedonProdName(this._cust.ID, cmbType.Text);
                if (_orderItem != null) _orderItem.ID = 0;

                UpdateControls(this._cust.Name, _orderItem);
            }
        }

        private void Winform_MeasurementAdd_Load(object sender, EventArgs e)
        {
            UpdateControls(this._cust.Name, this._orderItem);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            new Winform_DocumentDetails(null, InEdit).ShowDialog();
        }

        private void dgvOrderItemDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (IsNullOrEmpty(dgvOrderItemDoc.Rows[e.RowIndex].Cells[0].Value))
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
                if (IsNullOrEmpty(dgvOrderItemDoc.Rows[e.RowIndex].Cells[0].Value))
                    return;

                if (dgvOrderItemDoc.Columns["colDelete"].Index == e.ColumnIndex)
                {
                    DialogResult dres = MessageBox.Show("Continue deleting selected Document?", "Delete Document", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dres == DialogResult.No) return;

                    if (docList.Count != 0 && e.RowIndex + 1 <= docList.Count)
                    {
                        bool success = false;
                        if (docList[e.RowIndex].ID != 0)
                            success = SpindleSoft.Savers.OrderSaver.DeleteOrderItemDocument(docList[e.RowIndex].ID);

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
                    dgvOrderItemDoc.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        #endregion

        #region Validation
        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            var txtbox = (sender as TextBox);
            if (txtbox.Text == String.Empty)
                return;

            //allow only signed int/ float
            Match _match = Regex.Match(txtbox.Text, "^[0-9]+(\\.[0-9]+)?$");
            string errorMsg = _match.Success ? "" : "Invalid Input for fields\n" +
                                                    " For example '34.2'";
            errorProvider1.SetError(txtbox, errorMsg);

            if (errorMsg != "")
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtbox.Select(0, txtbox.TextLength);
            }
        }

        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
            var value = (sender as ComboBox).Text;
            if (string.IsNullOrEmpty(value)) return;

            UpdateCmbType(value);
        }
        #endregion

        #region Custom
        internal bool UpdateDocumentItemList(Document _doc)
        {
            var docindex = docList.IndexOf(docList.Where(x => x.Type == _doc.Type).SingleOrDefault());
            if (docList.Count == 0 || docindex == -1)
            {
                docList.Add(new OrderItemDocument
                {
                    Image = _doc.Image,
                    Type = _doc.Type,
                });
                dgvOrderItemDoc.Rows.Add();
                docindex = dgvOrderItemDoc.Rows.Count - 1;
            }
            else
            {
                docList[docindex].Image = _doc.Image;
                docList[docindex].Type = _doc.Type;
            }

            dgvOrderItemDoc.Rows[docindex].Cells["colDocType"].Value = _doc.Type;
            _orderItem.OrderItemDocuments = docList;
            return true;
        }

        private void UpdateControls(string custName, OrderItem orderItem)
        {
            this._orderItem = orderItem != null ? orderItem : new OrderItem();

            txtCustName.Text = custName;
            txtLength.Text = this._orderItem.Length;
            txtWaist.Text = this._orderItem.Waist;
            txtChest.Text = this._orderItem.Chest;
            txtShoulder.Text = this._orderItem.Shoulder;
            txtFront.Text = this._orderItem.Front;
            txtBack.Text = this._orderItem.Back;
            txtD.Text = this._orderItem.D;
            txtHip.Text = this._orderItem.Hip;

            txtBotHip.Text = this._orderItem.BottomHip;
            txtBotWaist.Text = this._orderItem.BottomWaist;
            txtBotLength.Text = this._orderItem.BottomLength;
            txtBotLoose.Text = this._orderItem.BottomLoose;

            txtSlvAHole.Text = this._orderItem.SleeveArmHole;
            txtSlvLength.Text = this._orderItem.SleeveLength;
            txtSlvLoose.Text = this._orderItem.SleeveLoose;
            txtComment.Text = this._orderItem.Comment;

            UpdateCmbType(this._orderItem.Name ?? cmbType.Text);
            nudQuantity.Value = this._orderItem.Quantity == 0 ? 1 : this._orderItem.Quantity;
            txtPrice.Text = this._orderItem.Price.ToString();

            if (_orderItem != null && _orderItem.OrderItemDocuments != null && _orderItem.OrderItemDocuments.Count != 0)
            {
                docList = _orderItem.OrderItemDocuments as List<OrderItemDocument>;
                foreach (OrderItemDocument doc in _orderItem.OrderItemDocuments)
                {
                    int index = _orderItem.OrderItemDocuments.IndexOf(doc);
                    dgvOrderItemDoc.Rows.Add();

                    dgvOrderItemDoc.Rows[index].Cells["colDocType"].Value = doc.Type;
                }

                if (!InEdit)
                    dgvOrderItemDoc.Columns["ColDelete"].Visible = false;
            }
        }

        private void UpdateCmbType(string value)
        {
            if (this._orderTypeList.IndexOf(value) == -1)
            {
                this._orderTypeList.Add(value);
                cmbType.DataSource = null;
                cmbType.DataSource = _orderTypeList;
            }
            cmbType.SelectedItem = value;
        }
        #endregion Custom
    }
}