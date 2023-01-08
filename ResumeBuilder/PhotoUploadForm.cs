namespace ResumeBuilder
{
    public partial class PhotoUploadForm : Form
    {
        static string filepath = "";
        PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
        SqlControllers sqlControllers = new SqlControllers();
        public PhotoUploadForm()
        {
            InitializeComponent();
        }

        public string getPhotoPath() { return filepath; }

        private void selectPhotoButton_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;)|*.jpg";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                selectedPictureBox.Image = new Bitmap(opnfd.FileName);
                if (formLogin.getDescription() != "")
                {
                    filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + sqlControllers.GetIdFromDescription().ToString().Trim() + ".jpg";
                    File.Copy(opnfd.FileName, filepath, true);
                }
                else
                {
                    filepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\" + personalDetailsForm.getID().ToString().Trim().ToString().Trim() + ".jpg";
                    File.Copy(opnfd.FileName, filepath, true);
                }
                var image = new ImageConverter().ConvertTo(selectedPictureBox.Image, typeof(Byte[]));
                sqlControllers.AddNewDataOrEdit($"insert into Image (id, image) values('{personalDetailsForm.getID().ToString().Trim()}', '{filepath}')", $"insert into Image (id, image) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{filepath}')");
            }
        }

        private void getPhotoButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sqlControllers.getPicture()))
            {
                selectedPictureBox.Image = new Bitmap(sqlControllers.getPicture());
            }
        }
    }
}
