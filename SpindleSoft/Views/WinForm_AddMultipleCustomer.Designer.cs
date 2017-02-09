namespace SpindleSoft.Views
{
    partial class WinForm_AddMultipleCustomer
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.grpbxSearch = new System.Windows.Forms.GroupBox();
            this.lblInst = new System.Windows.Forms.Label();
            this.dgvCustomerRegister = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvSelectedCustomer = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grpbxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerRegister)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(47, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.dgvCustomerReload);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 23);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(35, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Name";
            // 
            // grpbxSearch
            // 
            this.grpbxSearch.Controls.Add(this.lblInst);
            this.grpbxSearch.Controls.Add(this.dgvCustomerRegister);
            this.grpbxSearch.Controls.Add(this.lblSearch);
            this.grpbxSearch.Controls.Add(this.txtName);
            this.grpbxSearch.Location = new System.Drawing.Point(12, 13);
            this.grpbxSearch.Name = "grpbxSearch";
            this.grpbxSearch.Size = new System.Drawing.Size(450, 297);
            this.grpbxSearch.TabIndex = 0;
            this.grpbxSearch.TabStop = false;
            this.grpbxSearch.Text = "Search";
            // 
            // lblInst
            // 
            this.lblInst.AutoSize = true;
            this.lblInst.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInst.Location = new System.Drawing.Point(6, 56);
            this.lblInst.Name = "lblInst";
            this.lblInst.Size = new System.Drawing.Size(164, 13);
            this.lblInst.TabIndex = 2;
            this.lblInst.Text = "*Double  Click to select Customer";
            // 
            // dgvCustomerRegister
            // 
            this.dgvCustomerRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomerRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerRegister.Location = new System.Drawing.Point(6, 75);
            this.dgvCustomerRegister.Name = "dgvCustomerRegister";
            this.dgvCustomerRegister.Size = new System.Drawing.Size(441, 216);
            this.dgvCustomerRegister.TabIndex = 1;
            this.dgvCustomerRegister.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerRegister_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.dgvSelectedCustomer);
            this.groupBox1.Location = new System.Drawing.Point(468, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 297);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Participants";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(260, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvSelectedCustomer
            // 
            this.dgvSelectedCustomer.AllowUserToAddRows = false;
            this.dgvSelectedCustomer.AllowUserToDeleteRows = false;
            this.dgvSelectedCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectedCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colMobile,
            this.colRemove});
            this.dgvSelectedCustomer.Location = new System.Drawing.Point(6, 56);
            this.dgvSelectedCustomer.Name = "dgvSelectedCustomer";
            this.dgvSelectedCustomer.ReadOnly = true;
            this.dgvSelectedCustomer.Size = new System.Drawing.Size(347, 235);
            this.dgvSelectedCustomer.TabIndex = 1;
            this.dgvSelectedCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectedCustomer_CellContentClick);
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colMobile
            // 
            this.colMobile.HeaderText = "MobileNo";
            this.colMobile.Name = "colMobile";
            this.colMobile.ReadOnly = true;
            // 
            // colRemove
            // 
            this.colRemove.HeaderText = "Click to Remove";
            this.colRemove.Name = "colRemove";
            this.colRemove.ReadOnly = true;
            // 
            // WinForm_AddMultipleCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 322);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpbxSearch);
            this.Name = "WinForm_AddMultipleCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Multiple Customer";
            this.Load += new System.EventHandler(this.WinForm_AddMultipleCustomer_Load);
            this.grpbxSearch.ResumeLayout(false);
            this.grpbxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerRegister)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox grpbxSearch;
        private System.Windows.Forms.DataGridView dgvCustomerRegister;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvSelectedCustomer;
        private System.Windows.Forms.Label lblInst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMobile;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove;
        private System.Windows.Forms.Button btnAdd;
    }
}