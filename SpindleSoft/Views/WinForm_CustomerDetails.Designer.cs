namespace SpindleSoft.Views
{
    partial class WinForm_CustomerDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_CustomerDetails));
            this.grbMemPersonDetail = new System.Windows.Forms.GroupBox();
            this.pcbCustImage = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblEmailID = new System.Windows.Forms.Label();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.AddReferralToolStrip = new System.Windows.Forms.ToolStripButton();
            this.MeasurementDetailsToolStrip = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.process1 = new System.Diagnostics.Process();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRefMob = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefName = new System.Windows.Forms.TextBox();
            this.pcbReferral = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbMemPersonDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReferral)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMemPersonDetail
            // 
            this.grbMemPersonDetail.Controls.Add(this.pcbCustImage);
            this.grbMemPersonDetail.Controls.Add(this.btnCapture);
            this.grbMemPersonDetail.Controls.Add(this.lblPhoneNo);
            this.grbMemPersonDetail.Controls.Add(this.txtPhoneNo);
            this.grbMemPersonDetail.Controls.Add(this.lblAddress);
            this.grbMemPersonDetail.Controls.Add(this.txtAddress);
            this.grbMemPersonDetail.Controls.Add(this.lblEmailID);
            this.grbMemPersonDetail.Controls.Add(this.txtEmailID);
            this.grbMemPersonDetail.Controls.Add(this.lblMobile);
            this.grbMemPersonDetail.Controls.Add(this.txtName);
            this.grbMemPersonDetail.Controls.Add(this.lblName);
            this.grbMemPersonDetail.Controls.Add(this.txtMobNo);
            this.grbMemPersonDetail.Location = new System.Drawing.Point(12, 65);
            this.grbMemPersonDetail.Name = "grbMemPersonDetail";
            this.grbMemPersonDetail.Size = new System.Drawing.Size(509, 188);
            this.grbMemPersonDetail.TabIndex = 0;
            this.grbMemPersonDetail.TabStop = false;
            this.grbMemPersonDetail.Text = "Personal Details";
            // 
            // pcbCustImage
            // 
            this.pcbCustImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbCustImage.BackgroundImage")));
            this.pcbCustImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbCustImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbCustImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbCustImage.InitialImage")));
            this.pcbCustImage.Location = new System.Drawing.Point(11, 20);
            this.pcbCustImage.Name = "pcbCustImage";
            this.pcbCustImage.Size = new System.Drawing.Size(128, 121);
            this.pcbCustImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCustImage.TabIndex = 110;
            this.pcbCustImage.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapture.Location = new System.Drawing.Point(11, 152);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(130, 28);
            this.btnCapture.TabIndex = 109;
            this.btnCapture.Text = "CAPTURE PHOTO";
            this.btnCapture.UseVisualStyleBackColor = false;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click_1);
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(160, 76);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(82, 13);
            this.lblPhoneNo.TabIndex = 0;
            this.lblPhoneNo.Text = "Phone No. [+0 ]";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(246, 73);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(243, 20);
            this.txtPhoneNo.TabIndex = 2;
            this.txtPhoneNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhoneNo_Validating);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(160, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 93;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(246, 127);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(243, 32);
            this.txtAddress.TabIndex = 4;
            // 
            // lblEmailID
            // 
            this.lblEmailID.AutoSize = true;
            this.lblEmailID.Location = new System.Drawing.Point(160, 103);
            this.lblEmailID.Name = "lblEmailID";
            this.lblEmailID.Size = new System.Drawing.Size(46, 13);
            this.lblEmailID.TabIndex = 86;
            this.lblEmailID.Text = "Email ID";
            // 
            // txtEmailID
            // 
            this.txtEmailID.Location = new System.Drawing.Point(246, 100);
            this.txtEmailID.MaxLength = 100;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(243, 20);
            this.txtEmailID.TabIndex = 3;
            this.txtEmailID.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmailID_Validating);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(160, 47);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(85, 13);
            this.lblMobile.TabIndex = 84;
            this.lblMobile.Text = "Mobile No. [+91]";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(246, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(243, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(160, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 82;
            this.lblName.Text = "Name ";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(246, 46);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(243, 20);
            this.txtMobNo.TabIndex = 1;
            this.txtMobNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobNo_Validating);
            // 
            // AddReferralToolStrip
            // 
            this.AddReferralToolStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AddReferralToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddReferralToolStrip.Image")));
            this.AddReferralToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddReferralToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddReferralToolStrip.Name = "AddReferralToolStrip";
            this.AddReferralToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddReferralToolStrip.Text = "&Add Referral";
            this.AddReferralToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddReferralToolStrip.Click += new System.EventHandler(this.AddReferralToolStrip_Click);
            // 
            // MeasurementDetailsToolStrip
            // 
            this.MeasurementDetailsToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("MeasurementDetailsToolStrip.Image")));
            this.MeasurementDetailsToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MeasurementDetailsToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MeasurementDetailsToolStrip.Name = "MeasurementDetailsToolStrip";
            this.MeasurementDetailsToolStrip.Size = new System.Drawing.Size(76, 51);
            this.MeasurementDetailsToolStrip.Text = "Measurements";
            this.MeasurementDetailsToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MeasurementDetailsToolStrip.Click += new System.EventHandler(this.MeasurementDetailsToolStrip_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRefMob);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRefName);
            this.groupBox1.Controls.Add(this.pcbReferral);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(509, 130);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Referred By Details";
            // 
            // txtRefMob
            // 
            this.txtRefMob.Enabled = false;
            this.txtRefMob.Location = new System.Drawing.Point(246, 61);
            this.txtRefMob.Name = "txtRefMob";
            this.txtRefMob.Size = new System.Drawing.Size(243, 20);
            this.txtRefMob.TabIndex = 113;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Mobile No. [+91]";
            // 
            // txtRefName
            // 
            this.txtRefName.Enabled = false;
            this.txtRefName.Location = new System.Drawing.Point(246, 35);
            this.txtRefName.Name = "txtRefName";
            this.txtRefName.Size = new System.Drawing.Size(243, 20);
            this.txtRefName.TabIndex = 111;
            // 
            // pcbReferral
            // 
            this.pcbReferral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbReferral.BackgroundImage")));
            this.pcbReferral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbReferral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbReferral.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbReferral.InitialImage")));
            this.pcbReferral.Location = new System.Drawing.Point(13, 19);
            this.pcbReferral.Name = "pcbReferral";
            this.pcbReferral.Size = new System.Drawing.Size(113, 103);
            this.pcbReferral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbReferral.TabIndex = 109;
            this.pcbReferral.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Name";
            // 
            // WinForm_CustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 419);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbMemPersonDetail);
            this.Name = "WinForm_CustomerDetails";
            this.Text = "Customer Details Form ";
            this.Load += new System.EventHandler(this.WinForm_CustomerDetails_Load);
            this.Controls.SetChildIndex(this.grbMemPersonDetail, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grbMemPersonDetail.ResumeLayout(false);
            this.grbMemPersonDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbReferral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMemPersonDetail;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Diagnostics.Process process1;
        internal System.Windows.Forms.ToolStripButton AddReferralToolStrip;
        internal System.Windows.Forms.ToolStripButton MeasurementDetailsToolStrip;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.PictureBox pcbReferral;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.PictureBox pcbCustImage;
        internal System.Windows.Forms.Button btnCapture;
        internal System.Windows.Forms.Label lblPhoneNo;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblEmailID;
        internal System.Windows.Forms.TextBox txtEmailID;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtMobNo;
        private System.Windows.Forms.TextBox txtRefName;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRefMob;
    }
}