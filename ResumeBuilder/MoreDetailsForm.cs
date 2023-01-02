namespace ResumeBuilder
{
    public partial class MoreDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();

        public MoreDetailsForm()
        {
            InitializeComponent();
            appControllers.getPersonalDataFromDb();
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void addSkillButton_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            appControllers.getDataFromDB();
            int idCount = appControllers.ds.Tables[0].Rows.Count;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"insert into MoreDetails (id, Skill) values('{formLogin.getId().ToString().Trim()}', '{skillTextbox.Text}')");
            }
            else
            {
                idCount++; ;
                appControllers.insertDataSql($"insert into MoreDetails (id, Skill) values('{idCount}', '{skillTextbox.Text}')");
            }
            ClearTextBoxes();
        }
        private void addCertificationButton_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            int idCount = appControllers.personalDataSet.Tables[0].Rows.Count;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"insert into MoreDetails (id, Certifications) values('{formLogin.getId().ToString().Trim()}', '{certificationTextbox.Text}')");
            }
            else
            {
                idCount = idCount + 1;
                appControllers.insertDataSql($"insert into MoreDetails (id, Certifications) values('{idCount}', '{certificationTextbox.Text}')");
            }
            ClearTextBoxes();
        }
        private void addLanguageButton_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            int idCount = appControllers.personalDataSet.Tables[0].Rows.Count;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"insert into MoreDetails (id, Languages) values('{formLogin.getId().ToString().Trim()}', '{languageTextbox.Text}')");
            }
            else
            {
                idCount = idCount + 1;
                appControllers.insertDataSql($"insert into MoreDetails (id, Languages) values('{idCount}', '{languageTextbox.Text}')");
            }
            ClearTextBoxes();
        }
        private void addPersonalProjectButton_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            int idCount = appControllers.personalDataSet.Tables[0].Rows.Count;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"insert into MoreDetails (id, PersonalProjects) values('{formLogin.getId().ToString().Trim()}', '{personalProjectTitleTextbox.Text}')");
            }
            else
            {
                idCount = idCount + 1;
                appControllers.insertDataSql($"insert into MoreDetails (id, PersonalProjects) values('{idCount}', '{personalProjectTitleTextbox.Text}')");
            }
            ClearTextBoxes();
        }
        private void addInterestButton_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            int idCount = appControllers.personalDataSet.Tables[0].Rows.Count;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"insert into MoreDetails (id, Interests) values('{formLogin.getId().ToString().Trim()}', '{interestTextbox.Text}')");
            }
            else
            {
                idCount = idCount + 1;
                appControllers.insertDataSql($"insert into MoreDetails (id, Interests) values('{idCount}', '{interestTextbox.Text}')");
            }
            ClearTextBoxes();
        }
    }
}
