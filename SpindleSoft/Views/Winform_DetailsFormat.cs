using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace SpindleSoft.Views
{
#if DEBUG

    public partial class Winform_DetailsFormat : Form
    {
        public bool InEdit { get; set; }
        public List<String> excludeControlList { get; set; }

#else
        public abstract partial class Winform_DetailsFormat: Form
        {
#endif
        public Winform_DetailsFormat()
        {
            InitializeComponent();
        }

        protected void WinFormControls_InEdit(Control con, List<String> _excludeControlList = null)
        {
            if (_excludeControlList != null)
            {
                if (excludeControlList == null)
                    excludeControlList = new List<string>();
                excludeControlList.AddRange(_excludeControlList);
            }

            foreach (Control c in con.Controls)
            {
                WinFormControls_InEdit(c);
            }

            if (!InEdit && excludeControlList != null && excludeControlList.Any(c => c == con.Name))
            {
                con.Parent.Enabled = true;
            }
            else
                con.Enabled = InEdit;

            /*Enable editToolStrip*/
            //toolStripParent.Enabled = true;
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

        protected virtual void UpdateStatus(string statusText = "Enter Details and Click Save..", int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;

            if (statusValue == 100)
                MessageBox.Show(statusText, "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected virtual bool IsNullOrEmpty(object obj)
        {
            return (obj == null || obj.ToString() == "");
        }

        protected virtual void EditToolStrip_Click(object sender, EventArgs e)
        {
            InEdit = true;
            WinFormControls_InEdit(this);
            EditToolStrip.Enabled = false;
        }
    }
}