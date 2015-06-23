namespace SpindleSoft.Views
{
    partial class Winform_MeasurementAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_MeasurementAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtShoulder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBack = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFront = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChest = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWaist = new System.Windows.Forms.TextBox();
            this.txtHip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSlvAHole = new System.Windows.Forms.TextBox();
            this.txtSlvLoose = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSlvLength = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBotLength = new System.Windows.Forms.TextBox();
            this.txtBotHip = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBotWaist = new System.Windows.Forms.TextBox();
            this.toolStrip_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.grpBoxCustMeasure = new System.Windows.Forms.GroupBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtClothingType = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBoxCustMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Details";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtShoulder);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.txtD);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtBack);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txtFront);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtChest);
            this.groupBox4.Controls.Add(this.txtLength);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtWaist);
            this.groupBox4.Controls.Add(this.txtHip);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 97);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Basic Measurement";
            // 
            // txtShoulder
            // 
            this.txtShoulder.Location = new System.Drawing.Point(64, 70);
            this.txtShoulder.MaxLength = 10;
            this.txtShoulder.Name = "txtShoulder";
            this.txtShoulder.Size = new System.Drawing.Size(63, 20);
            this.txtShoulder.TabIndex = 6;
            this.txtShoulder.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 105;
            this.label7.Text = "Shoulder";
            // 
            // txtD
            // 
            this.txtD.Location = new System.Drawing.Point(175, 70);
            this.txtD.MaxLength = 10;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(63, 20);
            this.txtD.TabIndex = 7;
            this.txtD.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "D";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(252, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 101;
            this.label14.Text = "Back";
            // 
            // txtBack
            // 
            this.txtBack.Location = new System.Drawing.Point(286, 48);
            this.txtBack.MaxLength = 100;
            this.txtBack.Name = "txtBack";
            this.txtBack.Size = new System.Drawing.Size(63, 20);
            this.txtBack.TabIndex = 5;
            this.txtBack.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(253, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 99;
            this.label15.Text = "Front";
            // 
            // txtFront
            // 
            this.txtFront.Location = new System.Drawing.Point(286, 20);
            this.txtFront.MaxLength = 100;
            this.txtFront.Name = "txtFront";
            this.txtFront.Size = new System.Drawing.Size(63, 20);
            this.txtFront.TabIndex = 2;
            this.txtFront.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Length";
            // 
            // txtChest
            // 
            this.txtChest.Location = new System.Drawing.Point(64, 45);
            this.txtChest.MaxLength = 10;
            this.txtChest.Name = "txtChest";
            this.txtChest.Size = new System.Drawing.Size(63, 20);
            this.txtChest.TabIndex = 3;
            this.txtChest.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(64, 20);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(63, 20);
            this.txtLength.TabIndex = 0;
            this.txtLength.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Chest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 93;
            this.label2.Text = "Hip";
            // 
            // txtWaist
            // 
            this.txtWaist.Location = new System.Drawing.Point(175, 20);
            this.txtWaist.MaxLength = 100;
            this.txtWaist.Name = "txtWaist";
            this.txtWaist.Size = new System.Drawing.Size(63, 20);
            this.txtWaist.TabIndex = 1;
            this.txtWaist.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // txtHip
            // 
            this.txtHip.Location = new System.Drawing.Point(175, 45);
            this.txtHip.MaxLength = 100;
            this.txtHip.Name = "txtHip";
            this.txtHip.Size = new System.Drawing.Size(63, 20);
            this.txtHip.TabIndex = 4;
            this.txtHip.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 86;
            this.label3.Text = "Waist";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtSlvAHole);
            this.groupBox3.Controls.Add(this.txtSlvLoose);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtSlvLength);
            this.groupBox3.Location = new System.Drawing.Point(6, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 52);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sleeve Measurement";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(250, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 103;
            this.label11.Text = "Loose";
            // 
            // txtSlvAHole
            // 
            this.txtSlvAHole.Location = new System.Drawing.Point(64, 19);
            this.txtSlvAHole.Name = "txtSlvAHole";
            this.txtSlvAHole.Size = new System.Drawing.Size(63, 20);
            this.txtSlvAHole.TabIndex = 0;
            this.txtSlvAHole.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // txtSlvLoose
            // 
            this.txtSlvLoose.Location = new System.Drawing.Point(286, 19);
            this.txtSlvLoose.MaxLength = 100;
            this.txtSlvLoose.Name = "txtSlvLoose";
            this.txtSlvLoose.Size = new System.Drawing.Size(63, 20);
            this.txtSlvLoose.TabIndex = 2;
            this.txtSlvLoose.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 100;
            this.label12.Text = "Arm Hole";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(135, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 101;
            this.label13.Text = "Length";
            // 
            // txtSlvLength
            // 
            this.txtSlvLength.Location = new System.Drawing.Point(175, 19);
            this.txtSlvLength.MaxLength = 100;
            this.txtSlvLength.Name = "txtSlvLength";
            this.txtSlvLength.Size = new System.Drawing.Size(63, 20);
            this.txtSlvLength.TabIndex = 1;
            this.txtSlvLength.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtBotLength);
            this.groupBox2.Controls.Add(this.txtBotHip);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtBotWaist);
            this.groupBox2.Location = new System.Drawing.Point(6, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bottom Measurement";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 103;
            this.label8.Text = "Hip";
            // 
            // txtBotLength
            // 
            this.txtBotLength.Location = new System.Drawing.Point(64, 19);
            this.txtBotLength.Name = "txtBotLength";
            this.txtBotLength.Size = new System.Drawing.Size(63, 20);
            this.txtBotLength.TabIndex = 0;
            this.txtBotLength.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // txtBotHip
            // 
            this.txtBotHip.Location = new System.Drawing.Point(286, 19);
            this.txtBotHip.MaxLength = 100;
            this.txtBotHip.Name = "txtBotHip";
            this.txtBotHip.Size = new System.Drawing.Size(63, 20);
            this.txtBotHip.TabIndex = 2;
            this.txtBotHip.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 100;
            this.label10.Text = "Length";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(138, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Waist";
            // 
            // txtBotWaist
            // 
            this.txtBotWaist.Location = new System.Drawing.Point(175, 19);
            this.txtBotWaist.MaxLength = 100;
            this.txtBotWaist.Name = "txtBotWaist";
            this.txtBotWaist.Size = new System.Drawing.Size(63, 20);
            this.txtBotWaist.TabIndex = 1;
            this.txtBotWaist.Validating += new System.ComponentModel.CancelEventHandler(this.textBox3_Validating);
            // 
            // toolStrip_Label
            // 
            this.toolStrip_Label.Name = "toolStrip_Label";
            this.toolStrip_Label.Size = new System.Drawing.Size(461, 17);
            this.toolStrip_Label.Spring = true;
            this.toolStrip_Label.Text = "Save";
            this.toolStrip_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // grpBoxCustMeasure
            // 
            this.grpBoxCustMeasure.Controls.Add(this.txtCustName);
            this.grpBoxCustMeasure.Controls.Add(this.label1);
            this.grpBoxCustMeasure.Enabled = false;
            this.grpBoxCustMeasure.Location = new System.Drawing.Point(8, 55);
            this.grpBoxCustMeasure.Name = "grpBoxCustMeasure";
            this.grpBoxCustMeasure.Size = new System.Drawing.Size(181, 48);
            this.grpBoxCustMeasure.TabIndex = 2;
            this.grpBoxCustMeasure.TabStop = false;
            this.grpBoxCustMeasure.Text = "Customer Details";
            // 
            // txtCustName
            // 
            this.txtCustName.Enabled = false;
            this.txtCustName.Location = new System.Drawing.Point(70, 20);
            this.txtCustName.MaxLength = 10;
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(96, 20);
            this.txtCustName.TabIndex = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 133;
            this.label1.Text = "Name";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(27, 377);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(336, 44);
            this.txtComment.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(8, 359);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(373, 69);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Comment";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtClothingType);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(194, 55);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(185, 48);
            this.groupBox6.TabIndex = 134;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Product Details";
            // 
            // txtClothingType
            // 
            this.txtClothingType.Enabled = false;
            this.txtClothingType.Location = new System.Drawing.Point(82, 20);
            this.txtClothingType.MaxLength = 10;
            this.txtClothingType.Name = "txtClothingType";
            this.txtClothingType.Size = new System.Drawing.Size(96, 20);
            this.txtClothingType.TabIndex = 132;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 133;
            this.label16.Text = "Clothing Type";
            // 
            // Winform_MeasurementAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 460);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.grpBoxCustMeasure);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.groupBox5);
            this.Name = "Winform_MeasurementAdd";
            this.Text = "Measurement Details";
            this.Load += new System.EventHandler(this.Winform_MeasurementAdd_Load);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.txtComment, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpBoxCustMeasure, 0);
            this.Controls.SetChildIndex(this.groupBox6, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBoxCustMeasure.ResumeLayout(false);
            this.grpBoxCustMeasure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtBack;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtFront;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtChest;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtWaist;
        internal System.Windows.Forms.TextBox txtHip;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtSlvAHole;
        internal System.Windows.Forms.TextBox txtSlvLoose;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtSlvLength;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtBotLength;
        internal System.Windows.Forms.TextBox txtBotHip;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtBotWaist;
        private System.Windows.Forms.GroupBox grpBoxCustMeasure;
        internal System.Windows.Forms.TextBox txtD;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtShoulder;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton CancelToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        internal System.Windows.Forms.TextBox txtComment;
        internal System.Windows.Forms.TextBox txtCustName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox6;
        internal System.Windows.Forms.TextBox txtClothingType;
        internal System.Windows.Forms.Label label16;
    }
}