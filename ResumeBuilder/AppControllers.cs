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
        DataSet ds = new DataSet();
        SqlConnection cnn;
        SqlDataReader reader1;
        public string json, cmdstring = "";
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeDb;Integrated Security=True";
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
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM Certifications;SELECT * FROM PersonalProjects;SELECT * FROM Languages;SELECT * FROM Interests;SELECT * FROM Skills";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.Fill(ds);
            json = JsonConvert.SerializeObject(ds, Formatting.Indented);
        }
    }
}
