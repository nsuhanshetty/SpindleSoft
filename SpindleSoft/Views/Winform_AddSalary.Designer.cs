namespace SpindleSoft.Views
{
    partial class Winform_AddSalary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_AddSalary));
            this.AddStaffToolStrip = new System.Windows.Forms.ToolStripButton();
            this.grpBoxCustomer = new System.Windows.Forms.GroupBox();
            this.pcbCustImage = new System.Windows.Forms.PictureBox();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSalaryAmount = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpBoxCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalaryAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddStaffToolStrip
            // 
            this.AddStaffToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddStaffToolStrip.Image")));
            this.AddStaffToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddStaffToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddStaffToolStrip.Name = "AddStaffToolStrip";
            this.AddStaffToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddStaffToolStrip.Text = "&Add Staff";
            this.AddStaffToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddStaffToolStrip.Click += new System.EventHandler(this.AddStaffToolStrip_Click);
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
            this.grpBoxCustomer.Location = new System.Drawing.Point(11, 57);
            this.grpBoxCustomer.Name = "grpBoxCustomer";
            this.grpBoxCustomer.Size = new System.Drawing.Size(259, 117);
            this.grpBoxCustomer.TabIndex = 123;
            this.grpBoxCustomer.TabStop = false;
            this.grpBoxCustomer.Text = "Staff Details";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(104, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 127;
            this.label1.Text = "Salary Amount";
            // 
            // nudSalaryAmount
            // 
            this.nudSalaryAmount.Location = new System.Drawing.Point(185, 180);
            this.nudSalaryAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSalaryAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSalaryAmount.Name = "nudSalaryAmount";
            this.nudSalaryAmount.Size = new System.Drawing.Size(85, 20);
            this.nudSalaryAmount.TabIndex = 128;
            this.nudSalaryAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Winform_AddSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 226);
            this.ControlBox = false;
            this.Controls.Add(this.nudSalaryAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grpBoxCustomer);
            this.Name = "Winform_AddSalary";
            this.Text = "Add Salary";
            this.Load += new System.EventHandler(this.Winform_AddSalary_Load);
            this.Controls.SetChildIndex(this.grpBoxCustomer, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.nudSalaryAmount, 0);
            this.grpBoxCustomer.ResumeLayout(false);
            this.grpBoxCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbCustImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSalaryAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton AddStaffToolStrip;
        private System.Windows.Forms.GroupBox grpBoxCustomer;
        internal System.Windows.Forms.PictureBox pcbCustImage;
        internal System.Windows.Forms.TextBox txtMobNo;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSalaryAmount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}