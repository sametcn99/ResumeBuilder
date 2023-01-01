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
            this.selectedPhotoPathLabel = new System.Windows.Forms.Label();
            this.selectPhotoButton = new System.Windows.Forms.Button();
            this.selectPhotoLabel = new System.Windows.Forms.Label();
            this.selectedPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectedPhotoPathLabel
            // 
            this.selectedPhotoPathLabel.AutoSize = true;
            this.selectedPhotoPathLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.selectedPhotoPathLabel.Location = new System.Drawing.Point(316, 78);
            this.selectedPhotoPathLabel.Margin = new System.Windows.Forms.Padding(5);
            this.selectedPhotoPathLabel.Name = "selectedPhotoPathLabel";
            this.selectedPhotoPathLabel.Size = new System.Drawing.Size(66, 15);
            this.selectedPhotoPathLabel.TabIndex = 67;
            this.selectedPhotoPathLabel.Text = "Photo Path";
            this.selectedPhotoPathLabel.Visible = false;
            // 
            // selectPhotoButton
            // 
            this.selectPhotoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.selectPhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectPhotoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.selectPhotoButton.Location = new System.Drawing.Point(416, 359);
            this.selectPhotoButton.Margin = new System.Windows.Forms.Padding(5);
            this.selectPhotoButton.Name = "selectPhotoButton";
            this.selectPhotoButton.Size = new System.Drawing.Size(100, 23);
            this.selectPhotoButton.TabIndex = 66;
            this.selectPhotoButton.Text = "Select";
            this.selectPhotoButton.UseVisualStyleBackColor = false;
            // 
            // selectPhotoLabel
            // 
            this.selectPhotoLabel.AutoSize = true;
            this.selectPhotoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.selectPhotoLabel.Location = new System.Drawing.Point(333, 359);
            this.selectPhotoLabel.Margin = new System.Windows.Forms.Padding(5);
            this.selectPhotoLabel.Name = "selectPhotoLabel";
            this.selectPhotoLabel.Size = new System.Drawing.Size(73, 15);
            this.selectPhotoLabel.TabIndex = 65;
            this.selectPhotoLabel.Text = "Select Photo";
            // 
            // selectedPictureBox
            // 
            this.selectedPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.selectedPictureBox.Location = new System.Drawing.Point(316, 101);
            this.selectedPictureBox.Name = "selectedPictureBox";
            this.selectedPictureBox.Size = new System.Drawing.Size(200, 250);
            this.selectedPictureBox.TabIndex = 68;
            this.selectedPictureBox.TabStop = false;
            // 
            // PhotoUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.selectedPictureBox);
            this.Controls.Add(this.selectedPhotoPathLabel);
            this.Controls.Add(this.selectPhotoButton);
            this.Controls.Add(this.selectPhotoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhotoUploadForm";
            this.Text = "PhotoUploadForm";
            ((System.ComponentModel.ISupportInitialize)(this.selectedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label selectedPhotoPathLabel;
        private Button selectPhotoButton;
        private Label selectPhotoLabel;
        private PictureBox selectedPictureBox;
    }
}