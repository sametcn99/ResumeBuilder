namespace ResumeBuilder
{
    public partial class FormHome : Form
    {
        private Button currentButton;
        private Form activeForm;

        //*****DRAG FORM FIELDS*****
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public FormHome()
        {
            InitializeComponent();
        }

        //*****CHILDFORM METHODS*****
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null) { activeForm.Close(); }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.childFormPanel.Controls.Add(childForm);
            this.childFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                    currentButton.ForeColor = Color.White;
                    homeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                    homeButton.ForeColor = System.Drawing.Color.FromArgb(238, 238, 238);
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in leftMenuPanel.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(33, 33, 33);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                }
            }
        }

        //*****CHILDFORM EVENTS*****
        private void personalDetailsPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PersonalDetailsForm(), sender);
        }
        private void addJobExperiencePanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new JobExperienceForm(), sender);
        }
        private void educationPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new EducationsForm(), sender);
        }
        private void settingsPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new SettingsForm(), sender);
        }
        private void aboutPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AboutForm(), sender);
        }
        private void selectPhotoPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new PhotoUploadForm(), sender);
        }
        private void addMoreDetailPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new MoreDetailsForm(), sender);
        }
        private void layoutPanelButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LayoutForm(), sender);
        }
        private void homeButton_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                DisableButton();
                homeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                homeButton.ForeColor = Color.White;
            }
        }

        //*****OTHER EVENTS*****
        private void closeAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void childFormPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void navigationPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
        }
    }
}