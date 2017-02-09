using MySql.Data.MySqlClient;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.IO;
using System.Configuration;
using SpindleSoft.Utilities;

namespace SpindleSoft.Views
{
    public partial class Winform_RestoreDB : Form
    {
        ILog log = LogManager.GetLogger(typeof(Winform_RestoreDB));
        static string constring = "server=localhost;user=sa;pwd=sshetty;database=spindlesoftdb;Convert Zero Datetime=True;";
        string baseDoc = Secrets.FileLocation["BaseDocDirectory"];
        string dbBackupPath = Secrets.FileLocation["DBBackUp"];

        List<FileInfo> bkList;
        public Winform_RestoreDB()
        {
            InitializeComponent();
        }

        private void Winform_RestoreDB_Load(object sender, EventArgs e)
        {
            //list all the files
            var fileList = new DirectoryInfo(string.Format("{0}/{1}", baseDoc, dbBackupPath)).GetFiles("*.*", SearchOption.AllDirectories);
            bkList = (from file in fileList
                               orderby file.CreationTime descending
                               select file).Take(5).ToList();
            foreach (var item in bkList)
            {
                int index = dgvRestore.Rows.Add();
                var dgvRow = dgvRestore.Rows[index];
                dgvRow.Cells["colSI"].Value = bkList.IndexOf(item) + 1;
                dgvRow.Cells["colFile"].Value = item.CreationTime;
            }
        }

        private void dgvRestore_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != dgvRestore.Columns["colButton"].Index) return;
            var dr = MessageBox.Show("Do you want to Restore Data?", "Restore DB", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;          

            try
            {
                string file = bkList[e.RowIndex].FullName;
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();                            
                            progBarRestore.Value = 25;
                            mb.ImportFromFile(file);
                            progBarRestore.Value = 50;
                            conn.Close();

                            progBarRestore.Value = 100;
                            log.Info("Database successfully restored to File " + file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Database Restore Faled: " + ex);
                MessageBox.Show("Error While restoring Database. Contact Techinal Assistance if error persists", "Error Restoring DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
