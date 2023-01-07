using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ResumeBuilder
{
    internal class SqlControllers
    {
#pragma warning disable CS8618 // Non-nullable field 'cnn' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        SqlConnection cnn;
#pragma warning restore CS8618 // Non-nullable field 'cnn' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'reader1' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        SqlDataReader reader1;
#pragma warning restore CS8618 // Non-nullable field 'reader1' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'skills' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'personalProjects' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'certifications' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'educations' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'interests' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'summary' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'personDetails' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'jobs' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'name' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS8618 // Non-nullable field 'languages' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        public static string name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills, summary;
#pragma warning restore CS8618 // Non-nullable field 'languages' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'name' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'jobs' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'personDetails' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'summary' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'interests' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'educations' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'certifications' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'personalProjects' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning restore CS8618 // Non-nullable field 'skills' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
#pragma warning disable CS0649 // Field 'SqlControllers.id' is never assigned to, and will always have its default value 0
        public static int id;
#pragma warning restore CS0649 // Field 'SqlControllers.id' is never assigned to, and will always have its default value 0
        public int id2 = 0;
        string cmdstring = "";
#pragma warning disable CS8618 // Non-nullable field 'imagePath' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.
        string imagePath;
#pragma warning restore CS8618 // Non-nullable field 'imagePath' must contain a non-null value when exiting constructor. Consider declaring the field as nullable.

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
        public string defaultNullValue = """
            UPDATE MoreDetails SET PersonalProjects = null  WHERE PersonalProjects = 'empty';
            UPDATE MoreDetails SET Skill = null WHERE Skill = 'empty';
            UPDATE MoreDetails SET Languages = null WHERE Languages = 'empty';
            UPDATE MoreDetails SET Interests = null WHERE Interests = 'empty';
            UPDATE MoreDetails SET Certifications = null WHERE Certifications = 'empty';
            UPDATE Person SET Website = null WHERE Website = '';
            UPDATE Person SET SocialMedia = null WHERE SocialMedia = '';
            UPDATE Person SET Address = null WHERE Address = '';
            UPDATE Person SET PhoneNumber = null WHERE PhoneNumber = '';
            UPDATE Person SET Website = null WHERE Website = '';
            UPDATE Person SET Email = null WHERE Email = '';
            UPDATE Job SET JobTitle = null WHERE JobTitle = '';
            UPDATE Job SET JobStart = null WHERE JobStart = '';
            UPDATE Job SET JobEnd = null WHERE JobEnd = '';
            UPDATE Job SET JobDetail = null WHERE JobDetail = '';
            UPDATE Education SET EducationTitle = null WHERE EducationTitle = '';
            UPDATE Education SET EducationStart = null WHERE EducationStart = '';
            UPDATE Education SET EducationTitle = null WHERE EducationTitle = '';
            UPDATE Education SET EducationTitle = null WHERE EducationTitle = '';
            """;
        public int getRandomID()
        {
            return id;
        }

        public string getPicture()
        {
            FormLogin formLogin = new FormLogin();
            PhotoUploadForm photoUploadFormform = new PhotoUploadForm();
            cnn = new SqlConnection(connectionString);
            if (formLogin.getDescription() != "")
            {
                SqlCommand cmd = new SqlCommand($"select image from Image where id = '{GetIdFromDescription().ToString().Trim()}'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cnn.Open();
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    imagePath = reader1[0].ToString();
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                cnn.Close();
            }
            else
            {
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                SqlCommand cmd = new SqlCommand($"select image from Image where id = '{personalDetailsForm.getID().ToString().Trim()}'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cnn.Open();
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
#pragma warning disable CS8601 // Possible null reference assignment.
                    imagePath = reader1[0].ToString();
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                cnn.Close();
            }
#pragma warning disable CS8603 // Possible null reference return.
            return imagePath;
#pragma warning restore CS8603 // Possible null reference return.
        }

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
                    string descp = "";
                    PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                    cnn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand($"select description from Person where id = '{personalDetailsForm.getID().ToString().Trim()}'", cnn);
                    cnn.Open();
                    reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        descp = (reader1.GetString("description").ToString().Trim());
                    }
                    cnn.Close();
                    formLogin.setDescription(descp);
                    cnn = new SqlConnection(connectionString);
                    cmd = new SqlCommand(addCmd, cnn);
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
            catch (System.Data.SqlClient.SqlException) { }
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
            SqlExecuter("delete from Person; delete from Job; delete from Education; delete from MoreDetails; delete from Image");
        }
        public string GetDatabaseAsJsonText()
        {
            DataSet dataSet = new DataSet();
            var json = "";
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM MoreDetails; select * from Image";
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
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                dataSet = JsonConvert.DeserializeObject<DataSet>(readText);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString);
                string[] tableNames = { "dbo.Person", "dbo.Job", "dbo.Education", "dbo.MoreDetails", "dbo.Image" };
                int i = 0;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                while (i < dataSet.Tables.Count)
                {
                    bulkCopy.DestinationTableName = tableNames[i];
                    bulkCopy.WriteToServer(dataSet.Tables[i]);
                    i++;
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
        public (string, string, string, string, string, string, string, string, string, string) fillPdfFields()
        {
            DataSet dataSet = GetPersonalTables();
            SqlExecuter(defaultEmptyValue);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            name = dataSet.Tables[0].Rows[0].Field<string>("Name").ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            personDetails = dataSet.Tables[0].Rows[0].Field<string>("Address").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("PhoneNumber").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("Email").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("Website").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("SocialMedia").ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            summary = dataSet.Tables[0].Rows[0].Field<string>("Summary").ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            jobs = "";
            int i = 0;
            while (i < dataSet.Tables[1].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                jobs = jobs + dataSet.Tables[1].Rows[i].Field<string>("JobTitle").ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                jobs = jobs + " (" + dataSet.Tables[1].Rows[i].Field<string>("JobStart").ToString().Trim() + "-" + dataSet.Tables[1].Rows[i].Field<string>("JobEnd").ToString().Trim() + ")";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                jobs = jobs + "\n" + dataSet.Tables[1].Rows[i].Field<string>("JobDetail").ToString().Trim() + "\n";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            educations = "";
            i = 0;
            while (i < dataSet.Tables[2].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                educations = educations + dataSet.Tables[2].Rows[i].Field<string>("EducationTitle").ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                educations = educations + " (" + dataSet.Tables[2].Rows[i].Field<string>("EducationStart").ToString().Trim() + "-" + dataSet.Tables[2].Rows[i].Field<string>("EducationEnd").ToString().Trim() + ")";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                educations = educations + "\n" + dataSet.Tables[2].Rows[i].Field<string>("EducationDetail").ToString().Trim() + "\n";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            i = 0;
            certifications = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Certifications").ToString().Trim()) == false)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    certifications = certifications + dataSet.Tables[3].Rows[i].Field<string>("Certifications").ToString().Trim() + " ";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            i = 0;
            personalProjects = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("PersonalProjects").ToString().Trim()) == false)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    personalProjects = personalProjects + dataSet.Tables[3].Rows[i].Field<string>("PersonalProjects").ToString().Trim() + " ";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            i = 0;
            languages = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Languages").ToString().Trim()) == false)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    languages = languages + dataSet.Tables[3].Rows[i].Field<string>("Languages").ToString().Trim() + " ";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            i = 0;
            interests = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Interests").ToString().Trim()) == false)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    interests = interests + dataSet.Tables[3].Rows[i].Field<string>("Interests").ToString().Trim() + " ";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            i = 0;
            skills = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Skill").ToString().Trim()) == false)
                {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    skills = skills + dataSet.Tables[3].Rows[i].Field<string>("Skill").ToString().Trim() + " ";
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                i++;
            }
            i = 0;
            SqlExecuter(defaultNullValue);
            return (name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills, summary);
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
                //MessageBox.Show("Please fill Person Details First!");
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