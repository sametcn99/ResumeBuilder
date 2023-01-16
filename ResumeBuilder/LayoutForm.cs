using ResumeBuilder.Properties;

namespace ResumeBuilder
{
    public partial class LayoutForm : Form
    {
        public static string selectedLayout = "0";
        public string getSelectedLayout() { return selectedLayout; }
        public LayoutForm()
        {
            InitializeComponent();
            titleFontSizeTextBox.Text = Settings.Default.titleFontSize.ToString();
            detailFontSizeTextBox.Text = Settings.Default.detailFontSize.ToString();
            pictureSizeTextBox.Text = Settings.Default.pictureSize.ToString();
        }

        private void layoutStylesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLayout = layoutStylesCombobox.SelectedIndex.ToString();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            Settings.Default.titleFontSize = 13;
            Settings.Default.detailFontSize = 11;
            Settings.Default.pictureSize = 150;
            titleFontSizeTextBox.Text = Settings.Default.titleFontSize.ToString();
            detailFontSizeTextBox.Text = Settings.Default.detailFontSize.ToString();
            pictureSizeTextBox.Text = Settings.Default.pictureSize.ToString();
        }

        private void titleFontSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.titleFontSize = (int)Settings.Default.titleFontSize;
        }

        private void detailFontSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.detailFontSize = (int)Settings.Default.detailFontSize;

        }

        private void pictureSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.pictureSize = (int)Settings.Default.pictureSize;
        }
    }
}
