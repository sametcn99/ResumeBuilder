using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ResumeBuilder
{
    internal class SqlControllers
    {
        SqlConnection cnn;
        SqlDataReader reader1;
        public string id;
        string cmdstring = "";
        public string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public string defaultEmptyValue = "UPDATE MoreDetails\r\nSET PersonalProjects = ''\r\nWHERE PersonalProjects IS NULL;\r\nUPDATE MoreDetails\r\nSET Skill = ''\r\nWHERE Skill IS NULL;\r\nUPDATE MoreDetails\r\nSET Languages = ''\r\nWHERE Languages IS NULL;\r\nUPDATE MoreDetails\r\nSET Interests = ''\r\nWHERE Interests IS NULL;\r\nUPDATE MoreDetails\r\nSET Certifications = ''\r\nWHERE Certifications IS NULL;\r\nUPDATE Person\r\nSET Website = ''\r\nWHERE Website IS NULL;\r\nUPDATE Person\r\nSET SocialMedia = ''\r\nWHERE SocialMedia IS NULL;\r\nUPDATE Person\r\nSET Address = ''\r\nWHERE Address IS NULL;";
        public void SqlExecuter(string cmdstring)
        {
            try
            {
                cnn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(cmdstring, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (System.IndexOutOfRangeException ex) { MessageBox.Show("something went wrong\n " + ex.Message); }
            catch (Exception ex) { MessageBox.Show("an unexpected error occurred " + ex.Message); throw; }
        }
        public void AddNewDataOrEdit(string addCmd, string editCmd)
        {
            try
            {
                FormLogin formLogin = new FormLogin();
                if (formLogin.getDescription().ToString().Trim() == "")
                {
                    cnn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(addCmd, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                else
                {
                    cnn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(editCmd, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch (System.IndexOutOfRangeException ex) { MessageBox.Show("something went wrong\n " + ex.Message); }
            catch (Exception ex) { MessageBox.Show("an unexpected error occurred " + ex.Message); throw; }
        }
        public List<string> GetDescriptions(string selectedName)
        {
            List<string> description = new List<string>();
            cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand($"select description from Person where Name = '{selectedName}'", cnn);
            cnn.Open();
            reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                description.Add(reader1.GetString("description"));
            }
            cnn.Close();
            return description;
        }
        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand($" select distinct Name from Person", cnn);
            cnn.Open();
            reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                names.Add(reader1.GetString("Name"));
            }
            cnn.Close();
            return names;
        }
        public void ClearDatabase()
        {
            SqlExecuter("delete from Person; delete from Job; delete from Education; delete from MoreDetails");
        }
        public string GetDatabaseAsJsonText()
        {
            DataSet dataSet = new DataSet();
            var json = "";
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM MoreDetails";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connectionString);
            dataAdapter.Fill(dataSet);
            json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            return json;
        }
        public void ImportDatabase()
        {
            DataSet dataSet = new DataSet();
            AppControllers appControllers = new AppControllers();
            string readText = "";
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Title = "Select JSON File.";
            file.Filter = "Json Files |*.json";
            file.Multiselect = false;
            if (file.ShowDialog() == DialogResult.OK)
            {
                readText = File.ReadAllText(file.FileName);
                dataSet = JsonConvert.DeserializeObject<DataSet>(readText);
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString);
                string[] tableNames = { "dbo.Person", "dbo.Job", "dbo.Education", "dbo.MoreDetails" };
                int i = 0;
                while (i < dataSet.Tables.Count)
                {
                    bulkCopy.DestinationTableName = tableNames[i];
                    bulkCopy.WriteToServer(dataSet.Tables[i]);
                    i++;
                }
            }
        }
        public void ExportDatabase()
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
                sw.WriteLine(GetDatabaseAsJsonText());
                sw.Close();
                MessageBox.Show("Saved!\nYou can import this file when you need edit.");
            }
        }
        public DataSet getPersonDetails()
        {
            FormLogin formLogin = new FormLogin();
            DataSet dataSet = new DataSet();
            if (formLogin.getDescription() != "")
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from Person where description = '{formLogin.getDescription()}'", connectionString);
                dataAdapter.Fill(dataSet);
            }
            return dataSet;
        }
        public int getIdFromDescription()
        {
            FormLogin formLogin = new FormLogin();
            formLogin.getDescription();
            cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand($"select id from Person where description = '{formLogin.getDescription().Trim()}'", cnn);
            cnn.Open();
            int id = (int)cmd.ExecuteScalar();
            cnn.Close();
            return id;
        }
    }
}