using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ResumeBuilder
{
    public partial class FormLogin : Form
    {
        AppControllers appControllers = new AppControllers();
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        public string cmdstring = "";
        SqlConnection cnn;
        SqlDataReader reader1;
        public static string id = "";
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        FormHome formHome = new FormHome();

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
        public string getId()
        {
            return id;
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (resumeVersionCombobox.Items.Count > 0)
            {
                cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand($"select id from Person where description = '{resumeVersionCombobox.SelectedItem.ToString().Trim()}'", cnn);
                cnn.Open();
                reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1.GetValue("id").ToString();
                }
                formHome.Show();
                formHome.nameLbl.Visible = true;
                formHome.helloLbl.Visible = true;
                formHome.nameLbl.Text = appControllers.ds.Tables[0].Rows[0].Field<string>("Name").Trim();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Select resume to continue!");
            }
        }

        private void navigationPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeAppButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createNewResumeButton_Click(object sender, EventArgs e)
        {
            formHome.Show();
            this.Hide();
        }
    }
}
