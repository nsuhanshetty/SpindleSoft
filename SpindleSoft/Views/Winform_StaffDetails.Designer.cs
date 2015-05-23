namespace SpindleSoft.Views
{
    partial class Winform_StaffDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_StaffDetails));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.grbMemNo = new System.Windows.Forms.GroupBox();
            this.pcbMemImage = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.grbMemPersonDetail = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmailID = new System.Windows.Forms.Label();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.grbMemNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).BeginInit();
            this.grbMemPersonDetail.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStrip_Label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 261);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(523, 22);
            this.statusStrip1.TabIndex = 121;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip_Label
            // 
            this.toolStrip_Label.Name = "toolStrip_Label";
            this.toolStrip_Label.Size = new System.Drawing.Size(406, 17);
            this.toolStrip_Label.Spring = true;
            this.toolStrip_Label.Text = "Saved";
            this.toolStrip_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grbMemNo
            // 
            this.grbMemNo.Controls.Add(this.pcbMemImage);
            this.grbMemNo.Controls.Add(this.btnCapture);
            this.grbMemNo.Location = new System.Drawing.Point(12, 61);
            this.grbMemNo.Name = "grbMemNo";
            this.grbMemNo.Size = new System.Drawing.Size(141, 193);
            this.grbMemNo.TabIndex = 120;
            this.grbMemNo.TabStop = false;
            // 
            // pcbMemImage
            // 
            this.pcbMemImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbMemImage.BackgroundImage")));
            this.pcbMemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbMemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbMemImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbMemImage.InitialImage")));
            this.pcbMemImage.Location = new System.Drawing.Point(6, 19);
            this.pcbMemImage.Name = "pcbMemImage";
            this.pcbMemImage.Size = new System.Drawing.Size(128, 121);
            this.pcbMemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMemImage.TabIndex = 108;
            this.pcbMemImage.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.Location = new System.Drawing.Point(6, 151);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(130, 28);
            this.btnCapture.TabIndex = 0;
            this.btnCapture.Text = "CAPTURE PHOTO";
            this.btnCapture.UseVisualStyleBackColor = false;
            // 
            // grbMemPersonDetail
            // 
            this.grbMemPersonDetail.Controls.Add(this.lblAddress);
            this.grbMemPersonDetail.Controls.Add(this.txtAddress);
            this.grbMemPersonDetail.Controls.Add(this.lblEmailID);
            this.grbMemPersonDetail.Controls.Add(this.txtEmailID);
            this.grbMemPersonDetail.Controls.Add(this.lblMobile);
            this.grbMemPersonDetail.Controls.Add(this.txtName);
            this.grbMemPersonDetail.Controls.Add(this.lblName);
            this.grbMemPersonDetail.Controls.Add(this.txtMobNo);
            this.grbMemPersonDetail.Location = new System.Drawing.Point(159, 62);
            this.grbMemPersonDetail.Name = "grbMemPersonDetail";
            this.grbMemPersonDetail.Size = new System.Drawing.Size(354, 192);
            this.grbMemPersonDetail.TabIndex = 119;
            this.grbMemPersonDetail.TabStop = false;
            this.grbMemPersonDetail.Text = "Personal Details";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(13, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 93;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(86, 127);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(243, 51);
            this.txtAddress.TabIndex = 92;
            // 
            // lblEmailID
            // 
            this.lblEmailID.AutoSize = true;
            this.lblEmailID.Location = new System.Drawing.Point(13, 103);
            this.lblEmailID.Name = "lblEmailID";
            this.lblEmailID.Size = new System.Drawing.Size(46, 13);
            this.lblEmailID.TabIndex = 86;
            this.lblEmailID.Text = "Email ID";
            // 
            // txtEmailID
            // 
            this.txtEmailID.Location = new System.Drawing.Point(86, 100);
            this.txtEmailID.MaxLength = 100;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(243, 20);
            this.txtEmailID.TabIndex = 4;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(13, 48);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 84;
            this.lblMobile.Text = "Mobile No.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(243, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 82;
            this.lblName.Text = "Name ";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(86, 45);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(243, 20);
            this.txtMobNo.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.CancelToolStrip,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(523, 54);
            this.toolStrip1.TabIndex = 122;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(47, 51);
            this.toolStripButton1.Text = "Cancel";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // CancelToolStrip
            // 
            this.CancelToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("CancelToolStrip.Image")));
            this.CancelToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelToolStrip.Name = "CancelToolStrip";
            this.CancelToolStrip.Size = new System.Drawing.Size(36, 51);
            this.CancelToolStrip.Text = "Save";
            this.CancelToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // Winform_StaffDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 283);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grbMemNo);
            this.Controls.Add(this.grbMemPersonDetail);
            this.Name = "Winform_StaffDetails";
            this.Text = "Staff Details";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grbMemNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).EndInit();
            this.grbMemPersonDetail.ResumeLayout(false);
            this.grbMemPersonDetail.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        private System.Windows.Forms.GroupBox grbMemNo;
        internal System.Windows.Forms.PictureBox pcbMemImage;
        internal System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox grbMemPersonDetail;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblEmailID;
        internal System.Windows.Forms.TextBox txtEmailID;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtMobNo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton CancelToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}