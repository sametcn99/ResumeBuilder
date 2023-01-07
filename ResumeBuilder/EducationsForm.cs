namespace ResumeBuilder
{
    public partial class EducationsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();
#pragma warning disable CS8618 // Non-nullable field 'EducationTitle' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        public static string EducationTitle;
#pragma warning restore CS8618 // Non-nullable field 'EducationTitle' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.

        public EducationsForm()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[2];
            dataGridView1.Refresh();
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

        private void addEduBtn_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{personalDetailsForm.getID().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')", $"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')");
            ClearTextBoxes();
            dataGridView1.DataSource = sqlControllers.GetPersonalTables().Tables[2];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            EducationTitle = dataGridView1.Rows[e.RowIndex].Cells["EducationTitle"].Value.ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
