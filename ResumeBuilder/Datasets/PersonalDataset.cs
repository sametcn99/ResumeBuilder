using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Datasets
{
    internal class PersonalDataset
    {
        public static DataSet ds()
        {
            DataSet dataSet = new DataSet();
            DataTable personTable = dataSet.Tables.Add("Person");
            personTable.Columns.Add("id", typeof(int));
            personTable.Columns.Add("Name", typeof(string));
            personTable.Columns.Add("Address", typeof(string));
            personTable.Columns.Add("PhoneNumber", typeof(string));
            personTable.Columns.Add("Email", typeof(string));
            personTable.Columns.Add("Website", typeof(string));
            personTable.Columns.Add("SocialMedia", typeof(string));
            personTable.Columns.Add("Summary", typeof(string));
            personTable.Columns.Add("description", typeof(string));
            personTable.Columns.Add("AreaCode", typeof(string));
            DataTable jobTable = dataSet.Tables.Add("Job");
            jobTable.Columns.Add("id", typeof(int));
            jobTable.Columns.Add("JobTitle", typeof(string));
            jobTable.Columns.Add("JobDetail", typeof(string));
            jobTable.Columns.Add("JobStart", typeof(string));
            jobTable.Columns.Add("JobEnd", typeof(string));
            DataTable educationTable = dataSet.Tables.Add("Education");
            educationTable.Columns.Add("id", typeof(int));
            educationTable.Columns.Add("EducationTitle", typeof(string));
            educationTable.Columns.Add("EducationDetail", typeof(string));
            educationTable.Columns.Add("EducationStart", typeof(string));
            educationTable.Columns.Add("EducationEnd", typeof(string));
            DataTable moreDetailsTable = dataSet.Tables.Add("MoreDetails");
            moreDetailsTable.Columns.Add("id", typeof(int));
            moreDetailsTable.Columns.Add("Skill", typeof(string));
            moreDetailsTable.Columns.Add("Languages", typeof(string));
            moreDetailsTable.Columns.Add("Interests", typeof(string));
            moreDetailsTable.Columns.Add("Certifications", typeof(string));
            moreDetailsTable.Columns.Add("PersonalProjects", typeof(string));
            DataTable imageTable = dataSet.Tables.Add("Image");
            imageTable.Columns.Add("id", typeof(int));
            imageTable.Columns.Add("image", typeof(string));
            return dataSet;
        }
    }
}
