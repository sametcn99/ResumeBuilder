using ResumeBuilder.Controllers;
using ResumeBuilder.Properties;

namespace ResumeBuilder
{
    /*This code defines the behavior of the login form in the ResumeBuilder application. 
    It initializes the necessary controllers, sets the language based on user preferences, 
    populates the names and resume versions in the respective combo boxes, and handles user 
    interactions such as clicking the login button, creating a new resume, selecting a name 
    or resume version, and closing the application. It also includes a method to get and set 
    the description and ID of the selected resume version.
*/
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
            sqlControllers.CheckDatabaseExists();

            /**
            * Sets the current UI culture based on the language setting in the application settings.
            */
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


            /**
            * Adds the names from the sqlControllers to the namesCombobox.
            */
            foreach (var item in sqlControllers.GetNames())
            {
                namesCombobox.Items.Add(item.Trim());
            }
        }

        public string getDescription() { return description; }


        /**
        * Sets the description of an object.
        */
        public string setDescription(string value)
        {
            description = value;
            return description;
        }
        public int getID() { return id; }



/**
 * Handles the click event of the login button. 
 If the resume version combobox is not null, it sets the description to the selected item of the combobox, 
 creates a new FormHome object, shows it, sets the helloLbl and nameLbl to visible, and sets the text of 
 the nameLbl to the selected item of the namesCombobox. If the resume version combobox is null, it displays a message box.
 * @param sender The object that raised the event.
 * @param e The event arguments.
 */
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



        /**
        * Handles the MouseDown event of the navigationPanel control.
        */
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

        /**
        * @description Handles the SelectedIndexChanged event of the namesCombobox control.
        *              Populates the resumeVersionCombobox with the descriptions of the selected item from the namesCombobox.
        */
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
