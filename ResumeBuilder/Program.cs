namespace ResumeBuilder
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        /*This code is the entry point for a Windows Forms application that builds resumes. 
        It initializes the application configuration and runs the login form. The ApplicationConfiguration.Initialize() 
        method is used to customize the application configuration, such as setting high DPI settings or default font. 
        The FormLogin is the first form that the user sees when they launch the application, and it prompts the user to 
        log in before they can access the resume builder.*/
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin());
        }
    }
}
