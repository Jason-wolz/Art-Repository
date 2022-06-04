using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class SettingsScreen : Form
    {
        readonly Font smallFont = new Font("Segoe UI", 9);
        readonly Font mediumFont = new Font("Segoe UI", 12);
        readonly Font largeFont = new Font("Segoe UI", 14);
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
            if (nightCheck.Checked)
            {
                Program.nightMode = true;
                BackColor = Program.nightColor;
                nightCheck.ForeColor = Color.White;
                groupBox1.ForeColor = Color.White;
                smallCheck.ForeColor = Color.White;
                mediumCheck.ForeColor = Color.White;
                largeCheck.ForeColor = Color.White;
            }
            else
            {
                Program.nightMode = false;
                BackColor = Program.dayColor;
                nightCheck.ForeColor = Color.Black;
                groupBox1.ForeColor = Color.Black;
                smallCheck.ForeColor = Color.Black;
                mediumCheck.ForeColor = Color.Black;
                largeCheck.ForeColor = Color.Black;
            }
        }

        private void largeCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.fontSize = 2;
            nightCheck.Font = largeFont;
            reportsButton.Font = largeFont;
            backButton.Font = largeFont;
        }

        private void mediumCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.fontSize = 1;
            nightCheck.Font = mediumFont;
            reportsButton.Font = mediumFont;
            backButton.Font = mediumFont;
        }

        private void smallCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.fontSize = 0;
            nightCheck.Font = smallFont;
            reportsButton.Font = smallFont;
            backButton.Font = smallFont;
        }

        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                nightCheck.Checked = true;
            }
            else
            {
                BackColor = Program.dayColor;
            }

            switch (Program.fontSize)
            {
                case 0:
                    smallCheck.Checked = true;
                    nightCheck.Font = smallFont;
                    reportsButton.Font = smallFont;
                    backButton.Font = smallFont;
                    break;
                case 1:
                    mediumCheck.Checked = true;
                    nightCheck.Font = mediumFont;
                    reportsButton.Font = mediumFont;
                    backButton.Font = mediumFont;
                    break;
                default:
                    largeCheck.Checked = true;
                    nightCheck.Font = largeFont;
                    reportsButton.Font = largeFont;
                    backButton.Font = largeFont;
                    break;
            }
        }
    }
}
