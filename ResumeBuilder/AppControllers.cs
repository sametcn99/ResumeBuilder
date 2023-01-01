using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder
{
    internal class AppControllers
    {
        public DataSet ds = new DataSet();
        public DataSet personalDataSet = new DataSet();
        SqlConnection cnn;
        SqlDataReader reader1;
        public string json, cmdstring = "";
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public int id { get; set; }
        public string description { get; set; }
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
        public string clearDatabase = "delete from Person; delete from Job; delete from Education; delete from MoreDetails";
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
                if (i != 0)
                {
                    MessageBox.Show("Saved data!");
                }
            }
            catch (System.IndexOutOfRangeException ex)
            {
                MessageBox.Show("something went wrong\n " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("an unexpected error occurred " + ex.Message);
                throw;
            }
        }
        public void removeDataSql(string cmdstring)
        {
            cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand(cmdstring, cnn);
            cnn.Open();
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
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
        public void getPersonalDataFromDb()
        {
            cmdstring = $"select Name, Address, PhoneNumber, Email, Website, SocialMedia, Summary from Person where id = '{id}';select JobTitle, JobDetail, JobStart, JobEnd from Job where id = '{id}';select EducationTitle, EducationDetail, EducationStart, EducationEnd from Education where id = '{id}';select Skill, Languages, Interests, Certifications, PersonalProjects from MoreDetails where id = '{id}';";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.Fill(personalDataSet);
        }
    }
}
