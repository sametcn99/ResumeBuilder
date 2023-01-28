using ResumeBuilder.Properties;

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
        public string pdfPath = "";
        public FormHome()
        {
            InitializeComponent();
        }
        public void formRefresh()
        {
            if (AppControllers.languageOption == 1)
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr");
                this.Controls.Clear();
                InitializeComponent();
            }
            else
            {
                InitializeComponent();
            }
        }

        //*****CHILDFORM METHODS*****
        private void OpenChildForm(Form childForm, object btnSender)
        {
            savingLabel.Visible = false;
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
            SqlControllers sqlControllers = new SqlControllers();
            ResumeLayouts resumeLayouts = new ResumeLayouts();
            LayoutForm layoutForm = new LayoutForm();
            SaveFileDialog save = new SaveFileDialog();
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            if (AppControllers.savingOption == 1)
            {
                save.InitialDirectory = @"D:\";
                save.Title = "Save DOCX File";
                save.Filter = "DOCX Files (*.docx)|*|All Files(*.*)|*.*";
            }
            else
            {
                save.OverwritePrompt = false;
                save.CreatePrompt = true;
                save.InitialDirectory = @"D:\";
                save.Title = "Save PDF File";
                save.DefaultExt = "pdf";
                save.Filter = "PDF Files (*.pdf)|*.pdf|All Files(*.*)|*.*";
            }
            savingLabel.Visible = true;
            if (activeForm != null)
            {
                activeForm.Close();
                DisableButton();
                homeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                homeButton.ForeColor = Color.White;
            }
            if (save.ShowDialog() == DialogResult.OK)
            {
                pdfPath = save.FileName;
                if (layoutForm.getSelectedLayout() == "0")
                {
                    resumeLayouts.ClassicLayout(save.FileName, sqlControllers.fillPdfFields().Item1.ToString(), sqlControllers.fillPdfFields().Item2.ToString(), sqlControllers.fillPdfFields().Item3.ToString(), sqlControllers.fillPdfFields().Item4.ToString(), sqlControllers.fillPdfFields().Item5.ToString(), sqlControllers.fillPdfFields().Item6.ToString(), sqlControllers.fillPdfFields().Item7.ToString(), sqlControllers.fillPdfFields().Item8.ToString(), sqlControllers.fillPdfFields().Item9.ToString(), sqlControllers.fillPdfFields().Item10.ToString());
                }
                if (layoutForm.getSelectedLayout() == "1")
                {
                    resumeLayouts.ModernLayout(save.FileName, sqlControllers.fillPdfFields().Item1.ToString(), sqlControllers.fillPdfFields().Item2.ToString(), sqlControllers.fillPdfFields().Item3.ToString(), sqlControllers.fillPdfFields().Item4.ToString(), sqlControllers.fillPdfFields().Item5.ToString(), sqlControllers.fillPdfFields().Item6.ToString(), sqlControllers.fillPdfFields().Item7.ToString(), sqlControllers.fillPdfFields().Item8.ToString(), sqlControllers.fillPdfFields().Item9.ToString(), sqlControllers.fillPdfFields().Item10.ToString());
                }
                savingLabel.Text = "Saved!";
                if (Settings.Default.SavingFileOption == 1)
                {
                    SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                    f.OpenPdf(pdfPath);
                    if (f.PageCount > 0)
                        f.ToWord(pdfPath.Replace(".pdf", "") + @".docx");
                    f.ClosePdf();
                    File.Delete(pdfPath);
                }
            }
        }

        private void logoLabel_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                DisableButton();
                homeButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                homeButton.ForeColor = Color.White;
            }
        }
    }
}