namespace SpindleSoft.Views
{
    partial class Winform_RestoreDB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpbxRestore = new System.Windows.Forms.GroupBox();
            this.dgvRestore = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progBarRestore = new System.Windows.Forms.ProgressBar();
            this.grpbxRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestore)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxRestore
            // 
            this.grpbxRestore.Controls.Add(this.dgvRestore);
            this.grpbxRestore.Location = new System.Drawing.Point(13, 12);
            this.grpbxRestore.Name = "grpbxRestore";
            this.grpbxRestore.Size = new System.Drawing.Size(487, 154);
            this.grpbxRestore.TabIndex = 0;
            this.grpbxRestore.TabStop = false;
            this.grpbxRestore.Text = "Restore Database";
            // 
            // dgvRestore
            // 
            this.dgvRestore.AllowUserToAddRows = false;
            this.dgvRestore.AllowUserToDeleteRows = false;
            this.dgvRestore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRestore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colSI,
            this.colFile,
            this.colButton});
            this.dgvRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRestore.Location = new System.Drawing.Point(3, 16);
            this.dgvRestore.Name = "dgvRestore";
            this.dgvRestore.ReadOnly = true;
            this.dgvRestore.Size = new System.Drawing.Size(481, 135);
            this.dgvRestore.TabIndex = 1;
            this.dgvRestore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRestore_CellClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colSI
            // 
            this.colSI.HeaderText = "SI.No";
            this.colSI.Name = "colSI";
            this.colSI.ReadOnly = true;
            // 
            // colFile
            // 
            this.colFile.HeaderText = "Log Name";
            this.colFile.Name = "colFile";
            this.colFile.ReadOnly = true;
            // 
            // colButton
            // 
            this.colButton.HeaderText = "Click to Restore";
            this.colButton.Name = "colButton";
            this.colButton.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progBarRestore);
            this.groupBox1.Location = new System.Drawing.Point(16, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Restore Status";
            // 
            // progBarRestore
            // 
            this.progBarRestore.Location = new System.Drawing.Point(6, 19);
            this.progBarRestore.Name = "progBarRestore";
            this.progBarRestore.Size = new System.Drawing.Size(469, 14);
            this.progBarRestore.TabIndex = 0;
            // 
            // Winform_RestoreDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 224);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbxRestore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Winform_RestoreDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restore Database";
            this.Load += new System.EventHandler(this.Winform_RestoreDB_Load);
            this.grpbxRestore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestore)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxRestore;
        private System.Windows.Forms.DataGridView dgvRestore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFile;
        private System.Windows.Forms.DataGridViewButtonColumn colButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progBarRestore;
    }
}