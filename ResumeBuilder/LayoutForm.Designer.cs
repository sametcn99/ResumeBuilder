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
            this.SuspendLayout();
            // 
            // layoutStylesCombobox
            // 
            resources.ApplyResources(this.layoutStylesCombobox, "layoutStylesCombobox");
            this.layoutStylesCombobox.FormattingEnabled = true;
            this.layoutStylesCombobox.Items.AddRange(new object[] {
            resources.GetString("layoutStylesCombobox.Items"),
            resources.GetString("layoutStylesCombobox.Items1")});
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
            // LayoutForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
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
    }
}