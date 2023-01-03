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
            this.components = new System.ComponentModel.Container();
            this.rjToggleButton1 = new ResumeBuilder.RJControls.RJToggleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.showJsonDataButton = new System.Windows.Forms.Button();
            this.sqlModeRadioButton = new System.Windows.Forms.RadioButton();
            this.localModeRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.importJsonDataButton = new System.Windows.Forms.Button();
            this.exportJsonDataButton = new System.Windows.Forms.Button();
            this.clearJsonDataButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.toolTip1.SetToolTip(this.rjToggleButton1, "Theme changer is not avaible");
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
            this.toolTip1.SetToolTip(this.label1, "Theme changer is not avaible");
            // 
            // showJsonDataButton
            // 
            this.showJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.showJsonDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.showJsonDataButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showJsonDataButton.Location = new System.Drawing.Point(12, 154);
            this.showJsonDataButton.Name = "showJsonDataButton";
            this.showJsonDataButton.Size = new System.Drawing.Size(150, 50);
            this.showJsonDataButton.TabIndex = 3;
            this.showJsonDataButton.Text = "Show Data";
            this.toolTip1.SetToolTip(this.showJsonDataButton, "Show Data");
            this.showJsonDataButton.UseVisualStyleBackColor = true;
            this.showJsonDataButton.Click += new System.EventHandler(this.showJsonDataButton_Click);
            // 
            // sqlModeRadioButton
            // 
            this.sqlModeRadioButton.AutoSize = true;
            this.sqlModeRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sqlModeRadioButton.Checked = true;
            this.sqlModeRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.sqlModeRadioButton.Location = new System.Drawing.Point(24, 22);
            this.sqlModeRadioButton.Name = "sqlModeRadioButton";
            this.sqlModeRadioButton.Size = new System.Drawing.Size(97, 19);
            this.sqlModeRadioButton.TabIndex = 4;
            this.sqlModeRadioButton.TabStop = true;
            this.sqlModeRadioButton.Text = "SQL Database";
            this.sqlModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // localModeRadioButton
            // 
            this.localModeRadioButton.AutoSize = true;
            this.localModeRadioButton.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.localModeRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.localModeRadioButton.Location = new System.Drawing.Point(17, 47);
            this.localModeRadioButton.Name = "localModeRadioButton";
            this.localModeRadioButton.Size = new System.Drawing.Size(104, 19);
            this.localModeRadioButton.TabIndex = 5;
            this.localModeRadioButton.Text = "Local Database";
            this.toolTip1.SetToolTip(this.localModeRadioButton, "Local Database is not availble");
            this.localModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sqlModeRadioButton);
            this.groupBox1.Controls.Add(this.localModeRadioButton);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Modes";
            this.toolTip1.SetToolTip(this.groupBox1, "Change Database models");
            // 
            // importJsonDataButton
            // 
            this.importJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.importJsonDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.importJsonDataButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importJsonDataButton.Location = new System.Drawing.Point(12, 266);
            this.importJsonDataButton.Name = "importJsonDataButton";
            this.importJsonDataButton.Size = new System.Drawing.Size(150, 50);
            this.importJsonDataButton.TabIndex = 7;
            this.importJsonDataButton.Text = "Import Data";
            this.toolTip1.SetToolTip(this.importJsonDataButton, "Import your data");
            this.importJsonDataButton.UseVisualStyleBackColor = true;
            this.importJsonDataButton.Click += new System.EventHandler(this.importJsonDataButton_Click);
            // 
            // exportJsonDataButton
            // 
            this.exportJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.exportJsonDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.exportJsonDataButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportJsonDataButton.Location = new System.Drawing.Point(12, 210);
            this.exportJsonDataButton.Name = "exportJsonDataButton";
            this.exportJsonDataButton.Size = new System.Drawing.Size(150, 50);
            this.exportJsonDataButton.TabIndex = 8;
            this.exportJsonDataButton.Text = "Export Data";
            this.toolTip1.SetToolTip(this.exportJsonDataButton, "Export your data");
            this.exportJsonDataButton.UseVisualStyleBackColor = true;
            this.exportJsonDataButton.Click += new System.EventHandler(this.exportJsonDataButton_Click);
            // 
            // clearJsonDataButton
            // 
            this.clearJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.clearJsonDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.clearJsonDataButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearJsonDataButton.Location = new System.Drawing.Point(12, 322);
            this.clearJsonDataButton.Name = "clearJsonDataButton";
            this.clearJsonDataButton.Size = new System.Drawing.Size(150, 50);
            this.clearJsonDataButton.TabIndex = 9;
            this.clearJsonDataButton.Text = "Clear Data";
            this.toolTip1.SetToolTip(this.clearJsonDataButton, "Clear all data");
            this.clearJsonDataButton.UseVisualStyleBackColor = true;
            this.clearJsonDataButton.Click += new System.EventHandler(this.clearJsonDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.groupBox2.Location = new System.Drawing.Point(227, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 78);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save Resume as";
            this.toolTip1.SetToolTip(this.groupBox2, "Change Database models");
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.radioButton1.Location = new System.Drawing.Point(52, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 19);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "PDF File";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.radioButton2.Location = new System.Drawing.Point(25, 47);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(94, 19);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "Ms Word File";
            this.toolTip1.SetToolTip(this.radioButton2, "Local Database is not availble");
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.clearJsonDataButton);
            this.Controls.Add(this.exportJsonDataButton);
            this.Controls.Add(this.importJsonDataButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.showJsonDataButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rjToggleButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJControls.RJToggleButton rjToggleButton1;
        private Label label1;
        private Button showJsonDataButton;
        private RadioButton sqlModeRadioButton;
        private RadioButton localModeRadioButton;
        private GroupBox groupBox1;
        private Button importJsonDataButton;
        private Button exportJsonDataButton;
        private Button clearJsonDataButton;
        private ToolTip toolTip1;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
    }
}