namespace ResumeBuilder
{
    public partial class PersonalDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers SqlControllers = new SqlControllers();
        public static int id = 0;

        public PersonalDetailsForm()
        {
            InitializeComponent();
            FormLogin formLogin = new FormLogin();
            if (formLogin.getDescription() != "")
            {
                nameTextbox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["Name"].ToString();
                AddressTextbox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["Address"].ToString();
                phoneNumberTextbox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["PhoneNumber"].ToString();
                emailTextbox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["Email"].ToString();
                websiteTextbox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["Website"].ToString();
                socialMediaLinksTextBox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["SocialMedia"].ToString();
                summaryTextbox.Text = SqlControllers.getPersonDetails().Tables[0].Rows[0]["Summary"].ToString();
            }
        }

        public int getID() { return id; }

        //*****EVENT HANDLERS*****
        private void summaryTextbox_TextChanged(object sender, EventArgs e)
        {
            summaryTextCounterLabel.Text = $"{summaryTextbox.Text.Length}/500";
        }
        private void phoneNumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void savePersonDataButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            id = rnd.Next(100000, 999999);
            FormLogin formLogin = new FormLogin();
            SqlControllers.AddNewDataOrEdit($"insert into Person (id, description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('{id}', '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', '{nameTextbox.Text}', '{AddressTextbox.Text}', '{phoneNumberTextbox.Text}', '{emailTextbox.Text}', '{summaryTextbox.Text}', '{websiteTextbox.Text}', '{socialMediaLinksTextBox.Text}')", $"update Person set description = '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', Name = '{nameTextbox.Text}', Address = '{AddressTextbox.Text}', PhoneNumber = '{phoneNumberTextbox.Text}', Email = '{emailTextbox.Text}', Summary = '{summaryTextbox.Text}', Website = '{websiteTextbox.Text}', SocialMedia = '{socialMediaLinksTextBox.Text}' where description = '{formLogin.getDescription().ToString().Trim()}'");
        }
    }
}
