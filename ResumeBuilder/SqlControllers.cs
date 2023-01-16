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
        public static string name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills, summary;
        public static int id;
        public int id2 = 0;
        string cmdstring = "";
        string imagePath;

        public string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={Application.StartupPath}ResumeBuilderLocalDb.mdf;Integrated Security=True";
        //public string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\samet\source\repos\ResumeBuilder\ResumeBuilder\ResumeBuilderLocalDb.mdf;Integrated Security=True";
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
        public string CreateDatabaseScript = """
                        USE [master]
            GO
            /****** Object:  Database [ResumeBuilderDb]    Script Date: 1/9/2023 5:42:14 PM ******/
            CREATE DATABASE [ResumeBuilderDb]
             CONTAINMENT = NONE
             ON  PRIMARY 
            ( NAME = N'ResumeBuilderDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ResumeBuilderDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
             LOG ON 
            ( NAME = N'ResumeBuilderDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\ResumeBuilderDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
             WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
            GO
            ALTER DATABASE [ResumeBuilderDb] SET COMPATIBILITY_LEVEL = 160
            GO
            IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
            begin
            EXEC [ResumeBuilderDb].[dbo].[sp_fulltext_database] @action = 'enable'
            end
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ANSI_NULL_DEFAULT OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ANSI_NULLS OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ANSI_PADDING OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ANSI_WARNINGS OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ARITHABORT OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET AUTO_CLOSE OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET AUTO_SHRINK OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET AUTO_UPDATE_STATISTICS ON 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET CURSOR_DEFAULT  GLOBAL 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET CONCAT_NULL_YIELDS_NULL OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET NUMERIC_ROUNDABORT OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET QUOTED_IDENTIFIER OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET RECURSIVE_TRIGGERS OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET  DISABLE_BROKER 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET TRUSTWORTHY OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET PARAMETERIZATION SIMPLE 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET READ_COMMITTED_SNAPSHOT OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET HONOR_BROKER_PRIORITY OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET RECOVERY SIMPLE 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET  MULTI_USER 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET PAGE_VERIFY CHECKSUM  
            GO
            ALTER DATABASE [ResumeBuilderDb] SET DB_CHAINING OFF 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET DELAYED_DURABILITY = DISABLED 
            GO
            ALTER DATABASE [ResumeBuilderDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
            GO
            ALTER DATABASE [ResumeBuilderDb] SET QUERY_STORE = ON
            GO
            ALTER DATABASE [ResumeBuilderDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
            GO
            USE [ResumeBuilderDb]
            GO
            /****** Object:  Table [dbo].[Education]    Script Date: 1/9/2023 5:42:15 PM ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[Education](
            	[id] [int] NOT NULL,
            	[EducationTitle] [nchar](100) NOT NULL,
            	[EducationDetail] [nchar](200) NULL,
            	[EducationStart] [nchar](10) NULL,
            	[EducationEnd] [nchar](10) NULL
            ) ON [PRIMARY]
            GO
            /****** Object:  Table [dbo].[Image]    Script Date: 1/9/2023 5:42:15 PM ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[Image](
            	[id] [int] NOT NULL,
            	[image] [ntext] NULL,
             CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
            (
            	[id] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
            GO
            /****** Object:  Table [dbo].[Job]    Script Date: 1/9/2023 5:42:15 PM ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[Job](
            	[id] [int] NOT NULL,
            	[JobTitle] [nchar](100) NOT NULL,
            	[JobDetail] [nchar](200) NULL,
            	[JobStart] [nchar](10) NOT NULL,
            	[JobEnd] [nchar](10) NOT NULL
            ) ON [PRIMARY]
            GO
            /****** Object:  Table [dbo].[MoreDetails]    Script Date: 1/9/2023 5:42:15 PM ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[MoreDetails](
            	[id] [int] NOT NULL,
            	[Skill] [nchar](10) NULL,
            	[Languages] [nchar](10) NULL,
            	[Interests] [nchar](10) NULL,
            	[Certifications] [nchar](10) NULL,
            	[PersonalProjects] [nchar](50) NULL
            ) ON [PRIMARY]
            GO
            /****** Object:  Table [dbo].[Person]    Script Date: 1/9/2023 5:42:15 PM ******/
            SET ANSI_NULLS ON
            GO
            SET QUOTED_IDENTIFIER ON
            GO
            CREATE TABLE [dbo].[Person](
            	[id] [int] NOT NULL,
            	[Name] [nchar](50) NOT NULL,
            	[Address] [nchar](200) NULL,
            	[PhoneNumber] [nchar](12) NULL,
            	[Email] [nchar](50) NULL,
            	[Website] [nchar](50) NULL,
            	[SocialMedia] [nchar](500) NULL,
            	[Summary] [nchar](500) NULL,
            	[description] [nvarchar](50) NOT NULL,
             CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
            (
            	[id] ASC
            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
            ) ON [PRIMARY]
            GO
            USE [master]
            GO
            ALTER DATABASE [ResumeBuilderDb] SET  READ_WRITE 
            GO
            

            """;

        public string getConnectionString()
        {
            return connectionString;
        }

        public bool CheckDatabaseExists()
        {
            //MessageBox.Show(connectionString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    connection.Close();
                    MessageBox.Show("database is not exist. please import database and restart the app.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Application.Exit();
                    return false;
                }
            }
        }
        //public bool CheckDatabaseExists2()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString2))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            connection.Close();
        //            connectionString = connectionString2;
        //            return true;
        //        }
        //        catch (SqlException ex)
        //        {
        //            connection.Close();
        //            MessageBox.Show("Database is not exist. please import database and restart the app.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //Application.Exit();
        //            return false;
        //        }
        //    }


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
                    imagePath = reader1[0].ToString();
                }
                cnn.Close();
            }
            else
            {
                MessageBox.Show("photo not found!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
                SqlCommand cmd = new SqlCommand($"select image from Image where id = '{personalDetailsForm.getID().ToString().Trim()}'", cnn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cnn.Open();
                reader1 = cmd.ExecuteReader();
                if (reader1.Read())
                {
                    imagePath = reader1[0].ToString();
                }
                cnn.Close();
            }
            return imagePath;
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
                dataSet = JsonConvert.DeserializeObject<DataSet>(readText);
                SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString);
                string[] tableNames = { "dbo.Person", "dbo.Job", "dbo.Education", "dbo.MoreDetails", "dbo.Image" };
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
        public (string, string, string, string, string, string, string, string, string, string) fillPdfFields()
        {
            SqlExecuter(defaultEmptyValue);
            DataSet dataSet = GetPersonalTables();
            name = dataSet.Tables[0].Rows[0].Field<string>("Name").ToString().Trim();
            personDetails = dataSet.Tables[0].Rows[0].Field<string>("Address").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("PhoneNumber").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("Email").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("Website").ToString().Trim() + "\n" + dataSet.Tables[0].Rows[0].Field<string>("SocialMedia").ToString().Trim();
            summary = dataSet.Tables[0].Rows[0].Field<string>("Summary").ToString().Trim();
            jobs = "";
            int i = 0;
            while (i < dataSet.Tables[1].Rows.Count)
            {
                jobs = jobs + dataSet.Tables[1].Rows[i].Field<string>("JobTitle").ToString().Trim();
                jobs = jobs + " (" + dataSet.Tables[1].Rows[i].Field<string>("JobStart").ToString().Trim() + "-" + dataSet.Tables[1].Rows[i].Field<string>("JobEnd").ToString().Trim() + ")";
                jobs = jobs + "\n" + dataSet.Tables[1].Rows[i].Field<string>("JobDetail").ToString().Trim() + "\n";
                i++;
            }
            educations = "";
            i = 0;
            while (i < dataSet.Tables[2].Rows.Count)
            {
                educations = educations + dataSet.Tables[2].Rows[i].Field<string>("EducationTitle").ToString().Trim();
                educations = educations + " (" + dataSet.Tables[2].Rows[i].Field<string>("EducationStart").ToString().Trim() + "-" + dataSet.Tables[2].Rows[i].Field<string>("EducationEnd").ToString().Trim() + ")";
                educations = educations + "\n" + dataSet.Tables[2].Rows[i].Field<string>("EducationDetail").ToString().Trim() + "\n";
                i++;
            }
            i = 0;
            certifications = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Certifications").ToString().Trim()) == false)
                {
                    certifications = certifications + dataSet.Tables[3].Rows[i].Field<string>("Certifications").ToString().Trim() + " ";
                }
                i++;
            }
            i = 0;
            personalProjects = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("PersonalProjects").ToString().Trim()) == false)
                {
                    personalProjects = personalProjects + dataSet.Tables[3].Rows[i].Field<string>("PersonalProjects").ToString().Trim() + " ";
                }
                i++;
            }
            i = 0;
            languages = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Languages").ToString().Trim()) == false)
                {
                    languages = languages + dataSet.Tables[3].Rows[i].Field<string>("Languages").ToString().Trim() + " ";
                }
                i++;
            }
            i = 0;
            interests = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Interests").ToString().Trim()) == false)
                {
                    interests = interests + dataSet.Tables[3].Rows[i].Field<string>("Interests").ToString().Trim() + " ";
                }
                i++;
            }
            i = 0;
            skills = "";
            while (i < dataSet.Tables[3].Rows.Count)
            {
                if (string.IsNullOrEmpty(dataSet.Tables[3].Rows[i].Field<string>("Skill").ToString().Trim()) == false)
                {
                    skills = skills + dataSet.Tables[3].Rows[i].Field<string>("Skill").ToString().Trim() + " ";
                }
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