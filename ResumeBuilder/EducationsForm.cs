namespace ResumeBuilder
{
    public partial class EducationsForm : Form
    {
        AppControllers appControllers = new AppControllers();

        public EducationsForm()
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

        private void addEduBtn_Click(object sender, EventArgs e)
        {
        }
    }
}
