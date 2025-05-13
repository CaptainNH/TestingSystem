using TestingSystem.Forms;

namespace TestingSystem
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
            var loginForm = new LoginForm();
            Application.Run(loginForm);
            if (loginForm.IsAuthenticated)
                Application.Run(new MainForm(loginForm.IsAdmin));
        }
    }
}