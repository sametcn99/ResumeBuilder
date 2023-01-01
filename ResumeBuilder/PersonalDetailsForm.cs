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
            appControllers.insertDataSql($"insert into Person (id,description, Name, Address, PhoneNumber, Email, Summary, Website, SocialMedia) values('1', '{DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt")}', '{nameTextbox.Text}', '{AddressTextbox.Text}', '{phoneNumberTextbox.Text}', '{emailTextbox.Text}', '{summaryTextbox.Text}', '{websiteTextbox.Text}', '{socialMediaLinksTextBox.Text}')");

        }

        private void fillTextboxes()
        {
            //MessageBox.Show(appControllers.ds.Tables[0].Rows[0].Field<string>("Name").Trim().ToLower());
            //nameTextbox.Text = appControllers.personalDataSet.Tables[0].Rows[0].Field<string>("Name").Trim().ToString();


            ////var textboxArray = new[] { "nameTextbox", "AddressTextbox", "phoneNumberTextbox", "emailTextbox", "websiteTextbox", "socialMediaLinksTextBox", "summaryTextbox" };
            //foreach (Control control in this.Controls)
            //{
            //    //MessageBox.Show("foreach");
            //    if (control is System.Windows.Forms.TextBox)
            //    {
            //        MessageBox.Show(appControllers.personalDataSet.Tables[0].Rows.ToString());
            //        System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)control;
            //        foreach (var item in appControllers.personalDataSet.Tables[0].Rows)
            //        {
            //            textBox.Text = appControllers.personalDataSet.Tables[0].Rows.ToString();
            //        }
            //    }
            //}

        }
    }
}
