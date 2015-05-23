using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpindleSoft.Builders;
using SpindleSoft.Model;

namespace SpindleSoft.Views
{
    public partial class Winform_CustomerRegister : Form
    {
        public Winform_CustomerRegister()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Winform_StaffRegister_Load(object sender, EventArgs e)
        {
            dgvCustomerRegister.DataSource = PeoplePracticeBuilder.GetCustomersList(txtName.Text, txtMobNo.Text, txtPhoneNo.Text);
        }

        private void dgvCustomerRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult _dialogResult = MessageBox.Show("Do you want to Modify the details of Customer " +
                                         Convert.ToString(dgvCustomerRegister.Rows[e.RowIndex].Cells[1].Value),
                                         "Modify Customer Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                         MessageBoxDefaultButton.Button2);

            if (_dialogResult == DialogResult.No) return;
            
            Customer _customer = PeoplePracticeBuilder.GetCustomerInfo(dgvCustomerRegister.Rows[e.RowIndex].Cells[2].Value.ToString());
            new WinForm_CustomerDetails(_customer).ShowDialog();
        }
    }
}
