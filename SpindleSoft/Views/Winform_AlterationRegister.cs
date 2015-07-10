using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft
{
    public partial class Winform_AlterationRegister : Form
    {
        public Winform_AlterationRegister()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}