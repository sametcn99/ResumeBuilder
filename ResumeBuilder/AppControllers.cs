using Microsoft.Win32;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ResumeBuilder
{
    internal class AppControllers
    {
        public DataSet ds = new DataSet();
        public DataSet personalDataSet = new DataSet();
        SqlConnection cnn;
        public string id;
        public string json, cmdstring = "";
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public string clearDatabase = "delete from Person; delete from Job; delete from Education; delete from MoreDetails";
        public string path, name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills;
        public string defaultEmptyValue = "UPDATE MoreDetails\r\nSET PersonalProjects = ''\r\nWHERE PersonalProjects IS NULL;\r\nUPDATE MoreDetails\r\nSET Skill = ''\r\nWHERE Skill IS NULL;\r\nUPDATE MoreDetails\r\nSET Languages = ''\r\nWHERE Languages IS NULL;\r\nUPDATE MoreDetails\r\nSET Interests = ''\r\nWHERE Interests IS NULL;\r\nUPDATE MoreDetails\r\nSET Certifications = ''\r\nWHERE Certifications IS NULL;\r\nUPDATE Person\r\nSET Website = ''\r\nWHERE Website IS NULL;\r\nUPDATE Person\r\nSET SocialMedia = ''\r\nWHERE SocialMedia IS NULL;\r\nUPDATE Person\r\nSET Address = ''\r\nWHERE Address IS NULL;";

        public (string, string, string, string, string, string, string, string, string, string) fillPdfFields()
        {
            getPersonalDataFromDb();
            try
            {
                name = personalDataSet.Tables[0].Rows[0].Field<string>("Name").Trim();
                personDetails = personalDataSet.Tables[0].Rows[0].Field<string>("Address").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("PhoneNumber").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("Email").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("Website").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("SocialMedia").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("Summary").Trim();
                jobs = "";
                int i = 0;
                while (i < personalDataSet.Tables[1].Rows.Count)
                {
                    jobs = jobs + personalDataSet.Tables[1].Rows[i].Field<string>("JobTitle").Trim();
                    jobs = jobs + "\n" + personalDataSet.Tables[1].Rows[i].Field<string>("JobStart").Trim() + "-" + personalDataSet.Tables[1].Rows[i].Field<string>("JobEnd").Trim();
                    jobs = jobs + "\n" + personalDataSet.Tables[1].Rows[i].Field<string>("JobDetail").Trim() + "\n";
                    i++;
                }
                educations = "";
                i = 0;
                while (i < personalDataSet.Tables[2].Rows.Count)
                {
                    educations = educations + personalDataSet.Tables[2].Rows[i].Field<string>("EducationTitle").Trim();
                    educations = educations + "\n" + personalDataSet.Tables[2].Rows[i].Field<string>("EducationStart").Trim() + "-" + personalDataSet.Tables[2].Rows[i].Field<string>("EducationEnd");
                    educations = educations + "\n" + personalDataSet.Tables[2].Rows[i].Field<string>("EducationDetail").Trim() + "\n";
                    i++;
                }
                i = 0;
                certifications = "";
                while (i < personalDataSet.Tables[3].Rows.Count)
                {
                    certifications = certifications + personalDataSet.Tables[3].Rows[i].Field<string>("Certifications").Trim() + ", ";

                    i++;
                }
                i = 0;
                personalProjects = "";
                while (i < personalDataSet.Tables[3].Rows.Count)
                {
                    personalProjects = personalProjects + personalDataSet.Tables[3].Rows[i].Field<string>("PersonalProjects").Trim() + "\n";
                    i++;
                }
                i = 0;
                languages = "";
                while (i < personalDataSet.Tables[3].Rows.Count)
                {
                    languages = languages + personalDataSet.Tables[3].Rows[i].Field<string>("Languages").Trim() + ",";
                    i++;
                }
                i = 0;
                interests = "";
                while (i < personalDataSet.Tables[3].Rows.Count)
                {
                    interests = interests + personalDataSet.Tables[3].Rows[i].Field<string>("Interests").Trim() + ", ";
                    i++;
                }
                i = 0;
                skills = "";
                while (i < personalDataSet.Tables[3].Rows.Count)
                {
                    skills = skills + personalDataSet.Tables[3].Rows[i].Field<string>("Skill").Trim() + ", ";
                    i++;
                }
                i = 0;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.IndexOutOfRangeException ex)
            {
                MessageBox.Show("data is empty." + ex.Message);
            }
            return (path, name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills);
        }

        //*****SQL CONTROLLERS*****
        public void insertDataSql(string cmdstring)
        {
            try
            {
                cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand(cmdstring, cnn);
                cnn.Open();
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                setNullValuestoDefaultEmptyValue();
                if (i != 0) { MessageBox.Show("OK!"); }
            }
            catch (System.IndexOutOfRangeException ex) { MessageBox.Show("something went wrong\n " + ex.Message); }
            catch (Exception ex) { MessageBox.Show("an unexpected error occurred " + ex.Message); throw; }
        }

        public void setNullValuestoDefaultEmptyValue()
        {
            try
            {
                cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand(defaultEmptyValue, cnn);
                cnn.Open();
                int i = cmd.ExecuteNonQuery();
                cnn.Close();
                if (i != 0) { MessageBox.Show("OK!"); }
            }
            catch (System.IndexOutOfRangeException ex) { MessageBox.Show("something went wrong\n " + ex.Message); }
            catch (Exception ex) { MessageBox.Show("an unexpected error occurred " + ex.Message); throw; }
        }
        public void getDataFromDB()
        {
            ds.Clear();
            json = "";
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM MoreDetails";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.Fill(ds);
            json = JsonConvert.SerializeObject(ds, Formatting.Indented);
        }
        public string exportJsonData()
        {
            ds.Clear();
            json = "";
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM MoreDetails";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.Fill(ds);
            json = JsonConvert.SerializeObject(ds, Formatting.Indented);
            return json;
        }
        public void getPersonalDataFromDb()
        {
            FormLogin formLogin = new FormLogin();
            id = formLogin.getId().ToString();
            if (id != "")
            {
                cmdstring = $"select Name, Address, PhoneNumber, Email, Website, SocialMedia, Summary from Person where id = '{id}';select JobTitle, JobDetail, JobStart, JobEnd from Job where id = '{id}';select EducationTitle, EducationDetail, EducationStart, EducationEnd from Education where id = '{id}';select Skill, Languages, Interests, Certifications, PersonalProjects from MoreDetails where id = '{id}';";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
                dataAdapter.Fill(personalDataSet);
            }
        }
        public void OpenURL(string url)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            // Get the default browser path on the system
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];
            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = url;
            p.Start();
        }
    }
}
