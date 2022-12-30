using Microsoft.Win32;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class Form1 : Form
    {
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeDb;Integrated Security=True";
        public string cmdstring = "";
        string json = "";
        string name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills = "";
        SqlConnection cnn;
        SqlDataReader reader1;
        DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
            restroreSession();
        }

        //*****CONTROLLERS*****
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
        private void restroreSession()
        {
            try
            {
                getDataFromDB();
                if (ds.Tables[0].Rows[0].ToString().Trim() != "")
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to restore previous last session?", "Saved Previous Session", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        fillCombobox();
                        nameTbox.Text = ds.Tables[0].Rows[0].Field<string>("Name").Trim();
                        SurnameTbox.Text = ds.Tables[0].Rows[0].Field<string>("Surname").Trim();
                        AddressTbox.Text = ds.Tables[0].Rows[0].Field<string>("Address").Trim();
                        phoneNuTbox.Text = ds.Tables[0].Rows[0].Field<string>("PhoneNumber").Trim();
                        emailTbox.Text = ds.Tables[0].Rows[0].Field<string>("Email").Trim();
                        websiteTbox.Text = ds.Tables[0].Rows[0].Field<string>("Website").Trim();
                        sMediaTbox.Text = ds.Tables[0].Rows[0].Field<string>("SocialMedia").Trim();
                        summaryTbox.Text = ds.Tables[0].Rows[0].Field<string>("Summary").Trim();
                        MessageBox.Show("Restored last session!");
                    }
                    else if (dialogResult == DialogResult.No)
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
            catch (System.IndexOutOfRangeException ex)
            {
                //MessageBox.Show("dataset is null " + ex.Message);
                //throw;
            }
        }
        //*****SQL CONTROLLERS*****
        private void insertDataSql(string cmdstring)
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
                    fillCombobox();
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
            ds.Clear();
            json = "";
            cmdstring = "SELECT * FROM Person;SELECT * FROM Job;SELECT * FROM Education;SELECT * FROM Certifications;SELECT * FROM PersonalProjects;SELECT * FROM Languages;SELECT * FROM Interests;SELECT * FROM Skills";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdstring, connetionString);
            dataAdapter.Fill(ds);
            json = JsonConvert.SerializeObject(ds, Formatting.Indented);
        }
        private void fillCombobox()
        {
            jobsCombobox.Items.Clear();
            eduCombobox.Items.Clear();
            skillsCombobox.Items.Clear();
            interestsCombobox.Items.Clear();
            prsnPrjctCombobox.Items.Clear();
            languagesCombobox.Items.Clear();
            certificationsCombobox.Items.Clear();
            string[] comboboxesStrings = { "select * from Job", "select * from Education", "select * from Skills", "select * from PersonalProjects", "select * from Languages", "select * from Certifications", "select * from Interests" };
            int index = 0;
            try
            {
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
                            jobsCombobox.Items.Add(reader1.GetString("JobTitle").Trim());
                        }
                        else if (index == 1)
                        {
                            eduCombobox.Items.Add(reader1.GetString("EducationTitle").Trim());
                        }
                        else if (index == 2)
                        {
                            skillsCombobox.Items.Add(reader1.GetString("Skill").Trim());
                        }
                        else if (index == 3)
                        {
                            prsnPrjctCombobox.Items.Add(reader1.GetString("PersonalProjectTitle").Trim());
                        }
                        else if (index == 4)
                        {
                            languagesCombobox.Items.Add(reader1.GetString("Language").Trim());
                        }
                        else if (index == 5)
                        {
                            certificationsCombobox.Items.Add(reader1.GetString("CertificationName").Trim());
                        }
                        else if (index == 6)
                        {
                            interestsCombobox.Items.Add(reader1.GetString("Interest").Trim());
                        }
                    }
                    index++;
                    cnn.Close();
                }
            }
            catch (System.InvalidOperationException e)
            {
                MessageBox.Show("An unexpected error." + e.Message);
                throw;
            }
        }
        private void printingDetailsFill()
        {
            name = ds.Tables[0].Rows[0].Field<string>("Name").Trim() + " " + ds.Tables[0].Rows[0].Field<string>("Surname").Trim();
            personDetails = ds.Tables[0].Rows[0].Field<string>("Address").Trim() + "\n" + ds.Tables[0].Rows[0].Field<string>("PhoneNumber").Trim() + "\n" + ds.Tables[0].Rows[0].Field<string>("Email").Trim() + "\n" + ds.Tables[0].Rows[0].Field<string>("Website").Trim() + "\n" + ds.Tables[0].Rows[0].Field<string>("SocialMedia").Trim() + "\n" + ds.Tables[0].Rows[0].Field<string>("Summary").Trim();
            jobs = "";
            int i = 0;
            while (i < ds.Tables[1].Rows.Count)
            {
                jobs = jobs + ds.Tables[1].Rows[i].Field<string>("JobTitle").Trim();
                jobs = jobs + "\n" + ds.Tables[1].Rows[i].Field<string>("JobStart").Trim() + "-" + ds.Tables[1].Rows[i].Field<string>("JobEnd").Trim();
                jobs = jobs + "\n" + ds.Tables[1].Rows[i].Field<string>("JobDetail").Trim() + "\n";
                i++;
            }
            educations = "";
            i = 0;
            while (i < ds.Tables[2].Rows.Count)
            {
                educations = educations + ds.Tables[2].Rows[i].Field<string>("EducationTitle").Trim();
                educations = educations + "\n" + ds.Tables[2].Rows[i].Field<string>("EducationStart").Trim() + "-" + ds.Tables[2].Rows[i].Field<string>("EducationEnd");
                educations = educations + "\n" + ds.Tables[2].Rows[i].Field<string>("EducationDetail").Trim() + "\n";
                i++;
            }
            i = 0;
            certifications = "";
            while (i < ds.Tables[3].Rows.Count)
            {
                certifications = certifications + ds.Tables[3].Rows[i].Field<string>("CertificationName").Trim() + ", ";
                i++;
            }
            i = 0;
            personalProjects = "";
            while (i < ds.Tables[4].Rows.Count)
            {
                personalProjects = personalProjects + ds.Tables[4].Rows[i].Field<string>("PersonalProjectTitle").Trim() + "\n" + ds.Tables[4].Rows[i].Field<string>("PersonalProjectDetail").Trim() + "\n";
                i++;
            }
            i = 0;
            languages = "";
            while (i < ds.Tables[5].Rows.Count)
            {
                languages = languages + ds.Tables[5].Rows[i].Field<string>("Language").Trim() + ",";
                i++;
            }
            i = 0;
            interests = "";
            while (i < ds.Tables[6].Rows.Count)
            {
                interests = interests + ds.Tables[6].Rows[i].Field<string>("Interest").Trim() + ", ";
                i++;
            }
            i = 0;
            skills = "";
            while (i < ds.Tables[7].Rows.Count)
            {
                skills = skills + ds.Tables[7].Rows[i].Field<string>("Skill").Trim() + ", ";
                i++;
            }
            i = 0;
        }

        //*****TEXT COUNTER EVENTS*****
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

        //*****DATA EVENTS*****
        private void showDataBtn_Click(object sender, EventArgs e)
        {
            getDataFromDB();
            try
            {
                if (ds.Tables[0].Rows[0].Field<string>("Name").Trim() != "")
                {
                    MessageBox.Show(json);
                }
            }
            catch (System.IndexOutOfRangeException ex)
            {
                MessageBox.Show($"Dataset is null.");
            }
        }
        private void savePersonDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            cmdstring = $"delete from Person";
            insertDataSql(cmdstring);
            cmdstring = $"insert into Person (Name, Surname, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('{nameTbox.Text}', '{SurnameTbox.Text}', '{AddressTbox.Text}', '{phoneNuTbox.Text}', '{emailTbox.Text}', '{summaryTbox.Text}', '{websiteTbox.Text}', '{sMediaTbox.Text}')";
            insertDataSql(cmdstring);
        }
        private void refreshDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            fillCombobox();
            MessageBox.Show("Refreshed!");
        }

        //*****ABOUT PAGE EVENTS*****
        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenURL("https://github.com/sametcn99");
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenURL("https://github.com/sametcn99");
        }

        //*****JSON EVENTS*****
        private void exportJsonBtn_Click(object sender, EventArgs e)
        {
            getDataFromDB();
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
                MessageBox.Show("Saved!\nYou can import this file when you need edit.");
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
                ds = JsonConvert.DeserializeObject<DataSet>(readText);
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connetionString);
                string[] tableNames = { "dbo.Person", "dbo.Job", "dbo.Education", "dbo.Certifications", "dbo.PersonalProjects", "dbo.Languages", "dbo.Interests", "dbo.Skills" };
                int i = 0;
                while (i < ds.Tables.Count)
                {
                    bulkCopy.DestinationTableName = tableNames[i];
                    bulkCopy.WriteToServer(ds.Tables[i]);
                    i++;
                }
                try
                {
                    fillCombobox();
                    nameTbox.Text = ds.Tables[0].Rows[0].Field<string>("Name").Trim();
                    SurnameTbox.Text = ds.Tables[0].Rows[0].Field<string>("Surname").Trim();
                    AddressTbox.Text = ds.Tables[0].Rows[0].Field<string>("Address").Trim();
                    phoneNuTbox.Text = ds.Tables[0].Rows[0].Field<string>("PhoneNumber").Trim();
                    emailTbox.Text = ds.Tables[0].Rows[0].Field<string>("Email").Trim();
                    websiteTbox.Text = ds.Tables[0].Rows[0].Field<string>("Website").Trim();
                    sMediaTbox.Text = ds.Tables[0].Rows[0].Field<string>("SocialMedia").Trim();
                    summaryTbox.Text = ds.Tables[0].Rows[0].Field<string>("Summary").Trim();
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    MessageBox.Show("something went wrong\n" + ex.Message);
                }
            }
        }

        //*****OTHER EVENTS*****
        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.OverwritePrompt = false;
                save.CreatePrompt = true;
                save.InitialDirectory = @"D:\";
                save.Title = "Save PDF File";
                save.DefaultExt = "pdf";
                save.Filter = "PDF Files (*.pdf)|*.pdf|All Files(*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Saved!");
                }
                printingDetailsFill();
                try
                {
                    Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));
                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);
                            x.Item().Text(name).FontSize(18).FontColor(Colors.Blue.Medium).Bold();
                            x.Item().Text(personDetails);
                            if (jobs != "")
                            {
                                x.Item().Text("JOB").Bold().FontSize(13);
                                x.Item().Text(jobs);
                            }
                            if (educations != "")
                            {
                                x.Item().Text("EDUCATION").Bold().FontSize(13);
                                x.Item().Text(educations);
                            }
                            if (certifications != "")
                            {
                                x.Item().Text("CERTIFICATIONS").Bold().FontSize(13);
                                x.Item().Text(certifications);
                            }
                            if (personalProjects != "")
                            {
                                x.Item().Text("PERSONAL PROJECTS").Bold().FontSize(13);
                                x.Item().Text(personalProjects);
                            }
                            if (languages != "")
                            {
                                x.Item().Text("LANGUAGES").Bold().FontSize(13);
                                x.Item().Text(languages);
                            }
                            if (interests != "")
                            {
                                x.Item().Text("INTERESTS").Bold().FontSize(13);
                                x.Item().Text(interests);
                            }
                            if (skills != "")
                            {
                                x.Item().Text("SKILLS").Bold().FontSize(13);
                                x.Item().Text(skills);
                            }
                        });
                });
            })
            .GeneratePdf(save.FileName);
                }
                catch (System.IO.IOException ex)
                {
                    MessageBox.Show(ex.Message + "Please close file and retry!");
                }
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show($"Canceled!\n{ex.Message}");
            }
            catch (System.IndexOutOfRangeException ex)
            {
                MessageBox.Show($"Canceled!\nDataset is null.\n{ex.Message}");
            }
        }
        private void phoneNuTbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void resumeBuilderTabControl_Selected(object sender, TabControlEventArgs e)
        {
            fillCombobox();
        }
    }
}