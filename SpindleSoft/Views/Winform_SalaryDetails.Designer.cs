namespace SpindleSoft.Views
{
    partial class Winform_SalaryDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_SalaryDetails));
            this.lblDateOfSalary = new System.Windows.Forms.Label();
            this.dtpSalary = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAddSalary = new System.Windows.Forms.Button();
            this.dgvSalaryItems = new System.Windows.Forms.DataGridView();
            this.StaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalSalaryPaid = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateOfSalary
            // 
            this.lblDateOfSalary.AutoSize = true;
            this.lblDateOfSalary.Location = new System.Drawing.Point(253, 71);
            this.lblDateOfSalary.Name = "lblDateOfSalary";
            this.lblDateOfSalary.Size = new System.Drawing.Size(76, 13);
            this.lblDateOfSalary.TabIndex = 123;
            this.lblDateOfSalary.Text = "Date Of Salary";
            // 
            // dtpSalary
            // 
            this.dtpSalary.Location = new System.Drawing.Point(335, 65);
            this.dtpSalary.Name = "dtpSalary";
            this.dtpSalary.Size = new System.Drawing.Size(136, 20);
            this.dtpSalary.TabIndex = 124;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAddSalary);
            this.groupBox2.Controls.Add(this.dgvSalaryItems);
            this.groupBox2.Controls.Add(this.btnAddItem);
            this.groupBox2.Location = new System.Drawing.Point(10, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 213);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Order Details";
            // 
            // btnAddSalary
            // 
            this.btnAddSalary.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddSalary.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddSalary.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSalary.Image")));
            this.btnAddSalary.Location = new System.Drawing.Point(416, 10);
            this.btnAddSalary.Name = "btnAddSalary";
            this.btnAddSalary.Size = new System.Drawing.Size(39, 35);
            this.btnAddSalary.TabIndex = 156;
            this.btnAddSalary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddSalary.UseVisualStyleBackColor = false;
            this.btnAddSalary.Click += new System.EventHandler(this.btnAddSalary_Click);
            // 
            // dgvSalaryItems
            // 
            this.dgvSalaryItems.AllowUserToAddRows = false;
            this.dgvSalaryItems.AllowUserToDeleteRows = false;
            this.dgvSalaryItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalaryItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StaffName,
            this.Amount,
            this.colDelete});
            this.dgvSalaryItems.Location = new System.Drawing.Point(3, 51);
            this.dgvSalaryItems.Name = "dgvSalaryItems";
            this.dgvSalaryItems.ReadOnly = true;
            this.dgvSalaryItems.Size = new System.Drawing.Size(452, 156);
            this.dgvSalaryItems.TabIndex = 0;
            this.dgvSalaryItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderItems_CellContentClick);
            // 
            // StaffName
            // 
            this.StaffName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StaffName.HeaderText = "Staff Name";
            this.StaffName.Name = "StaffName";
            this.StaffName.ReadOnly = true;
            this.StaffName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StaffName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colDelete.HeaderText = "Click To Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDelete.Width = 96;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(547, 10);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(39, 35);
            this.btnAddItem.TabIndex = 155;
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddItem.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Total Salary Paid";
            // 
            // txtTotalSalaryPaid
            // 
            this.txtTotalSalaryPaid.Enabled = false;
            this.txtTotalSalaryPaid.Location = new System.Drawing.Point(348, 307);
            this.txtTotalSalaryPaid.Name = "txtTotalSalaryPaid";
            this.txtTotalSalaryPaid.Size = new System.Drawing.Size(117, 20);
            this.txtTotalSalaryPaid.TabIndex = 127;
            // 
            // Winform_SalaryDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 354);
            this.ControlBox = false;
            this.Controls.Add(this.txtTotalSalaryPaid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtpSalary);
            this.Controls.Add(this.lblDateOfSalary);
            this.Name = "Winform_SalaryDetails";
            this.Text = "Salary Details";
            this.Controls.SetChildIndex(this.lblDateOfSalary, 0);
            this.Controls.SetChildIndex(this.dtpSalary, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTotalSalaryPaid, 0);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalaryItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDateOfSalary;
        private System.Windows.Forms.DateTimePicker dtpSalary;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSalaryItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnAddSalary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalSalaryPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}