using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Capstone_Project
{
    public partial class ReportsScreen : Form
    {                                 
        List<Artwork> list = new List<Artwork>(); 
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

        private void lastYearButton_Click(object sender, EventArgs e)
        {            
            var temp = DataSetClass.ConnectToData(DateTime.Today.AddMonths(-12));
            list = temp.Cast<Artwork>().ToList();
            lastYearView.DataSource = list;
            lastYearView.Columns["artworkID"].Visible = false;
            if (list.Count > 0)
            {
                artButton.Visible = true;
                downloadButton.Visible = true;
                Program.rowID = 0;
            }
            else
            {
                artButton.Visible = false;
                downloadButton.Visible = false;
                errorText.Text = "There were no records found.";
            }
        }

        private void artButton_Click(object sender, EventArgs e)
        {
            Program.fromCollection = true;
            var f = new SinglePieceScreen(list[Program.rowID]);
            this.Hide();
            f.Show();
        }

        private void allArtButton_Click(object sender, EventArgs e)
        {
            var temp = DataSetClass.ConnectToData(Program.allArt);
            list = temp.Cast<Artwork>().ToList();
            lastYearView.DataSource = list;
            lastYearView.Columns["artworkID"].Visible = false;
            if (list.Count > 0)
            {
                artButton.Visible = true;
                downloadButton.Visible = true;
                Program.rowID = 0;
            }
            else
            {
                artButton.Visible = false;
                downloadButton.Visible = false;
                errorText.Text = "There were no records found.";
            }
        }

        private  void downloadButton_Click(object sender, EventArgs e)//async
        {//to-do:: implement this report, need full info about a piece dumped to text file
         //    Artwork art = list[Program.rowID];
         //    var temp = DataSetClass.ConnectToData(Program.simpleExhib, art.artworkID);
         //    var exhibs = temp.Cast<Exhibition>().ToList();
         //    temp = DataSetClass.ConnectToData(Program.photos, art.artworkID);
         //    var photos = temp.Cast<Photos>().ToList();
         //    StreamWriter writer = new StreamWriter("Reports\\" + art.title + "Report\\" + art.title + ".txt");
        }

        private void lastYearView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowID = e.RowIndex;
        }

        private void lastYearView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            artButton_Click(this, new EventArgs());
        }

        private void ReportsScreen_Load(object sender, EventArgs e)
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
                Font = new System.Drawing.Font("Segoe UI", 9);
            }
            else if (Program.fontSize == 1)
            {
                Font = new System.Drawing.Font("Segoe UI", 12);
            }
            else
            {
                Font = new System.Drawing.Font("Segoe UI", 14);
            }
        }
    }
}
