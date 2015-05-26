using System;
using System.Drawing;
using System.Windows.Forms;
using WCC;

namespace SpindleSoft.Views
{
    public partial class Winform_ImageCapture : Form
    {
        private WCC.clsWC objwcc = new clsWC();
        private PictureBox pcb;

        public Winform_ImageCapture(PictureBox pcb)
        {
            InitializeComponent();
            this.pcb = pcb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap fimage = CaptureImage();
            this.pcb.Image = fimage;
            this.Close();
        }

        private Bitmap CaptureImage()
        {
            objwcc.preparecapture();
            Bitmap functionReturnValue = default(Bitmap);
            IDataObject data = default(IDataObject);
            data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
                functionReturnValue = (Bitmap)data.GetData(typeof(System.Drawing.Bitmap));
            return functionReturnValue;
        }

        private void WinformWebcam_Load(object sender, EventArgs e)
        {
            picCapture.Image = null;
            cmbCameraSelect.Items.Add(objwcc.LoadDeviceList().ToString());
            cmbCameraSelect.SelectedIndex = 0;
            objwcc.OpenPreviewWindow(picCapture.Height, picCapture.Width, long.Parse(picCapture.Handle.ToString()));
            timer1.Start();
        }
    }
}