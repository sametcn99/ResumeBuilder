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
    public partial class AboutForm : Form
    {
        AppControllers appControllers = new AppControllers();
        public AboutForm()
        {
            InitializeComponent();
        }

        private void aboutPictureBox_Click(object sender, EventArgs e)
        {
            appControllers.OpenURL("https://github.com/sametcn99");
        }
    }
}
