namespace ResumeBuilder
{
    public partial class JobExperienceForm : Form
    {
        SqlControllers sqlControllers = new SqlControllers();
#pragma warning disable CS8618 // Non-nullable field 'JobTitle' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        public static string JobTitle;
#pragma warning restore CS8618 // Non-nullable field 'JobTitle' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        public JobExperienceForm()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[1];
        }

        private void ClearTextBoxes()
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Action<Control.ControlCollection> func = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        (control as TextBox).Clear();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    else
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                        func(control.Controls);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            JobTitle = dataGridView1.Rows[e.RowIndex].Cells["JobTitle"].Value.ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}