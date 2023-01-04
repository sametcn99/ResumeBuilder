namespace ResumeBuilder
{
    public partial class MoreDetailsForm : Form
    {
        AppControllers appControllers = new AppControllers();

        public MoreDetailsForm()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void addSkillButton_Click(object sender, EventArgs e)
        {

            ClearTextBoxes();
        }
        private void addCertificationButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private void addLanguageButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private void addPersonalProjectButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
        private void addInterestButton_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
