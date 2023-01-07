

using Microsoft.VisualBasic.FileIO;
using ResumeBuilder.Properties;

namespace ResumeBuilder
{
    public partial class FormLogin : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();

        public static string description = "";
        public static int id = 0;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public FormLogin()
        {
            MessageBox.Show(Settings.Default.Language);
            switch (Settings.Default.Language)
            {
                case "en":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
                case "tr":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr");
                    break;
            }
            InitializeComponent();
            foreach (var item in sqlControllers.GetNames())
            {
                namesCombobox.Items.Add(item.Trim());
            }
        }

        public string getDescription() { return description; }
        public string setDescription(string value)
        {
            description = value;
            return description;
        }
        public int getID() { return id; }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (resumeVersionCombobox.SelectedItem is not null)
            {
                description = resumeVersionCombobox.SelectedItem.ToString().Trim();
                FormHome formHome = new FormHome();
                formHome.Show();
                formHome.helloLbl.Visible = true;
                formHome.nameLbl.Visible = true;
                formHome.nameLbl.Text = namesCombobox.SelectedItem.ToString().Trim();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Select Resume to Continue!");
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
            FormHome formHome = new FormHome();
            formHome.Show();
            this.Hide();
        }
        private void namesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in sqlControllers.GetDescriptions(namesCombobox.SelectedItem.ToString().Trim()))
            {
                resumeVersionCombobox.Items.Add(item.Trim());
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
