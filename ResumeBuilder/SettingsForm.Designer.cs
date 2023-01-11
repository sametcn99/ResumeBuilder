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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.showJsonDataButton = new System.Windows.Forms.Button();
            this.importJsonDataButton = new System.Windows.Forms.Button();
            this.exportJsonDataButton = new System.Windows.Forms.Button();
            this.clearJsonDataButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.removePersonButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.loginPanelNameLabel = new System.Windows.Forms.Label();
            this.loginPanelResumeVersionLabel = new System.Windows.Forms.Label();
            this.namesCombobox = new System.Windows.Forms.ComboBox();
            this.resumeVersionCombobox = new System.Windows.Forms.ComboBox();
            this.appLanguagesLabel = new System.Windows.Forms.Label();
            this.appLanguagesCombobox = new System.Windows.Forms.ComboBox();
            this.connectionStringLabel = new System.Windows.Forms.Label();
            this.resetToDefaultSettingsButton = new System.Windows.Forms.Button();
            this.changeTitlesButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // showJsonDataButton
            // 
            this.showJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.showJsonDataButton, "showJsonDataButton");
            this.showJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.showJsonDataButton.Name = "showJsonDataButton";
            this.toolTip1.SetToolTip(this.showJsonDataButton, resources.GetString("showJsonDataButton.ToolTip"));
            this.showJsonDataButton.UseVisualStyleBackColor = true;
            this.showJsonDataButton.Click += new System.EventHandler(this.showJsonDataButton_Click);
            // 
            // importJsonDataButton
            // 
            this.importJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.importJsonDataButton, "importJsonDataButton");
            this.importJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.importJsonDataButton.Name = "importJsonDataButton";
            this.toolTip1.SetToolTip(this.importJsonDataButton, resources.GetString("importJsonDataButton.ToolTip"));
            this.importJsonDataButton.UseVisualStyleBackColor = true;
            this.importJsonDataButton.Click += new System.EventHandler(this.importJsonDataButton_Click);
            // 
            // exportJsonDataButton
            // 
            this.exportJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.exportJsonDataButton, "exportJsonDataButton");
            this.exportJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.exportJsonDataButton.Name = "exportJsonDataButton";
            this.toolTip1.SetToolTip(this.exportJsonDataButton, resources.GetString("exportJsonDataButton.ToolTip"));
            this.exportJsonDataButton.UseVisualStyleBackColor = true;
            this.exportJsonDataButton.Click += new System.EventHandler(this.exportJsonDataButton_Click);
            // 
            // clearJsonDataButton
            // 
            this.clearJsonDataButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.clearJsonDataButton, "clearJsonDataButton");
            this.clearJsonDataButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.clearJsonDataButton.Name = "clearJsonDataButton";
            this.toolTip1.SetToolTip(this.clearJsonDataButton, resources.GetString("clearJsonDataButton.ToolTip"));
            this.clearJsonDataButton.UseVisualStyleBackColor = true;
            this.clearJsonDataButton.Click += new System.EventHandler(this.clearJsonDataButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.radioButton2.Name = "radioButton2";
            this.toolTip1.SetToolTip(this.radioButton2, resources.GetString("radioButton2.ToolTip"));
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // removePersonButton
            // 
            this.removePersonButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.removePersonButton, "removePersonButton");
            this.removePersonButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.removePersonButton.Name = "removePersonButton";
            this.toolTip1.SetToolTip(this.removePersonButton, resources.GetString("removePersonButton.ToolTip"));
            this.removePersonButton.UseVisualStyleBackColor = true;
            this.removePersonButton.Click += new System.EventHandler(this.removePersonButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.loginPanelNameLabel);
            this.groupBox3.Controls.Add(this.loginPanelResumeVersionLabel);
            this.groupBox3.Controls.Add(this.removePersonButton);
            this.groupBox3.Controls.Add(this.namesCombobox);
            this.groupBox3.Controls.Add(this.resumeVersionCombobox);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // loginPanelNameLabel
            // 
            resources.ApplyResources(this.loginPanelNameLabel, "loginPanelNameLabel");
            this.loginPanelNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginPanelNameLabel.Name = "loginPanelNameLabel";
            // 
            // loginPanelResumeVersionLabel
            // 
            resources.ApplyResources(this.loginPanelResumeVersionLabel, "loginPanelResumeVersionLabel");
            this.loginPanelResumeVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginPanelResumeVersionLabel.Name = "loginPanelResumeVersionLabel";
            // 
            // namesCombobox
            // 
            this.namesCombobox.ForeColor = System.Drawing.Color.Black;
            this.namesCombobox.FormattingEnabled = true;
            resources.ApplyResources(this.namesCombobox, "namesCombobox");
            this.namesCombobox.Name = "namesCombobox";
            this.namesCombobox.SelectedIndexChanged += new System.EventHandler(this.namesCombobox_SelectedIndexChanged);
            // 
            // resumeVersionCombobox
            // 
            this.resumeVersionCombobox.ForeColor = System.Drawing.Color.Black;
            this.resumeVersionCombobox.FormattingEnabled = true;
            resources.ApplyResources(this.resumeVersionCombobox, "resumeVersionCombobox");
            this.resumeVersionCombobox.Name = "resumeVersionCombobox";
            // 
            // appLanguagesLabel
            // 
            resources.ApplyResources(this.appLanguagesLabel, "appLanguagesLabel");
            this.appLanguagesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.appLanguagesLabel.Name = "appLanguagesLabel";
            this.toolTip1.SetToolTip(this.appLanguagesLabel, resources.GetString("appLanguagesLabel.ToolTip"));
            // 
            // appLanguagesCombobox
            // 
            this.appLanguagesCombobox.ForeColor = System.Drawing.Color.Black;
            this.appLanguagesCombobox.FormattingEnabled = true;
            this.appLanguagesCombobox.Items.AddRange(new object[] {
            resources.GetString("appLanguagesCombobox.Items"),
            resources.GetString("appLanguagesCombobox.Items1")});
            resources.ApplyResources(this.appLanguagesCombobox, "appLanguagesCombobox");
            this.appLanguagesCombobox.Name = "appLanguagesCombobox";
            this.appLanguagesCombobox.SelectedIndexChanged += new System.EventHandler(this.appLanguagesCombobox_SelectedIndexChanged);
            // 
            // connectionStringLabel
            // 
            resources.ApplyResources(this.connectionStringLabel, "connectionStringLabel");
            this.connectionStringLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.connectionStringLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.connectionStringLabel.Name = "connectionStringLabel";
            this.connectionStringLabel.Click += new System.EventHandler(this.connectionStringLabel_Click);
            // 
            // resetToDefaultSettingsButton
            // 
            this.resetToDefaultSettingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.resetToDefaultSettingsButton, "resetToDefaultSettingsButton");
            this.resetToDefaultSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.resetToDefaultSettingsButton.Name = "resetToDefaultSettingsButton";
            this.resetToDefaultSettingsButton.UseVisualStyleBackColor = true;
            this.resetToDefaultSettingsButton.Click += new System.EventHandler(this.resetToDefaultSettingsButton_Click);
            // 
            // changeTitlesButton
            // 
            this.changeTitlesButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            resources.ApplyResources(this.changeTitlesButton, "changeTitlesButton");
            this.changeTitlesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.changeTitlesButton.Name = "changeTitlesButton";
            this.changeTitlesButton.UseVisualStyleBackColor = true;
            this.changeTitlesButton.Click += new System.EventHandler(this.changeTitlesButton_Click);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.changeTitlesButton);
            this.Controls.Add(this.resetToDefaultSettingsButton);
            this.Controls.Add(this.connectionStringLabel);
            this.Controls.Add(this.appLanguagesCombobox);
            this.Controls.Add(this.appLanguagesLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.clearJsonDataButton);
            this.Controls.Add(this.exportJsonDataButton);
            this.Controls.Add(this.importJsonDataButton);
            this.Controls.Add(this.showJsonDataButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button showJsonDataButton;
        private Button importJsonDataButton;
        private Button exportJsonDataButton;
        private Button clearJsonDataButton;
        private ToolTip toolTip1;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label loginPanelResumeVersionLabel;
        private Label loginPanelNameLabel;
        public ComboBox resumeVersionCombobox;
        private ComboBox namesCombobox;
        public Button removePersonButton;
        private GroupBox groupBox3;
        private Label appLanguagesLabel;
        public ComboBox appLanguagesCombobox;
        public Label connectionStringLabel;
        private Button resetToDefaultSettingsButton;
        private Button changeTitlesButton;
    }
}