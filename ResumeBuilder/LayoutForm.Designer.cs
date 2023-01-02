namespace ResumeBuilder
{
    partial class LayoutForm
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
            this.layoutStylesCombobox = new System.Windows.Forms.ComboBox();
            this.layoutStylesLabel = new System.Windows.Forms.Label();
            this.previewSampleLayoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layoutStylesCombobox
            // 
            this.layoutStylesCombobox.FormattingEnabled = true;
            this.layoutStylesCombobox.Location = new System.Drawing.Point(12, 27);
            this.layoutStylesCombobox.Name = "layoutStylesCombobox";
            this.layoutStylesCombobox.Size = new System.Drawing.Size(244, 23);
            this.layoutStylesCombobox.TabIndex = 0;
            // 
            // layoutStylesLabel
            // 
            this.layoutStylesLabel.AutoSize = true;
            this.layoutStylesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.layoutStylesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.layoutStylesLabel.Location = new System.Drawing.Point(12, 9);
            this.layoutStylesLabel.Name = "layoutStylesLabel";
            this.layoutStylesLabel.Size = new System.Drawing.Size(76, 15);
            this.layoutStylesLabel.TabIndex = 1;
            this.layoutStylesLabel.Text = "Layout Styles";
            // 
            // previewSampleLayoutButton
            // 
            this.previewSampleLayoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previewSampleLayoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.previewSampleLayoutButton.Location = new System.Drawing.Point(156, 56);
            this.previewSampleLayoutButton.Name = "previewSampleLayoutButton";
            this.previewSampleLayoutButton.Size = new System.Drawing.Size(100, 23);
            this.previewSampleLayoutButton.TabIndex = 2;
            this.previewSampleLayoutButton.Text = "Preview Sample";
            this.previewSampleLayoutButton.UseVisualStyleBackColor = true;
            // 
            // LayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.previewSampleLayoutButton);
            this.Controls.Add(this.layoutStylesLabel);
            this.Controls.Add(this.layoutStylesCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LayoutForm";
            this.Text = "LayoutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox layoutStylesCombobox;
        private Label layoutStylesLabel;
        private Button previewSampleLayoutButton;
    }
}