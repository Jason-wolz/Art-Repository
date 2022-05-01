using System;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            BackColor = Program.dayColor;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            var f = new MainScreen();
            this.Hide();
            f.Show();
        }
    }
}
