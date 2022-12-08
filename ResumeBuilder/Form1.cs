using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ResumeBuilder
{
    public partial class Form1 : Form
    {
        /*
        * Example sql command: string cmdstring = $"insert into TableName (Column1, Column2) values('Row1', {Row2Textbox.text})";
        * TO-DO:
        *   multiline textbox'lardaki karakter sınırlarını canlı göster
        *   hata mesajlarını göster
        *   hataları yakala
        *   veritabanı veri tiplerini düzenle
        *   başlama bitiş tarihleri sadece yıl olarak seçilecek
        *   fotoğraf yükleme özelliği ekle
        *   json olarak kaydetme çalışmazsa database'teki verileri datagride yazdırıp datagridden json olarak dışarı aktar
        *   program kapatıldığında veritabanını sıfırla (EN SON YAPILACAK)
        *   json dosyasından veri aktarma butonunu yap
        */
        string connetionString = "Data Source=samet\\SQLEXPRESS;Initial Catalog=ResumeDb;Integrated Security=True";
        SqlConnection cnn;
        SqlDataReader reader1;
        public Form1()
        {
            InitializeComponent();
            fillCombobox();
        }

        public void fillCombobox()
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
                cnn.Close();
                index++;
            }
        }

        public void insertDataSql(string cmdstring)
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

        private void savePersonDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            string cmdstring = $"insert into Person (Name, Surname, PhoneNumber, Address, Email, Summary, Website, SocialMedia) values('{nameTbox.Text}', '{SurnameTbox.Text}', '{AddressTbox.Text}', '{phoneNuTbox.Text}', '{emailTbox.Text}', '{summaryTbox.Text}', '{websiteTbox.Text}', '{sMediaTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void addJobBtn_MouseClick(object sender, MouseEventArgs e)
        {
            string cmdstring = $"insert into Job (JobTitle, JobDetail, JobStart, JobEnd) values('{jobttlTbox.Text}', '{jobDtlTbox.Text}', '{jobSDateTbox.Text}', '{jobEDateTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void addEduBtn_MouseClick(object sender, MouseEventArgs e)
        {
            string cmdstring = $"insert into Education (EducationTitle, EducationDetail, EducationStart, EducationEnd) values('{eduTtlTbox.Text}','{eduDtlTbox.Text}', '{eduSDateTbox.Text}', '{EduEDateTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void addSkillBtn_Click(object sender, EventArgs e)
        {
            string cmdstring = $"insert into Skills (Skill) values('{skillTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void languageBtn_Click(object sender, EventArgs e)
        {
            string cmdstring = $"insert into Languages (Language) values('{languageTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void addPrsnPrjctBtn_Click(object sender, EventArgs e)
        {
            string cmdstring = $"insert into PersonalProjects (PersonalProjectTitle, PersonalProjectDetail) values('{prsnPrcjtTtlTbox.Text}', '{prsnPrjctDtlTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void addInterestBtn_Click(object sender, EventArgs e)
        {
            string cmdstring = $"insert into Interests (Interest) values('{interestTbox.Text}')";
            insertDataSql(cmdstring);
        }

        private void exportJsonBtn_Click(object sender, EventArgs e)
        {
            string cmdstring = "select * from Person for json path";
            string jsondata = "";
            cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand(cmdstring, cnn);
            cnn.Open();

            reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                jsondata = reader1.GetString(0);
                MessageBox.Show(jsondata);
                SaveFileDialog save = new SaveFileDialog();
                save.OverwritePrompt = false;
                save.CreatePrompt = true;
                save.InitialDirectory = @"D:\";
                save.Title = "Save Json File";
                save.DefaultExt = "json";
                save.Filter = "text files (*.txt)|*.txt|Tüm Dosyalar(*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(save.FileName);
                    sw.WriteLine(jsondata);
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("no data found");
            }
            cnn.Close();
        }

        private void refreshDataBtn_MouseClick(object sender, MouseEventArgs e)
        {
            fillCombobox();
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


        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenURL("https://github.com/sametcn99");
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenURL("https://github.com/sametcn99");
        }

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
    }
}