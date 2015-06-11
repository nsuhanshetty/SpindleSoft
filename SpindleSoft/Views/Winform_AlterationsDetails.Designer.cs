namespace SpindleSoft.Views
{
    partial class Winform_AlterationsDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_AlterationsDetails));
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pcbMemImage = new System.Windows.Forms.PictureBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.txtAltNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpbxCustomerDetails = new System.Windows.Forms.GroupBox();
            this.grpbxAlterationdetails = new System.Windows.Forms.GroupBox();
            this.AddCustomerToolStrip = new System.Windows.Forms.ToolStripButton();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBalanceAmnt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotAmnt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmntPaid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.OrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderMeasurement = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OrderMeasureInherit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpbxAlterationdetails.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(203, 137);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneNo.TabIndex = 141;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 142;
            this.label5.Text = "Phone No.";
            // 
            // pcbMemImage
            // 
            this.pcbMemImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbMemImage.BackgroundImage")));
            this.pcbMemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbMemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbMemImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbMemImage.InitialImage")));
            this.pcbMemImage.Location = new System.Drawing.Point(12, 72);
            this.pcbMemImage.Name = "pcbMemImage";
            this.pcbMemImage.Size = new System.Drawing.Size(115, 108);
            this.pcbMemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMemImage.TabIndex = 140;
            this.pcbMemImage.TabStop = false;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(138, 114);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 139;
            this.lblMobile.Text = "Mobile No.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(203, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 136;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(138, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 138;
            this.lblName.Text = "Name ";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(203, 111);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(131, 20);
            this.txtMobNo.TabIndex = 137;
            // 
            // txtAltNo
            // 
            this.txtAltNo.Enabled = false;
            this.txtAltNo.Location = new System.Drawing.Point(81, 25);
            this.txtAltNo.MaxLength = 10;
            this.txtAltNo.Name = "txtAltNo";
            this.txtAltNo.Size = new System.Drawing.Size(133, 20);
            this.txtAltNo.TabIndex = 134;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 135;
            this.label1.Text = "Alteration No.";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(81, 77);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(133, 20);
            this.dtpDeliveryDate.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 132;
            this.label4.Text = "Delivery Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 26);
            this.button1.TabIndex = 131;
            this.button1.Text = "Edit Measurements";
            this.button1.UseVisualStyleBackColor = true;
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
            // grpbxCustomerDetails
            // 
            this.grpbxCustomerDetails.Location = new System.Drawing.Point(5, 57);
            this.grpbxCustomerDetails.Name = "grpbxCustomerDetails";
            this.grpbxCustomerDetails.Size = new System.Drawing.Size(336, 136);
            this.grpbxCustomerDetails.TabIndex = 145;
            this.grpbxCustomerDetails.TabStop = false;
            this.grpbxCustomerDetails.Text = "CustomerDetails";
            // 
            // grpbxAlterationdetails
            // 
            this.grpbxAlterationdetails.Controls.Add(this.txtOrderNo);
            this.grpbxAlterationdetails.Controls.Add(this.label3);
            this.grpbxAlterationdetails.Controls.Add(this.dtpDeliveryDate);
            this.grpbxAlterationdetails.Controls.Add(this.label4);
            this.grpbxAlterationdetails.Controls.Add(this.label1);
            this.grpbxAlterationdetails.Controls.Add(this.txtAltNo);
            this.grpbxAlterationdetails.Location = new System.Drawing.Point(348, 57);
            this.grpbxAlterationdetails.Name = "grpbxAlterationdetails";
            this.grpbxAlterationdetails.Size = new System.Drawing.Size(220, 135);
            this.grpbxAlterationdetails.TabIndex = 146;
            this.grpbxAlterationdetails.TabStop = false;
            this.grpbxAlterationdetails.Text = "Alteration Details";
            // 
            // AddCustomerToolStrip
            // 
            this.AddCustomerToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddCustomerToolStrip.Image")));
            this.AddCustomerToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddCustomerToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCustomerToolStrip.Name = "AddCustomerToolStrip";
            this.AddCustomerToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddCustomerToolStrip.Text = "Add Customer";
            this.AddCustomerToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCustomerToolStrip.Click += new System.EventHandler(this.AddCustomerToolStrip_Click);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Location = new System.Drawing.Point(81, 51);
            this.txtOrderNo.MaxLength = 10;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(133, 20);
            this.txtOrderNo.TabIndex = 147;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Order No.";
            // 
            // txtBalanceAmnt
            // 
            this.txtBalanceAmnt.Enabled = false;
            this.txtBalanceAmnt.Location = new System.Drawing.Point(445, 386);
            this.txtBalanceAmnt.MaxLength = 10;
            this.txtBalanceAmnt.Name = "txtBalanceAmnt";
            this.txtBalanceAmnt.Size = new System.Drawing.Size(115, 20);
            this.txtBalanceAmnt.TabIndex = 148;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(348, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 152;
            this.label7.Text = "Balance Amount";
            // 
            // txtTotAmnt
            // 
            this.txtTotAmnt.Enabled = false;
            this.txtTotAmnt.Location = new System.Drawing.Point(445, 414);
            this.txtTotAmnt.MaxLength = 10;
            this.txtTotAmnt.Name = "txtTotAmnt";
            this.txtTotAmnt.Size = new System.Drawing.Size(115, 20);
            this.txtTotAmnt.TabIndex = 149;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 151;
            this.label6.Text = "Total Amount";
            // 
            // txtAmntPaid
            // 
            this.txtAmntPaid.Location = new System.Drawing.Point(445, 359);
            this.txtAmntPaid.MaxLength = 10;
            this.txtAmntPaid.Name = "txtAmntPaid";
            this.txtAmntPaid.Size = new System.Drawing.Size(115, 20);
            this.txtAmntPaid.TabIndex = 147;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(366, 362);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 150;
            this.label8.Text = "Paid Amount";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOrderItems);
            this.groupBox2.Location = new System.Drawing.Point(5, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 150);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Order Details";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderType,
            this.OrderQuantity,
            this.OrderPrice,
            this.OrderMeasurement,
            this.OrderMeasureInherit});
            this.dgvOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderItems.Location = new System.Drawing.Point(3, 16);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.Size = new System.Drawing.Size(560, 131);
            this.dgvOrderItems.TabIndex = 0;
            // 
            // OrderType
            // 
            this.OrderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.OrderType.HeaderText = "Clothing Type";
            this.OrderType.Name = "OrderType";
            this.OrderType.Width = 103;
            // 
            // OrderQuantity
            // 
            this.OrderQuantity.HeaderText = "Quantity";
            this.OrderQuantity.Name = "OrderQuantity";
            // 
            // OrderPrice
            // 
            this.OrderPrice.HeaderText = "Price";
            this.OrderPrice.Name = "OrderPrice";
            // 
            // OrderMeasurement
            // 
            this.OrderMeasurement.HeaderText = "Edit Measurement";
            this.OrderMeasurement.Name = "OrderMeasurement";
            this.OrderMeasurement.Text = "Edit";
            // 
            // OrderMeasureInherit
            // 
            this.OrderMeasureInherit.HeaderText = "Inherit";
            this.OrderMeasureInherit.Name = "OrderMeasureInherit";
            // 
            // Winform_AlterationsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtBalanceAmnt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotAmnt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmntPaid);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pcbMemImage);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtMobNo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpbxCustomerDetails);
            this.Controls.Add(this.grpbxAlterationdetails);
            this.Name = "Winform_AlterationsDetails";
            this.Text = "Alterations Details";
            this.Load += new System.EventHandler(this.Winform_AlterationsDetails_Load);
            this.Controls.SetChildIndex(this.grpbxAlterationdetails, 0);
            this.Controls.SetChildIndex(this.grpbxCustomerDetails, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.txtMobNo, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblMobile, 0);
            this.Controls.SetChildIndex(this.pcbMemImage, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPhoneNo, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtAmntPaid, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTotAmnt, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtBalanceAmnt, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpbxAlterationdetails.ResumeLayout(false);
            this.grpbxAlterationdetails.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.PictureBox pcbMemImage;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtMobNo;
        internal System.Windows.Forms.TextBox txtAltNo;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton CancelToolStrip;
        internal System.Windows.Forms.ToolStripButton AddCustomerToolStrip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox grpbxCustomerDetails;
        private System.Windows.Forms.GroupBox grpbxAlterationdetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.TextBox txtOrderNo;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtBalanceAmnt;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtTotAmnt;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtAmntPaid;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderPrice;
        private System.Windows.Forms.DataGridViewButtonColumn OrderMeasurement;
        private System.Windows.Forms.DataGridViewCheckBoxColumn OrderMeasureInherit;
    }
}