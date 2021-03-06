﻿namespace SpindleSoft.Views
{
    partial class Winform_SalesDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_SalesDetails));
            this.grpBoxCustomer = new System.Windows.Forms.GroupBox();
            this.pcbCustImage = new System.Windows.Forms.PictureBox();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.dgvSaleItem = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AddCustToolStrip = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.colCart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpBxSearch = new System.Windows.Forms.GroupBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSrcProCode = new System.Windows.Forms.TextBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.txtSrcName = new System.Windows.Forms.TextBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpbxPayDet = new System.Windows.Forms.GroupBox();
            this.txtAmntPaid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBalanceAmnt = new System.Windows.Forms.TextBox();
            this.txtTotAmnt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpBoxCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItem)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.grpBxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpbxPayDet.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.grpBoxCustomer.Location = new System.Drawing.Point(467, 57);
            this.grpBoxCustomer.Name = "grpBoxCustomer";
            this.grpBoxCustomer.Size = new System.Drawing.Size(247, 111);
            this.grpBoxCustomer.TabIndex = 0;
            this.grpBoxCustomer.TabStop = false;
            this.grpBoxCustomer.Text = "Customer Details";
            // 
            // pcbCustImage
            // 
            this.pcbCustImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbCustImage.BackgroundImage")));
            this.pcbCustImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbCustImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbCustImage.Enabled = false;
            this.pcbCustImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbCustImage.InitialImage")));
            this.pcbCustImage.Location = new System.Drawing.Point(6, 23);
            this.pcbCustImage.Name = "pcbCustImage";
            this.pcbCustImage.Size = new System.Drawing.Size(88, 88);
            this.pcbCustImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbCustImage.TabIndex = 123;
            this.pcbCustImage.TabStop = false;
            // 
            // txtMobNo
            // 
            this.txtMobNo.Enabled = false;
            this.txtMobNo.Location = new System.Drawing.Point(158, 55);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(85, 20);
            this.txtMobNo.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Enabled = false;
            this.lblName.Location = new System.Drawing.Point(100, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 121;
            this.lblName.Text = "Name ";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(158, 29);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(85, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Enabled = false;
            this.lblMobile.Location = new System.Drawing.Point(100, 58);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 122;
            this.lblMobile.Text = "Mobile No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Location = new System.Drawing.Point(100, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Phone No.";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Enabled = false;
            this.txtPhoneNo.Location = new System.Drawing.Point(158, 81);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(85, 20);
            this.txtPhoneNo.TabIndex = 2;
            // 
            // dgvSaleItem
            // 
            this.dgvSaleItem.AllowUserToAddRows = false;
            this.dgvSaleItem.AllowUserToDeleteRows = false;
            this.dgvSaleItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSaleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colProductCode,
            this.ColQuantity,
            this.colPrice,
            this.colStock,
            this.colDelete});
            this.dgvSaleItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSaleItem.Location = new System.Drawing.Point(3, 16);
            this.dgvSaleItem.Name = "dgvSaleItem";
            this.dgvSaleItem.ReadOnly = true;
            this.dgvSaleItem.Size = new System.Drawing.Size(435, 253);
            this.dgvSaleItem.TabIndex = 2;
            this.dgvSaleItem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_CellClick);
