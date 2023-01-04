using Microsoft.Identity.Client;

namespace ResumeBuilder
{
    public partial class EducationsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();

        public EducationsForm()
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

        private void addEduBtn_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            sqlControllers.AddNewDataOrEdit($"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{personalDetailsForm.getID().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')", $"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')");
            ClearTextBoxes();
        }
    }
}
