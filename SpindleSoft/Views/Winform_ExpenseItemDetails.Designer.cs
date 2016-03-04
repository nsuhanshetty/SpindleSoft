namespace SpindleSoft.Views
{
    partial class Winform_ExpenseItemDetails
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbVariable = new System.Windows.Forms.RadioButton();
            this.rdbFixed = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.cmbName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Expense Details";
            // 
            // nudAmount
            // 
            this.nudAmount.Location = new System.Drawing.Point(73, 89);
            this.nudAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(68, 20);
            this.nudAmount.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 133;
            this.label4.Text = "Amount";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(73, 114);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(234, 77);
            this.txtComment.TabIndex = 3;
            // 
            // cmbName
            // 
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(73, 61);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(174, 21);
            this.cmbName.TabIndex = 1;
            this.cmbName.Validated += new System.EventHandler(this.cmbName_Validated);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbVariable);
            this.groupBox2.Controls.Add(this.rdbFixed);
            this.groupBox2.Location = new System.Drawing.Point(73, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 36);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // rdbVariable
            // 
            this.rdbVariable.AutoSize = true;
            this.rdbVariable.Location = new System.Drawing.Point(91, 13);
            this.rdbVariable.Name = "rdbVariable";
            this.rdbVariable.Size = new System.Drawing.Size(63, 17);
            this.rdbVariable.TabIndex = 1;
            this.rdbVariable.Text = "Variable";
            this.rdbVariable.UseVisualStyleBackColor = true;
            // 
            // rdbFixed
            // 
            this.rdbFixed.AutoSize = true;
            this.rdbFixed.Checked = true;
            this.rdbFixed.Location = new System.Drawing.Point(18, 13);
            this.rdbFixed.Name = "rdbFixed";
            this.rdbFixed.Size = new System.Drawing.Size(50, 17);
            this.rdbFixed.TabIndex = 0;
            this.rdbFixed.TabStop = true;
            this.rdbFixed.Text = "Fixed";
            this.rdbFixed.UseVisualStyleBackColor = true;
            this.rdbFixed.CheckedChanged += new System.EventHandler(this.rdbFixed_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "Comment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 126;
            this.label1.Text = "Type";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Winform_ExpenseItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 282);
            this.Controls.Add(this.groupBox1);
            this.Name = "Winform_ExpenseItemDetails";
            this.Text = "Add Expense Item Details";
            this.Load += new System.EventHandler(this.Winform_ExpenseItemDetails_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbVariable;
        private System.Windows.Forms.RadioButton rdbFixed;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}