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
            this.sqlModeRadioButton = new System.Windows.Forms.RadioButton();
            this.localModeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
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
            this.rjToggleButton1.OffBackColor = System.Drawing.Color.White;
            this.rjToggleButton1.OffToggleColor = System.Drawing.Color.Black;
            this.rjToggleButton1.OnBackColor = System.Drawing.Color.Black;
            this.rjToggleButton1.OnToggleColor = System.Drawing.Color.White;
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
            // sqlModeRadioButton
            // 
            this.sqlModeRadioButton.AutoSize = true;
            this.sqlModeRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sqlModeRadioButton.Checked = true;
            this.sqlModeRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.sqlModeRadioButton.Location = new System.Drawing.Point(13, 22);
            this.sqlModeRadioButton.Name = "sqlModeRadioButton";
            this.sqlModeRadioButton.Size = new System.Drawing.Size(131, 19);
            this.sqlModeRadioButton.TabIndex = 4;
            this.sqlModeRadioButton.TabStop = true;
            this.sqlModeRadioButton.Text = "SQL Database Mode";
            this.sqlModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // localModeRadioButton
            // 
            this.localModeRadioButton.AutoSize = true;
            this.localModeRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.localModeRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.localModeRadioButton.Location = new System.Drawing.Point(6, 47);
            this.localModeRadioButton.Name = "localModeRadioButton";
            this.localModeRadioButton.Size = new System.Drawing.Size(138, 19);
            this.localModeRadioButton.TabIndex = 5;
            this.localModeRadioButton.Text = "Local Database Mode";
            this.localModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sqlModeRadioButton);
            this.groupBox1.Controls.Add(this.localModeRadioButton);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Modes";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personalDetailsPanelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rjToggleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJControls.RJToggleButton rjToggleButton1;
        private Label label1;
        private Button personalDetailsPanelButton;
        private RadioButton sqlModeRadioButton;
        private RadioButton localModeRadioButton;
        private GroupBox groupBox1;
    }
}