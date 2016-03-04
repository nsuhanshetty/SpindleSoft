namespace SpindleSoft.Views
{
    partial class WinForm_SKUDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinForm_SKUDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbVendorMade = new System.Windows.Forms.RadioButton();
            this.rdbSelfMade = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbSize = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpBxVendDetails = new System.Windows.Forms.GroupBox();
            this.txtVendMobile = new System.Windows.Forms.TextBox();
            this.txtVendName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NewVendToolStrip = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.dgvItemSKUDoc = new System.Windows.Forms.DataGridView();
            this.colDocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpBxVendDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSKUDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(106, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbVendorMade);
            this.groupBox1.Controls.Add(this.rdbSelfMade);
            this.groupBox1.Location = new System.Drawing.Point(106, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 33);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // rdbVendorMade
            // 
            this.rdbVendorMade.AutoSize = true;
            this.rdbVendorMade.Location = new System.Drawing.Point(78, 11);
            this.rdbVendorMade.Name = "rdbVendorMade";
            this.rdbVendorMade.Size = new System.Drawing.Size(59, 17);
            this.rdbVendorMade.TabIndex = 1;
            this.rdbVendorMade.Text = "Vendor";
            this.rdbVendorMade.UseVisualStyleBackColor = true;
            this.rdbVendorMade.CheckedChanged += new System.EventHandler(this.rdbSelfMade_CheckedChanged);
            // 
            // rdbSelfMade
            // 
            this.rdbSelfMade.AutoSize = true;
            this.rdbSelfMade.Checked = true;
            this.rdbSelfMade.Location = new System.Drawing.Point(10, 11);
            this.rdbSelfMade.Name = "rdbSelfMade";
            this.rdbSelfMade.Size = new System.Drawing.Size(43, 17);
            this.rdbSelfMade.TabIndex = 0;
            this.rdbSelfMade.TabStop = true;
            this.rdbSelfMade.Text = "Self";
            this.rdbSelfMade.UseVisualStyleBackColor = true;
            this.rdbSelfMade.CheckedChanged += new System.EventHandler(this.rdbSelfMade_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product Source";
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(67, 16);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(50, 20);
            this.txtCP.TabIndex = 0;
            this.txtCP.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cost Price";
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(196, 16);
            this.txtSP.Name = "txtSP";
            this.txtSP.Size = new System.Drawing.Size(50, 20);
            this.txtSP.TabIndex = 1;
            this.txtSP.Validating += new System.ComponentModel.CancelEventHandler(this.textBox2_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Selling Price";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSP);
            this.groupBox2.Controls.Add(this.txtCP);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(13, 377);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 43);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Color";
            // 
            // cmbColor
            // 
            this.cmbColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(93, 18);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(156, 21);
            this.cmbColor.TabIndex = 0;
            this.cmbColor.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // cmbSize
            // 
            this.cmbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSize.FormattingEnabled = true;
            this.cmbSize.Location = new System.Drawing.Point(93, 44);
            this.cmbSize.Name = "cmbSize";
            this.cmbSize.Size = new System.Drawing.Size(156, 21);
            this.cmbSize.TabIndex = 1;
            this.cmbSize.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Size";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(93, 70);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(156, 21);
            this.cmbMaterial.TabIndex = 2;
            this.cmbMaterial.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMaterial_Validating);
            this.cmbMaterial.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Material";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmbMaterial);
            this.groupBox3.Controls.Add(this.cmbSize);
            this.groupBox3.Controls.Add(this.cmbColor);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variations";
            // 
            // grpBxVendDetails
            // 
            this.grpBxVendDetails.Controls.Add(this.txtVendMobile);
            this.grpBxVendDetails.Controls.Add(this.txtVendName);
            this.grpBxVendDetails.Controls.Add(this.label9);
            this.grpBxVendDetails.Controls.Add(this.label10);
            this.grpBxVendDetails.Enabled = false;
            this.grpBxVendDetails.Location = new System.Drawing.Point(13, 302);
            this.grpBxVendDetails.Name = "grpBxVendDetails";
            this.grpBxVendDetails.Size = new System.Drawing.Size(260, 69);
            this.grpBxVendDetails.TabIndex = 5;
            this.grpBxVendDetails.TabStop = false;
            this.grpBxVendDetails.Text = "Vendor Details";
            // 
            // txtVendMobile
            // 
            this.txtVendMobile.Location = new System.Drawing.Point(93, 39);
            this.txtVendMobile.Name = "txtVendMobile";
            this.txtVendMobile.Size = new System.Drawing.Size(155, 20);
            this.txtVendMobile.TabIndex = 1;
            // 
            // txtVendName
            // 
            this.txtVendName.Location = new System.Drawing.Point(93, 13);
            this.txtVendName.Name = "txtVendName";
            this.txtVendName.Size = new System.Drawing.Size(155, 20);
            this.txtVendName.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Mobile No.";
            // 
            // NewVendToolStrip
            // 
            this.NewVendToolStrip.Enabled = false;
            this.NewVendToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("NewVendToolStrip.Image")));
            this.NewVendToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NewVendToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewVendToolStrip.Name = "NewVendToolStrip";
            this.NewVendToolStrip.Size = new System.Drawing.Size(36, 51);
            this.NewVendToolStrip.Text = "&New Vendor";
            this.NewVendToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewVendToolStrip.Click += new System.EventHandler(this.NewVendToolStrip_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(106, 106);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(155, 50);
            this.txtDesc.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 123;
            this.label8.Text = "Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 125;
            this.label11.Text = "Product Code";
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(106, 83);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 431);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 127;
            this.label12.Text = "Quantity";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(80, 424);
            this.txtQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 20);
            this.txtQuantity.TabIndex = 128;
            this.txtQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnAddItem);
            this.groupBox6.Controls.Add(this.dgvItemSKUDoc);
            this.groupBox6.Location = new System.Drawing.Point(12, 454);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(329, 161);
            this.groupBox6.TabIndex = 129;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Order Item Documents";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(280, 13);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(39, 35);
            this.btnAddItem.TabIndex = 156;
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // dgvItemSKUDoc
            // 
            this.dgvItemSKUDoc.AllowUserToAddRows = false;
            this.dgvItemSKUDoc.AllowUserToDeleteRows = false;
            this.dgvItemSKUDoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemSKUDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemSKUDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDocType,
            this.ColDelete});
            this.dgvItemSKUDoc.Location = new System.Drawing.Point(3, 54);
            this.dgvItemSKUDoc.Name = "dgvItemSKUDoc";
            this.dgvItemSKUDoc.ReadOnly = true;
            this.dgvItemSKUDoc.Size = new System.Drawing.Size(316, 100);
            this.dgvItemSKUDoc.TabIndex = 0;
            this.dgvItemSKUDoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItemDoc_CellClick);
            // 
            // colDocType
            // 
            this.colDocType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDocType.HeaderText = "Document Type";
            this.colDocType.Name = "colDocType";
            this.colDocType.ReadOnly = true;
            this.colDocType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColDelete
            // 
            this.ColDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColDelete.HeaderText = "Click To Delete";
            this.ColDelete.Name = "ColDelete";
            this.ColDelete.ReadOnly = true;
            this.ColDelete.Width = 77;
            // 
            // WinForm_SKUDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 640);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grpBxVendDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "WinForm_SKUDetails";
            this.Text = "Product Details";
            this.Load += new System.EventHandler(this.WinForm_Sale_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.grpBxVendDetails, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtDesc, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtQuantity, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpBxVendDetails.ResumeLayout(false);
            this.grpBxVendDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemSKUDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbVendorMade;
        private System.Windows.Forms.RadioButton rdbSelfMade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpBxVendDetails;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVendMobile;
        private System.Windows.Forms.TextBox txtVendName;
        private System.Windows.Forms.ToolStripButton NewVendToolStrip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.DataGridView dgvItemSKUDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDocType;
        private System.Windows.Forms.DataGridViewButtonColumn ColDelete;
    }
}