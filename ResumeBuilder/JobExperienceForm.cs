using ResumeBuilder.Controllers;

namespace ResumeBuilder
{
    public partial class JobExperienceForm : Form
    {
        SqlControllers sqlControllers = new SqlControllers();
        public static string JobTitle;
        public JobExperienceForm()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[1];
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

        private void addJobBtn_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{personalDetailsForm.getID().ToString().Trim()}', '{jobTitleTextbox.Text.Trim()}', '{jobDetailTextbox.Text.Trim()}', '{jobStartDateTextbox.Text.Trim()}', '{jobEndDateTextbox.Text.Trim()}')", $"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{jobTitleTextbox.Text.Trim()}', '{jobDetailTextbox.Text.Trim()}', '{jobStartDateTextbox.Text.Trim()}', '{jobEndDateTextbox.Text.Trim()}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[1];
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"delete from Job where id = '{personalDetailsForm.getID().ToString().Trim()}' and JobTitle = '{JobTitle}'", $"delete from Job where id = '{sqlControllers.GetIdFromDescription().ToString().Trim()}' and JobTitle = '{JobTitle}'");
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[1];
            ClearTextBoxes();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            JobTitle = dataGridView1.Rows[e.RowIndex].Cells["JobTitle"].Value.ToString().Trim();
        }
    }
}