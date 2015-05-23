using System;
using System.Drawing;
using System.Windows.Forms;
using WCC;

namespace SpindleSoft.Views
{
    public partial class Winform_ImageCapture : Form
    {
        private WCC.clsWC objwcc = new clsWC();
        private WinForm_CustomerDetails _customerDetails;
        private Bitmap fimage;

        public Winform_ImageCapture(WinForm_CustomerDetails _customerDetails)
        {
            InitializeComponent();
            this._customerDetails = _customerDetails;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap fimage = CaptureImage();
            _customerDetails.pcbCustImage.Image = fimage;
            _customerDetails.btnCapture.Enabled = true;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (f % 2 == 0)
            //{
            fimage = CaptureImage();
            //}
            //f = f + 1;
        }
    }
}