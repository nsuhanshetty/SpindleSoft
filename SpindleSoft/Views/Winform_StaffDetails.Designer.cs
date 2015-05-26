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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_StaffDetails));
            this.toolStrip_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.grbMemNo = new System.Windows.Forms.GroupBox();
            this.pcbStaffImage = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.grbMemPersonDetail = new System.Windows.Forms.GroupBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBoxStaffType = new System.Windows.Forms.GroupBox();
            this.rdbPerm = new System.Windows.Forms.RadioButton();
            this.rdbTemp = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grbMemNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStaffImage)).BeginInit();
            this.grbMemPersonDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpBoxStaffType.SuspendLayout();
            this.SuspendLayout();
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
            this.grbMemNo.Controls.Add(this.pcbStaffImage);
            this.grbMemNo.Controls.Add(this.btnCapture);
            this.grbMemNo.Location = new System.Drawing.Point(12, 61);
            this.grbMemNo.Name = "grbMemNo";
            this.grbMemNo.Size = new System.Drawing.Size(141, 193);
            this.grbMemNo.TabIndex = 1;
            this.grbMemNo.TabStop = false;
            // 
            // pcbStaffImage
            // 
            this.pcbStaffImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbStaffImage.BackgroundImage")));
            this.pcbStaffImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbStaffImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbStaffImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbStaffImage.InitialImage")));
            this.pcbStaffImage.Location = new System.Drawing.Point(6, 19);
            this.pcbStaffImage.Name = "pcbStaffImage";
            this.pcbStaffImage.Size = new System.Drawing.Size(128, 121);
            this.pcbStaffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbStaffImage.TabIndex = 108;
            this.pcbStaffImage.TabStop = false;
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
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // grbMemPersonDetail
            // 
            this.grbMemPersonDetail.Controls.Add(this.label1);
            this.grbMemPersonDetail.Controls.Add(this.grpBoxStaffType);
            this.grbMemPersonDetail.Controls.Add(this.lblAddress);
            this.grbMemPersonDetail.Controls.Add(this.txtAddress);
            this.grbMemPersonDetail.Controls.Add(this.lblMobile);
            this.grbMemPersonDetail.Controls.Add(this.txtName);
            this.grbMemPersonDetail.Controls.Add(this.lblName);
            this.grbMemPersonDetail.Controls.Add(this.txtMobNo);
            this.grbMemPersonDetail.Location = new System.Drawing.Point(159, 62);
            this.grbMemPersonDetail.Name = "grbMemPersonDetail";
            this.grbMemPersonDetail.Size = new System.Drawing.Size(354, 192);
            this.grbMemPersonDetail.TabIndex = 0;
            this.grbMemPersonDetail.TabStop = false;
            this.grbMemPersonDetail.Text = "Personal Details";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 90);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 93;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(86, 87);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(243, 51);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(12, 61);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 84;
            this.lblMobile.Text = "Mobile No.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(243, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 82;
            this.lblName.Text = "Name ";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(86, 57);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(243, 20);
            this.txtMobNo.TabIndex = 1;
            this.txtMobNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobNo_Validating);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpBoxStaffType
            // 
            this.grpBoxStaffType.Controls.Add(this.rdbTemp);
            this.grpBoxStaffType.Controls.Add(this.rdbPerm);
            this.grpBoxStaffType.Enabled = false;
            this.grpBoxStaffType.Location = new System.Drawing.Point(86, 144);
            this.grpBoxStaffType.Name = "grpBoxStaffType";
            this.grpBoxStaffType.Size = new System.Drawing.Size(243, 36);
            this.grpBoxStaffType.TabIndex = 94;
            this.grpBoxStaffType.TabStop = false;
            // 
            // rdbPerm
            // 
            this.rdbPerm.AutoSize = true;
            this.rdbPerm.Checked = true;
            this.rdbPerm.Location = new System.Drawing.Point(32, 14);
            this.rdbPerm.Name = "rdbPerm";
            this.rdbPerm.Size = new System.Drawing.Size(76, 17);
            this.rdbPerm.TabIndex = 0;
            this.rdbPerm.TabStop = true;
            this.rdbPerm.Text = "Permanent";
            this.rdbPerm.UseVisualStyleBackColor = true;
            // 
            // rdbTemp
            // 
            this.rdbTemp.AutoSize = true;
            this.rdbTemp.Location = new System.Drawing.Point(144, 14);
            this.rdbTemp.Name = "rdbTemp";
            this.rdbTemp.Size = new System.Drawing.Size(75, 17);
            this.rdbTemp.TabIndex = 1;
            this.rdbTemp.Text = "Temporary";
            this.rdbTemp.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Staff Type";
            // 
            // Winform_StaffDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 283);
            this.Controls.Add(this.grbMemNo);
            this.Controls.Add(this.grbMemPersonDetail);
            this.Name = "Winform_StaffDetails";
            this.Text = "Staff Details";
            this.Controls.SetChildIndex(this.grbMemPersonDetail, 0);
            this.Controls.SetChildIndex(this.grbMemNo, 0);
            this.grbMemNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbStaffImage)).EndInit();
            this.grbMemPersonDetail.ResumeLayout(false);
            this.grbMemPersonDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpBoxStaffType.ResumeLayout(false);
            this.grpBoxStaffType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMemNo;
        internal System.Windows.Forms.PictureBox pcbStaffImage;
        internal System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.GroupBox grbMemPersonDetail;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtMobNo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        //private System.Windows.Forms.ToolStripButton CancelToolStrip;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        //private System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        private System.Windows.Forms.GroupBox grpBoxStaffType;
        private System.Windows.Forms.RadioButton rdbTemp;
        private System.Windows.Forms.RadioButton rdbPerm;
        internal System.Windows.Forms.Label label1;
    }
}