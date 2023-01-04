namespace ResumeBuilder
{
    public partial class JobExperienceForm : Form
    {
        SqlControllers sqlControllers = new SqlControllers();
        public JobExperienceForm()
        {
            InitializeComponent();
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
            sqlControllers.AddNewDataOrEdit($"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{personalDetailsForm.getID().ToString().Trim()}', '{jobTitleTextbox.Text.Trim()}', '{jobDetailTextbox.Text.Trim()}', '{jobStartDateTextbox.Text.Trim()}', '{jobEndDateTextbox.Text.Trim()}')", $"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{sqlControllers.getIdFromDescription().ToString().Trim()}', '{jobTitleTextbox.Text.Trim()}', '{jobDetailTextbox.Text.Trim()}', '{jobStartDateTextbox.Text.Trim()}', '{jobEndDateTextbox.Text.Trim()}')");
            ClearTextBoxes();
        }
    }
}