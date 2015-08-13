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
    public partial class Winform_PictureBox : Form
    {
        public Winform_PictureBox(string type, string imagePath)
        {
            InitializeComponent();
            this.Text = type;
            pcbDoc.Image = System.Drawing.Image.FromFile(imagePath);
        }
    }
}
