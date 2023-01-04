namespace ResumeBuilder
{
    public partial class JobExperienceForm : Form
    {
        AppControllers appControllers = new AppControllers();
        public JobExperienceForm()
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

        private void addJobBtn_Click(object sender, EventArgs e)
        {
            try
            {
                FormLogin formLogin = new FormLogin();
                AppControllers appControllers = new AppControllers();
                appControllers.getDataFromDB();
                int idCount = appControllers.ds.Tables[0].Rows.Count;
                idCount++;
                if (formLogin.getId().ToString().Trim() != "")
                {
                    appControllers.insertDataSql($"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{formLogin.getId().ToString().Trim()}', '{jobTitleTextbox.Text}', '{jobDetailTextbox.Text}', '{jobStartDateTextbox.Text}', '{jobEndDateTextbox.Text}')");
                }
                else
                {
                    appControllers.insertDataSql($"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{idCount}', '{jobTitleTextbox.Text}', '{jobDetailTextbox.Text}', '{jobStartDateTextbox.Text}', '{jobEndDateTextbox.Text}')");
                }
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
