using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIMS_dan
{
    public partial class WelcomePage : Form
    {
        // Timer declaration
        private Timer timer = new Timer();

        public WelcomePage()
        {
            InitializeComponent();
            // Timer setup
            timer.Interval = 3000; // Set timer for 3 seconds
            timer.Tick += Timer_Tick; // Event handler for Timer Tick
        }

        private void WelcomePage_Load(object sender, EventArgs e)
        {
            timer.Start(); // Start the timer when the form loads
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); // Stop the timer to prevent it from ticking again

            // Close the current WelcomePage form
            this.Close();

            // Open the SignInPage form
            SignInPage signInPage = new SignInPage();
            signInPage.Show();
        }
    }
}