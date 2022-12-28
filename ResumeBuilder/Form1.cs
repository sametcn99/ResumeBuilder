using Microsoft.Win32;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ResumeBuilder
{
    public partial class Form1 : Form
    {
        public string connetionString = "Data Source=samet\\SQLEXPRESS;Initial Catalog=ResumeDb;Integrated Security=True";
        public string cmdstring = "";
        string json = "";
        SqlConnection cnn;
        SqlDataReader reader1;
        DataSet dataSet = new DataSet();

        public Form1()
        {
            InitializeComponent();
            fillCombobox();
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
                catch (Exception)
                {
                    MessageBox.Show("an unexpected error occurred ");
                    throw;
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
        private void getDataFromDB()
        {
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM Certifications;SELECT * FROM PersonalProjects;SELECT * FROM Languages;SELECT * FROM Interests;SELECT * FROM Skills";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.Fill(dataSet);
            cnn.Close();
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

        //*****TEXT COUNTERS*****
        private void summaryTbox_TextChanged(object sender, EventArgs e)
        {
            summaryTextCounterLabel.Text = $"{summaryTbox.Text.Length}/500";
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

        //*****ADD BUTTON CLICK EVENTS*****
        private void addJobBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cmdstring = $"insert into Job (JobTitle, JobDetail, JobStart, JobEnd) values('{jobttlTbox.Text}', '{jobDtlTbox.Text}', '{jobSDateTbox.Text}', '{jobEDateTbox.Text}')";
            insertDataSql(cmdstring);
            jobttlTbox.Text = "";
            jobDtlTbox.Text = "";
            jobSDateTbox.Text = "";
            jobEDateTbox.Text = "";
        }
        private void addEduBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cmdstring = $"insert into Education (EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{eduTtlTbox.Text}','{eduDtlTbox.Text}', '{eduSDateTbox.Text}', '{EduEDateTbox.Text}')";
            insertDataSql(cmdstring);
            eduTtlTbox.Text = "";
            eduDtlTbox.Text = "";
            eduSDateTbox.Text = "";
            EduEDateTbox.Text = "";
        }
        private void addSkillBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Skills (Skill) values('{skillTbox.Text}')";
            insertDataSql(cmdstring);
            skillTbox.Text = "";
        }
        private void addlanguageBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Languages (Language) values('{languageTbox.Text}')";
            insertDataSql(cmdstring);
            languageTbox.Text = "";
        }
        private void addPrsnPrjctBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into PersonalProjects (PersonalProjectTitle, PersonalProjectDetail) values('{prsnPrcjtTtlTbox.Text}', '{prsnPrjctDtlTbox.Text}')";
            insertDataSql(cmdstring);
            prsnPrcjtTtlTbox.Text = "";
            prsnPrjctDtlTbox.Text = "";
        }
        private void addCertificationBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Certifications (CertificationName) values('{certificationTbox.Text}')";
            insertDataSql(cmdstring);
            certificationTbox.Text = "";
        }
        private void addInterestBtn_Click(object sender, EventArgs e)
        {
            cmdstring = $"insert into Interests (Interest) values('{interestTbox.Text}')";
            insertDataSql(cmdstring);
            interestTbox.Text = "";
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

        //*****OTHER EVENTS*****
        private void showDataBtn_Click(object sender, EventArgs e)
        {
            getDataFromDB();
            json = "";
            json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            MessageBox.Show(json);
        }
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
            getDataFromDB();
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
            cmdstring = $"delete from Person";
            insertDataSql(cmdstring);
            cmdstring = $"insert into Person (Name, Surname, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('{nameTbox.Text}', '{SurnameTbox.Text}', '{AddressTbox.Text}', '{phoneNuTbox.Text}', '{emailTbox.Text}', '{summaryTbox.Text}', '{websiteTbox.Text}', '{sMediaTbox.Text}')";
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
        private void importJsonBtn_Click(object sender, EventArgs e)
        {
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
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connetionString);
                string[] tableNames = { "dbo.Person", "dbo.Job", "dbo.Education", "dbo.Certifications", "dbo.PersonalProjects", "dbo.Languages", "dbo.Interests", "dbo.Skills" };
                int i = 0;
                while (i < dataSet.Tables.Count)
                {
                    bulkCopy.DestinationTableName = tableNames[i];
                    bulkCopy.WriteToServer(dataSet.Tables[i]);
                    i++;
                }
            }
            nameTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("Name");
            SurnameTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("Surname");
            AddressTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("Address");
            phoneNuTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("PhoneNumber");
            emailTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("Email");
            websiteTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("Website");
            sMediaTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("SocialMedia");
            summaryTbox.Text = dataSet.Tables[0].Rows[0].Field<string>("Summary");
            fillCombobox();
        }
        private void printBtn_Click(object sender, EventArgs e)
        {

        }
        private void refreshDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            fillCombobox();
        }
        private void phoneNuTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
    }
}