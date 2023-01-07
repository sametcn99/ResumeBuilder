namespace ResumeBuilder
{
    public partial class EducationsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();
        public static string EducationTitle;

        public EducationsForm()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[2];
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

        private void addEduBtn_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{personalDetailsForm.getID().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')", $"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[2];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EducationTitle = dataGridView1.Rows[e.RowIndex].Cells["EducationTitle"].Value.ToString().Trim();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"delete from Education where id = '{personalDetailsForm.getID().ToString().Trim()}' and JobTitle = '{EducationTitle}'", $"delete from Job where id = '{sqlControllers.GetIdFromDescription().ToString().Trim()}' and JobTitle = '{EducationTitle}'");
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[1];
            ClearTextBoxes();
        }
    }
}
