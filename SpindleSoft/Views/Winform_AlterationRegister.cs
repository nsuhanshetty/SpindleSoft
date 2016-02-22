using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using SpindleSoft.Views;
using log4net;

namespace SpindleSoft
{
    public partial class Winform_AlterationRegister : Form
    {
        ILog log = LogManager.GetLogger(typeof(Winform_AlterationRegister));
        public Winform_AlterationRegister()
        {
            InitializeComponent();
        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.Rows[e.RowIndex].Cells["AlterationID"] == null) return;

            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Alteration " +
                                        Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["AlterationID"].Value.ToString()),
                                        "Modify Alteration Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (_dialogResult == DialogResult.No) return;

            Alteration alt = AlterationBuilder.GetAlteration(int.Parse(dgvSearch.Rows[e.RowIndex].Cells["AlterationID"].Value.ToString()));
            new Winform_AlterationsDetails(alt).ShowDialog();
            txtName_TextChanged(this, new EventArgs());
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            var delCol = dgvSearch.Columns["colDelete"];
            delCol.Visible = false;

            //if (string.IsNullOrEmpty(txtAltNo.Text) && string.IsNullOrEmpty(txtMobNo.Text) && string.IsNullOrEmpty(txtName.Text))
            //{
            //    dgvSearch.DataSource = null;
            //    return;
            //}

            List<Alteration> altList = (AlterationBuilder.GetAlterationList(txtName.Text, txtMobNo.Text, txtAltNo.Text));
            if (altList != null && altList.Count != 0)
            {
                dgvSearch.DataSource = (from alt in altList
                                        select new
                                        {
                                            AlterationID = alt.ID,
                                            alt.TotalPrice,
                                            AmountPaid = alt.CurrentPayment,
                                            PromisedDate = alt.PromisedDate
                                        }).ToList();
                delCol.DisplayIndex = dgvSearch.Columns.Count - 1;
                delCol.Visible = true;
            }
            else
            {
                dgvSearch.DataSource = null;
            }
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvSearch.Rows[e.RowIndex].Cells["AlterationID"].Value == null) return;
            int altID = int.Parse(dgvSearch.Rows[e.RowIndex].Cells["AlterationID"].Value.ToString());

            if (e.ColumnIndex == dgvSearch.Columns["colDelete"].Index)
            {
                DialogResult dr = MessageBox.Show("Do you want to Delete Alteration " + altID, "Delete Alteration", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.No) return;

                bool success = SpindleSoft.Savers.AlterationSaver.DeleteAlteration(altID);
                if (success == true)
                {
                    txtName_TextChanged(this, new EventArgs());
                    statusStrip1.Text = "Alteration Deleted.";
                }
                return;
            }
        }

        private void Winform_AlterationRegister_Load(object sender, EventArgs e)
        {
            txtName_TextChanged(this, new EventArgs());
        }

        private void dgvSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvSearch_CellDoubleClick(this, new DataGridViewCellEventArgs(dgvSearch.CurrentCell.ColumnIndex, dgvSearch.CurrentCell.RowIndex));
            }
        }
    }
}