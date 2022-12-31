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
    public partial class FormHome : Form
    {
        private Button currentButton;
        private Form activeForm;

        public FormHome()
        {
            InitializeComponent();
        }

        private void closeAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
