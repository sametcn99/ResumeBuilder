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
