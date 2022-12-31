namespace ResumeBuilder
{
    partial class SettingsForm
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
            this.rjToggleButton1 = new ResumeBuilder.RJControls.RJToggleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.personalDetailsPanelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rjToggleButton1
            // 
            this.rjToggleButton1.AutoSize = true;
            this.rjToggleButton1.Checked = true;
            this.rjToggleButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rjToggleButton1.Location = new System.Drawing.Point(88, 6);
            this.rjToggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.rjToggleButton1.Name = "rjToggleButton1";
            this.rjToggleButton1.OffBackColor = System.Drawing.Color.Gray;
            this.rjToggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.rjToggleButton1.OnBackColor = System.Drawing.Color.DimGray;
            this.rjToggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.rjToggleButton1.Size = new System.Drawing.Size(45, 22);
            this.rjToggleButton1.TabIndex = 1;
            this.rjToggleButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dark Theme";
            // 
            // personalDetailsPanelButton
            // 
            this.personalDetailsPanelButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.personalDetailsPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personalDetailsPanelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.personalDetailsPanelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.personalDetailsPanelButton.Location = new System.Drawing.Point(12, 45);
            this.personalDetailsPanelButton.Name = "personalDetailsPanelButton";
            this.personalDetailsPanelButton.Size = new System.Drawing.Size(150, 50);
            this.personalDetailsPanelButton.TabIndex = 3;
            this.personalDetailsPanelButton.Text = "Show Json Data";
            this.personalDetailsPanelButton.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.personalDetailsPanelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rjToggleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJControls.RJToggleButton rjToggleButton1;
        private Label label1;
        private Button personalDetailsPanelButton;
    }
}