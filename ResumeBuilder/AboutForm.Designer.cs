namespace ResumeBuilder
{
    partial class AboutForm
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
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.aboutPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.AutoSize = true;
            this.aboutLinkLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutLinkLabel.LinkColor = System.Drawing.Color.White;
            this.aboutLinkLabel.Location = new System.Drawing.Point(332, 344);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(150, 19);
            this.aboutLinkLabel.TabIndex = 3;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "github.com/sametcn99";
            // 
            // aboutPictureBox
            // 
            this.aboutPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutPictureBox.Image = global::ResumeBuilder.Properties.Resources.github_mark_white;
            this.aboutPictureBox.Location = new System.Drawing.Point(292, 124);
            this.aboutPictureBox.Name = "aboutPictureBox";
            this.aboutPictureBox.Size = new System.Drawing.Size(238, 239);
            this.aboutPictureBox.TabIndex = 2;
            this.aboutPictureBox.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.aboutLinkLabel);
            this.Controls.Add(this.aboutPictureBox);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkLabel aboutLinkLabel;
        private PictureBox aboutPictureBox;
    }
}