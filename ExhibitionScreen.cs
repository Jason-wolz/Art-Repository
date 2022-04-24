using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class ExhibitionScreen : Form
    {
        public ExhibitionScreen()//move screen to connect to calendar page or make new page to display all exhibitions
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var f = new MainScreen();
            this.Hide();
            f.Show();
        }

        private void SinglePieceButton_Click(object sender, EventArgs e)
        {
            Program.fromCollection = false;
            var f = new SinglePieceScreen(new Artwork());
            this.Hide();
            f.Show();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            nameText.Enabled = false;
            locationText.Enabled = false;
            feeCheckBox.Enabled = false;
            startTime.Enabled = false;
            endTime.Enabled = false;
            juriedCheckBox.Enabled = false;
            notesText.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            nameText.Enabled = true;
            locationText.Enabled = true;
            feeCheckBox.Enabled = true;
            startTime.Enabled = true;
            endTime.Enabled = true;
            juriedCheckBox.Enabled = true;
            notesText.Enabled = true;
        }

        private void FeeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (feeCheckBox.Checked)
            {
                feeText.Enabled = true;
            }
            else
            {
                feeText.Enabled = false;
            }
        }

        private void JuriedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (juriedCheckBox.Checked)
            {
                juriedText.Enabled = true;
            }
            else 
            { 
                juriedText.Enabled = false; 
            }
        }
    }
}
