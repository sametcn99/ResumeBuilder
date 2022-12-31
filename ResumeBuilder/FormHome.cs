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
    public partial class FormHome : Form
    {
        private Button currentButton;
        private Form activeForm;


        public FormHome()
        {
            InitializeComponent();
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
                    //btnCloseChildForm.Visible = true;
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

        private void closeAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        private void homeButton_Click(object sender, EventArgs e)
        {
            activeForm.Close();
        }
    }
}
