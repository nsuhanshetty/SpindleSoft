namespace SpindleSoft.Views
{
    partial class Winform_OrderDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_OrderDetails));
            this.pcbCustImage = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.OrderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OrderQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderMeasurement = new System.Windows.Forms.DataGridViewButtonColumn();
            this.OrderDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpBoxCustomer = new System.Windows.Forms.GroupBox();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.AddCustomerToolStrip = new System.Windows.Forms.ToolStripButton();
            this.NewOrderTypeToolStrip = new System.Windows.Forms.ToolStripButton();
            this.AddReferralToolStrip = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtAmntPaid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBalanceAmnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotAmnt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.grpBoxCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbCustImage
            // 
            this.pcbCustImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbCustImage.BackgroundImage")));
            this.pcbCustImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbCustImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbCustImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbCustImage.InitialImage")));
            this.pcbCustImage.Location = new System.Drawing.Point(6, 23);
            this.pcbCustImage.Name = "pcbCustImage";
            this.pcbCustImage.Size = new System.Drawing.Size(120, 115);
            this.pcbCustImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCustImage.TabIndex = 123;
            this.pcbCustImage.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(206, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(109, 20);
            this.txtName.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvOrderItems);
            this.groupBox2.Location = new System.Drawing.Point(8, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 166);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Order Details";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderType,
            this.OrderQuantity,
            this.OrderPrice,
            this.OrderMeasurement,
            this.OrderDelete});
            this.dgvOrderItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderItems.Location = new System.Drawing.Point(3, 16);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.Size = new System.Drawing.Size(586, 147);
            this.dgvOrderItems.TabIndex = 0;
            this.dgvOrderItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvOrderItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellEndEdit);
            this.dgvOrderItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOrderItems_DataError);
            this.dgvOrderItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOrderItems_EditingControlShowing);
            // 
            // OrderType
            // 
            this.OrderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.OrderType.HeaderText = "Clothing Type";
            this.OrderType.Name = "OrderType";
            // 
            // OrderQuantity
            // 
            this.OrderQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderQuantity.HeaderText = "Quantity";
            this.OrderQuantity.Name = "OrderQuantity";
            // 
            // OrderPrice
            // 
            this.OrderPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderPrice.HeaderText = "Price\\ Item";
            this.OrderPrice.Name = "OrderPrice";
            // 
            // OrderMeasurement
            // 
            this.OrderMeasurement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OrderMeasurement.HeaderText = "Measurement Details";
            this.OrderMeasurement.Name = "OrderMeasurement";
            this.OrderMeasurement.Text = "Edit";
            // 
            // OrderDelete
            // 
            this.OrderDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.OrderDelete.HeaderText = "Click To Delete";
            this.OrderDelete.Name = "OrderDelete";
            this.OrderDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OrderDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OrderDelete.Width = 96;
            // 
            // grpBoxCustomer
            // 
            this.grpBoxCustomer.Controls.Add(this.pcbCustImage);
            this.grpBoxCustomer.Controls.Add(this.txtMobNo);
            this.grpBoxCustomer.Controls.Add(this.lblName);
            this.grpBoxCustomer.Controls.Add(this.txtName);
            this.grpBoxCustomer.Controls.Add(this.lblMobile);
            this.grpBoxCustomer.Controls.Add(this.label5);
            this.grpBoxCustomer.Controls.Add(this.txtPhoneNo);
            this.grpBoxCustomer.Enabled = false;
            this.grpBoxCustomer.Location = new System.Drawing.Point(8, 60);
            this.grpBoxCustomer.Name = "grpBoxCustomer";
            this.grpBoxCustomer.Size = new System.Drawing.Size(336, 145);
            this.grpBoxCustomer.TabIndex = 0;
            this.grpBoxCustomer.TabStop = false;
            this.grpBoxCustomer.Text = "Customer Details";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(206, 70);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(109, 20);
            this.txtMobNo.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(141, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 121;
            this.lblName.Text = "Name ";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(141, 73);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 122;
            this.lblMobile.Text = "Mobile No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Phone No.";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(206, 96);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(109, 20);
            this.txtPhoneNo.TabIndex = 2;
            // 
            // AddCustomerToolStrip
            // 
            this.AddCustomerToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddCustomerToolStrip.Image")));
            this.AddCustomerToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddCustomerToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCustomerToolStrip.Name = "AddCustomerToolStrip";
            this.AddCustomerToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddCustomerToolStrip.Text = "&Add Customer";
            this.AddCustomerToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCustomerToolStrip.Click += new System.EventHandler(this.AddCustomerToolStrip_Click);
            // 
            // NewOrderTypeToolStrip
            // 
            this.NewOrderTypeToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("NewOrderTypeToolStrip.Image")));
            this.NewOrderTypeToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NewOrderTypeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewOrderTypeToolStrip.Name = "NewOrderTypeToolStrip";
            this.NewOrderTypeToolStrip.Size = new System.Drawing.Size(76, 51);
            this.NewOrderTypeToolStrip.Text = "New Order Type";
            this.NewOrderTypeToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // AddReferralToolStrip
            // 
            this.AddReferralToolStrip.Name = "AddReferralToolStrip";
            this.AddReferralToolStrip.Size = new System.Drawing.Size(23, 23);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtAmntPaid
            // 
            this.txtAmntPaid.Location = new System.Drawing.Point(100, 93);
            this.txtAmntPaid.MaxLength = 10;
            this.txtAmntPaid.Name = "txtAmntPaid";
            this.txtAmntPaid.Size = new System.Drawing.Size(113, 20);
            this.txtAmntPaid.TabIndex = 156;
            this.txtAmntPaid.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmntPaid_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 157;
            this.label8.Text = "Paid Amount";
            // 
            // txtBalanceAmnt
            // 
            this.txtBalanceAmnt.Enabled = false;
            this.txtBalanceAmnt.Location = new System.Drawing.Point(100, 67);
            this.txtBalanceAmnt.MaxLength = 10;
            this.txtBalanceAmnt.Name = "txtBalanceAmnt";
            this.txtBalanceAmnt.Size = new System.Drawing.Size(113, 20);
            this.txtBalanceAmnt.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Balance Amount";
            // 
            // txtTotAmnt
            // 
            this.txtTotAmnt.Enabled = false;
            this.txtTotAmnt.Location = new System.Drawing.Point(100, 41);
            this.txtTotAmnt.MaxLength = 10;
            this.txtTotAmnt.Name = "txtTotAmnt";
            this.txtTotAmnt.Size = new System.Drawing.Size(113, 20);
            this.txtTotAmnt.TabIndex = 138;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 140;
            this.label6.Text = "Total Amount";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(464, 214);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 23);
            this.btnDelete.TabIndex = 155;
            this.btnDelete.Text = "Select Row to Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(100, 15);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(113, 20);
            this.dtpDeliveryDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 128;
            this.label4.Text = "Due Date";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAmntPaid);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBalanceAmnt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDeliveryDate);
            this.groupBox1.Controls.Add(this.txtTotAmnt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(364, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 145);
            this.groupBox1.TabIndex = 156;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Status Details";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Ready To Stitch",
            "Stitch In Progress",
            "Ready To Collect",
            "Delivered"});
            this.cmbStatus.Location = new System.Drawing.Point(100, 120);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(113, 21);
            this.cmbStatus.TabIndex = 141;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 140;
            this.label7.Text = "Order Status";
            // 
            // Winform_OrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 430);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpBoxCustomer);
            this.Controls.Add(this.groupBox2);
            this.Name = "Winform_OrderDetails";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.Winform_OrderDetails_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grpBoxCustomer, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.grpBoxCustomer.ResumeLayout(false);
            this.grpBoxCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pcbCustImage;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.GroupBox grpBoxCustomer;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        internal System.Windows.Forms.ToolStripButton AddReferralToolStrip;
        
        //Toolstrip Add
        internal System.Windows.Forms.ToolStripButton AddCustomerToolStrip;
        internal System.Windows.Forms.ToolStripButton NewOrderTypeToolStrip;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTotAmnt;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.TextBox txtAmntPaid;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtBalanceAmnt;
        internal System.Windows.Forms.TextBox txtMobNo;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewComboBoxColumn OrderType;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderPrice;
        private System.Windows.Forms.DataGridViewButtonColumn OrderMeasurement;
        private System.Windows.Forms.DataGridViewButtonColumn OrderDelete;
    }
}