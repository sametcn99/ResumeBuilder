namespace ResumeBuilder
{
    public partial class SettingsForm : Form
    {
        AppControllers appControllers = new AppControllers();
        SqlControllers sqlControllers = new SqlControllers();
        public string connetionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=ResumeBuilderDb;Integrated Security=True";
        string json;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void exportJsonDataButton_Click(object sender, EventArgs e)
        {
            sqlControllers.ExportDatabase();
        }

        private void importJsonDataButton_Click(object sender, EventArgs e)
        {
            sqlControllers.ImportDatabase();
        }

        private void showJsonDataButton_Click(object sender, EventArgs e)
        {
            FlexibleMessageBox.Show(sqlControllers.GetDatabaseAsJsonText());
        }

        private void clearJsonDataButton_Click(object sender, EventArgs e)
        {
            sqlControllers.ClearDatabase();
        }
    }
}
