using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class MainScreen : Form//for calendar use selection range to highlight exhibition dates, also set calendar to disabled
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void piecesButton_Click(object sender, EventArgs e)
        {
            var f = new CollectionScreen();
            this.Hide();
            f.Show();
        }

        private void calendarButton_Click(object sender, EventArgs e)
        {
            var f = new CalendarScreen();
            this.Hide();
            f.Show();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            var f = new SettingsScreen();
            this.Hide();
            f.Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            if (Program.nightMode)
            {
                BackColor = Program.nightColor;
            }
            else
            {
                BackColor = Program.dayColor;
            }
            if (Program.fontSize == 0)
            {
                Font = new Font("Segoe UI", 9);
            }
            else if (Program.fontSize == 1)
            {
                Font = new Font("Segoe UI", 12);
            }
            else
            {
                Font = new Font("Segoe UI", 14);
            }
        }
    }
}
