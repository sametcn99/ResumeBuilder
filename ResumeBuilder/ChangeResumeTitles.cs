using ResumeBuilder.Controllers;
using ResumeBuilder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class ChangeResumeTitles : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public ChangeResumeTitles()
        {
            InitializeComponent();
            AppControllers appControllers = new AppControllers();
            if (Settings.Default.Language == "en")
            {
                jobTitleTextbox.Text = appControllers.titlesEN[0].Trim();
                educationTitleTextbox.Text = appControllers.titlesEN[1].Trim();
                certificationsTitleTextbox.Text = appControllers.titlesEN[2].Trim();
                personalProjectsTitleTextbox.Text = appControllers.titlesEN[3].Trim();
                languagesTitleTextbox.Text = appControllers.titlesEN[4].Trim();
                interestsTitleTextbox.Text = appControllers.titlesEN[5].Trim();
                skillsTitleTextbox.Text = appControllers.titlesEN[6].Trim();
            }
            if (Settings.Default.Language == "tr")
            {
                jobTitleTextbox.Text = appControllers.titlesTR[0].Trim();
                educationTitleTextbox.Text = appControllers.titlesTR[1].Trim();
                certificationsTitleTextbox.Text = appControllers.titlesTR[2].Trim();
                personalProjectsTitleTextbox.Text = appControllers.titlesTR[3].Trim();
                languagesTitleTextbox.Text = appControllers.titlesTR[4].Trim();
                interestsTitleTextbox.Text = appControllers.titlesTR[5].Trim();
                skillsTitleTextbox.Text = appControllers.titlesTR[6].Trim();
            }
        }

        private void saveTitlesButton_Click(object sender, EventArgs e)
        {
            Settings.Default.jobTitleLanguage = jobTitleTextbox.Text.Trim();
            Settings.Default.educationTitleLanguage = educationTitleTextbox.Text.Trim();
            Settings.Default.certificationsTitleLanguage = certificationsTitleTextbox.Text.Trim();
            Settings.Default.personalProjectsTitleLanguage = personalProjectsTitleTextbox.Text.Trim();
            Settings.Default.languagesTitleLanguage = languagesTitleTextbox.Text.Trim();
            Settings.Default.interestsTitleLanguage = interestsTitleTextbox.Text.Trim();
            Settings.Default.skillsTitleLanguage = skillsTitleTextbox.Text.Trim();
            this.Close();
        }

        private void resetTitlesButton_Click(object sender, EventArgs e)
        {
            AppControllers appControllers = new AppControllers();
            if (Settings.Default.Language == "en")
            {
                jobTitleTextbox.Text = appControllers.titlesEN[0].Trim();
                educationTitleTextbox.Text = appControllers.titlesEN[1].Trim();
                certificationsTitleTextbox.Text = appControllers.titlesEN[2].Trim();
                personalProjectsTitleTextbox.Text = appControllers.titlesEN[3].Trim();
                languagesTitleTextbox.Text = appControllers.titlesEN[4].Trim();
                interestsTitleTextbox.Text = appControllers.titlesEN[5].Trim();
                skillsTitleTextbox.Text = appControllers.titlesEN[6].Trim();
            }
            if (Settings.Default.Language == "tr")
            {
                jobTitleTextbox.Text = appControllers.titlesTR[0].Trim();
                educationTitleTextbox.Text = appControllers.titlesTR[1].Trim();
                certificationsTitleTextbox.Text = appControllers.titlesTR[2].Trim();
                personalProjectsTitleTextbox.Text = appControllers.titlesTR[3].Trim();
                languagesTitleTextbox.Text = appControllers.titlesTR[4].Trim();
                interestsTitleTextbox.Text = appControllers.titlesTR[5].Trim();
                skillsTitleTextbox.Text = appControllers.titlesTR[6].Trim();
            }
            Settings.Default.jobTitleLanguage = jobTitleTextbox.Text.Trim();
            Settings.Default.educationTitleLanguage = educationTitleTextbox.Text.Trim();
            Settings.Default.certificationsTitleLanguage = certificationsTitleTextbox.Text.Trim();
            Settings.Default.personalProjectsTitleLanguage = personalProjectsTitleTextbox.Text.Trim();
            Settings.Default.languagesTitleLanguage = languagesTitleTextbox.Text.Trim();
            Settings.Default.interestsTitleLanguage = interestsTitleTextbox.Text.Trim();
            Settings.Default.skillsTitleLanguage = skillsTitleTextbox.Text.Trim();
        }

        private void cancelSaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeAppButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navigationPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
