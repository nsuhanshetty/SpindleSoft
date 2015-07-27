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
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpbxCustomerDetails = new System.Windows.Forms.GroupBox();
            this.AddCustomerToolStrip = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvAlterationItems = new System.Windows.Forms.DataGridView();
            this.AltType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AltPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AltQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AltComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpBxSearch = new System.Windows.Forms.GroupBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.grpbxPayDet = new System.Windows.Forms.GroupBox();
            this.txtBalanceAmnt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotAmnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmntPaid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlterationItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.grpBxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.grpbxPayDet.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(628, 137);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneNo.TabIndex = 141;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(563, 140);
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
            this.pcbMemImage.Location = new System.Drawing.Point(437, 72);
            this.pcbMemImage.Name = "pcbMemImage";
            this.pcbMemImage.Size = new System.Drawing.Size(115, 108);
            this.pcbMemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMemImage.TabIndex = 140;
            this.pcbMemImage.TabStop = false;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(563, 114);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 139;
            this.lblMobile.Text = "Mobile No.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(628, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 136;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(563, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 138;
            this.lblName.Text = "Name ";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(628, 111);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(131, 20);
            this.txtMobNo.TabIndex = 137;
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
            this.grpbxCustomerDetails.Location = new System.Drawing.Point(430, 57);
            this.grpbxCustomerDetails.Name = "grpbxCustomerDetails";
            this.grpbxCustomerDetails.Size = new System.Drawing.Size(336, 136);
            this.grpbxCustomerDetails.TabIndex = 145;
            this.grpbxCustomerDetails.TabStop = false;
            this.grpbxCustomerDetails.Text = "CustomerDetails";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAlterationItems);
            this.groupBox2.Location = new System.Drawing.Point(430, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 188);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Alteration Item Details";
            // 
            // dgvAlterationItems
            // 
            this.dgvAlterationItems.AllowUserToDeleteRows = false;
            this.dgvAlterationItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlterationItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlterationItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AltType,
            this.AltPrice,
            this.AltQuantity,
            this.AltComment});
            this.dgvAlterationItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlterationItems.Location = new System.Drawing.Point(3, 16);
            this.dgvAlterationItems.Name = "dgvAlterationItems";
            this.dgvAlterationItems.Size = new System.Drawing.Size(564, 169);
            this.dgvAlterationItems.TabIndex = 0;
            this.dgvAlterationItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellEndEdit);
            this.dgvAlterationItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAlterationItems_EditingControlShowing);
            this.dgvAlterationItems.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlterationItems_RowLeave);
            // 
            // AltType
            // 
            this.AltType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AltType.DataPropertyName = "Name";
            this.AltType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.AltType.HeaderText = "Clothing Type";
            this.AltType.Name = "AltType";
            this.AltType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // AltPrice
            // 
            this.AltPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AltPrice.DataPropertyName = "Price";
            this.AltPrice.HeaderText = "Price \\ Item";
            this.AltPrice.Name = "AltPrice";
            this.AltPrice.Width = 87;
            // 
            // AltQuantity
            // 
            this.AltQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.AltQuantity.DataPropertyName = "Quantity";
            this.AltQuantity.HeaderText = "Quantity";
            this.AltQuantity.Name = "AltQuantity";
            this.AltQuantity.Width = 71;
            // 
            // AltComment
            // 
            this.AltComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AltComment.DataPropertyName = "Comment";
            this.AltComment.HeaderText = "Comment";
            this.AltComment.Name = "AltComment";
            this.AltComment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AltComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpBxSearch);
            this.panel1.Controls.Add(this.dgvSearch);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 348);
            this.panel1.TabIndex = 2;
            // 
            // grpBxSearch
            // 
            this.grpBxSearch.Controls.Add(this.txtOrderID);
            this.grpBxSearch.Controls.Add(this.label2);
            this.grpBxSearch.Location = new System.Drawing.Point(4, 7);
            this.grpBxSearch.Name = "grpBxSearch";
            this.grpBxSearch.Size = new System.Drawing.Size(405, 52);
            this.grpBxSearch.TabIndex = 0;
            this.grpBxSearch.TabStop = false;
            this.grpBxSearch.Text = "Search Details";
            // 
            // txtOrderID
            // 
            this.txtOrderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtOrderID.Location = new System.Drawing.Point(65, 21);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(118, 20);
            this.txtOrderID.TabIndex = 140;
            this.txtOrderID.Validated += new System.EventHandler(this.txtOrderID_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 139;
            this.label2.Text = "Order No.";
            // 
            // dgvSearch
            // 
            this.dgvSearch.AllowUserToAddRows = false;
            this.dgvSearch.AllowUserToDeleteRows = false;
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(3, 65);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.ReadOnly = true;
            this.dgvSearch.Size = new System.Drawing.Size(406, 280);
            this.dgvSearch.TabIndex = 1;
            this.dgvSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearch_CellDoubleClick);
            // 
            // grpbxPayDet
            // 
            this.grpbxPayDet.Controls.Add(this.txtBalanceAmnt);
            this.grpbxPayDet.Controls.Add(this.label1);
            this.grpbxPayDet.Controls.Add(this.txtTotAmnt);
            this.grpbxPayDet.Controls.Add(this.label3);
            this.grpbxPayDet.Controls.Add(this.txtAmntPaid);
            this.grpbxPayDet.Controls.Add(this.label4);
            this.grpbxPayDet.Location = new System.Drawing.Point(772, 89);
            this.grpbxPayDet.Name = "grpbxPayDet";
            this.grpbxPayDet.Size = new System.Drawing.Size(228, 106);
            this.grpbxPayDet.TabIndex = 141;
            this.grpbxPayDet.TabStop = false;
            this.grpbxPayDet.Text = "Payment Details";
            // 
            // txtBalanceAmnt
            // 
            this.txtBalanceAmnt.Enabled = false;
            this.txtBalanceAmnt.Location = new System.Drawing.Point(92, 45);
            this.txtBalanceAmnt.MaxLength = 10;
            this.txtBalanceAmnt.Name = "txtBalanceAmnt";
            this.txtBalanceAmnt.Size = new System.Drawing.Size(109, 20);
            this.txtBalanceAmnt.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Balance Amount";
            // 
            // txtTotAmnt
            // 
            this.txtTotAmnt.Enabled = false;
            this.txtTotAmnt.Location = new System.Drawing.Point(92, 70);
            this.txtTotAmnt.MaxLength = 10;
            this.txtTotAmnt.Name = "txtTotAmnt";
            this.txtTotAmnt.Size = new System.Drawing.Size(109, 20);
            this.txtTotAmnt.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 140;
            this.label3.Text = "Total Amount";
            // 
            // txtAmntPaid
            // 
            this.txtAmntPaid.Location = new System.Drawing.Point(92, 20);
            this.txtAmntPaid.MaxLength = 10;
            this.txtAmntPaid.Name = "txtAmntPaid";
            this.txtAmntPaid.Size = new System.Drawing.Size(109, 20);
            this.txtAmntPaid.TabIndex = 136;
            this.txtAmntPaid.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmntPaid_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 139;
            this.label4.Text = "Paid Amount";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(876, 62);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(116, 20);
            this.dtpDueDate.TabIndex = 139;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(814, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 140;
            this.label9.Text = "Due Date ";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(867, 201);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 23);
            this.btnDelete.TabIndex = 154;
            this.btnDelete.Text = "Select Row && Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Winform_AlterationsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 433);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpbxPayDet);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtPhoneNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pcbMemImage);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtMobNo);
            this.Controls.Add(this.grpbxCustomerDetails);
            this.Name = "Winform_AlterationsDetails";
            this.Text = "Alterations Details";
            this.Load += new System.EventHandler(this.Winform_AlterationsDetails_Load);
            this.Controls.SetChildIndex(this.grpbxCustomerDetails, 0);
            this.Controls.SetChildIndex(this.txtMobNo, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.lblMobile, 0);
            this.Controls.SetChildIndex(this.pcbMemImage, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPhoneNo, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.dtpDueDate, 0);
            this.Controls.SetChildIndex(this.grpbxPayDet, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlterationItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grpBxSearch.ResumeLayout(false);
            this.grpBxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.grpbxPayDet.ResumeLayout(false);
            this.grpbxPayDet.PerformLayout();
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
        //private System.Windows.Forms.ToolStripButton CancelToolStrip;
        internal System.Windows.Forms.ToolStripButton AddCustomerToolStrip;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox grpbxCustomerDetails;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvAlterationItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.GroupBox grpBxSearch;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpbxPayDet;
        internal System.Windows.Forms.TextBox txtBalanceAmnt;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtTotAmnt;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAmntPaid;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripButton CancelToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.DataGridViewComboBoxColumn AltType;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AltComment;
    }
}