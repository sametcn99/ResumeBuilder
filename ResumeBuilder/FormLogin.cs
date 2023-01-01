using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ResumeBuilder
{
    public partial class FormLogin : Form
    {
        AppControllers appControllers = new AppControllers();
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public string cmdstring = "";
        SqlConnection cnn;
        SqlDataReader reader1;
        public FormLogin()
        {
            InitializeComponent();
            appControllers.getDataFromDB();
            resumeVersionCombobox.Items.Clear();
            var i = 0;
            while (i < appControllers.ds.Tables[0].Rows.Count)
            {
                userLoginCombobox.Items.Add(appControllers.ds.Tables[0].Rows[i].Field<string>("Name").Trim().ToLower());
                i++;
            }
            HashSet<string> items = new HashSet<string>();
            items.UnionWith(userLoginCombobox.Items.OfType<string>());
            userLoginCombobox.Items.Clear();
            foreach (string item in items)
            {
                userLoginCombobox.Items.Add(item);
            }
        }

        private void userLoginCombobox_SelectedValueChanged_1(object sender, EventArgs e)
        {
            resumeVersionCombobox.Items.Clear();
            cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand($"select description from Person where Name = '{userLoginCombobox.SelectedItem.ToString().Trim()}'", cnn);
            cnn.Open();
            reader1 = cmd.ExecuteReader();
            int i = 0;
            while (reader1.Read())
            {
                resumeVersionCombobox.Items.Add(reader1.GetString("description"));
            }
            cnn.Close();
        }
    }
}
