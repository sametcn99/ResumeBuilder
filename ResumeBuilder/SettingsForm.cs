using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace ResumeBuilder
{
    public partial class SettingsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        string json;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void exportJsonDataButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.CreatePrompt = true;
            save.InitialDirectory = @"D:\";
            save.Title = "Save Json File";
            save.DefaultExt = "json";
            save.Filter = "json files (*.json)|*.json|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(save.FileName);
                sw.WriteLine(appControllers.exportJsonData().ToString().Trim());
                sw.Close();
                MessageBox.Show("Saved!\nYou can import this file when you need edit.");
            }
        }


        private void importJsonDataButton_Click(object sender, EventArgs e)
        {
            appControllers.getDataFromDB();
            string readText = "";
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Title = "Select JSON File.";
            file.Filter = "Json Files |*.json";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                readText = File.ReadAllText(file.FileName);
                appControllers.ds = JsonConvert.DeserializeObject<DataSet>(readText);
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connetionString);
                string[] tableNames = { "dbo.Person", "dbo.Job", "dbo.Education", "dbo.MoreDetails" };
                int i = 0;
                while (i < appControllers.ds.Tables.Count)
                {
                    bulkCopy.DestinationTableName = tableNames[i];
                    bulkCopy.WriteToServer(appControllers.ds.Tables[i]);
                    i++;
                }
            }
        }

        private void showJsonDataButton_Click(object sender, EventArgs e)
        {
            appControllers.getDataFromDB();
            json = JsonConvert.SerializeObject(appControllers.ds, Formatting.Indented);
            try
            {
                if (appControllers.ds.Tables[0].Rows[0].Field<string>("Name").Trim() != "")
                {
                    FlexibleMessageBox.Show(json);
                }
            }
            catch (System.IndexOutOfRangeException ex)
            {
                MessageBox.Show($"Dataset is null.");
            }
        }

        private void clearJsonDataButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Clearing all data.", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                appControllers.insertDataSql("delete from Person; delete from Job; delete from Education; delete from MoreDetails");
            }
        }
    }
}
