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
    public partial class Winform_SKURegister : Form
    {
        public Winform_SKURegister()
        {
            InitializeComponent();
        }

        private void NewVendToolStrip_Click(object sender, EventArgs e)
        {
            new WinForm_SKUDetails().ShowDialog();
        }
    }
}
