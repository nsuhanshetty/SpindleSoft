using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using SpindleSoft.Views;

namespace SpindleSoft
{
    public partial class Winform_AlterationRegister : Form
    {
        public Winform_AlterationRegister()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //todo : Check txtboxes for sql injection
            List<Alteration> altList = (AlterationBuilder.GetAlterationList(txtName.Text, txtMobNo.Text, txtAltNo.Text));
            if (altList != null)
            {
                dgvSearch.DataSource = (from alt in altList
                                        select new
                                        {
                                            OrderID = alt.ID,
                                            alt.TotalPrice,
                                            AmountPaid = alt.CurrentPayment,
                                            PromisedDate = alt.PromisedDate
                                        }).ToList();
            }
            else
                dgvSearch.DataSource = null;
        }

        private void Winform_AlterationRegister_Load(object sender, EventArgs e)
        {

        }

        private void dgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearch.Rows[e.RowIndex].Cells["OrderID"] == null) return;

             DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Alteration " +
                                         Convert.ToString(dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString()),
                                         "Modify Alteration Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);
            if (_dialogResult == DialogResult.No) return;

            Alteration alt = AlterationBuilder.GetAlteration(int.Parse(dgvSearch.Rows[e.RowIndex].Cells["OrderID"].Value.ToString()));
            new Winform_AlterationsDetails(alt).ShowDialog();
        }
    }
}