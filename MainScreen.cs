using System;
using System.Drawing;
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
            BackColor = Program.nightMode ? Program.nightColor : Program.dayColor;
            Font = Program.fontSize switch
            {
                0 => new Font("Segoe UI", 9),
                1 => new Font("Segoe UI", 12),
                _ => new Font("Segoe UI", 14)
            };
        }
    }
}
