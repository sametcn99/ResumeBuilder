using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public partial class LoginForm : Form
    {
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public string cmdstring = "";
        SqlConnection cnn;
        SqlDataReader reader1;
        FormHome formHome = new FormHome();

        AppControllers appControllers = new AppControllers();
        public LoginForm()
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
            //deleting duplicate names from combobox
            HashSet<string> items = new HashSet<string>();
            items.UnionWith(userLoginCombobox.Items.OfType<string>());
            userLoginCombobox.Items.Clear();
            foreach (string item in items)
            {
                userLoginCombobox.Items.Add(item);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand($"select id from Person where description = '{resumeVersionCombobox.SelectedItem.ToString().Trim()}'", cnn);
            cnn.Open();
            reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                appControllers.id = (int)reader1.GetValue("id");
                MessageBox.Show(appControllers.id.ToString().Trim());
            }
        }

        private void userLoginCombobox_SelectedValueChanged(object sender, EventArgs e)
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

        }

        private void createNewResumeButton_Click(object sender, EventArgs e)
        {
            formHome.Show();
            this.Hide();
        }

        private void closeAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
