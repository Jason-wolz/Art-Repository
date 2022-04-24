using System;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class ReportsScreen : Form//report ideas:pieces done latest year-possibly summary description
    {//                                                     full info about a piece dumped to text file
        public ReportsScreen()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            var f = new SettingsScreen();
            this.Hide();
            f.Show();
        }
    }
}
