namespace SpindleSoft.Views
{
    partial class Winform_ExpenseRegister
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromExpenseDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFixedExpense = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvVariableExpense = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedExpense)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariableExpense)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToExpenseDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpFromExpenseDate);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 51);
            this.groupBox1.TabIndex = 136;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter Text to Search";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 135;
            this.label2.Text = "To Date";
            // 
            // dtpToExpenseDate
            // 
            this.dtpToExpenseDate.CustomFormat = "dd MMM yyyy";
            this.dtpToExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToExpenseDate.Location = new System.Drawing.Point(255, 19);
            this.dtpToExpenseDate.Name = "dtpToExpenseDate";
            this.dtpToExpenseDate.Size = new System.Drawing.Size(102, 20);
            this.dtpToExpenseDate.TabIndex = 134;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "From Date";
            // 
            // dtpFromExpenseDate
            // 
            this.dtpFromExpenseDate.CustomFormat = "dd MMM yyyy";
            this.dtpFromExpenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromExpenseDate.Location = new System.Drawing.Point(75, 19);
            this.dtpFromExpenseDate.Name = "dtpFromExpenseDate";
            this.dtpFromExpenseDate.Size = new System.Drawing.Size(102, 20);
            this.dtpFromExpenseDate.TabIndex = 132;
            this.dtpFromExpenseDate.ValueChanged += new System.EventHandler(this.dtpExpenseDate_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFixedExpense);
            this.groupBox2.Location = new System.Drawing.Point(9, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 108);
            this.groupBox2.TabIndex = 139;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fixed Expenses";
            // 
            // dgvFixedExpense
            // 
            this.dgvFixedExpense.AllowUserToAddRows = false;
            this.dgvFixedExpense.AllowUserToDeleteRows = false;
            this.dgvFixedExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFixedExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFixedExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFixedExpense.Location = new System.Drawing.Point(3, 16);
            this.dgvFixedExpense.Name = "dgvFixedExpense";
            this.dgvFixedExpense.ReadOnly = true;
            this.dgvFixedExpense.Size = new System.Drawing.Size(525, 89);
            this.dgvFixedExpense.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvVariableExpense);
            this.groupBox3.Location = new System.Drawing.Point(9, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(531, 108);
            this.groupBox3.TabIndex = 140;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variable Expenses";
            // 
            // dgvVariableExpense
            // 
            this.dgvVariableExpense.AllowUserToAddRows = false;
            this.dgvVariableExpense.AllowUserToDeleteRows = false;
            this.dgvVariableExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVariableExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariableExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVariableExpense.Location = new System.Drawing.Point(3, 16);
            this.dgvVariableExpense.Name = "dgvVariableExpense";
            this.dgvVariableExpense.ReadOnly = true;
            this.dgvVariableExpense.Size = new System.Drawing.Size(525, 89);
            this.dgvVariableExpense.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvExpense);
            this.groupBox4.Location = new System.Drawing.Point(9, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(531, 162);
            this.groupBox4.TabIndex = 140;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Expense Details";
            // 
            // dgvExpense
            // 
            this.dgvExpense.AllowUserToAddRows = false;
            this.dgvExpense.AllowUserToDeleteRows = false;
            this.dgvExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDelete});
            this.dgvExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpense.Location = new System.Drawing.Point(3, 16);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.ReadOnly = true;
            this.dgvExpense.Size = new System.Drawing.Size(525, 143);
            this.dgvExpense.TabIndex = 0;
            this.dgvExpense.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellClick);
            this.dgvExpense.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpense_CellDoubleClick);
            this.dgvExpense.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvExpense_PreviewKeyDown);
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Click To Delete";
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(18, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Click on the Expense for more details.";
            // 
            // Winform_ExpenseRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 499);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Winform_ExpenseRegister";
            this.Text = "Expense Register";
            this.Load += new System.EventHandler(this.Winform_ExpenseRegister_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFixedExpense)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariableExpense)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFromExpenseDate;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvFixedExpense;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvVariableExpense;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvExpense;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToExpenseDate;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}