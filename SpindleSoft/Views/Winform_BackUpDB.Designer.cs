namespace SpindleSoft.Views
{
    partial class Winform_BackUpDB
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvBackup = new System.Windows.Forms.DataGridView();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.lblDateOfUpdateVal = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackup)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDateOfUpdateVal);
            this.groupBox1.Controls.Add(this.progBar);
            this.groupBox1.Controls.Add(this.lblLastDate);
            this.groupBox1.Controls.Add(this.btnBackup);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BackUp Data";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(240, 50);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(101, 30);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "Take BackUp";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastDate.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblLastDate.Location = new System.Drawing.Point(16, 28);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(98, 13);
            this.lblLastDate.TabIndex = 2;
            this.lblLastDate.Text = "Last BackUp Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvBackup);
            this.groupBox2.Location = new System.Drawing.Point(13, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 148);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "BackUp Registry";
            // 
            // dgvBackup
            // 
            this.dgvBackup.AllowUserToAddRows = false;
            this.dgvBackup.AllowUserToDeleteRows = false;
            this.dgvBackup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBackup.Location = new System.Drawing.Point(3, 16);
            this.dgvBackup.Name = "dgvBackup";
            this.dgvBackup.ReadOnly = true;
            this.dgvBackup.Size = new System.Drawing.Size(355, 129);
            this.dgvBackup.TabIndex = 0;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(19, 86);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(322, 11);
            this.progBar.TabIndex = 3;
            // 
            // lblDateOfUpdateVal
            // 
            this.lblDateOfUpdateVal.AutoSize = true;
            this.lblDateOfUpdateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfUpdateVal.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblDateOfUpdateVal.Location = new System.Drawing.Point(120, 28);
            this.lblDateOfUpdateVal.Name = "lblDateOfUpdateVal";
            this.lblDateOfUpdateVal.Size = new System.Drawing.Size(0, 13);
            this.lblDateOfUpdateVal.TabIndex = 4;
            // 
            // Winform_BackUpDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 293);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Winform_BackUpDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database BackUp";
            this.Load += new System.EventHandler(this.Winform_BackUpDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBackup;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label lblDateOfUpdateVal;
    }
}