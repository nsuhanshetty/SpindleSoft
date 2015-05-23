namespace SpindleSoft.Views
{
    partial class Winform_DetailsFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Winform_DetailsFormat));
            this.toolStripParent = new System.Windows.Forms.ToolStrip();
            this.CancelToolStrip = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripParent.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripParent
            // 
            this.toolStripParent.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripParent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CancelToolStrip,
            this.SaveToolStrip,
            this.toolStripSeparator1});
            this.toolStripParent.Location = new System.Drawing.Point(0, 0);
            this.toolStripParent.Name = "toolStripParent";
            this.toolStripParent.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripParent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripParent.Size = new System.Drawing.Size(590, 54);
            this.toolStripParent.TabIndex = 121;
            this.toolStripParent.Text = "toolStrip1";
            // 
            // CancelToolStrip
            // 
            this.CancelToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("CancelToolStrip.Image")));
            this.CancelToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CancelToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelToolStrip.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.CancelToolStrip.Name = "CancelToolStrip";
            this.CancelToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CancelToolStrip.Size = new System.Drawing.Size(47, 51);
            this.CancelToolStrip.Text = "Cancel";
            this.CancelToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CancelToolStrip.Click += new System.EventHandler(this.CancelToolStrip_Click);
            // 
            // SaveToolStrip
            // 
            this.SaveToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStrip.Image")));
            this.SaveToolStrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStrip.Name = "SaveToolStrip";
            this.SaveToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SaveToolStrip.Size = new System.Drawing.Size(36, 51);
            this.SaveToolStrip.Text = "Save";
            this.SaveToolStrip.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveToolStrip.Click += new System.EventHandler(this.SaveToolStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_Label,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 365);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(590, 22);
            this.statusStrip1.TabIndex = 122;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip_Label
            // 
            this.toolStrip_Label.Name = "toolStrip_Label";
            this.toolStrip_Label.Size = new System.Drawing.Size(473, 17);
            this.toolStrip_Label.Spring = true;
            this.toolStrip_Label.Text = "Enter Details and Click Save.";
            this.toolStrip_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // Winform_DetailsFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 387);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripParent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Winform_DetailsFormat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Winform_DetailsFormat_Load);
            this.toolStripParent.ResumeLayout(false);
            this.toolStripParent.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolStrip toolStripParent;
        protected System.Windows.Forms.ToolStripButton CancelToolStrip;
        protected System.Windows.Forms.ToolStripButton SaveToolStrip;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.ToolStripStatusLabel toolStrip_Label;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;

    }
}