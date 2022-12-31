namespace ResumeBuilder
{
    partial class LoginForm
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
            this.loginPanel = new System.Windows.Forms.Panel();
            this.createNewResumeButton = new System.Windows.Forms.Button();
            this.loginPanelResumeVersionLabel = new System.Windows.Forms.Label();
            this.loginPanelNameLabel = new System.Windows.Forms.Label();
            this.resumeVersionCombobox = new System.Windows.Forms.ComboBox();
            this.userLoginCombobox = new System.Windows.Forms.ComboBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.createNewResumeButton);
            this.loginPanel.Controls.Add(this.loginPanelResumeVersionLabel);
            this.loginPanel.Controls.Add(this.loginPanelNameLabel);
            this.loginPanel.Controls.Add(this.resumeVersionCombobox);
            this.loginPanel.Controls.Add(this.userLoginCombobox);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Location = new System.Drawing.Point(121, 81);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(558, 289);
            this.loginPanel.TabIndex = 5;
            // 
            // createNewResumeButton
            // 
            this.createNewResumeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.createNewResumeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createNewResumeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.createNewResumeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createNewResumeButton.Location = new System.Drawing.Point(337, 200);
            this.createNewResumeButton.Name = "createNewResumeButton";
            this.createNewResumeButton.Size = new System.Drawing.Size(150, 50);
            this.createNewResumeButton.TabIndex = 7;
            this.createNewResumeButton.Text = "CREATE NEW";
            this.createNewResumeButton.UseVisualStyleBackColor = true;
            // 
            // loginPanelResumeVersionLabel
            // 
            this.loginPanelResumeVersionLabel.AutoSize = true;
            this.loginPanelResumeVersionLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginPanelResumeVersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginPanelResumeVersionLabel.Location = new System.Drawing.Point(86, 111);
            this.loginPanelResumeVersionLabel.Name = "loginPanelResumeVersionLabel";
            this.loginPanelResumeVersionLabel.Size = new System.Drawing.Size(116, 20);
            this.loginPanelResumeVersionLabel.TabIndex = 6;
            this.loginPanelResumeVersionLabel.Text = "Resume Version:";
            // 
            // loginPanelNameLabel
            // 
            this.loginPanelNameLabel.AutoSize = true;
            this.loginPanelNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.loginPanelNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginPanelNameLabel.Location = new System.Drawing.Point(86, 68);
            this.loginPanelNameLabel.Name = "loginPanelNameLabel";
            this.loginPanelNameLabel.Size = new System.Drawing.Size(114, 20);
            this.loginPanelNameLabel.TabIndex = 5;
            this.loginPanelNameLabel.Text = "Name Surname:";
            // 
            // resumeVersionCombobox
            // 
            this.resumeVersionCombobox.ForeColor = System.Drawing.Color.Black;
            this.resumeVersionCombobox.FormattingEnabled = true;
            this.resumeVersionCombobox.Location = new System.Drawing.Point(211, 108);
            this.resumeVersionCombobox.Margin = new System.Windows.Forms.Padding(10);
            this.resumeVersionCombobox.Name = "resumeVersionCombobox";
            this.resumeVersionCombobox.Size = new System.Drawing.Size(276, 23);
            this.resumeVersionCombobox.TabIndex = 4;
            // 
            // userLoginCombobox
            // 
            this.userLoginCombobox.ForeColor = System.Drawing.Color.Black;
            this.userLoginCombobox.FormattingEnabled = true;
            this.userLoginCombobox.Location = new System.Drawing.Point(213, 65);
            this.userLoginCombobox.Margin = new System.Windows.Forms.Padding(10);
            this.userLoginCombobox.Name = "userLoginCombobox";
            this.userLoginCombobox.Size = new System.Drawing.Size(276, 23);
            this.userLoginCombobox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.loginButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loginButton.Location = new System.Drawing.Point(339, 144);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(150, 50);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "LOGIN";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginPanel);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel loginPanel;
        private Button createNewResumeButton;
        private Label loginPanelResumeVersionLabel;
        private Label loginPanelNameLabel;
        private ComboBox resumeVersionCombobox;
        private ComboBox userLoginCombobox;
        private Button loginButton;
    }
}