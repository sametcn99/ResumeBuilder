using Microsoft.Win32;
using System.Diagnostics;

namespace ResumeBuilder
{
    internal class AppControllers
    {

        /*public (string, string, string, string, string, string, string, string, string) fillPdfFields()
        {
            getPersonalDataFromDb();
            name = personalDataSet.Tables[0].Rows[0].Field<string>("Name").Trim();
            personDetails = personalDataSet.Tables[0].Rows[0].Field<string>("Address").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("PhoneNumber").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("Email").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("Website").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("SocialMedia").Trim() + "\n" + personalDataSet.Tables[0].Rows[0].Field<string>("Summary").Trim();
            jobs = "";
            int i = 0;
            MessageBox.Show("personalDataSet.Tables[1].Rows[i].Field<string>(\"JobTitle\").Trim(): " + personalDataSet.Tables[1].Rows[0]["JobTitle"].ToString());

            while (i < personalDataSet.Tables[1].Rows.Count)
            {
                getPersonalDataFromDb();
                getDataFromDB();
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

            return (name, personDetails, jobs, educations, certifications, personalProjects, languages, interests, skills);
        }
        */
        //*****SQL CONTROLLERS*****


        /*public void setNullValuestoDefaultEmptyValue()
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
        }*/

        public void OpenURL(string url)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];
            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = url;
            p.Start();
        }
    }
}
