using System;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
#if DEBUG

    public partial class Winform_DetailsFormat : Form
    {
#else
        public abstract partial class Winform_DetailsFormat: Form
        {
#endif

        public Winform_DetailsFormat()
        {
            InitializeComponent();
        }

        private void Winform_DetailsFormat_Load(object sender, EventArgs e)
        {
        }

        protected virtual void SaveToolStrip_Click(object sender, EventArgs e)
        {
        }

        protected virtual void CancelToolStrip_Click(object sender, EventArgs e)
        {
        }

        protected virtual void UpdateStatus(string statusText="Enter Details and Click Save..", int statusValue=0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }

        protected virtual bool IsNullOrEmpty(object obj)
        {
            return (obj == null || obj.ToString() == "");
        }
    }
}