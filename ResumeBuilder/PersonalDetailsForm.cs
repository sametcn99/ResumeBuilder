using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class PersonalDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();


        public PersonalDetailsForm()
        {
            InitializeComponent();
        }

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
            //string cmdstring =
            appControllers.insertDataSql($"insert into Person (id, Name, Surname, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('1', '{nameTextbox.Text}', '{SurnameTextbox.Text}', '{AddressTextbox.Text}', '{phoneNumberTextbox.Text}', '{emailTextbox.Text}', '{summaryTextbox.Text}', '{websiteTextbox.Text}', '{socialMediaLinksTextBox.Text}')");
        }
    }
}
