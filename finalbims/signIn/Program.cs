using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMS_dan
{
internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Start with the WelcomePage
        ShowForm(new WelcomePage());

        // Continue with other forms based on some condition or user action
        // For example, after WelcomePage, you might want to show SignInPage
        // This can be determined by setting and checking some static variables or properties
        // For simplicity, directly showing SignInPage after WelcomePage closes
        ShowForm(new SignInPage());
    }

    static void ShowForm(Form form)
    {
        // This method ensures the application does not exit when a form is closed
        // Instead, control returns to the Main method to decide what to do next
        Application.Run(form);
    }
}
}