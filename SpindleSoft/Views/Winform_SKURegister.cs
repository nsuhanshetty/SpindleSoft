using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Windows.Forms;
using log4net;

namespace SpindleSoft.Views
{
    public partial class Winform_SKURegister : winform_Register
    {
        ILog log = LogManager.GetLogger(typeof(Winform_SKURegister));
        #region ctor
        public Winform_SKURegister()
        {
            InitializeComponent();
        } 
        #endregion

        #region Events

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new WinForm_SKUDetails().ShowDialog();
        }

        public void dgvSearch_ReloadRegister(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);
            //todo : how do we add vendors name along with salename
            var skulist = SaleBuilder.GetSKUItems(txtName.Text, txtProCode.Text, txtDesc.Text, cmbColor.Text, cmbSize.Text, cmbMaterial.Text);
            if (skulist != null || skulist.Count != 0)
            {
                dgvSearch.DataSource = skulist;
                colDelete.Visible = colEdit.Visible = true;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvSearch.Columns.Count - 1;
                dgvSearch.Columns["ID"].Visible = false;
            }
            else
            {
                dgvSearch.DataSource = null;
                colDelete.Visible = colEdit.Visible = false;
            }
            UpdateStatus((dgvSearch.RowCount == 0) ? "No Results Found" : dgvSearch.RowCount + " Results Found", 100);
        }

        private void Winform_SKURegister_Load(object sender, EventArgs e)
        {
            //Load ComboBox
            var ComboBoxResults = SaleBuilder.GetVariationValues();

            cmbSize.Items.Add("All");
            cmbSize.Items.AddRange(ComboBoxResults[2].ToArray());

            cmbColor.Items.Add("All");
            cmbColor.Items.AddRange(ComboBoxResults[0].ToArray());

            cmbMaterial.Items.Add("All");
            cmbMaterial.Items.AddRange(ComboBoxResults[1].ToArray());

            dgvSearch_ReloadRegister(this, new EventArgs());
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var skuID = dgvSearch.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            try
            {
                if (dgvSearch.Columns["colDelete"].Index == e.ColumnIndex)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete Sale Item " + dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value + "?", "Delete Sale Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;

                    if (!Savers.SalesSaver.CheckIfSKUItemSold(skuID))
                    {
                        MessageBox.Show("Cannot Delete Sale Item as its part of a Sale", "Delete SaleItem", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    bool success = Savers.SalesSaver.DeleteSkuItem(skuID);
                    if (success)
                    {
                        dgvSearch_ReloadRegister(this, new EventArgs());
                        UpdateStatus("Sale Item Deleted.", 100);
                    }
                    else
                    {
                        UpdateStatus("Error deleting Sale Item. ", 100);
                    }
                }
                else
                {
                    bool _inEdit = false;
                    if (dgvSearch.Columns["colEdit"].Index == e.ColumnIndex)
                    {
                        DialogResult dr = MessageBox.Show("Continue to Edit Sale Item " + dgvSearch.Rows[e.RowIndex].Cells["ProductName"].Value + " details?", "Edit SKU Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.No) return;
                        _inEdit = true;
                    }

                    SKUItem _saleItem = SaleBuilder.GetSkuItemInfo(skuID);
                    new WinForm_SKUDetails(_saleItem, _inEdit).ShowDialog();
                    dgvSearch_ReloadRegister(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void dgvSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSearch_CellClick(this, new DataGridViewCellEventArgs(dgvSearch.CurrentCell.ColumnIndex, dgvSearch.CurrentCell.RowIndex));
            }
        } 
        #endregion
    }
}
