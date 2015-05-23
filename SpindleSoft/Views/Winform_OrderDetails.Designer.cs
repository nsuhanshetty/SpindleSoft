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
            this.button1 = new System.Windows.Forms.Button();
            this.txtAmntPaid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pcbMemImage = new System.Windows.Forms.PictureBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtMobNo = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.AddCustomerToolStrip = new System.Windows.Forms.ToolStripButton();
            this.NewCustomerToolStrip = new System.Windows.Forms.ToolStripButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "Edit Measurements";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtAmntPaid
            // 
            this.txtAmntPaid.Location = new System.Drawing.Point(459, 397);
            this.txtAmntPaid.MaxLength = 10;
            this.txtAmntPaid.Name = "txtAmntPaid";
            this.txtAmntPaid.Size = new System.Drawing.Size(115, 20);
            this.txtAmntPaid.TabIndex = 5;
            this.txtAmntPaid.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmntPaid_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Paid Amount";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(459, 452);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(115, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Total Amount";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pcbMemImage
            // 
            this.pcbMemImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbMemImage.BackgroundImage")));
            this.pcbMemImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbMemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbMemImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pcbMemImage.InitialImage")));
            this.pcbMemImage.Location = new System.Drawing.Point(6, 23);
            this.pcbMemImage.Name = "pcbMemImage";
            this.pcbMemImage.Size = new System.Drawing.Size(115, 108);
            this.pcbMemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMemImage.TabIndex = 123;
            this.pcbMemImage.TabStop = false;
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Location = new System.Drawing.Point(132, 65);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(58, 13);
            this.lblMobile.TabIndex = 122;
            this.lblMobile.Text = "Mobile No.";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(197, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(132, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 121;
            this.lblName.Text = "Name ";
            // 
            // txtMobNo
            // 
            this.txtMobNo.Location = new System.Drawing.Point(197, 62);
            this.txtMobNo.MaxLength = 10;
            this.txtMobNo.Name = "txtMobNo";
            this.txtMobNo.Size = new System.Drawing.Size(131, 20);
            this.txtMobNo.TabIndex = 1;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(197, 88);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(131, 20);
            this.txtPhoneNo.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Phone No.";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(459, 424);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(115, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 129;
            this.label7.Text = "Remianing Amount";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(350, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add Catalogue";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(8, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 150);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Order Details";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 131);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pcbMemImage);
            this.groupBox1.Controls.Add(this.txtMobNo);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lblMobile);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPhoneNo);
            this.groupBox1.Location = new System.Drawing.Point(8, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 142);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtpDeliveryDate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(350, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 142);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Order Details";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ready to Sew",
            "Stitch In Progress",
            "Stitched",
            "Ready to Deliver",
            "Alteration",
            ""});
            this.comboBox1.Location = new System.Drawing.Point(84, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(133, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 132;
            this.label6.Text = "Order Status";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(84, 33);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(133, 20);
            this.textBox5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 131;
            this.label1.Text = "Order No.";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Location = new System.Drawing.Point(84, 59);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(133, 20);
            this.dtpDeliveryDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 128;
            this.label4.Text = "Delivery Date";
            //
            // AddCustomerToolStrip
            // 
            this.AddCustomerToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("AddCustomerToolStrip.Image")));
            this.AddCustomerToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddCustomerToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddCustomerToolStrip.Name = "AddCustomerToolStrip";
            this.AddCustomerToolStrip.Size = new System.Drawing.Size(76, 51);
            this.AddCustomerToolStrip.Text = "Add Referral";
            this.AddCustomerToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.AddCustomerToolStrip.Click += new System.EventHandler(this.AddCustomerToolStrip_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Winform_OrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 501);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmntPaid);
            this.Controls.Add(this.label2);
            this.Name = "Winform_OrderDetails";
            this.Text = "Order Details";
            this.Load += new System.EventHandler(this.Winform_OrderAdd_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtAmntPaid, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pcbMemImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox txtAmntPaid;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.PictureBox pcbMemImage;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtMobNo;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox textBox5;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        
        //Toolstrip Add
        internal System.Windows.Forms.ToolStripButton AddCustomerToolStrip;
        internal System.Windows.Forms.ToolStripButton NewCustomerToolStrip;
    }
}