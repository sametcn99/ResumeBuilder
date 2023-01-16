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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutForm));
            this.layoutStylesCombobox = new System.Windows.Forms.ComboBox();
            this.layoutStylesLabel = new System.Windows.Forms.Label();
            this.previewSampleLayoutButton = new System.Windows.Forms.Button();
            this.titleFontSizeLabel = new System.Windows.Forms.Label();
            this.detailFontSizeLabel = new System.Windows.Forms.Label();
            this.pictureSizeLabel = new System.Windows.Forms.Label();
            this.titleFontSizeTextBox = new System.Windows.Forms.TextBox();
            this.pictureSizeTextBox = new System.Windows.Forms.TextBox();
            this.detailFontSizeTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // layoutStylesCombobox
            // 
            this.layoutStylesCombobox.FormattingEnabled = true;
            this.layoutStylesCombobox.Items.AddRange(new object[] {
            resources.GetString("layoutStylesCombobox.Items"),
            resources.GetString("layoutStylesCombobox.Items1")});
            resources.ApplyResources(this.layoutStylesCombobox, "layoutStylesCombobox");
            this.layoutStylesCombobox.Name = "layoutStylesCombobox";
            this.layoutStylesCombobox.SelectedIndexChanged += new System.EventHandler(this.layoutStylesCombobox_SelectedIndexChanged);
            // 
            // layoutStylesLabel
            // 
            resources.ApplyResources(this.layoutStylesLabel, "layoutStylesLabel");
            this.layoutStylesLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.layoutStylesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.layoutStylesLabel.Name = "layoutStylesLabel";
            // 
            // previewSampleLayoutButton
            // 
            resources.ApplyResources(this.previewSampleLayoutButton, "previewSampleLayoutButton");
            this.previewSampleLayoutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.previewSampleLayoutButton.Name = "previewSampleLayoutButton";
            this.previewSampleLayoutButton.UseVisualStyleBackColor = true;
            // 
            // titleFontSizeLabel
            // 
            resources.ApplyResources(this.titleFontSizeLabel, "titleFontSizeLabel");
            this.titleFontSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.titleFontSizeLabel.Name = "titleFontSizeLabel";
            // 
            // detailFontSizeLabel
            // 
            resources.ApplyResources(this.detailFontSizeLabel, "detailFontSizeLabel");
            this.detailFontSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.detailFontSizeLabel.Name = "detailFontSizeLabel";
            // 
            // pictureSizeLabel
            // 
            resources.ApplyResources(this.pictureSizeLabel, "pictureSizeLabel");
            this.pictureSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.pictureSizeLabel.Name = "pictureSizeLabel";
            // 
            // titleFontSizeTextBox
            // 
            resources.ApplyResources(this.titleFontSizeTextBox, "titleFontSizeTextBox");
            this.titleFontSizeTextBox.Name = "titleFontSizeTextBox";
            this.titleFontSizeTextBox.TextChanged += new System.EventHandler(this.titleFontSizeTextBox_TextChanged);
            // 
            // pictureSizeTextBox
            // 
            resources.ApplyResources(this.pictureSizeTextBox, "pictureSizeTextBox");
            this.pictureSizeTextBox.Name = "pictureSizeTextBox";
            this.pictureSizeTextBox.TextChanged += new System.EventHandler(this.pictureSizeTextBox_TextChanged);
            // 
            // detailFontSizeTextBox
            // 
            resources.ApplyResources(this.detailFontSizeTextBox, "detailFontSizeTextBox");
            this.detailFontSizeTextBox.Name = "detailFontSizeTextBox";
            this.detailFontSizeTextBox.TextChanged += new System.EventHandler(this.detailFontSizeTextBox_TextChanged);
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // LayoutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.detailFontSizeTextBox);
            this.Controls.Add(this.pictureSizeTextBox);
            this.Controls.Add(this.titleFontSizeTextBox);
            this.Controls.Add(this.pictureSizeLabel);
            this.Controls.Add(this.detailFontSizeLabel);
            this.Controls.Add(this.titleFontSizeLabel);
            this.Controls.Add(this.previewSampleLayoutButton);
            this.Controls.Add(this.layoutStylesLabel);
            this.Controls.Add(this.layoutStylesCombobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LayoutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label layoutStylesLabel;
        private Button previewSampleLayoutButton;
        public ComboBox layoutStylesCombobox;
        private Label titleFontSizeLabel;
        private Label detailFontSizeLabel;
        private Label pictureSizeLabel;
        private TextBox titleFontSizeTextBox;
        private TextBox pictureSizeTextBox;
        private TextBox detailFontSizeTextBox;
        private Button resetButton;
    }
}