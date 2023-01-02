using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ResumeBuilder
{
    public partial class PersonalDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();

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
            appControllers.insertDataSql($"insert into Person (id,description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('1', '{DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")}', '{nameTextbox.Text}', '{AddressTextbox.Text}', '{phoneNumberTextbox.Text}', '{emailTextbox.Text}', '{summaryTextbox.Text}', '{websiteTextbox.Text}', '{socialMediaLinksTextBox.Text}')");
        }
    }
}
