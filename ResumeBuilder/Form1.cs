﻿using Microsoft.Win32;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ResumeBuilder
{
    public partial class Form1 : Form
    {
        /*NOTEPAD
        * Example sql command: string cmdstring = $"insert into TableName (Column1, Column2) values('Row1', {Row2Textbox.text})";
        * TO-DO:
        *   hata mesajlarını göster
        *   hataları yakala
        *   veritabanı veri tiplerini düzenle
        *   fotoğraf yükleme özelliği ekle
        *   json dosyasından veri aktarma butonunu yap   
        */
        string connetionString = "Data Source=samet\\SQLEXPRESS;Initial Catalog=ResumeDb;Integrated Security=True";
        string cmdstring = "";
        string json = "";
        SqlConnection cnn;
        SqlDataReader reader1;
        DataSet dataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            fillCombobox();
        }

        private void fillCombobox()
        {
            jobsCombobox.Items.Clear();
            eduCombobox.Items.Clear();
            skillsCombobox.Items.Clear();
            interestsCombobox.Items.Clear();
            prsnPrjctCombobox.Items.Clear();
            languagesCombobox.Items.Clear();
            skillsCombobox.Items.Clear();
            string[] comboboxesStrings = { "select * from Job", "select * from Education", "select * from Skills", "select * from PersonalProjects", "select * from Languages", "select * from Certifications", "select * from Interests" };
            int index = 0;
            while (index < comboboxesStrings.Length)
            {
                cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand(comboboxesStrings[index], cnn);
                cnn.Open();
                reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    if (index == 0)
                    {
                        jobsCombobox.Items.Add(reader1.GetString("JobTitle"));
                    }
                    else if (index == 1)
                    {
                        eduCombobox.Items.Add(reader1.GetString("EducationTitle"));
                    }
                    else if (index == 2)
                    {
                        skillsCombobox.Items.Add(reader1.GetString("Skill"));
                    }
                    else if (index == 3)
                    {
                        prsnPrjctCombobox.Items.Add(reader1.GetString("PersonalProjectTitle"));
                    }
                    else if (index == 4)
                    {
                        languagesCombobox.Items.Add(reader1.GetString("Language"));
                    }
                    else if (index == 5)
                    {
                        certificationsCombobox.Items.Add(reader1.GetString("CertificationName"));
                    }
                    else if (index == 6)
                    {
                        interestsCombobox.Items.Add(reader1.GetString("Interest"));
                    }
                }
                index++;
            }
        }
        private void OpenURL(string url)
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

        //*****SQL FUNCTIONS*****
        private void insertDataSql(string cmdstring)
        {
            if (nameTbox.Text == "" && SurnameTbox.Text == "")
            {
                MessageBox.Show("Please enter your Name and Surname first!");
            }
            else
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
        }
        private void removeDataSql(string cmdstring)
        {
            cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand(cmdstring, cnn);
            cnn.Open();
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //*****TEXT COUNTERS*****
        private void summaryTbox_TextChanged(object sender, EventArgs e)
        {
            summaryTextCounterLabel.Text = $"{summaryTbox.Text.Length}/200";
        }
        private void jobDtlTbox_TextChanged(object sender, EventArgs e)
        {
            jobDetailTextCounterLabel.Text = $"{jobDtlTbox.Text.Length}/200";
        }
        private void eduDtlTbox_TextChanged(object sender, EventArgs e)
        {
            educationTextCounterLabel.Text = $"{eduDtlTbox.Text.Length}/200";
        }
        private void prsnPrjctDtlTbox_TextChanged(object sender, EventArgs e)
        {
            personalProjectTextCounterLabel.Text = $"{prsnPrjctDtlTbox.Text.Length}/200";
        }

        //*****BUTTON CLICK EVENTS*****
        //*****ADD BUTTON CLICK EVENTS*****
        private void addJobBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cmdstring = $"insert into Job (JobTitle, JobDetail, JobStart, JobEnd) values('{jobttlTbox.Text}', '{jobDtlTbox.Text}', '{jobSDateTbox.Text}', '{jobEDateTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void addEduBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cmdstring = $"insert into Education (EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{eduTtlTbox.Text}','{eduDtlTbox.Text}', '{eduSDateTbox.Text}', '{EduEDateTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void addSkillBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Skills (Skill) values('{skillTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void addlanguageBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Languages (Language) values('{languageTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void addPrsnPrjctBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into PersonalProjects (PersonalProjectTitle, PersonalProjectDetail) values('{prsnPrcjtTtlTbox.Text}', '{prsnPrjctDtlTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void addCertificationBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Certifications (CertificationName) values('{certificationTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void addInterestBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Interests (Interest) values('{interestTbox.Text}')";
            insertDataSql(cmdstring);
        }
        //*****REMOVE BUTTON EVENTS*****
        private void jobsRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM Job WHERE JobTitle='{jobsCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void educationRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM Education WHERE EducationTitle='{eduCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void skillsRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM Skills WHERE Skill='{skillsCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void languageRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM Languages WHERE Language='{languagesCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void personelProjectRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM PersonalProjects WHERE PersonalProjectTitle='{prsnPrjctCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void interestRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM Interests WHERE Interest='{interestsCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void certificationRemoveBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"DELETE FROM Certifications WHERE CertificationName='{certificationsCombobox.Text}'";
            removeDataSql(cmdstring);
            MessageBox.Show("Data Removed!");
            fillCombobox();
        }
        private void refreshDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            fillCombobox();
        }
        //*****OTHER EVENTS*****
        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenURL("https://github.com/sametcn99");
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenURL("https://github.com/sametcn99");
        }
        private void exportJsonBtn_Click(object sender, EventArgs e)
        {
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM Certifications;SELECT * FROM PersonalProjects;SELECT * FROM Languages;SELECT * FROM Interests;SELECT * FROM Skills";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.TableMappings.Add("PersonTable", "Person");
            dataAdapter.TableMappings.Add("JobTable", "Job");
            dataAdapter.TableMappings.Add("CertificationTable", "Certification");
            dataAdapter.TableMappings.Add("PersonalProjectTable", "PersonalProject");
            dataAdapter.TableMappings.Add("LanguagesTable", "Language");
            dataAdapter.TableMappings.Add("InterestsTable", "Interests");
            dataAdapter.TableMappings.Add("SkillsTable", "Skills");
            dataAdapter.Fill(dataSet);
            cnn.Close();
            json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
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
                sw.WriteLine(json);
                sw.Close();
            }
        }
        private void savePersonDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cmdstring = $"insert into Person (Name, Surname, PhoneNumber, Address, Email, Summary, Website, SocialMedia) values('{nameTbox.Text}', '{SurnameTbox.Text}', '{AddressTbox.Text}', '{phoneNuTbox.Text}', '{emailTbox.Text}', '{summaryTbox.Text}', '{websiteTbox.Text}', '{sMediaTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] clearAllDataSql = { "delete from Certifications", "delete from Education", "delete from Interests", "delete from Job", "delete from Languages", "delete from Person", "delete from PersonalProjects", "delete from Skills" };
            int i = 0;
            while (i < clearAllDataSql.Length)
            {
                removeDataSql(clearAllDataSql[i]);
                i++;
            }
        }
    }
}