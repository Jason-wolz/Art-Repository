using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class SinglePieceScreen : Form//check whether user came from Collection or Exhibition screen
    {
        public SinglePieceScreen()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            titleText.Enabled = false;
            mediumText.Enabled = false;
            dimensionsText.Enabled = false;
            dateText.Enabled = false;
            soldCheckBox.Enabled = false;
            soldText.Enabled = false;
            editionCheckBox.Enabled = false;
            notesText.Enabled = false;
            framedCheckBox.Enabled = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            titleText.Enabled = true;
            mediumText.Enabled = true;
            dimensionsText.Enabled = true;
            dateText.Enabled = true;
            soldCheckBox.Enabled = true;
            editionCheckBox.Enabled = true;
            notesText.Enabled = true;
            framedCheckBox.Enabled = true;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var f = new CollectionScreen();
            this.Hide();
            f.Show();
        }

        private void SoldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (soldCheckBox.Checked)
            {
                soldText.Enabled = true;
            }
            else
            {
                soldText.Enabled = false;
            }
        }

        private void EditionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (editionCheckBox.Checked)
            {
                editionText.Enabled = true;
            }
            else
            {
                editionText.Enabled = false;
            }
        }
    }
}
