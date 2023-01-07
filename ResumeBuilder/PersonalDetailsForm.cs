namespace ResumeBuilder
{
    public partial class PersonalDetailsForm : Form
    {
        SqlControllers SqlControllers = new SqlControllers();
        public static int id = 0;
        public PersonalDetailsForm()
        {
            InitializeComponent();
            FormLogin formLogin = new FormLogin();
            if (formLogin.getDescription() != "")
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                nameTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Name"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                AddressTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Address"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                phoneNumberTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["PhoneNumber"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                emailTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Email"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                websiteTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Website"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                socialMediaLinksTextBox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["SocialMedia"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                summaryTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Summary"].ToString().Trim();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
            FormLogin formLogin = new FormLogin();
            Random random = new Random();
            if (formLogin.getDescription().ToString().Trim() == "")
            {
                id = random.Next(100000, 999999);
                SqlControllers.AddNewDataOrEdit($"insert into Person (id, description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('{id}', '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', '{nameTextbox.Text.Trim()}', '{AddressTextbox.Text.Trim()}', '{phoneNumberTextbox.Text.Trim()}', '{emailTextbox.Text}', '{summaryTextbox.Text.Trim()}', '{websiteTextbox.Text.Trim()}', '{socialMediaLinksTextBox.Text.Trim()}')", $"update Person set description = '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', Name = '{nameTextbox.Text.Trim()}', Address = '{AddressTextbox.Text.Trim()}', PhoneNumber = '{phoneNumberTextbox.Text.Trim()}', Email = '{emailTextbox.Text.Trim()}', Summary = '{summaryTextbox.Text.Trim()}', Website = '{websiteTextbox.Text.Trim()}', SocialMedia = '{socialMediaLinksTextBox.Text.Trim()}' where description = '{formLogin.getDescription().ToString().Trim()}'");
            }
            SqlControllers.AddNewDataOrEdit($"insert into Person (id, description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('{id}', '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', '{nameTextbox.Text.Trim()}', '{AddressTextbox.Text.Trim()}', '{phoneNumberTextbox.Text.Trim()}', '{emailTextbox.Text}', '{summaryTextbox.Text.Trim()}', '{websiteTextbox.Text.Trim()}', '{socialMediaLinksTextBox.Text.Trim()}')", $"update Person set description = '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', Name = '{nameTextbox.Text.Trim()}', Address = '{AddressTextbox.Text.Trim()}', PhoneNumber = '{phoneNumberTextbox.Text.Trim()}', Email = '{emailTextbox.Text.Trim()}', Summary = '{summaryTextbox.Text.Trim()}', Website = '{websiteTextbox.Text.Trim()}', SocialMedia = '{socialMediaLinksTextBox.Text.Trim()}' where description = '{formLogin.getDescription().ToString().Trim()}'");
        }
    }
}