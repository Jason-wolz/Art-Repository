﻿using System;
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
                Program.rowId = 0;
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
            var f = new SinglePieceScreen(list[Program.rowId]);
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
                Program.rowId = 0;
            }
            else
            {
                artButton.Visible = false;
                downloadButton.Visible = false;
                errorText.Text = "There were no records found.";
            }
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            Artwork art = list[Program.rowId];
            var temp = DataSetClass.ConnectToData(Program.simpleExhib, art.artworkID);
            var exhibs = temp.Cast<Exhibition>().ToList();
            temp = DataSetClass.ConnectToData(Program.photos, art.artworkID);
            var photos = temp.Cast<Photos>().ToList();
            string fileText = art.ToString();
            fileText += "\n\nExhibitions this art has been to:\n";
            foreach (Exhibition ex in exhibs)
            {
                fileText += ex + "\n\n";
            }
            try
            {
                string path = @"C:\Users\jason\source\repos\Jason-wolz\Capstone-Project\Reports\" + art.title + " Report\\";
                Directory.CreateDirectory(path);
                await File.WriteAllTextAsync(path + art.title + ".txt", fileText);
                for (int i = 0; i < photos.Count; i++)
                {
                    string newPath = path + art.title + " " + i + photos[i].url.Substring(photos[i].url.Length - 4);
                    if (File.Exists(newPath))
                    {
                        File.Delete(newPath);
                    }
                    File.Copy(photos[i].url, newPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lastYearView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Program.rowId = e.RowIndex;
        }

        private void lastYearView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            artButton_Click(this, EventArgs.Empty);
        }

        private void ReportsScreen_Load(object sender, EventArgs e)
        {
            BackColor = Program.nightMode ? Program.nightColor : Program.dayColor;
            Font = Program.fontSize switch
            {
                0 => new System.Drawing.Font("Segoe UI", 9),
                1 => new System.Drawing.Font("Segoe UI", 12),
                _ => new System.Drawing.Font("Segoe UI", 14),
            };
        }
    }
}
