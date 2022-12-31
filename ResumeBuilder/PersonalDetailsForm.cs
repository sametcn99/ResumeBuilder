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
    }
}
