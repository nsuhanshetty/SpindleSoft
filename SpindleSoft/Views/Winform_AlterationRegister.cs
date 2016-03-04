using SpindleSoft.Builders;
using System;
using System.Windows.Forms;
using SpindleSoft.Views;
using log4net;

namespace SpindleSoft
{
    public partial class Winform_AlterationRegister : winform_Register
    {
        ILog log = LogManager.GetLogger(typeof(Winform_AlterationRegister));
        #region ctor
        public Winform_AlterationRegister()
        {
            InitializeComponent();
        } 
        #endregion

        #region Events
        private void dgvSearch_ReloadRegister(object sender, EventArgs e)
        {
            UpdateStatus("Searching", 50);
            var altList = (AlterationBuilder.GetAlterationList(txtName.Text, txtMobNo.Text, txtAltNo.Text));
            if (altList != null && altList.Count != 0)
            {
                dgvSearch.DataSource = altList;
                colDelete.DisplayIndex = colEdit.DisplayIndex = dgvSearch.Columns.Count - 1;
                colDelete.Visible = colEdit.Visible = true;
            }
            else
            {
                dgvSearch.DataSource = null;
                colDelete.Visible = colEdit.Visible = false;
            }
            UpdateStatus((dgvSearch.RowCount == 0) ? "No Results Found" : dgvSearch.RowCount + " Results Found", 100);
        }

        private void dgvSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int altID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["AlterationID"].Value.ToString());
            if (e.ColumnIndex == colDelete.Index)
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete Alteration " + altID, "Delete Alteration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = SpindleSoft.Savers.AlterationSaver.DeleteAlteration(altID);
                if (success)
                {
                    dgvSearch_ReloadRegister(this, new EventArgs());
                    UpdateStatus("Alteration Deleted.", 100);
                }
                else
                {
                    UpdateStatus("Error deleting Alteration. ", 100);
                }
            }
            else
            {
                bool _inEdit = false;
                if (colEdit.Index == e.ColumnIndex)
                {
                    DialogResult dr = MessageBox.Show("Continue to Edit Alteration " + dgvSearch.Rows[e.RowIndex].Cells["AlterationID"].Value + " details", "Edit Alteration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.No) return;
                    _inEdit = true;
                }

                var _Alteration = Builders.AlterationBuilder.GetAlteration(altID);
                new Winform_AlterationsDetails(_Alteration, _inEdit).ShowDialog();
                dgvSearch_ReloadRegister(this, new EventArgs());
            }

        }

        private void Winform_AlterationRegister_Load(object sender, EventArgs e)
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

        protected override void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new Winform_AlterationsDetails().ShowDialog();
            dgvSearch_ReloadRegister(this, new EventArgs());
        } 
        #endregion
    }
}