namespace ResumeBuilder
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DialogResult dialogResult = MessageBox.Show("Open new design?(NOT WORKING CORRECTLY!!!)", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Run(new LoginForm());
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Run(new Form1());
            }

        }
    }
}