using HarfBuzzSharp;
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
        public static string name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills;
        public string id;
        public int id2 = 0;
        string cmdstring = "";
        public string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public string defaultEmptyValue = """
            UPDATE MoreDetails SET PersonalProjects = ''  WHERE PersonalProjects IS NULL;
            UPDATE MoreDetails SET Skill = '' WHERE Skill IS NULL;
            UPDATE MoreDetails SET Languages = '' WHERE Languages IS NULL;
            UPDATE MoreDetails SET Interests = '' WHERE Interests IS NULL;
            UPDATE MoreDetails SET Certifications = '' WHERE Certifications IS NULL;
            UPDATE Person SET Website = '' WHERE Website IS NULL;
            UPDATE Person SET SocialMedia = '' WHERE SocialMedia IS NULL;
            UPDATE Person SET Address = '' WHERE Address IS NULL;
            UPDATE Person SET PhoneNumber = '' WHERE PhoneNumber IS NULL;
            UPDATE Person SET Website = '' WHERE Website IS NULL;
            UPDATE Person SET Email = '' WHERE Email IS NULL;
            UPDATE Job SET JobTitle = '' WHERE JobTitle IS NULL;
            UPDATE Job SET JobStart = '' WHERE JobStart IS NULL;
            UPDATE Job SET JobEnd = '' WHERE JobEnd IS NULL;
            UPDATE Job SET JobDetail = '' WHERE JobDetail IS NULL;
            UPDATE Education SET EducationTitle = '' WHERE EducationTitle IS NULL;
            UPDATE Education SET EducationStart = '' WHERE EducationStart IS NULL;
            UPDATE Education SET EducationTitle = '' WHERE EducationTitle IS NULL;
            UPDATE Education SET EducationTitle = '' WHERE EducationTitle IS NULL;
            """;
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
        public DataSet GetPersonTable()
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
        public DataSet GetPersonalTables()
        {
            DataSet dataSet = new DataSet();
            FormLogin formLogin = new FormLogin();
            if (formLogin.getDescription() != "")
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from Person where description = '{formLogin.getDescription()}'; select * from Job where id = '{GetIdFromDescription().ToString().Trim()}'; select * from Education where id = '{GetIdFromDescription().ToString().Trim()}'; select * from MoreDetails where id = '{GetIdFromDescription().ToString().Trim()}'", connectionString);
                dataAdapter.Fill(dataSet);
            }
            else
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"select * from Person where description = '{personalDetailsForm.getID().ToString().Trim()}'; select * from Job where id = '{personalDetailsForm.getID().ToString().Trim()}'; select * from Education where id = '{personalDetailsForm.getID().ToString().Trim()}'; select * from MoreDetails where id = '{personalDetailsForm.getID().ToString().Trim()}'", connectionString);
                dataAdapter.Fill(dataSet);
            }
            return dataSet;
        }

        public (string, string, string, string, string, string, string, string, string) fillPdfFields()
        {
            SqlExecuter(defaultEmptyValue);
            name = GetPersonalTables().Tables[0].Rows[0].Field<string>("Name").Trim();
            personDetails = GetPersonalTables().Tables[0].Rows[0].Field<string>("Address").Trim() + "\n" + GetPersonalTables().Tables[0].Rows[0].Field<string>("PhoneNumber").Trim() + "\n" + GetPersonalTables().Tables[0].Rows[0].Field<string>("Email").Trim() + "\n" + GetPersonalTables().Tables[0].Rows[0].Field<string>("Website").Trim() + "\n" + GetPersonalTables().Tables[0].Rows[0].Field<string>("SocialMedia").Trim() + "\n" + GetPersonalTables().Tables[0].Rows[0].Field<string>("Summary").Trim();
            jobs = "";
            int i = 0;
            while (i < GetPersonalTables().Tables[1].Rows.Count)
            {

                jobs = jobs + GetPersonalTables().Tables[1].Rows[i].Field<string>("JobTitle").Trim();
                jobs = jobs + " (" + GetPersonalTables().Tables[1].Rows[i].Field<string>("JobStart").Trim() + "-" + GetPersonalTables().Tables[1].Rows[i].Field<string>("JobEnd").Trim() + ")";
                jobs = jobs + "\n" + GetPersonalTables().Tables[1].Rows[i].Field<string>("JobDetail").Trim() + "\n";
                i++;
            }
            educations = "";
            i = 0;
            while (i < GetPersonalTables().Tables[2].Rows.Count)
            {
                educations = educations + GetPersonalTables().Tables[2].Rows[i].Field<string>("EducationTitle").Trim();
                educations = educations + " (" + GetPersonalTables().Tables[2].Rows[i].Field<string>("EducationStart").Trim() + "-" + GetPersonalTables().Tables[2].Rows[i].Field<string>("EducationEnd").Trim() + ")";
                educations = educations + "\n" + GetPersonalTables().Tables[2].Rows[i].Field<string>("EducationDetail").Trim() + "\n";
                i++;
            }
            i = 0;
            certifications = "";
            while (i < GetPersonalTables().Tables[3].Rows.Count)
            {
                if (GetPersonalTables().Tables[3].Rows[i]["Certifications"] is not null)
                {
                    certifications = certifications + GetPersonalTables().Tables[3].Rows[i].Field<string>("Certifications").Trim() + ", ";
                    i++;
                }

            }
            i = 0;
            personalProjects = "";
            while (i < GetPersonalTables().Tables[3].Rows.Count)
            {
                personalProjects = personalProjects + GetPersonalTables().Tables[3].Rows[i].Field<string>("PersonalProjects").Trim() + "\n";
                i++;
            }
            i = 0;
            languages = "";
            while (i < GetPersonalTables().Tables[3].Rows.Count)
            {
                languages = languages + GetPersonalTables().Tables[3].Rows[i].Field<string>("Languages").Trim() + ",";
                i++;
            }
            i = 0;
            interests = "";
            while (i < GetPersonalTables().Tables[3].Rows.Count)
            {
                interests = interests + GetPersonalTables().Tables[3].Rows[i].Field<string>("Interests").Trim() + ", ";
                i++;
            }
            i = 0;
            skills = "";
            while (i < GetPersonalTables().Tables[3].Rows.Count)
            {
                skills = skills + GetPersonalTables().Tables[3].Rows[i].Field<string>("Skill").Trim() + ", ";
                i++;
            }
            i = 0;

            return (name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills);
        }

        public int GetIdFromDescription()
        {
            try
            {
                FormLogin formLogin = new FormLogin();
                formLogin.getDescription();
                cnn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand($"select id from Person where description = '{formLogin.getDescription().Trim()}'", cnn);
                cnn.Open();
                id2 = (int)cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill Person Details First!");
            }
            return id2;
        }
        public int GetIdFromDescriptionForRemovePerson(string description)
        {
            try
            {
                FormLogin formLogin = new FormLogin();
                formLogin.getDescription();
                cnn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand($"select id from Person where description = '{description}'", cnn);
                cnn.Open();
                id2 = (int)cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill Person Details First!");
            }
            return id2;
        }
    }
}