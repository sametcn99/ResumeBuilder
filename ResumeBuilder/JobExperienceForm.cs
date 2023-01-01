using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void addJobBtn_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            int idCount = appControllers.personalDataSet.Tables[1].Rows.Count;
            if (formLogin.getId().ToString().Trim() != null)
            {
                appControllers.insertDataSql($"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{formLogin.getId().ToString().Trim()}', '{jobTitleTextbox.Text}', '{jobDetailTextbox.Text}', '{jobStartDateTextbox.Text}', '{jobEndDateTextbox.Text}')");
            }
            else
            {
                idCount = idCount + 1;
                appControllers.insertDataSql($"insert into Job (id, JobTitle, JobDetail, JobStart, JobEnd) values('{idCount}', '{jobTitleTextbox.Text}', '{jobDetailTextbox.Text}', '{jobStartDateTextbox.Text}', '{jobEndDateTextbox.Text}')");
            }
        }
    }
}
