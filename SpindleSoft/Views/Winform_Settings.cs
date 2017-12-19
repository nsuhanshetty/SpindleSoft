using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using SpindleSoft.Model;
using SpindleSoft.Builders;
using log4net;

namespace SpindleSoft.Views
{
    public partial class Winform_Settings : Winform_DetailsFormat
    {
        ILog log = LogManager.GetLogger(typeof(Winform_Settings));
        Setting setting = new Setting();
        public Winform_Settings()
        {
            InitializeComponent();
            setting = SettingsBuilder.GetBaseImagePath();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();
            if (!(dr == DialogResult.OK)) return;
            else
                txtFolderPath.Text = folderBrowserDialog1.SelectedPath;
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFolderPath.Text))
            {
                MessageBox.Show("No path found. Try again");
                return;
            }

            string _baseImageFolder = txtFolderPath.Text;
            List<String> _imageFolderNames = new List<string> { "Customer_ProfilePictures", "Staff_ProfilePictures", 
                                                               "Staff_SecurityDocuments", "Order_OrderItemDocuments", "SKUItem_SKUItemDocuments","DBBackUp_Path" };
            foreach (var item in _imageFolderNames)
            {
                string path = _baseImageFolder + "\\" + item;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }

            if (setting == null)
            {
                setting = new Setting() { Name = "ImageBaseFolder", Value = txtFolderPath.Text };
            }
            else
                setting.Value = txtFolderPath.Text;

            bool success = SpindleSoft.Savers.SettingSaver.UpdateBaseImagePath(setting);
            if (success)
            {
                MessageBox.Show("Application will Restart to update the changes","Restart Application",MessageBoxButtons.OK);
                UpdateStatus("Settings Updated", 100);
                this.Close();

                try
                {
                    //restart application
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                    //close this one
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
            else
                UpdateStatus("Error Updating Settings", 100);
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Winform_Settings_Load(object sender, EventArgs e)
        {
            if (!(setting == null))
                txtFolderPath.Text = setting.Value;

        }
    }
}
