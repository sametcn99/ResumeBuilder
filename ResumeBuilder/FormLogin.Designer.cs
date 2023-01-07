namespace ResumeBuilder
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.closeAppButton = new System.Windows.Forms.Button();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.createNewResumeButton = new System.Windows.Forms.Button();
            this.loginPanelResumeVersionLabel = new System.Windows.Forms.Label();
            this.loginPanelNameLabel = new System.Windows.Forms.Label();
            this.resumeVersionCombobox = new System.Windows.Forms.ComboBox();
            this.namesCombobox = new System.Windows.Forms.ComboBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.navigationPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            resources.ApplyResources(this.navigationPanel, "navigationPanel");
            this.navigationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.navigationPanel.Controls.Add(this.closeAppButton);
            this.navigationPanel.Name = "navigationPanel";
            this.toolTip1.SetToolTip(this.navigationPanel, resources.GetString("navigationPanel.ToolTip"));
            this.navigationPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navigationPanel_MouseDown);
            // 
            // closeAppButton
            // 
            resources.ApplyResources(this.closeAppButton, "closeAppButton");
            this.closeAppButton.FlatAppearance.BorderSize = 0;
            this.closeAppButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.closeAppButton.Name = "closeAppButton";
            this.toolTip1.SetToolTip(this.closeAppButton, resources.GetString("closeAppButton.ToolTip"));
            this.closeAppButton.UseVisualStyleBackColor = true;
            this.closeAppButton.Click += new System.EventHandler(this.closeAppButton_Click);
            // 
            // loginPanel
            // 
            resources.ApplyResources(this.loginPanel, "loginPanel");
            this.loginPanel.Controls.Add(this.createNewResumeButton);
            this.loginPanel.Controls.Add(this.loginPanelResumeVersionLabel);
            this.loginPanel.Controls.Add(this.loginPanelNameLabel);
            this.loginPanel.Controls.Add(this.resumeVersionCombobox);
            this.loginPanel.Controls.Add(this.namesCombobox);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Name = "loginPanel";
            this.toolTip1.SetToolTip(this.loginPanel, resources.GetString("loginPanel.ToolTip"));
            // 
            // createNewResumeButton
            // 
            resources.ApplyResources(this.createNewResumeButton, "createNewResumeButton");
            this.createNewResumeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.createNewResumeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.createNewResumeButton.Name = "createNewResumeButton";
            this.toolTip1.SetToolTip(this.createNewResumeButton, resources.GetString("createNewResumeButton.ToolTip"));
            this.createNewResumeButton.UseVisualStyleBackColor = true;
            this.createNewResumeButton.Click += new System.EventHandler(this.createNewResumeButton_Click);
            // 
            // loginPanelResumeVersionLabel
            // 
            resources.ApplyResources(this.loginPanelResumeVersionLabel, "loginPanelResumeVersionLabel");
            this.loginPanelResumeVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginPanelResumeVersionLabel.Name = "loginPanelResumeVersionLabel";
            this.toolTip1.SetToolTip(this.loginPanelResumeVersionLabel, resources.GetString("loginPanelResumeVersionLabel.ToolTip"));
            // 
            // loginPanelNameLabel
            // 
            resources.ApplyResources(this.loginPanelNameLabel, "loginPanelNameLabel");
            this.loginPanelNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginPanelNameLabel.Name = "loginPanelNameLabel";
            this.toolTip1.SetToolTip(this.loginPanelNameLabel, resources.GetString("loginPanelNameLabel.ToolTip"));
            // 
            // resumeVersionCombobox
            // 
            resources.ApplyResources(this.resumeVersionCombobox, "resumeVersionCombobox");
            this.resumeVersionCombobox.ForeColor = System.Drawing.Color.Black;
            this.resumeVersionCombobox.FormattingEnabled = true;
            this.resumeVersionCombobox.Name = "resumeVersionCombobox";
            this.toolTip1.SetToolTip(this.resumeVersionCombobox, resources.GetString("resumeVersionCombobox.ToolTip"));
            // 
            // namesCombobox
            // 
            resources.ApplyResources(this.namesCombobox, "namesCombobox");
            this.namesCombobox.ForeColor = System.Drawing.Color.Black;
            this.namesCombobox.FormattingEnabled = true;
            this.namesCombobox.Name = "namesCombobox";
            this.toolTip1.SetToolTip(this.namesCombobox, resources.GetString("namesCombobox.ToolTip"));
            this.namesCombobox.SelectedIndexChanged += new System.EventHandler(this.namesCombobox_SelectedIndexChanged);
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginButton.Name = "loginButton";
            this.toolTip1.SetToolTip(this.loginButton, resources.GetString("loginButton.ToolTip"));
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // FormLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.navigationPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.navigationPanel.ResumeLayout(false);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel navigationPanel;
        private Button closeAppButton;
        private Panel loginPanel;
        private Button createNewResumeButton;
        private Label loginPanelResumeVersionLabel;
        private Label loginPanelNameLabel;
        public ComboBox resumeVersionCombobox;
        private ComboBox namesCombobox;
        public Button loginButton;
        private ToolTip toolTip1;
    }
}