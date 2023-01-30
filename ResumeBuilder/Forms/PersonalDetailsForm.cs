using ResumeBuilder.Controllers;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Text.RegularExpressions;
using static ResumeBuilder.Controllers.AppControllers;
using static ResumeBuilder.Datasets.PersonalDataset;
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
            if (countriesCombobox.DataSource == null)
            {
                countriesCombobox.DataSource = CountryCodes.countryCodesMapping.ToList();
                countriesCombobox.ValueMember = "Value";
                countriesCombobox.DisplayMember = "Key";
            }
            countriesCombobox.DropDownWidth = AppControllers.DropDownWidth(countriesCombobox);
            if (formLogin.getDescription() != "")
            {
                nameTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Name"].ToString().Trim();
                AddressTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Address"].ToString().Trim();
                maskedTextBox1.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["PhoneNumber"].ToString().Trim();
                countriesCombobox.Text = AppControllers.GetKeyFromValue(AppControllers.regex(SqlControllers.GetPersonTable().Tables[0].Rows[0]["AreaCode"].ToString().Trim()));
                emailTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Email"].ToString().Trim();
                websiteTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Website"].ToString().Trim();
                socialMediaLinksTextBox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["SocialMedia"].ToString().Trim();
                summaryTextbox.Text = SqlControllers.GetPersonTable().Tables[0].Rows[0]["Summary"].ToString().Trim();
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
            if (AppControllers.validatePhoneNumber(countriesCombobox.SelectedValue.ToString().Trim(), maskedTextBox1.Text.ToString().Trim()) == true)
            {
                FormLogin formLogin = new FormLogin();
                Random random = new Random();
                if (formLogin.getDescription().ToString().Trim() == "")
                {
                    id = random.Next(100000, 999999);
                    SqlControllers.AddNewDataOrEdit($"insert into Person (id, description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia, AreaCode) " +
                        $"values('{id}', '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', '{nameTextbox.Text.Trim()}', '{AddressTextbox.Text.Trim()}', '{AppControllers.numberWithNoCountryCode.Trim()}', '{emailTextbox.Text}', '{summaryTextbox.Text.Trim()}', '{websiteTextbox.Text.Trim()}', '{socialMediaLinksTextBox.Text.Trim()}', '+{countriesCombobox.SelectedValue.ToString().Trim()}')",
                        $"update Person set description = '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', Name = '{nameTextbox.Text.Trim()}', Address = '{AddressTextbox.Text.Trim()}', PhoneNumber = '{AppControllers.numberWithNoCountryCode.Trim()}', Email = '{emailTextbox.Text.Trim()}', Summary = '{summaryTextbox.Text.Trim()}', Website = '{websiteTextbox.Text.Trim()}', SocialMedia = '{socialMediaLinksTextBox.Text.Trim()}', AreaCode = '+{countriesCombobox.SelectedValue.ToString().Trim()}' where description = '{formLogin.getDescription().ToString().Trim()}'");
                }
                SqlControllers.AddNewDataOrEdit($"insert into Person (id, description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia, AreaCode) " +
                    $"values('{id}', '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', '{nameTextbox.Text.Trim()}', '{AddressTextbox.Text.Trim()}', '{AppControllers.numberWithNoCountryCode.Trim()}', '{emailTextbox.Text}', '{summaryTextbox.Text.Trim()}', '{websiteTextbox.Text.Trim()}', '{socialMediaLinksTextBox.Text.Trim()}', '{countriesCombobox.SelectedValue.ToString().Trim()}')",
                    $"update Person set description = '{DateTime.Now.ToString("dddd dd MMMM yyyy HH:mm").Trim()}', Name = '{nameTextbox.Text.Trim()}', Address = '{AddressTextbox.Text.Trim()}', PhoneNumber = '{AppControllers.numberWithNoCountryCode.Trim()}', Email = '{emailTextbox.Text.Trim()}', Summary = '{summaryTextbox.Text.Trim()}', Website = '{websiteTextbox.Text.Trim()}', SocialMedia = '{socialMediaLinksTextBox.Text.Trim()}', AreaCode = '+{countriesCombobox.SelectedValue.ToString().Trim()}' where description = '{formLogin.getDescription().ToString().Trim()}'");
            }
        }

        private void countriesCombobox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86 && Regex.Replace(Clipboard.GetText().ToString().Trim(), @"[^0-9]+", "").Length != 10)
            {
                MessageBox.Show("Coppied text is not a phone number!");
            }
        }

        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            if (Regex.Replace(maskedTextBox1.Text.ToString(), @"[^0-9]+", "").Length == 0)
            {
                maskedTextBox1.Select(0, 0);
            }
            else if (Regex.Replace(maskedTextBox1.Text.ToString(), @"[^0-9]+", "").Length != 0)
            {
                maskedTextBox1.SelectAll();
            }
        }
    }
}