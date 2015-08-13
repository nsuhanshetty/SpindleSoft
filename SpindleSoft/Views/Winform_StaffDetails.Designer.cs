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
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxStaffType = new System.Windows.Forms.GroupBox();
            this.rdbOSrc = new System.Windows.Forms.RadioButton();
            this.rdbTemp = new System.Windows.Forms.RadioButton();
            this.rdbPerm = new System.Windows.Forms.RadioButton();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserBankName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIFSCNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSecurityDoc = new System.Windows.Forms.DataGridView();
            this.colDocType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDocPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDocAdd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDocView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.grbMemNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbStaffImage)).BeginInit();
            this.grbMemPersonDetail.SuspendLayout();
            this.grpBoxStaffType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecurityDoc)).BeginInit();
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
            this.grbMemPersonDetail.Controls.Add(this.lblPhoneNo);
            this.grbMemPersonDetail.Controls.Add(this.txtPhoneNo);
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
            this.grbMemPersonDetail.Size = new System.Drawing.Size(364, 192);
            this.grbMemPersonDetail.TabIndex = 0;
            this.grbMemPersonDetail.TabStop = false;
            this.grbMemPersonDetail.Text = "Personal Details";
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(12, 82);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(82, 13);
            this.lblPhoneNo.TabIndex = 96;
            this.lblPhoneNo.Text = "Phone No. [+0 ]";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(98, 80);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(243, 20);
            this.txtPhoneNo.TabIndex = 2;
            this.txtPhoneNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhoneNo_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Staff Type";
            // 
            // grpBoxStaffType
            // 
            this.grpBoxStaffType.Controls.Add(this.rdbOSrc);
            this.grpBoxStaffType.Controls.Add(this.rdbTemp);
            this.grpBoxStaffType.Controls.Add(this.rdbPerm);
            this.grpBoxStaffType.Location = new System.Drawing.Point(98, 140);
            this.grpBoxStaffType.Name = "grpBoxStaffType";
            this.grpBoxStaffType.Size = new System.Drawing.Size(243, 36);
            this.grpBoxStaffType.TabIndex = 4;
            this.grpBoxStaffType.TabStop = false;
            // 
            // rdbOSrc
            // 
            this.rdbOSrc.AutoSize = true;
            this.rdbOSrc.Location = new System.Drawing.Point(162, 14);
            this.rdbOSrc.Name = "rdbOSrc";
            this.rdbOSrc.Size = new System.Drawing.Size(79, 17);
            this.rdbOSrc.TabIndex = 2;
            this.rdbOSrc.Text = "Out Source";
            this.rdbOSrc.UseVisualStyleBackColor = true;
            // 
            // rdbTemp
            // 
            this.rdbTemp.AutoSize = true;
            this.rdbTemp.Location = new System.Drawing.Point(88, 14);
            this.rdbTemp.Name = "rdbTemp";
            this.rdbTemp.Size = new System.Drawing.Size(75, 17);
            this.rdbTemp.TabIndex = 1;
            this.rdbTemp.Text = "Temporary";
            this.rdbTemp.UseVisualStyleBackColor = true;
            // 
            // rdbPerm
            // 
            this.rdbPerm.AutoSize = true;
            this.rdbPerm.Checked = true;
            this.rdbPerm.Location = new System.Drawing.Point(6, 14);
            this.rdbPerm.Name = "rdbPerm";
            this.rdbPerm.Size = new System.Drawing.Size(76, 17);
            this.rdbPerm.TabIndex = 0;
            this.rdbPerm.TabStop = true;
            this.rdbPerm.Text = "Permanent";
            this.rdbPerm.UseVisualStyleBackColor = true;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(12, 111);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 93;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(98, 107);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(243, 32);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(12, 57);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(85, 13);
            this.lblMobile.TabIndex = 84;
            this.lblMobile.Text = "Mobile No. [+91]";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(98, 29);
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
            this.txtMobNo.Location = new System.Drawing.Point(98, 54);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUserBankName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIFSCNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAccNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBankName);
            this.groupBox1.Location = new System.Drawing.Point(159, 259);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 119);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bank Details";
            // 
            // txtUserBankName
            // 
            this.txtUserBankName.Location = new System.Drawing.Point(98, 17);
            this.txtUserBankName.Name = "txtUserBankName";
            this.txtUserBankName.Size = new System.Drawing.Size(243, 20);
            this.txtUserBankName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 125;
            this.label4.Text = "IFSC Code";
            // 
            // txtIFSCNo
            // 
            this.txtIFSCNo.Location = new System.Drawing.Point(98, 89);
            this.txtIFSCNo.MaxLength = 20;
            this.txtIFSCNo.Name = "txtIFSCNo";
            this.txtIFSCNo.Size = new System.Drawing.Size(243, 20);
            this.txtIFSCNo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 98;
            this.label5.Text = "Name ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Acc. No";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(98, 64);
            this.txtAccNo.MaxLength = 20;
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.Size = new System.Drawing.Size(243, 20);
            this.txtAccNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Bank Name";
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(98, 41);
            this.txtBankName.MaxLength = 10;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(243, 20);
            this.txtBankName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvSecurityDoc);
            this.groupBox2.Location = new System.Drawing.Point(159, 385);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 119);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Security Documents";
            // 
            // dgvSecurityDoc
            // 
            this.dgvSecurityDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecurityDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocType,
            this.colDocPath,
            this.colDocAdd,
            this.colDocView,
            this.ColDelete});
            this.dgvSecurityDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSecurityDoc.Location = new System.Drawing.Point(3, 16);
            this.dgvSecurityDoc.Name = "dgvSecurityDoc";
            this.dgvSecurityDoc.Size = new System.Drawing.Size(412, 100);
            this.dgvSecurityDoc.TabIndex = 0;
            this.dgvSecurityDoc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSecurityDoc_CellContentClick);
            this.dgvSecurityDoc.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSecurityDoc_DataError);
            this.dgvSecurityDoc.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSecDocumet_EditingControlShowing);
            // 
            // colDocType
            // 
            this.colDocType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colDocType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colDocType.HeaderText = "Document Type";
            this.colDocType.Name = "colDocType";
            this.colDocType.Width = 80;
            // 
            // colDocPath
            // 
            this.colDocPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDocPath.HeaderText = "Document Path";
            this.colDocPath.Name = "colDocPath";
            this.colDocPath.ReadOnly = true;
            // 
            // colDocAdd
            // 
            this.colDocAdd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDocAdd.HeaderText = "Click To Add";
            this.colDocAdd.Name = "colDocAdd";
            // 
            // colDocView
            // 
            this.colDocView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDocView.HeaderText = "Click To View";
            this.colDocView.Name = "colDocView";
            // 
            // ColDelete
            // 
            this.ColDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColDelete.HeaderText = "Click To Delete";
            this.ColDelete.Name = "ColDelete";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";
            // 
            // Winform_StaffDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 532);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbMemNo);
            this.Controls.Add(this.grbMemPersonDetail);
            this.Name = "Winform_StaffDetails";
            this.Text = "Staff Details";
            this.Load += new System.EventHandler(this.Winform_StaffDetails_Load);
            this.Controls.SetChildIndex(this.grbMemPersonDetail, 0);
            this.Controls.SetChildIndex(this.grbMemNo, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.grbMemNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbStaffImage)).EndInit();
            this.grbMemPersonDetail.ResumeLayout(false);
            this.grbMemPersonDetail.PerformLayout();
            this.grpBoxStaffType.ResumeLayout(false);
            this.grpBoxStaffType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecurityDoc)).EndInit();
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
        //private System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        //private System.Windows.Forms.ToolStripButton CancelToolStrip;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.Label lblPhoneNo;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.RadioButton rdbOSrc;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAccNo;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtBankName;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtIFSCNo;
        internal System.Windows.Forms.TextBox txtUserBankName;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        private System.Windows.Forms.ToolStripButton CancelToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSecurityDoc;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocPath;
        private System.Windows.Forms.DataGridViewButtonColumn colDocAdd;
        private System.Windows.Forms.DataGridViewButtonColumn colDocView;
        private System.Windows.Forms.DataGridViewButtonColumn ColDelete;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}