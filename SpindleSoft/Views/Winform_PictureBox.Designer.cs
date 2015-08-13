namespace SpindleSoft.Views
{
    partial class Winform_PictureBox
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcbDoc = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pcbDoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 477);
            this.panel1.TabIndex = 0;
            // 
            // pcbDoc
            // 
            this.pcbDoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbDoc.Location = new System.Drawing.Point(0, 0);
            this.pcbDoc.Name = "pcbDoc";
            this.pcbDoc.Size = new System.Drawing.Size(467, 477);
            this.pcbDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDoc.TabIndex = 1;
            this.pcbDoc.TabStop = false;
            // 
            // Winform_PictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 477);
            this.Controls.Add(this.panel1);
            this.Name = "Winform_PictureBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbDoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcbDoc;


    }
}