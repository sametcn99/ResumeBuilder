using System.Windows.Forms;

namespace ResumeBuilder
{
    public partial class PhotoUploadForm : Form
    {
        PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
        SqlControllers sqlControllers = new SqlControllers();
        public PhotoUploadForm()
        {
            InitializeComponent();
        }

        private void selectPhotoButton_Click(object sender, EventArgs e)
        {
            PersonalDetailsForm personalDetailsForm = new PersonalDetailsForm();
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(opnfd.FileName);
                selectedPictureBox.Image = new Bitmap(opnfd.FileName);
            }
            var image = new ImageConverter().ConvertTo(selectedPictureBox.Image, typeof(Byte[]));
            sqlControllers.AddNewDataOrEdit($"insert into Image (id, image) values('{personalDetailsForm.getID().ToString().Trim()}', '{opnfd.FileName}')", $"insert into Image (id, image) values('{sqlControllers.GetIdFromDescription().ToString().Trim()}', '{opnfd.FileName}')");
        }

        private void getPhotoButton_Click(object sender, EventArgs e)
        {
            selectedPictureBox.Image = new Bitmap(sqlControllers.getPicture());

        }
    }
}
