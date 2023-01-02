using System.Data;

namespace ResumeBuilder
{
    public partial class PersonalDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();

        FormHome formHome = new FormHome();
        public PersonalDetailsForm()
        {
            InitializeComponent();
            appControllers.getPersonalDataFromDb();
            fillTextboxes();

        }

        private void fillTextboxes()
        {
            FormLogin formLogin = new FormLogin();

            if (formLogin.getId().ToString().Trim() != "")
            {
                nameTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("Name").Trim();
                AddressTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("Address").Trim();
                phoneNumberTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("PhoneNumber").Trim();
                emailTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("Email").Trim();
                websiteTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("Website").Trim();
                socialMediaLinksTextBox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("SocialMedia").Trim();
                summaryTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("Summary").Trim();
            }
        }

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
            appControllers.getDataFromDB();
            int idCount = appControllers.ds.Tables[0].Rows.Count;
            idCount++;
            if (formLogin.getId().ToString().Trim() != "")
            {
                appControllers.insertDataSql($"update Person set description = '{DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")}', Name = '{nameTextbox.Text}', Address = '{AddressTextbox.Text}', PhoneNumber = '{phoneNumberTextbox.Text}', Email = '{emailTextbox.Text}', Summary = '{summaryTextbox.Text}', Website = '{websiteTextbox.Text}', SocialMedia = '{socialMediaLinksTextBox.Text}' where id = '{formLogin.getId().ToString().Trim()}'");
            }
            else
            {
                appControllers.insertDataSql($"insert into Person ({idCount},description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('1', '{DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")}', '{nameTextbox.Text}', '{AddressTextbox.Text}', '{phoneNumberTextbox.Text}', '{emailTextbox.Text}', '{summaryTextbox.Text}', '{websiteTextbox.Text}', '{socialMediaLinksTextBox.Text}')");
            }
        }
    }
}
