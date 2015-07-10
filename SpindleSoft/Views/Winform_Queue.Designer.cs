namespace SpindleSoft.Views
{
    partial class Winform_Queue
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvR2S = new System.Windows.Forms.DataGridView();
            this.dgvSIP = new System.Windows.Forms.DataGridView();
            this.dgvR2D = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR2S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR2D)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvR2S);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 305);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ready To Stitch";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSIP);
            this.groupBox2.Location = new System.Drawing.Point(244, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 336);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stitch In Progress";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvR2D);
            this.groupBox3.Location = new System.Drawing.Point(476, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 305);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ready To Deliver";
            // 
            // dgvR2S
            // 
            this.dgvR2S.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvR2S.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvR2S.Location = new System.Drawing.Point(3, 16);
            this.dgvR2S.Name = "dgvR2S";
            this.dgvR2S.Size = new System.Drawing.Size(194, 286);
            this.dgvR2S.TabIndex = 0;
            // 
            // dgvSIP
            // 
            this.dgvSIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSIP.Location = new System.Drawing.Point(0, 19);
            this.dgvSIP.Name = "dgvSIP";
            this.dgvSIP.Size = new System.Drawing.Size(200, 280);
            this.dgvSIP.TabIndex = 1;
            // 
            // dgvR2D
            // 
            this.dgvR2D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvR2D.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvR2D.Location = new System.Drawing.Point(3, 16);
            this.dgvR2D.Name = "dgvR2D";
            this.dgvR2D.Size = new System.Drawing.Size(194, 286);
            this.dgvR2D.TabIndex = 1;
            // 
            // Winform_Queue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 372);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Winform_Queue";
            this.Text = "Queue";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvR2S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR2D)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvR2S;
        private System.Windows.Forms.DataGridView dgvSIP;
        private System.Windows.Forms.DataGridView dgvR2D;
    }
}