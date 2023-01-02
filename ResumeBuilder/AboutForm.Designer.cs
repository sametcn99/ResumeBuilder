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
            this.components = new System.ComponentModel.Container();
            this.aboutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.aboutPictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutLinkLabel
            // 
            this.aboutLinkLabel.AutoSize = true;
            this.aboutLinkLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutLinkLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.aboutLinkLabel.LinkColor = System.Drawing.Color.White;
            this.aboutLinkLabel.Location = new System.Drawing.Point(46, 231);
            this.aboutLinkLabel.Name = "aboutLinkLabel";
            this.aboutLinkLabel.Size = new System.Drawing.Size(150, 19);
            this.aboutLinkLabel.TabIndex = 3;
            this.aboutLinkLabel.TabStop = true;
            this.aboutLinkLabel.Text = "github.com/sametcn99";
            this.toolTip1.SetToolTip(this.aboutLinkLabel, "Open my Github Profile on Web Browser");
            // 
            // aboutPictureBox
            // 
            this.aboutPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aboutPictureBox.Image = global::ResumeBuilder.Properties.Resources.github_mark_white;
            this.aboutPictureBox.Location = new System.Drawing.Point(0, 0);
            this.aboutPictureBox.Name = "aboutPictureBox";
            this.aboutPictureBox.Size = new System.Drawing.Size(250, 250);
            this.aboutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.aboutPictureBox.TabIndex = 2;
            this.aboutPictureBox.TabStop = false;
            this.toolTip1.SetToolTip(this.aboutPictureBox, "Open my Github Profile on Web Browser");
            this.aboutPictureBox.Click += new System.EventHandler(this.aboutPictureBox_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.aboutLinkLabel);
            this.panel1.Controls.Add(this.aboutPictureBox);
            this.panel1.Location = new System.Drawing.Point(300, 150);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 250);
            this.panel1.TabIndex = 4;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            ((System.ComponentModel.ISupportInitialize)(this.aboutPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LinkLabel aboutLinkLabel;
        private PictureBox aboutPictureBox;
        private ToolTip toolTip1;
        private Panel panel1;
    }
}