using System;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
    public partial class Winform_SMSRegister : winform_Register
    {
        public Winform_SMSRegister()
        {
            InitializeComponent();
        }

        private void Winform_SMSRegister_Load(object sender, EventArgs e)
        {
            this.NewVendToolStrip.Visible = false;
            this.toolStrip1.Items.Add(this.toolStripBtnSearch);
        }

        private void toolStripBtnSearch_Click(object sender, EventArgs e)
        {
            dgvRegister.DataSource = "";
            UpdateStatus("Searching", 50);
            dgvRegister.DataSource = Builders.SMSBuilder.GetSMSLog(dtpFromDate.Value, dtpToDate.Value, txtCustName.Text);
            UpdateStatus(dgvRegister.Rows.Count + " Results Found.", 100);
        }
    }
}