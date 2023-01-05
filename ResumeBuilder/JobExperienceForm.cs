using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class JobExperienceForm : Form
    {
        SqlControllers sqlControllers = new SqlControllers();
        public JobExperienceForm()
        {
            InitializeComponent();
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

        }

    }
}