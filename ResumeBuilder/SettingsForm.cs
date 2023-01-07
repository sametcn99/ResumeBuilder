using ResumeBuilder.Properties;
namespace ResumeBuilder
{

    public partial class SettingsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();

        public SettingsForm()
        {
            InitializeComponent();
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
            sqlControllers.ClearDatabase();
#pragma warning disable CS8604 // Possible null reference argument for parameter 'path' in 'IEnumerable<string> Directory.EnumerateFiles(string path, string searchPattern, SearchOption searchOption)'.
            var files = Directory.EnumerateFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "*.jpg", SearchOption.AllDirectories);
#pragma warning restore CS8604 // Possible null reference argument for parameter 'path' in 'IEnumerable<string> Directory.EnumerateFiles(string path, string searchPattern, SearchOption searchOption)'.
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
        private void namesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var item in sqlControllers.GetDescriptions(namesCombobox.SelectedItem.ToString().Trim()))
            {
                resumeVersionCombobox.Items.Add(item.Trim());
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
        private void removePersonButton_Click(object sender, EventArgs e)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            int id = sqlControllers.GetIdFromDescriptionForRemovePerson(resumeVersionCombobox.SelectedItem.ToString().Trim());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            sqlControllers.SqlExecuter($"delete from Person where description = '{resumeVersionCombobox.SelectedItem.ToString().Trim()}'; delete from Job where id = '{id}'; delete from Education where id = '{id}'; delete from MoreDetails where id = '{id}'");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            AppControllers.savingOption = 1;
        }

        private void appLanguagesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (appLanguagesCombobox.SelectedIndex)
            {
                case 0:
                    Settings.Default.Language = "en";
                    break;
                case 1:
                    Settings.Default.Language = "tr";
                    break;
            }
            Settings.Default.Save();
            Application.Restart();
        }
    }
}
