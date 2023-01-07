namespace ResumeBuilder
{
    partial class PhotoUploadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotoUploadForm));
            this.selectedPhotoPathLabel = new System.Windows.Forms.Label();
            this.selectPhotoButton = new System.Windows.Forms.Button();
            this.selectPhotoLabel = new System.Windows.Forms.Label();
            this.selectedPictureBox = new System.Windows.Forms.PictureBox();
            this.getPhotoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedPhotoPathLabel
            // 
            resources.ApplyResources(this.selectedPhotoPathLabel, "selectedPhotoPathLabel");
            this.selectedPhotoPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.selectedPhotoPathLabel.Name = "selectedPhotoPathLabel";
            // 
            // selectPhotoButton
            // 
            resources.ApplyResources(this.selectPhotoButton, "selectPhotoButton");
            this.selectPhotoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.selectPhotoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.selectPhotoButton.Name = "selectPhotoButton";
            this.selectPhotoButton.UseVisualStyleBackColor = false;
            this.selectPhotoButton.Click += new System.EventHandler(this.selectPhotoButton_Click);
            // 
            // selectPhotoLabel
            // 
            resources.ApplyResources(this.selectPhotoLabel, "selectPhotoLabel");
            this.selectPhotoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.selectPhotoLabel.Name = "selectPhotoLabel";
            // 
            // selectedPictureBox
            // 
            resources.ApplyResources(this.selectedPictureBox, "selectedPictureBox");
            this.selectedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectedPictureBox.Name = "selectedPictureBox";
            this.selectedPictureBox.TabStop = false;
            // 
            // getPhotoButton
            // 
            resources.ApplyResources(this.getPhotoButton, "getPhotoButton");
            this.getPhotoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.getPhotoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.getPhotoButton.Name = "getPhotoButton";
            this.getPhotoButton.UseVisualStyleBackColor = false;
            this.getPhotoButton.Click += new System.EventHandler(this.getPhotoButton_Click);
            // 
            // PhotoUploadForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.getPhotoButton);
            this.Controls.Add(this.selectedPictureBox);
            this.Controls.Add(this.selectedPhotoPathLabel);
            this.Controls.Add(this.selectPhotoButton);
            this.Controls.Add(this.selectPhotoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhotoUploadForm";
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label selectedPhotoPathLabel;
        private Button selectPhotoButton;
        private Label selectPhotoLabel;
        public PictureBox selectedPictureBox;
        private Button getPhotoButton;
    }
}