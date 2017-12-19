namespace SpindleSoft.Views
{
    partial class Winform_SMSSend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_SMSSend));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBxMsg = new System.Windows.Forms.GroupBox();
            this.lblLimit = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.grpBxContact = new System.Windows.Forms.GroupBox();
            this.dgvToList = new System.Windows.Forms.DataGridView();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.grpBxMsg.SuspendLayout();
            this.grpBxContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToList)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStrip_Label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(336, 22);
            this.statusStrip1.TabIndex = 121;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStrip_Label
            // 
            this.toolStrip_Label.Name = "toolStrip_Label";
            this.toolStrip_Label.Size = new System.Drawing.Size(219, 17);
            this.toolStrip_Label.Spring = true;
            this.toolStrip_Label.Text = "Waiting to Send SMS.";
            this.toolStrip_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBxMsg
            // 
            this.grpBxMsg.Controls.Add(this.label1);
            this.grpBxMsg.Controls.Add(this.lblLimit);
            this.grpBxMsg.Controls.Add(this.txtMessage);
            this.grpBxMsg.Location = new System.Drawing.Point(13, 13);
            this.grpBxMsg.Name = "grpBxMsg";
            this.grpBxMsg.Size = new System.Drawing.Size(315, 118);
            this.grpBxMsg.TabIndex = 122;
            this.grpBxMsg.TabStop = false;
            this.grpBxMsg.Text = "Message";
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(249, 99);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(13, 13);
            this.lblLimit.TabIndex = 157;
            this.lblLimit.Text = "0";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(7, 20);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(302, 75);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // grpBxContact
            // 
            this.grpBxContact.Controls.Add(this.dgvToList);
            this.grpBxContact.Location = new System.Drawing.Point(13, 171);
            this.grpBxContact.Name = "grpBxContact";
            this.grpBxContact.Size = new System.Drawing.Size(315, 195);
            this.grpBxContact.TabIndex = 123;
            this.grpBxContact.TabStop = false;
            this.grpBxContact.Text = "To:";
            // 
            // dgvToList
            // 
            this.dgvToList.AllowUserToAddRows = false;
            this.dgvToList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvToList.EnableHeadersVisualStyles = false;
            this.dgvToList.Location = new System.Drawing.Point(3, 16);
            this.dgvToList.Name = "dgvToList";
            this.dgvToList.ReadOnly = true;
            this.dgvToList.Size = new System.Drawing.Size(309, 176);
            this.dgvToList.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(253, 370);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 124;
            this.btnSend.Text = "Send SMS";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(289, 141);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(39, 35);
            this.btnAddItem.TabIndex = 156;
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 158;
            this.label1.Text = "/160";
            // 
            // Winform_SMSSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 420);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.grpBxContact);
            this.Controls.Add(this.grpBxMsg);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Winform_SMSSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send Promotional SMS";
            this.Load += new System.EventHandler(this.Winform_SMSSend_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpBxMsg.ResumeLayout(false);
            this.grpBxMsg.PerformLayout();
            this.grpBxContact.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        private System.Windows.Forms.GroupBox grpBxMsg;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox grpBxContact;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridView dgvToList;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Label label1;
    }
}