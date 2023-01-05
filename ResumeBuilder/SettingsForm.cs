﻿namespace ResumeBuilder
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
            MessageBox.Show("Cleared!\nApplication restarted.");
            Application.Restart();
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
            sqlControllers.SqlExecuter($"delete from Person where description = '{resumeVersionCombobox.SelectedItem.ToString().Trim()}'; delete from Job where id = '{id}'; delete from Education where id = '{id}'; delete from MoreDetails where id = '{id}'");
        }
    }
}
