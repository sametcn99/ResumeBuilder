namespace ResumeBuilder
{
    public partial class LayoutForm : Form
    {
        public static string selectedLayout = "0";
        public string getSelectedLayout() { return selectedLayout; }
        public LayoutForm()
        {
            InitializeComponent();
        }

        private void layoutStylesCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLayout = layoutStylesCombobox.SelectedIndex.ToString();
        }
    }
}
