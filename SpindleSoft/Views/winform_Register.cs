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
    public partial class winform_Register : Form
    {
        public winform_Register()
        {
            InitializeComponent();
        }

        protected virtual void UpdateStatus(string statusText = "Search Completed", int statusValue = 0)
        {
            toolStrip_Label.Text = statusText;
            toolStripProgressBar1.Value = statusValue;
        }

        protected virtual void NewVendToolStrip_Click(object sender, EventArgs e)
        {

        }
    }
}
