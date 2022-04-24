using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var f = new MainScreen();
            this.Hide();
            f.Show();
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            var f = new ReportsScreen();
            this.Hide();
            f.Show();
        }

        private void nightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (nightCheck.Checked == true)
            {
                Program.nightMode = true;
            }
            else
            {
                Program.nightMode = false;
            }
        }

        private void largeCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.fontSize = 2;
        }

        private void mediumCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.fontSize = 1;
        }

        private void smallCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.fontSize = 0;
        }

        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                BackColor = Color.BlueViolet;
            }
        }
    }
}
