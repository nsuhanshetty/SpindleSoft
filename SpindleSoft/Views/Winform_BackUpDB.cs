using log4net;
using MySql.Data.MySqlClient;
using SpindleSoft.Builders;
using SpindleSoft.Model;
using SpindleSoft.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_BackUpDB : Form
    {
        static ILog log = LogManager.GetLogger(typeof(Winform_BackUpDB));
        static string constring = Secrets.ConnStringBackUp;
        string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        string dbBackupPath = Secrets.FileLocation["DBBackUp"];
        
        public Winform_BackUpDB()
        {
            InitializeComponent();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                var dateOfUpdate = DateTime.Now;
                string filePath = string.Format("{0}/{1}/SpindleSoftDB_{2:yyyy-MM-dd_hh-mm-ss-tt}.sql", baseDoc, dbBackupPath, dateOfUpdate);
                progBar.Value = 25;

                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(filePath);
                            conn.Close();
                            progBar.Value = 50;

                            //Keep only the top 5 files
                            var fileList = new DirectoryInfo(string.Format("{0}/{1}", baseDoc, dbBackupPath)).GetFiles("*.*", SearchOption.AllDirectories);
                            var deleteFiles = (from file in fileList
                                               orderby file.CreationTime descending
                                               select file).Skip(5).ToList();
                            deleteFiles.All(f => { File.Delete(f.FullName); return true; });

                            ////Add backuplog to db
                            //BackUpLog bkLog = new BackUpLog();
                            //bkLog.FileName = filePath;
                            //bkLog.DateOfUpdate = dateOfUpdate;
                            //Savers.SettingSaver.SaveBackUpLog(bkLog);

                            progBar.Value = 75;
                        }
                    }
                }
                progBar.Value = 100;
                GetLatestDate();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                MessageBox.Show("Error BackingUp Database. Contact Techincal Assistance if the error persists", "Error BackingUp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Winform_BackUpDB_Load(object sender, EventArgs e)
        {
            GetLatestDate();
        }

        private void GetLatestDate()
        {
            int SI = 1;
            //list all the files
            var fileList = new DirectoryInfo(string.Format("{0}/{1}", baseDoc, dbBackupPath)).GetFiles("*.*", SearchOption.AllDirectories);
            var bkList = (from file in fileList
                          orderby file.CreationTime descending
                          select file).Take(5).ToList();
            dgvBackup.DataSource = (from log in bkList
                                    select new { SI = SI++, log.CreationTime }).ToList();

            //BackUpLog bkLog = SettingsBuilder.GetLastBackUpLog();
            if (bkList != null && bkList.Count > 1)
            {
                lblDateOfUpdateVal.Text = bkList[0].CreationTime.ToString();
            }
        }
    }
}
