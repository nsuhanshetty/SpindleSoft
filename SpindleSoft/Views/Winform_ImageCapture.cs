using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WCC;

// Reference path for the following assemblies --> C:\Program Files\Microsoft Expression\Encoder 4\SDK\
using Microsoft.Expression.Encoder.Devices;
using Microsoft.Expression.Encoder.Live;
using Microsoft.Expression.Encoder;
using System.Runtime.InteropServices;

namespace SpindleSoft.Views
{
    public partial class Winform_ImageCapture : Form
    {
        private WCC.clsWC objwcc = new clsWC();
        private PictureBox pcb;

        /// <summary>
        /// Creates job for capture of live source
        /// </summary>
        private LiveJob _job;

        /// <summary>
        /// Device for live source
        /// </summary>
        private LiveDeviceSource _deviceSource;

        public Winform_ImageCapture(PictureBox pcb)
        {
            InitializeComponent();
            this.pcb = pcb;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap profileImage = CaptureImage();
            this.pcb.Image = profileImage;

            StopJob();
            this.Close();
        }

        private Bitmap CaptureImage()
        {

            Bitmap profileImage = default(Bitmap);

            // Create a Bitmap of the same dimension of panelVideoPreview (Width x Height)
            using (Bitmap bitmap = new Bitmap(picCapture.Width, picCapture.Height))
            {
                Rectangle rectanglePanelVideoPreview;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    // Get the paramters to call g.CopyFromScreen and get the image
                    rectanglePanelVideoPreview = picCapture.Bounds;
                    Point sourcePoints = picCapture.PointToScreen(new Point(picCapture.ClientRectangle.X, picCapture.ClientRectangle.Y));
                    g.CopyFromScreen(sourcePoints, Point.Empty, rectanglePanelVideoPreview.Size);
                }

                profileImage = new Bitmap(bitmap);
            }
            return profileImage;
        }

        private void WinformWebcam_Load(object sender, EventArgs e)
        {
            picCapture.Image = null;
            List<string> deviceNames = new List<string>();

            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                //todo: Avoid ScreenCapture
                if (edv.Name == "Screen Capture Source") continue;

                deviceNames.Add(edv.Name);
            }
            cmbCameraSelect.DataSource = deviceNames;
            btnPreview_Click(this, new EventArgs());
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            EncoderDevice video = null;
            EncoderDevice audio = null;

            GetSelectedVideoAndAudioDevices(out video, out audio);
            StopJob();

            if (video == null)
            {
                return;
            }

            // Starts new job for preview window
            _job = new LiveJob();

            // Checks for a/v devices
            if (video != null) //&& audio != null
            {
                // Create a new device source. We use the first audio and video devices on the system
                _deviceSource = _job.AddDeviceSource(video, audio);

                // Is it required to show the configuration dialogs ?
                if (checkBoxShowConfigDialog.Checked)
                {
                    // Yes
                    // VFW video device ?
                    if (cmbCameraSelect.SelectedItem.ToString().EndsWith("(VFW)", StringComparison.OrdinalIgnoreCase))
                    {
                        // Yes
                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VfwFormatDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VfwFormatDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VfwSourceDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VfwSourceDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VfwDisplayDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VfwDisplayDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                    }
                    else
                    {
                        // No
                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VideoCapturePinDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoCapturePinDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VideoCaptureDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoCaptureDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VideoCrossbarDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoCrossbarDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VideoPreviewPinDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoPreviewPinDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }

                        if (_deviceSource.IsDialogSupported(ConfigurationDialog.VideoSecondCrossbarDialog))
                        {
                            _deviceSource.ShowConfigurationDialog(ConfigurationDialog.VideoSecondCrossbarDialog, (new HandleRef(picCapture, picCapture.Handle)));
                        }
                    }
                }
                else
                {
                    // No
                    // Setup the video resolution and frame rate of the video device
                    // NOTE: Of course, the resolution and frame rate you specify must be supported by the device!
                    // NOTE2: May be not all video devices support this call, and so it just doesn't work, as if you don't call it (no error is raised)
                    // NOTE3: As a workaround, if the .PickBestVideoFormat method doesn't work, you could force the resolution in the 
                    //        following instructions (called few lines belows): 'panelVideoPreview.Size=' and '_job.OutputFormat.VideoProfile.Size=' 
                    //        to be the one you choosed (640, 480).
                    _deviceSource.PickBestVideoFormat(new Size(640, 480), 15);
                }

                // Get the properties of the device video
                SourceProperties sp = _deviceSource.SourcePropertiesSnapshot();

                // Resize the preview panel to match the video device resolution set
                // panelVideoPreview.Size = new Size(sp.Size.Width, sp.Size.Height);

                // Setup the output video resolution file as the preview
                _job.OutputFormat.VideoProfile.Size = new Size(sp.Size.Width, sp.Size.Height);

                // Display the video device properties set
                //toolStripStatusLabel1.Text = sp.Size.Width.ToString() + "x" + sp.Size.Height.ToString() + "  " + sp.FrameRate.ToString() + " fps";

                // Sets preview window to winform panel hosted by xaml window
                _deviceSource.PreviewWindow = new PreviewWindow(new HandleRef(picCapture, picCapture.Handle));

                // Make this source the active one
                _job.ActivateSource(_deviceSource);

                //btnStartStopRecording.Enabled = true;
                // btnGrabImage.Enabled = true;

                //toolStripStatusLabel1.Text = "Preview activated";
            }
            else
            {
                // Gives error message as no audio and/or video devices found
                MessageBox.Show("No Video capture devices have been found.", "Warning");
                // toolStripStatusLabel1.Text = "No Video capture devices have been found.";
            }
        }

        private void GetSelectedVideoAndAudioDevices(out EncoderDevice video, out EncoderDevice audio)
        {
            video = null;
            audio = null;

            if (cmbCameraSelect.SelectedIndex < 0)
            {
                MessageBox.Show("No Video capture devices have been selected.\n Select a video devices from the dropdown and try again.", "Warning");
                return;
            }

            // Get the selected video device            
            foreach (EncoderDevice edv in EncoderDevices.FindDevices(EncoderDeviceType.Video))
            {
                if (String.Compare(edv.Name, cmbCameraSelect.SelectedItem.ToString()) == 0)
                {
                    video = edv;
                    break;
                }
            }
        }

        void StopJob()
        {
            // Has the Job already been created ?
            if (_job != null)
            {
                _job.StopEncoding();

                // Remove the Device Source and destroy the job
                _job.RemoveDeviceSource(_deviceSource);

                // Destroy the device source
                _deviceSource.PreviewWindow = null;
                _deviceSource = null;
            }
        }
    }
}