//            this.dgvSaleItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_CellDoubleClick);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "ProductCode";
            this.colProductCode.HeaderText = "ProductCode";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            // 
            // ColQuantity
            // 
            this.ColQuantity.DataPropertyName = "Quantity";
            this.ColQuantity.HeaderText = "Quantity";
            this.ColQuantity.Name = "ColQuantity";
            this.ColQuantity.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.HeaderText = "InStock";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            this.colStock.Visible = false;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Click To Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AddCustToolStrip
            // 
            this.AddCustToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddCustToolStrip.Image")));
            this.AddCustToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddCustToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCustToolStrip.Name = "AddCustToolStrip";
            this.AddCustToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddCustToolStrip.Text = "&Add Customer";
            this.AddCustToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCustToolStrip.Click += new System.EventHandler(this.AddCustToolStrip_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSearch);
            this.panel1.Controls.Add(this.grpBxSearch);
            this.panel1.Location = new System.Drawing.Point(5, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 388);
            this.panel1.TabIndex = 1;
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCart});
            this.dgvSearch.Location = new System.Drawing.Point(5, 115);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(442, 273);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellClick);
            //this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSaleItem_CellDoubleClick);
            // 
            // colCart
            // 
            this.colCart.HeaderText = "Add to Cart";
            this.colCart.Name = "colCart";
            this.colCart.ReadOnly = true;
            // 
            // grpBxSearch
            // 
            this.grpBxSearch.Controls.Add(this.txtDesc);
            this.grpBxSearch.Controls.Add(this.label6);
            this.grpBxSearch.Controls.Add(this.label10);
            this.grpBxSearch.Controls.Add(this.txtSrcProCode);
            this.grpBxSearch.Controls.Add(this.cmbMaterial);
            this.grpBxSearch.Controls.Add(this.label1);
            this.grpBxSearch.Controls.Add(this.cmbSize);
            this.grpBxSearch.Controls.Add(this.txtSrcName);
            this.grpBxSearch.Controls.Add(this.cmbColor);
            this.grpBxSearch.Controls.Add(this.label4);
            this.grpBxSearch.Controls.Add(this.label8);
            this.grpBxSearch.Controls.Add(this.label9);
            this.grpBxSearch.Location = new System.Drawing.Point(4, 7);
            this.grpBxSearch.Name = "grpBxSearch";
            this.grpBxSearch.Size = new System.Drawing.Size(443, 103);
            this.grpBxSearch.TabIndex = 0;
            this.grpBxSearch.TabStop = false;
            this.grpBxSearch.Text = "Search Details";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(69, 77);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(147, 20);
            this.txtDesc.TabIndex = 2;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(229, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 142;
            this.label6.Text = "Material";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 138;
            this.label10.Text = "Description";
            // 
            // txtSrcProCode
            // 
            this.txtSrcProCode.Location = new System.Drawing.Point(69, 48);
            this.txtSrcProCode.Name = "txtSrcProCode";
            this.txtSrcProCode.Size = new System.Drawing.Size(147, 20);
            this.txtSrcProCode.TabIndex = 1;
            this.txtSrcProCode.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(282, 77);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(78, 21);
            this.cmbMaterial.TabIndex = 5;
            this.cmbMaterial.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 139;
            this.label1.Text = "Name ";
            // 
            // cmbSize
            // 
            this.cmbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(282, 46);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(78, 21);
            this.cmbSize.TabIndex = 4;
            this.cmbSize.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // txtSrcName
            // 
            this.txtSrcName.Location = new System.Drawing.Point(69, 19);
            this.txtSrcName.Name = "txtSrcName";
            this.txtSrcName.Size = new System.Drawing.Size(147, 20);
            this.txtSrcName.TabIndex = 0;
            this.txtSrcName.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(282, 15);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(78, 21);
            this.cmbColor.TabIndex = 3;
            this.cmbColor.TextChanged += new System.EventHandler(this.txtSrcName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 140;
            this.label4.Text = "Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(242, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 140;
            this.label8.Text = "Color";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(246, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 141;
            this.label9.Text = "Size";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // grpbxPayDet
            // 
            this.grpbxPayDet.Controls.Add(this.txtAmntPaid);
            this.grpbxPayDet.Controls.Add(this.label2);
            this.grpbxPayDet.Controls.Add(this.label3);
            this.grpbxPayDet.Controls.Add(this.label7);
            this.grpbxPayDet.Controls.Add(this.txtBalanceAmnt);
            this.grpbxPayDet.Controls.Add(this.txtTotAmnt);
            this.grpbxPayDet.Location = new System.Drawing.Point(720, 58);
            this.grpbxPayDet.Name = "grpbxPayDet";
            this.grpbxPayDet.Size = new System.Drawing.Size(188, 110);
            this.grpbxPayDet.TabIndex = 137;
            this.grpbxPayDet.TabStop = false;
            this.grpbxPayDet.Text = "Payment Details";
            // 
            // txtAmntPaid
            // 
            this.txtAmntPaid.Location = new System.Drawing.Point(98, 28);
            this.txtAmntPaid.MaxLength = 10;
            this.txtAmntPaid.Name = "txtAmntPaid";
            this.txtAmntPaid.Size = new System.Drawing.Size(84, 20);
            this.txtAmntPaid.TabIndex = 3;
            this.txtAmntPaid.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAmntPaid_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 133;
            this.label2.Text = "Paid Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 134;
            this.label3.Text = "Total Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 135;
            this.label7.Text = "Balance Amount";
            // 
            // txtBalanceAmnt
            // 
            this.txtBalanceAmnt.Enabled = false;
            this.txtBalanceAmnt.Location = new System.Drawing.Point(98, 53);
            this.txtBalanceAmnt.MaxLength = 10;
            this.txtBalanceAmnt.Name = "txtBalanceAmnt";
            this.txtBalanceAmnt.Size = new System.Drawing.Size(84, 20);
            this.txtBalanceAmnt.TabIndex = 4;
            // 
            // txtTotAmnt
            // 
            this.txtTotAmnt.Enabled = false;
            this.txtTotAmnt.Location = new System.Drawing.Point(98, 78);
            this.txtTotAmnt.MaxLength = 10;
            this.txtTotAmnt.Name = "txtTotAmnt";
            this.txtTotAmnt.Size = new System.Drawing.Size(84, 20);
            this.txtTotAmnt.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSaleItem);
            this.groupBox1.Location = new System.Drawing.Point(467, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 272);
            this.groupBox1.TabIndex = 138;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sale Item Details";
            // 
            // Winform_SalesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpBoxCustomer);
            this.Controls.Add(this.grpbxPayDet);
            this.Controls.Add(this.groupBox1);
            this.Name = "Winform_SalesDetails";
            this.Text = "Add Sales Details";
            this.Load += new System.EventHandler(this.Winform_SalesDetails_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpbxPayDet, 0);
            this.Controls.SetChildIndex(this.grpBoxCustomer, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.grpBoxCustomer.ResumeLayout(false);
            this.grpBoxCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleItem)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.grpBxSearch.ResumeLayout(false);
            this.grpBxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpbxPayDet.ResumeLayout(false);
            this.grpbxPayDet.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxCustomer;
        internal System.Windows.Forms.PictureBox pcbCustImage;
        internal System.Windows.Forms.TextBox txtMobNo;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.DataGridView dgvSaleItem;
        private System.Windows.Forms.ToolStripButton AddCustToolStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grpBxSearch;
        private System.Windows.Forms.DataGridView dgvSearch;
        internal System.Windows.Forms.TextBox txtSrcProCode;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtSrcName;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtDesc;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox grpbxPayDet;
        internal System.Windows.Forms.TextBox txtBalanceAmnt;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtTotAmnt;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAmntPaid;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colCart;

    }
}