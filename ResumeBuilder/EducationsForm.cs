namespace ResumeBuilder
{
    public partial class EducationsForm : Form
    {
        AppControllers appControllers = new AppControllers();

        public EducationsForm()
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

        private void addEduBtn_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            AppControllers appControllers = new AppControllers();
            appControllers.getDataFromDB();
            int idCount = appControllers.ds.Tables[0].Rows.Count;
            idCount++;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{formLogin.getId().ToString().Trim()}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')");
            }
            else
            {

                appControllers.insertDataSql($"insert into Education (id, EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{idCount}', '{educationTitleTextbox.Text}','{educationDetailTextbox.Text}', '{educationStartDateTextbox.Text}', '{educationEndDateTextbox.Text}')");
            }
            ClearTextBoxes();
        }
    }
}
