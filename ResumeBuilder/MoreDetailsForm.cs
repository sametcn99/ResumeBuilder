namespace ResumeBuilder
{
    public partial class MoreDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();
        PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
        public MoreDetailsForm()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
            dataGridView1.Refresh();
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
            if (skillTextbox.Text.Trim() != "")
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Skill) values('{personalDetailsForm.getID().ToString().Trim()}', '{skillTextbox.Text}')", $"insert into MoreDetails (id, Skill) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{skillTextbox.Text}')");
                ClearTextBoxes();
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
            }
        }
        private void addCertificationButton_Click(object sender, EventArgs e)
        {
            if (certificationTextbox.Text.Trim() != "")
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Certifications) values('{personalDetailsForm.getID().ToString().Trim()}', '{certificationTextbox.Text}')", $"insert into MoreDetails (id, Certifications) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{certificationTextbox.Text}')");
                ClearTextBoxes();
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
            }
        }
        private void addLanguageButton_Click(object sender, EventArgs e)
        {
            if (languageTextbox.Text.Trim() != "")
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Languages) values('{personalDetailsForm.getID().ToString().Trim()}', '{languageTextbox.Text}')", $"insert into MoreDetails (id, Languages) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{languageTextbox.Text}')");
                ClearTextBoxes();
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
            }
        }
        private void addPersonalProjectButton_Click(object sender, EventArgs e)
        {
            if (personalProjectTitleTextbox.Text.Trim() != "")
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, PersonalProjects) values('{personalDetailsForm.getID().ToString().Trim()}', '{personalProjectTitleTextbox.Text}')", $"insert into MoreDetails (id, PersonalProjects) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{personalProjectTitleTextbox.Text}')");
                ClearTextBoxes();
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
            }
        }
        private void addInterestButton_Click(object sender, EventArgs e)
        {
            if (interestTextbox.Text.Trim() != "")
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                sqlControllers.AddNewDataOrEdit($"insert into MoreDetails (id, Interests) values('{personalDetailsForm.getID().ToString().Trim()}', '{interestTextbox.Text}')", $"insert into MoreDetails (id, Interests) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{interestTextbox.Text}')");
                ClearTextBoxes();
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            skillTextbox.Text = dataGridView1.Rows[e.RowIndex].Cells["Skill"].Value.ToString().Trim();
            certificationTextbox.Text = dataGridView1.Rows[e.RowIndex].Cells["Certifications"].Value.ToString().Trim();
            languageTextbox.Text = dataGridView1.Rows[e.RowIndex].Cells["Languages"].Value.ToString().Trim();
            interestTextbox.Text = dataGridView1.Rows[e.RowIndex].Cells["Interests"].Value.ToString().Trim();
            personalProjectTitleTextbox.Text = dataGridView1.Rows[e.RowIndex].Cells["PersonalProjects"].Value.ToString().Trim();
        }

        private void skillRemoveButton_Click(object sender, EventArgs e)
        {
            if (skillTextbox.Text != "")
            {
                sqlControllers.AddNewDataOrEdit($"delete from MoreDetails where id ='{personalDetailsForm.getID().ToString().Trim()}' and Skill='{skillTextbox.Text}'", $"delete from MoreDetails where id ='{sqlControllers.GetIdFromDescription().ToString().Trim()}' and Skill='{skillTextbox.Text}'");
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
                ClearTextBoxes();
            }
        }

        private void certificationsRemoveButton_Click(object sender, EventArgs e)
        {
            if (certificationTextbox.Text != "")
            {
                sqlControllers.AddNewDataOrEdit($"delete from MoreDetails where id ='{personalDetailsForm.getID().ToString().Trim()}' and Certifications='{certificationTextbox.Text.ToString().Trim()}'", $"delete from MoreDetails where id ='{sqlControllers.GetIdFromDescription().ToString().Trim()}' and Certifications='{certificationTextbox.Text.ToString().Trim()}'");
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
                ClearTextBoxes();
            }
        }

        private void languagesRemoveButton_Click(object sender, EventArgs e)
        {
            if (languageTextbox.Text != "")
            {
                sqlControllers.AddNewDataOrEdit($"delete from MoreDetails where id ='{personalDetailsForm.getID().ToString().Trim()}' and Languages='{languageTextbox.Text.ToString().Trim()}'", $"delete from MoreDetails where id ='{sqlControllers.GetIdFromDescription().ToString().Trim()}' and Languages='{languageTextbox.Text.ToString().Trim()}'");
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
                ClearTextBoxes();
            }
        }

        private void personalProjectRemoveButton_Click(object sender, EventArgs e)
        {
            if (personalProjectTitleTextbox.Text != "")
            {
                sqlControllers.AddNewDataOrEdit($"delete from MoreDetails where id ='{personalDetailsForm.getID().ToString().Trim()}' and PersonalProjects='{personalProjectTitleTextbox.Text.ToString().Trim()}'", $"delete from MoreDetails where id ='{sqlControllers.GetIdFromDescription().ToString().Trim()}' and PersonalProjects='{personalProjectTitleTextbox.Text.ToString().Trim()}'");
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
                ClearTextBoxes();
            }
        }

        private void interestsRemoveButton_Click(object sender, EventArgs e)
        {
            if (interestTextbox.Text != "")
            {
                sqlControllers.AddNewDataOrEdit($"delete from MoreDetails where id ='{personalDetailsForm.getID().ToString().Trim()}' and Interests='{interestTextbox.Text.ToString().Trim()}'", $"delete from MoreDetails where id ='{sqlControllers.GetIdFromDescription().ToString().Trim()}' and Interests='{interestTextbox.Text.ToString().Trim()}'");
                dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[3];
                ClearTextBoxes();
            }
        }
    }
}
