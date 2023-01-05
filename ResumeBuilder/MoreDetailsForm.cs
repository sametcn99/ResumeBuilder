namespace ResumeBuilder
{
    public partial class MoreDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();

        public MoreDetailsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
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
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Skill) values('{personalDetailsForm.getID().ToString().Trim()}', '{skillTextbox.Text}')", $"insert into MoreDetails (id, Skill) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{skillTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
        }
        private void addCertificationButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Certifications) values('{personalDetailsForm.getID().ToString().Trim()}', '{certificationTextbox.Text}')", $"insert into MoreDetails (id, Certifications) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{certificationTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
        }
        private void addLanguageButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Languages) values('{personalDetailsForm.getID().ToString().Trim()}', '{languageTextbox.Text}')", $"insert into MoreDetails (id, Languages) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{languageTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
        }
        private void addPersonalProjectButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, PersonalProjects) values('{personalDetailsForm.getID().ToString().Trim()}', '{personalProjectTitleTextbox.Text}')", $"insert into MoreDetails (id, PersonalProjects) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{personalProjectTitleTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
        }
        private void addInterestButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Interests) values('{personalDetailsForm.getID().ToString().Trim()}', '{interestTextbox.Text}')", $"insert into MoreDetails (id, Interests) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{interestTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
        }
    }
}
