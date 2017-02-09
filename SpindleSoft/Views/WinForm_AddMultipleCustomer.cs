using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class WinForm_AddMultipleCustomer : Form
    {
        List<Customer> selectedCustList = new List<Customer>();
        public WinForm_AddMultipleCustomer()
        {
            InitializeComponent();
        }

        public WinForm_AddMultipleCustomer(List<Customer> _custList)
        {
            InitializeComponent();
            this.selectedCustList = _custList;
        }

        private void WinForm_AddMultipleCustomer_Load(object sender, EventArgs e)
        {
            if (this.selectedCustList.Count != 0)
            {
                foreach (var _cust in selectedCustList)
                {
                    dgvSelectedCustomer.Rows.Add(_cust.Name, _cust.Mobile_No);
                }
            }

            dgvCustomerReload(this, new EventArgs());
        }

        private void dgvCustomerReload(object sender, EventArgs e)
        {
            var custList = SpindleSoft.Builders.PeoplePracticeBuilder.GetCustomersList(txtName.Text);
            if (custList != null && custList.Count != 0)
            {
                dgvCustomerRegister.DataSource = custList;
            }
            else
            {
                dgvCustomerRegister.DataSource = null;
            }
        }

        private void dgvCustomerRegister_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            int custID = int.Parse(dgvCustomerRegister.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            Customer _cust = Builders.PeoplePracticeBuilder.GetCustomerInfo(int.Parse(custID.ToString()));

            if (selectedCustList.Any(c => c.ID == _cust.ID))
            {
                MessageBox.Show("Customer Already added", "Add Participants", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            selectedCustList.Add(_cust);
            dgvSelectedCustomer.Rows.Add(_cust.Name, _cust.Mobile_No);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Winform_SMSSend sMSSend = Application.OpenForms["Winform_SMSSend"] as Winform_SMSSend;
            if (sMSSend != null)
            {
                sMSSend.UpdateCustomerList(selectedCustList);
                this.Close();
                return;
            }
        }

        private void dgvSelectedCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSelectedCustomer.Rows.Count == 0) return;
            if (dgvSelectedCustomer.Columns["colRemove"].Index != e.ColumnIndex) return;

            selectedCustList.RemoveAt(e.RowIndex);
            dgvSelectedCustomer.Rows.RemoveAt(e.RowIndex);
        }
    }
}
