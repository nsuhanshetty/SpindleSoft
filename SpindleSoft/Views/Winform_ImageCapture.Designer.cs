namespace SpindleSoft.Views
{
    partial class Winform_ImageCapture
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_ImageCapture));
            this.cmbCameraSelect = new System.Windows.Forms.ComboBox();
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblCameraSelect = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBoxShowConfigDialog = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCameraSelect
            // 
            this.cmbCameraSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCameraSelect.FormattingEnabled = true;
            this.cmbCameraSelect.Location = new System.Drawing.Point(94, 453);
            this.cmbCameraSelect.Name = "cmbCameraSelect";
            this.cmbCameraSelect.Size = new System.Drawing.Size(144, 21);
            this.cmbCameraSelect.TabIndex = 3;
            // 
            // picCapture
            // 
            this.picCapture.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCapture.Location = new System.Drawing.Point(1, 1);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(640, 408);
            this.picCapture.TabIndex = 6;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnCapture.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCapture.Image = ((System.Drawing.Image)(resources.GetObject("btnCapture.Image")));
            this.btnCapture.Location = new System.Drawing.Point(491, 420);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(111, 54);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Tag = "";
            this.btnCapture.Text = "Capture";
            this.btnCapture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCameraSelect
            // 
            this.lblCameraSelect.AutoSize = true;
            this.lblCameraSelect.Location = new System.Drawing.Point(4, 45);
            this.lblCameraSelect.Name = "lblCameraSelect";
            this.lblCameraSelect.Size = new System.Drawing.Size(76, 13);
            this.lblCameraSelect.TabIndex = 9;
            this.lblCameraSelect.Text = "Select Camera";
            // 
            // checkBoxShowConfigDialog
            // 
            this.checkBoxShowConfigDialog.AutoSize = true;
            this.checkBoxShowConfigDialog.Location = new System.Drawing.Point(12, 428);
            this.checkBoxShowConfigDialog.Name = "checkBoxShowConfigDialog";
            this.checkBoxShowConfigDialog.Size = new System.Drawing.Size(226, 17);
            this.checkBoxShowConfigDialog.TabIndex = 2;
            this.checkBoxShowConfigDialog.Text = "Show configuration dialogs before preview";
            this.checkBoxShowConfigDialog.UseVisualStyleBackColor = true;
            this.checkBoxShowConfigDialog.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCameraSelect);
            this.groupBox1.Location = new System.Drawing.Point(5, 411);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Details";
            // 
            // Winform_ImageCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 488);
            this.Controls.Add(this.checkBoxShowConfigDialog);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.cmbCameraSelect);
            this.Controls.Add(this.picCapture);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Winform_ImageCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture Image";
            this.Load += new System.EventHandler(this.WinformWebcam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbCameraSelect;
        internal System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblCameraSelect;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxShowConfigDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}