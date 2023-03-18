using ResumeBuilder.Controllers;
using ResumeBuilder.Properties;
using static ResumeBuilder.Controllers.AppControllers;
namespace ResumeBuilder
{

    public partial class SettingsForm : Form
    {
        /*This code defines the behavior of the SettingsForm in the ResumeBuilder application. 
        It includes methods for exporting and importing data from a SQL database, displaying and 
        clearing data, removing a person's information from the database, changing the language 
        of the application, changing the saving file option, displaying the connection string, 
        resetting settings to default, and changing the titles of sections in a resume. 
        It also initializes the form by populating combo boxes with data from the database and setting the connection string label.*/
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();

        public SettingsForm()
        {
            InitializeComponent();
            //SqlControllers sqlControllers = new SqlControllers();
            connectionStringLabel.Text = "Connection String: \n" + sqlControllers.getConnectionString().ToString();
            foreach (var item in sqlControllers.GetNames())
            {
                namesCombobox.Items.Add(item.Trim());
            }
        }

        private void exportJsonDataButton_Click(object sender, EventArgs e)
        {
            sqlControllers.ExportDatabase();
        }
        private void importJsonDataButton_Click(object sender, EventArgs e)
        {
            sqlControllers.ImportDatabase();
            MessageBox.Show("Imported!\nApplication restarted.");
            Application.Restart();
        }
        private void showJsonDataButton_Click(object sender, EventArgs e)
        {
            FlexibleMessageBox.Show(sqlControllers.GetDatabaseAsJsonText());
        }
        private void clearJsonDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                sqlControllers.ClearDatabase();
                var files = Directory.EnumerateFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "*.jpg", SearchOption.AllDirectories);
                foreach (var item in files)
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch (Exception)
                    { //log exception}
                    }
                }
                MessageBox.Show("Cleared!\nApplication restarted.");
                Application.Restart();
            }
            catch (Exception)
            {
            }
        }
        private void namesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in sqlControllers.GetDescriptions(namesCombobox.SelectedItem.ToString().Trim()))
            {
                resumeVersionCombobox.Items.Add(item.Trim());
            }
        }
        private void removePersonButton_Click(object sender, EventArgs e)
        {
            int id = sqlControllers.GetIdFromDescriptionForRemovePerson(resumeVersionCombobox.SelectedItem.ToString().Trim());
            sqlControllers.SqlExecuter($"delete from Person where description = '{resumeVersionCombobox.SelectedItem.ToString().Trim()}'; delete from Job where id = '{id}'; delete from Education where id = '{id}'; delete from MoreDetails where id = '{id}'; delete from Image where id = '{id}'");
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            Settings.Default.SavingFileOption = 1;
        }

        private void appLanguagesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppControllers appControllers = new AppControllers();
            DialogResult dialogResult = new DialogResult();
            dialogResult = MessageBox.Show("Some of the operations you perform require an application restart to take affect.", "Uyarı!", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                switch (appLanguagesCombobox.SelectedIndex)
                {
                    case 0:
                        Settings.Default.Language = "en";
                        Settings.Default.jobTitleLanguage = appControllers.titlesEN[0].Trim();
                        Settings.Default.educationTitleLanguage = appControllers.titlesEN[1].Trim();
                        Settings.Default.certificationsTitleLanguage = appControllers.titlesEN[2].Trim();
                        Settings.Default.personalProjectsTitleLanguage = appControllers.titlesEN[3].Trim();
                        Settings.Default.languagesTitleLanguage = appControllers.titlesEN[4].Trim();
                        Settings.Default.interestsTitleLanguage = appControllers.titlesEN[5].Trim();
                        Settings.Default.skillsTitleLanguage = appControllers.titlesEN[6].Trim();
                        break;
                    case 1:
                        Settings.Default.Language = "tr";
                        Settings.Default.jobTitleLanguage = appControllers.titlesTR[0].Trim();
                        Settings.Default.educationTitleLanguage = appControllers.titlesTR[1].Trim();
                        Settings.Default.certificationsTitleLanguage = appControllers.titlesTR[2].Trim();
                        Settings.Default.personalProjectsTitleLanguage = appControllers.titlesTR[3].Trim();
                        Settings.Default.languagesTitleLanguage = appControllers.titlesTR[4].Trim();
                        Settings.Default.interestsTitleLanguage = appControllers.titlesTR[5].Trim();
                        Settings.Default.skillsTitleLanguage = appControllers.titlesTR[6].Trim();
                        break;
                }
                Settings.Default.Save();
                Application.Restart();
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            Settings.Default.SavingFileOption = 0;
        }

        private void connectionStringLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sqlControllers.getConnectionString().ToString());
        }

        private void resetToDefaultSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            MessageBox.Show("Settings changed to default.\nRestarted Program.");
            Application.Restart();
        }

        private void changeTitlesButton_Click(object sender, EventArgs e)
        {
            ChangeResumeTitles changeResumeTitles = new ChangeResumeTitles();
            changeResumeTitles.Show();
        }
    }
}
